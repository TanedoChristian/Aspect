using Microsoft.AspNetCore.Mvc;

namespace Microservices.UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
