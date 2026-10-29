package com.hkm.studentmanagement.controller;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import com.hkm.studentmanagement.dto.CourseDTO;
import com.hkm.studentmanagement.service.CourseService;

import jakarta.validation.Valid;

@Controller
@RequestMapping("/course")
public class CourseController {
	
	private CourseService courseService;
	
	public CourseController(CourseService courseService) {
		this.courseService = courseService;
	}

	@GetMapping("/new")
	public String showCreateCourse(Model model) {
		model.addAttribute("courseDTO", new CourseDTO());
		return "add-course";
	}
	
	@GetMapping("/list")
	public String listCourses() {
		return "courses";
	}
	
	@PostMapping
	public String createCourse(@Valid @ModelAttribute("courseDTO") CourseDTO courseDTO, BindingResult bindingResult, Model model,
			RedirectAttributes redirectAttributes) {
		if(bindingResult.hasErrors()) {
			return "add-course";
		}
		
		if(courseService.existsByCourseCodeIgnoreCase(courseDTO.getCourseCode())) {
			bindingResult.rejectValue("courseCode", null, "Ders Kodu Benzersiz Olmalıdır!");
			return "add-course";
		}
		
		courseService.createCourse(courseDTO);
		
		redirectAttributes.addAttribute("message", "Ders Başarıyla Eklendi!");
		
		return "redirect:/course/list";
	}
}
