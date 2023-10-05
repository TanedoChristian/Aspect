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
        public async Task<IActionResult> AddPhoto()
        {
            var photoDto = new PhotoDto();
            var formCollection = await Request.ReadFormAsync();

            string id = formCollection["id"];

            var file = formCollection.Files.GetFile("file");


            if (file != null)
            {
                var filePath = Path.Combine($"{_config["FileStorage"]}", file.FileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                photoDto.ProductId = int.Parse(id);
                photoDto.PhotoUrl = filePath;

                var photo = _mapper.Map<ProductPhoto>(photoDto);

                await _context.ProductPhotos.AddAsync(photo);
                await _context.SaveChangesAsync();


                return Ok("File uploaded successfully.");
            }

            return BadRequest("Error");
        }

        [HttpGet("{filename}")]
        public async Task<IActionResult> GetFile(string filename)
        {
            var filePath = Path.Combine($"{_config["FileStorage"]}", filename);
            var file = System.IO.File.OpenRead(filePath);
            return File(file, "application/octet-stream", filename);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.ProductPhotos.ToListAsync());
        }


    }
}