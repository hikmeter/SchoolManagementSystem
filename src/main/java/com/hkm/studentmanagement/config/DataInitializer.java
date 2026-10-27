package com.hkm.studentmanagement.config;

import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.crypto.password.PasswordEncoder;

import com.hkm.studentmanagement.model.Users;
import com.hkm.studentmanagement.repository.UsersRepository;

@Configuration
public class DataInitializer {
	@Bean
	CommandLineRunner loadSampleData(UsersRepository usersRepository, PasswordEncoder passwordEncoder) {
		return args -> {
			if(!usersRepository.existsByUsername("admin")) {
				Users users = new Users();
				users.setActive(true);
				users.setPassword(passwordEncoder.encode("admin123"));
				users.setUsername("admin");
				usersRepository.save(users);
			}
		};
	}
}
