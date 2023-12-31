﻿using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using UserApi.Dto;
using UserApi.Entities;
using UserApi.Repositories.UserRepository;

namespace UserApi.Controllers
{
    public class UserController: BaseApiController
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _userRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);

            if(user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpPost("login")]
        
        public async Task <IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmail(loginDto.Email);


            if(user == null)
            {
                return BadRequest();
            }

            if(BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return Ok(user);
            }

            return BadRequest();

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
                var user = _mapper.Map<User>(userDto);
                user.Type = "user";
                user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
                await _userRepository.Create(user);
            return Ok();    
        }


        [HttpGet("/email/{email}")]
        public async Task<IActionResult> AddUser(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            return Ok(user);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }

            var user = await _userRepository.GetById(id);

            if(user == null)
            {
                return BadRequest();
            }

            _mapper.Map(userDto, user);
            await _userRepository.Update(user);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return BadRequest();
            }

            await _userRepository.Delete(user);
            return Ok();
        }
    }
}
