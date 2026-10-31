package com.hkm.studentmanagement.controller;



import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.data.domain.Page;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import com.hkm.studentmanagement.dto.StudentDTO;
import com.hkm.studentmanagement.service.StudentService;

import jakarta.validation.Valid;

@Controller
@RequestMapping("/student")
public class StudentController {
	
	private final StudentService studentService;
	private static final Logger log = LoggerFactory.getLogger(CourseController.class);
	
	public StudentController(StudentService studentService) {
		this.studentService = studentService;
	}
	
	@GetMapping("/new")
	public String showCreateStudent(Model model) {
		log.info("GET /student - Öğrenci ekleme sayfası açıldı.");
		model.addAttribute("studentDTO", new StudentDTO());
		return "add-student";
	}
	
	@GetMapping("/list")
	public String listStudent(@RequestParam(defaultValue = "0") int page, @RequestParam(defaultValue = "5") int size, 
			Model model, @RequestParam(value = "message", required = false) String message) {
		log.info("GET /student - Öğrenci listeleme sayfası açıldı.");
		Page<StudentDTO> students =  studentService.getStudents(page, size);
		model.addAttribute("students", students);
		model.addAttribute("message", message);
		return "students";
	}
	
	@PostMapping()
	public String createStudent(@Valid @ModelAttribute("studentDTO") StudentDTO studentDTO, BindingResult bindingResult,
			Model model, RedirectAttributes redirectAttributes) {
		log.info("POST /student - Yeni öğrenci ekleme isteği alındı.");
		if (bindingResult.hasErrors()) {
			log.error("POST /student - Doğrulama hatalarından dolayı kayıt eklenmedi.");
			return "add-student";
		}
		
		if (studentService.existsByEmailIgnoreCase(studentDTO.getEmail())) {
			log.error("POST /student - E-Posta adresi benzersizliği hatasından dolayı kayıt eklenmedi.");
			bindingResult.rejectValue("email", null, "E-Posta Adresi Benzersiz Olmalıdır!");
			return "add-student";
		}
		
		if (studentService.existsByPhoneNumber(studentDTO.getPhoneNumber())) {
			log.error("POST /student - Telefon numarası benzersizliği hatasından dolayı kayıt eklenmedi.");
			bindingResult.rejectValue("phoneNumber", null, "Telefon Numarası Benzersiz Olmalıdır!");
			return "add-student";
		}
		
		studentService.createStudent(studentDTO);
		redirectAttributes.addAttribute("message", "Öğrenci Başarıyla Eklendi!");
		log.info("POST /course - Öğrenci başarıyla eklendi.");
		
		return "redirect:/student/list";
	}
	
	@GetMapping("{id}")
	public String getStudentById(@PathVariable long id, Model model) {
		StudentDTO student = studentService.getStudentById(id);
		model.addAttribute("student", student);
		return "view-student";
	}
	
	@GetMapping("{id}/edit")
	public String editCourse(@PathVariable long id, Model model) {
		StudentDTO student = studentService.getStudentById(id);
		model.addAttribute("student", student);
		return "edit-student";
	}
	
	@PostMapping("{id}/update")
	public String updateStudent(@Valid @ModelAttribute("studentDTO") StudentDTO studentDTO, BindingResult bindingResult,
			Model model, RedirectAttributes redirectAttributes) {
		log.info("POST id/student - Yeni öğrenci ekleme isteği alındı.");
		if (bindingResult.hasErrors()) {
			log.error("POST /student - Doğrulama hatalarından dolayı kayıt eklenmedi.");
			return "edit-student";
		}
		
		if (studentService.existsByEmailIgnoreCaseAndIdNot(studentDTO.getEmail(), studentDTO.getId())) {
			log.error("POST /student - E-Posta adresi benzersizliği hatasından dolayı kayıt eklenmedi.");
			bindingResult.rejectValue("email", null, "E-Posta Adresi Benzersiz Olmalıdır!");
			return "edit-student";
		}
		
		if (studentService.existsByPhoneNumberAndIdNot(studentDTO.getPhoneNumber(), studentDTO.getId())) {
			log.error("POST /student - Telefon numarası benzersizliği hatasından dolayı kayıt eklenmedi.");
			bindingResult.rejectValue("phoneNumber", null, "Telefon Numarası Benzersiz Olmalıdır!");
			return "add-student";
		}
		
		studentService.createStudent(studentDTO);
		redirectAttributes.addAttribute("message", "Öğrenci Başarıyla Güncellendi!");
		log.info("POST /student - Öğrenci başarıyla güncellendi.");
		
		return "redirect:/student/list";
	}
}
