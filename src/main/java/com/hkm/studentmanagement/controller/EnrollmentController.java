package com.hkm.studentmanagement.controller;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;

import com.hkm.studentmanagement.dto.EnrollmentDTO;
import com.hkm.studentmanagement.service.CourseService;
import com.hkm.studentmanagement.service.StudentService;

@Controller
@RequestMapping("/enrollment")
public class EnrollmentController {
	
	private final CourseService courseService;
	private final StudentService studentService;
	private static final Logger log = LoggerFactory.getLogger(EnrollmentController.class);
		
	public EnrollmentController(CourseService courseService, StudentService studentService) {
		this.courseService = courseService;
		this.studentService = studentService;
	}

	@GetMapping("/showEnroll")
	public String showEnroll(Model model) {
		log.info("GET enrollment/showEnroll - Öğrenci ders kaydı sayfası açıldı.");
		model.addAttribute("enrollmentDTO", new EnrollmentDTO());
		model.addAttribute("courseList", courseService.getAllCourses());
		model.addAttribute("studentList", studentService.getAllStudents());
		return "enroll-course";
	}
}
