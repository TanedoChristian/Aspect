using AutoMapper;
using Microservices.UserApi.Dto;
using Microservices.UserApi.Entities;
using Microservices.UserApi.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.UserApi.Controllers
{
    public class UserController : BaseController
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
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

        [HttpPost]
        public async Task<IActionResult> AddUser(UserRequestDto userRequestDto)
        {



            if (userRequestDto == null)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(userRequestDto);
            await _userRepository.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserRequestDto userRequestDto)
        {
            if (userRequestDto == null)
            {
                return BadRequest();
            }

            var user = await _userRepository.GetById(id);


            _mapper.Map(userRequestDto, user);

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
            return Ok("Success");
        }
    }
}
