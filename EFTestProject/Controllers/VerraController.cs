using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EFTestProject.Data;
using EFTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTestProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    
    public class VerraController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public VerraController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpPost]
        [Route("AddProject")]
        public async Task<ActionResult<Project>> AddProject(ProjectDto dto)
        {
            var retrieveProjName = _dataContext.Projects.Any(a => a.Name == dto.Name);
            var retrieveCountry = _dataContext.Addresses.Any(a => a.Country == dto.Country);

            var project = new Project()
            {
                Name = dto.Name
            };


            if (retrieveProjName || retrieveCountry)
            {
                project.Name = string.Format("Unsuccessful. Project {0} or Country {1} already added. " + dto.Name, dto.Country);
                project.Id = -1;
            }
            else
            {
                _dataContext.Projects.Add(project);
                await _dataContext.SaveChangesAsync();

                // Get the new ProjectId
                var newlyAddedItem = _dataContext.Projects.Where(w => w.Name == dto.Name).FirstOrDefault();

                // Assign to Address
                var address = new Address()
                {
                    Country = dto.Country,
                    ProjectId = newlyAddedItem.Id
                };
                _dataContext.Addresses.Add(address);
                await _dataContext.SaveChangesAsync();
            }

            //var toReturn = await _dataContext.Projects.ToListAsync();            
            return Ok(project);
        }

        [HttpGet]
        [Route("GetCountries")]

        // Using Action Result here insead of the IActionResult Inface so I can see the results in the swagger UI
        public async Task<ActionResult<List<Address>>> GetCountries()
        {
            var toReturn = await _dataContext.Addresses.ToListAsync();
            return Ok(toReturn);
        }

        [HttpGet]
        [Route("GetAddresses")]

        public async Task<ActionResult<List<Address>>> GetAddresses()
        {
            var toReturn = await _dataContext.Addresses.ToListAsync();
            return Ok(toReturn);
        }

        [HttpGet]
        // Using Action Result here insead of the IActionResult Inface so I can see the results in the swagger UI
        [Route("GetRegisterList")]
        public async Task<ActionResult<List<ProjectDto>>> GetRegisterList()
        {
            var toReturn = new List<ProjectDto>();

            var projectList = await _dataContext.Projects.ToListAsync();
            var addressList = await _dataContext.Addresses.ToListAsync();
            var narrowedAddressList = addressList.Where(w => projectList.Any(p => p.Id == w.ProjectId)).ToList();

            projectList.ForEach(pl =>
            {
                var country = narrowedAddressList.Where(w => w.ProjectId == pl.Id).Select(s => s.Country).FirstOrDefault();
                var dto = new ProjectDto()
                {
                    Name = pl.Name,
                    Country = country
                };
                toReturn.Add(dto);
            });

            return Ok(toReturn);
        }




    }
}
