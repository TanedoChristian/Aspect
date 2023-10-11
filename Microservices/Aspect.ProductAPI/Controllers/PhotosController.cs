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
        private IConfiguration _config;

        public PhotosController(DataContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }


        [HttpPost]
        public async Task<IActionResult> AddFile()
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.GetFile("file");
            var id = formCollection["id"];


            var photoDto = new PhotoDto();
            if (file != null)
            {
                var filePath = Path.Combine($"{_config["FileStorage"]}", file.FileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                photoDto.ProductId = int.Parse(id);
                photoDto.PhotoUrl = file.FileName;

                var photo = _mapper.Map<ProductPhoto>(photoDto);

                await _context.ProductPhotos.AddAsync(photo);
                await _context.SaveChangesAsync();
                

                return Ok("File uploaded successfully.");
            }

            return BadRequest("Error");
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            
            var filePath = _context.ProductPhotos.FirstOrDefault(photo => photo.Id == id);
            var file = System.IO.File.OpenRead(filePath.PhotoUrl);
            return File(file, "application/octet-stream");
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.ProductPhotos.ToListAsync());
        }

        
    }
}