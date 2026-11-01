package com.hkm.studentmanagement.dto;

import java.util.ArrayList;
import java.util.List;

import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.NotNull;

public class EnrollmentDTO {
	
	@NotNull(message = "Öğrenci Seçiniz!")
	private long studentId;
	
	@NotEmpty(message = "En Az 1 Ders Seçiniz!")
	private List<Long> courseIds = new ArrayList<>();

	public long getStudentId() {
		return studentId;
	}

	public void setStudentId(long studentId) {
		this.studentId = studentId;
	}

	public List<Long> getCourseIds() {
		return courseIds;
	}

	public void setCourseIds(List<Long> courseIds) {
		this.courseIds = courseIds;
	}		
}
