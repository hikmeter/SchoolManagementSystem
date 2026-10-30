package com.hkm.studentmanagement.dto;

import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Pattern;
import jakarta.validation.constraints.Size;


public class StudentDTO {
	
	private long id;
	
	@NotBlank(message = "Ad alanı boş bırakılamaz!")
	@Size(max = 50, message = "Ad en fazla 50 karakter olabilir!")
	private String firstName;
	
	@NotBlank(message = "Soyad alanı boş bırakılamaz!")
	@Size(max = 50, message = "Soyad en fazla 50 karakter olabilir!")
	private String lastName;
	
	@NotBlank(message = "E-posta alanı boş bırakılamaz!")
	@Email(message = "Geçerli bir e-posta adresi giriniz!")
	@Size(max = 100, message = "E-posta en fazla 100 karakter olabilir!")
	private String email;
	
	@NotBlank(message = "Telefon numarası boş bırakılamaz!")
	@Pattern(
	    regexp = "^[0-9]{10,15}$",
	    message = "Telefon numarası 10-15 rakam arasında olmalıdır!"
	)
	private String phoneNumber;
	
	@NotBlank(message = "Adres alanı boş bırakılamaz!")
	@Size(max = 255, message = "Adres en fazla 255 karakter olabilir!")
	private String address;
	
	private boolean active;
		
	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getFirstName() {
		return firstName;
	}

	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}

	public String getLastName() {
		return lastName;
	}

	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getPhoneNumber() {
		return phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public boolean isActive() {
		return active;
	}

	public void setActive(boolean active) {
		this.active = active;
	}

}
