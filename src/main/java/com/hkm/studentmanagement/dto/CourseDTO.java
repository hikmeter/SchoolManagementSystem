package com.hkm.studentmanagement.dto;

import java.math.BigDecimal;

import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;

public class CourseDTO {
	private long id;
	
	@NotBlank(message = "Ders Adı Boş Olamaz!")
	@Size(max = 50, message = "Ders Adı En Fazla 50 Karakter Olabilir!")
	private String courseName;
	
	@NotBlank(message = "Ders Kodu Boş Olamaz!")
	@Size(max = 8, message = "Ders Kodu En Fazla 8 Karakter Olabilir!")
	private String courseCode;

	@NotBlank(message = "Ders Yarıyılı Boş Olamaz!")
	private String semester;

	@NotNull(message = "Ders Ücreti Boş Olamaz!")
	private BigDecimal fee;
	
	@Size(max = 1000, message = "Ders Açıklaması En Fazla 1000 Karakter Olabilir!")
	private String description;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getCourseName() {
		return courseName;
	}

	public void setCourseName(String courseName) {
		this.courseName = courseName;
	}

	public String getCourseCode() {
		return courseCode;
	}

	public void setCourseCode(String courseCode) {
		this.courseCode = courseCode;
	}

	public String getSemester() {
		return semester;
	}

	public void setSemester(String semester) {
		this.semester = semester;
	}

	public BigDecimal getFee() {
		return fee;
	}

	public void setFee(BigDecimal fee) {
		this.fee = fee;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}
	
}
