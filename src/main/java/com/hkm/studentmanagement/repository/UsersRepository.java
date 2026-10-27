package com.hkm.studentmanagement.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.hkm.studentmanagement.model.Users;

public interface UsersRepository extends JpaRepository<Users, Long>{
	
	boolean existsByUsername(String username);
}
