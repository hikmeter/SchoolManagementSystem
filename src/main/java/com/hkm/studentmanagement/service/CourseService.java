package com.hkm.studentmanagement.service;

import org.springframework.data.domain.Page;

import com.hkm.studentmanagement.dto.CourseDTO;

public interface CourseService {
	
	public CourseDTO createCourse(CourseDTO dto);
	
	public boolean existsByCourseCodeIgnoreCase(String code);
	
	public Page<CourseDTO> getCourses(int page, int size);
}
