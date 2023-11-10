using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EFTestProject.Data;

namespace EFTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerraController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public VerraController(DataContext context)
        {
            _dataContext = context;
        }
    }
}
