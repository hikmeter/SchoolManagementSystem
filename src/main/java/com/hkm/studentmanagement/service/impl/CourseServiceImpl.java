package com.hkm.studentmanagement.service.impl;

import org.modelmapper.ModelMapper;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Sort;
import org.springframework.data.domain.Sort.Direction;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.hkm.studentmanagement.dto.CourseDTO;
import com.hkm.studentmanagement.model.Courses;
import com.hkm.studentmanagement.repository.CourseRepository;
import com.hkm.studentmanagement.service.CourseService;

@Service
@Transactional
public class CourseServiceImpl implements CourseService {
	
	private static final Logger log = LoggerFactory.getLogger(CourseServiceImpl.class);
	private final CourseRepository courseRepository;
	private final ModelMapper modelMapper;
	
	public CourseServiceImpl(CourseRepository courseRepository, ModelMapper modelMapper) {
		this.courseRepository = courseRepository;
		this.modelMapper = modelMapper;
	}
	
	@Override
	public CourseDTO createCourse(CourseDTO dto) {
		log.info("Ders kaydı ilgili ders koduyla gerçekleştiriliyor: ", dto.getCourseCode());
		Courses courses = modelMapper.map(dto, Courses.class);
		courseRepository.save(courses);
		return modelMapper.map(courses, CourseDTO.class);
		
	}

	@Override
	public boolean existsByCourseCodeIgnoreCase(String code) {
		log.info("Ders kodu benzersizliği kontrol ediliyor: ", code);
		return courseRepository.existsByCourseCodeIgnoreCase(code);
	}

	@Override
	@Transactional(readOnly = true)
	public Page<CourseDTO> getCourses(int page, int size) {
		log.info("Ders listesi getiriliyor: ", page);
		PageRequest pageRequest = PageRequest.of(page, size, Sort.by(Direction.DESC, "id"));
		return courseRepository.findByActiveTrue(pageRequest).map(course -> modelMapper.map(course, CourseDTO.class));
	}

	@Override
	@Transactional(readOnly = true)
	public CourseDTO getCourseById(long id) {
		Courses courses = courseRepository.findById(id).orElseThrow(() -> new RuntimeException("Ders Bulunamadı!"));
		return modelMapper.map(courses, CourseDTO.class);
	}

	@Override
	public CourseDTO updateCourse(Long id, CourseDTO dto) {
		Courses courses = courseRepository.findById(id).orElseThrow(() -> new RuntimeException("Ders Bulunamadı!"));
		modelMapper.map(dto,courses);
		Courses updatedCourses = courseRepository.save(courses);
		return modelMapper.map(updatedCourses, dto.getClass());
	}

	@Override
	public boolean existsByCourseCodeIgnoreCaseAndIdNot(String code, long id) {
		log.info("Ders kodu ve ID benzersizliği kontrol ediliyor, id: {},  kod: {}  ", id, code);
		return courseRepository.existsByCourseCodeIgnoreCaseAndIdNot(code, id);
	}

}
