package com.hkm.studentmanagement.service.impl;

import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.hkm.studentmanagement.dto.CourseDTO;
import com.hkm.studentmanagement.model.Courses;
import com.hkm.studentmanagement.repository.CourseRepository;
import com.hkm.studentmanagement.service.CourseService;

@Service
@Transactional
public class CourseServiceImpl implements CourseService {
	
	private final CourseRepository courseRepository;
	private final ModelMapper modelMapper;
	
	public CourseServiceImpl(CourseRepository courseRepository, ModelMapper modelMapper) {
		this.courseRepository = courseRepository;
		this.modelMapper = modelMapper;
	}
	
	@Override
	public CourseDTO createCourse(CourseDTO dto) {
		Courses courses = modelMapper.map(dto, Courses.class);
		courseRepository.save(courses);
		return modelMapper.map(courses, CourseDTO.class);
		
	}

	@Override
	public boolean existsByCourseCodeIgnoreCase(String code) {
		return courseRepository.existsByCourseCodeIgnoreCase(code);
	}

}
