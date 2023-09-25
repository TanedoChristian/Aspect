using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aspect.ProductAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Aspect.ProductAPI.Data;
using Aspect.ProductAPI.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Aspect.ProductAPI.Controllers
{
   
    public class PhotosController : BaseApiController
    {
        
        private readonly DataContext _context;
        private IMapper _mapper;

        public PhotosController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoto(PhotoDto photoDto)
        {

            var photo = _mapper.Map<ProductPhoto>(photoDto);

            _context.ProductPhotos.Add(photo);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.ProductPhotos.ToListAsync());
        }

        
    }
}