package com.hkm.studentmanagement.service;

import org.springframework.data.domain.Page;

import com.hkm.studentmanagement.dto.CourseDTO;

public interface CourseService {
	
	public CourseDTO createCourse(CourseDTO dto);
	
	public boolean existsByCourseCodeIgnoreCase(String code);
	
	public boolean existsByCourseCodeIgnoreCaseAndIdNot(String code, long id);
	
	public Page<CourseDTO> getCourses(int page, int size);
	
	public CourseDTO getCourseById(long id);
	
	public CourseDTO updateCourse(Long id, CourseDTO dto);
}
