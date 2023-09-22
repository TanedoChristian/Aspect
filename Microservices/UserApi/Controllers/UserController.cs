using AutoMapper;
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

        [HttpPost]
        public async Task<IActionResult> AddUser(IEnumerable<UserDto> userDto)
        {
            /*if(userDto == null)
            {
                return BadRequest();
            }*/
            foreach(var c in userDto)
            {
                var user = _mapper.Map<User>(userDto);

                await _userRepository.Create(user);
            }
            
            return Ok();    
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
