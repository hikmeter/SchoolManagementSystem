package com.hkm.studentmanagement.service.impl;

import org.modelmapper.ModelMapper;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.hkm.studentmanagement.dto.StudentDTO;
import com.hkm.studentmanagement.model.Students;
import com.hkm.studentmanagement.repository.StudentRepository;
import com.hkm.studentmanagement.service.StudentService;

@Service
@Transactional
public class StudentServiceImpl implements StudentService {
	
	private final StudentRepository studentRepository;
	private final ModelMapper modelMapper;
	private static final Logger log = LoggerFactory.getLogger(StudentServiceImpl.class);
	
	public StudentServiceImpl(StudentRepository studentRepository, ModelMapper modelMapper) {
		this.studentRepository = studentRepository;
		this.modelMapper = modelMapper;
	}

	@Override
	public boolean existsByEmailIgnoreCase(String email) {
		log.info("E-Posta adresi benzersizliği kontrol ediliyor: ", email);
		return studentRepository.existsByEmailIgnoreCase(email);
	}

	@Override
	public boolean existsByPhoneNumber(String phone) {
		log.info("Telefon numarası benzersizliği kontrol ediliyor: ", phone);
		return studentRepository.existsByPhoneNumber(phone);
	}

	@Override
	public StudentDTO createStudent(StudentDTO studentDTO) {
		log.info("Öğrenci kayıt işlemi.");
		Students students = modelMapper.map(studentDTO, Students.class);
		studentRepository.save(students);
		return modelMapper.map(students, StudentDTO.class);
	}

}
