package com.hkm.studentmanagement.service;

import org.springframework.data.domain.Page;

import com.hkm.studentmanagement.dto.StudentDTO;

public interface StudentService {
	public boolean existsByEmailIgnoreCase(String email);
	
	public boolean existsByPhoneNumber(String phone);
	
	public boolean existsByEmailIgnoreCaseAndIdNot(String email, long id);
	
	public boolean existsByPhoneNumberAndIdNot(String phone, long id);
	
	public StudentDTO createStudent(StudentDTO studentDTO);
	
	public Page<StudentDTO> getStudents(int page, int size);
	
	public StudentDTO getStudentById(long id);
}
