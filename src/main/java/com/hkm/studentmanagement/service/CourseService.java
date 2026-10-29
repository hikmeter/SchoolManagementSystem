package com.hkm.studentmanagement.service;

import com.hkm.studentmanagement.dto.CourseDTO;

public interface CourseService {
	
	public CourseDTO createCourse(CourseDTO dto);
	
	public boolean existsByCourseCodeIgnoreCase(String code);
}
