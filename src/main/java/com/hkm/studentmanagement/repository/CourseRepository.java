package com.hkm.studentmanagement.repository;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;

import com.hkm.studentmanagement.model.Courses;


public interface CourseRepository extends JpaRepository<Courses, Long> {
	
	public boolean existsByCourseCodeIgnoreCase(String code);
	
	public boolean existsByCourseCodeIgnoreCaseAndIdNot(String code, long id);
	
	public Page<Courses> findByActiveTrue(Pageable pageable);
}
