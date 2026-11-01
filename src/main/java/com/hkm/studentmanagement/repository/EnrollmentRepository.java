package com.hkm.studentmanagement.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.hkm.studentmanagement.model.Enrollment;

public interface EnrollmentRepository extends JpaRepository<Enrollment, Long> {

}
