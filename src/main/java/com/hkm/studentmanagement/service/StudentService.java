package com.hkm.studentmanagement.service;

import com.hkm.studentmanagement.dto.StudentDTO;

public interface StudentService {
	public boolean existsByEmailIgnoreCase(String email);
	
	public boolean existsByPhoneNumber(String phone);
	
	public StudentDTO createStudent(StudentDTO studentDTO);
}
