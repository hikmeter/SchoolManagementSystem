package com.hkm.studentmanagement.repository;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;

import com.hkm.studentmanagement.model.Students;

public interface StudentRepository extends JpaRepository<Students, Long> {
	
	public boolean existsByEmailIgnoreCase(String email);
	
	public boolean existsByPhoneNumber(String phone);
	
	public Page<Students> findByActiveTrue(Pageable pageable);
}
