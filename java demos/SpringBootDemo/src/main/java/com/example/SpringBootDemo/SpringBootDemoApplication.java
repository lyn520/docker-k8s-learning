package com.example.SpringBootDemo;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

@EnableJpaRepositories("com.example.SpringBootDemo.repo")
@EntityScan("com.example.SpringBootDemo.model")
@SpringBootApplication
public class SpringBootDemoApplication {

	public static void main(String[] args) {

		SpringApplication.run(SpringBootDemoApplication.class, args);
	}

}
