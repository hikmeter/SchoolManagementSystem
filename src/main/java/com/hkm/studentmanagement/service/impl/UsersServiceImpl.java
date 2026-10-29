package com.hkm.studentmanagement.service.impl;

import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import com.hkm.studentmanagement.model.Users;
import com.hkm.studentmanagement.repository.UsersRepository;

@Service
public class UsersServiceImpl implements UserDetailsService {

	private UsersRepository usersRepository;
	
	public UsersServiceImpl(UsersRepository usersRepository) {
		this.usersRepository = usersRepository;
	}

	@Override
	public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
		Users users = usersRepository.findByUsername(username).orElseThrow(() -> new UsernameNotFoundException("Geçersiz Kullanıcı Adı!"));
		return User.withUsername(username).password(users.getPassword()).disabled(!users.isActive()).build();
	}

}
