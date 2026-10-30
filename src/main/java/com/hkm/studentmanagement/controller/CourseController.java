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

import com.hkm.studentmanagement.dto.CourseDTO;
import com.hkm.studentmanagement.service.CourseService;

import jakarta.validation.Valid;

@Controller
@RequestMapping("/course")
public class CourseController {

	private final CourseService courseService;
	private static final Logger log = LoggerFactory.getLogger(CourseController.class);

	public CourseController(CourseService courseService) {
		this.courseService = courseService;
	}

	@GetMapping("/new")
	public String showCreateCourse(Model model) {
		log.info("GET /course/new - Yeni ders ekleme sayfası.");
		model.addAttribute("courseDTO", new CourseDTO());
		return "add-course";
	}

	@GetMapping("/list")
	public String listCourses(@RequestParam(defaultValue = "0") int page, @RequestParam(defaultValue = "5") int size,
			Model model, @RequestParam(value = "message", required = false) String message) {
		log.info("GET /course/list - Ders listeleme sayfası.");
		Page<CourseDTO> courses = courseService.getCourses(page, size);
		model.addAttribute("courses", courses);
		model.addAttribute("message", message);
		return "courses";
	}

	@PostMapping
	public String createCourse(@Valid @ModelAttribute("courseDTO") CourseDTO courseDTO, BindingResult bindingResult,
			Model model, RedirectAttributes redirectAttributes) {
		log.info("POST /course - Yeni ders ekleme isteği alındı.");
		if (bindingResult.hasErrors()) {
			log.error("POST /course - Doğrulama hatalarından dolayı kayıt eklenmedi.");
			return "add-course";
		}

		if (courseService.existsByCourseCodeIgnoreCase(courseDTO.getCourseCode())) {
			log.error("POST /course - Ders kodu benzersizliği hatasından dolayı kayıt eklenmedi.");
			bindingResult.rejectValue("courseCode", null, "Ders Kodu Benzersiz Olmalıdır!");
			return "add-course";
		}

		courseService.createCourse(courseDTO);

		redirectAttributes.addAttribute("message", "Ders Başarıyla Eklendi!");
		log.info("POST /course - Ders başarıyla eklendi.");
		return "redirect:/course/list";
	}

	@GetMapping("{id}")
	public String getCourseById(@PathVariable long id, Model model) {
		CourseDTO course = courseService.getCourseById(id);
		model.addAttribute("course", course);
		return "view-course";
	}

	@GetMapping("{id}/edit")
	public String editCourse(@PathVariable long id, Model model) {
		CourseDTO course = courseService.getCourseById(id);
		model.addAttribute("course", course);
		return "edit-course";
	}

	@PostMapping("{id}/update")
	public String updateCourse(@PathVariable long id, @Valid @ModelAttribute("courseDTO") CourseDTO courseDTO,
			BindingResult bindingResult, Model model, RedirectAttributes redirectAttributes) {
		log.info("POST id/course - Ders güncelleme isteği ilgili ders için alındı: {}", id);
		if (bindingResult.hasErrors()) {
			log.error("POST id/course - Doğrulama hatalarından dolayı kayıt eklenmedi.");
			return "edit-course";
		}

		if (courseService.existsByCourseCodeIgnoreCaseAndIdNot(courseDTO.getCourseCode(), id)) {
			log.error("POST id/course - Ders kodu benzersizliği hatasından dolayı kayıt eklenmedi.");
			bindingResult.rejectValue("courseCode", null, "Ders Kodu Benzersiz Olmalıdır!");
			return "edit-course";
		}

		courseService.updateCourse(id, courseDTO);

		redirectAttributes.addAttribute("message", "Ders Başarıyla Güncellendi!");
		log.info("POST /course - Ders başarıyla eklendi.");
		return "redirect:/course/list";
	}
}
