using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspect.ProductAPI.Services.FileService
{
    public interface IFileService
    {
        Task Upload(IFormFile file);
    }
}