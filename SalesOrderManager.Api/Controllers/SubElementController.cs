using Microsoft.AspNetCore.Mvc;
using SalesOrderManager.DAL;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubElementController : Controller
    {
        private readonly ISubElementRepository _subElementRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SubElementController(ISubElementRepository subElementRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _subElementRepository = subElementRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult GetAllSubElements()
        {
            return Ok(_subElementRepository.GetAllSubElements());
        }

        [HttpGet("GetByWindowId")]
        public IActionResult GetAllWindowsByOrderId(int windowId)
        {
            return Ok(_subElementRepository.GetAllSubElementsByWindowId(windowId));
        }

        [HttpGet("{id}")]
        public IActionResult GetSubElementById(int id)
        {
            return Ok(_subElementRepository.GetSubElementById(id));
        }

        [HttpPost]
        public IActionResult CreateSubElement([FromBody] SubElement subElement)
        {
            if (subElement == null)
                return BadRequest();

            if (subElement.Height <0 || subElement.Width < 0)
            {
                ModelState.AddModelError("Height/Width", "The height or width shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //handle image upload
            //string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
            //var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{subElement.ImageName}";
            //var fileStream = System.IO.File.Create(path);
            //fileStream.Write(employee.ImageContent, 0, employee.ImageContent.Length);
            //fileStream.Close();

            //employee.ImageName = $"https://{currentUrl}/uploads/{employee.ImageName}";

            var createdEmployee = _subElementRepository.AddSubElement(subElement);

            return Created("subElement", subElement);
        }

        [HttpPut]
        public IActionResult UpdateSubelement([FromBody] SubElement subElement)
        {
            if (subElement == null)
                return BadRequest();

            if (subElement.Height < 0|| subElement.Width < 0)
            {
                ModelState.AddModelError("Height/Width", "height or width shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subElementToUpdate = _subElementRepository.GetSubElementById(subElement.SubElementId);

            if (subElementToUpdate == null)
                return NotFound();

            _subElementRepository.UpdateSubElement(subElement);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubElement(int id)
        {
            if (id == 0)
                return BadRequest();

            var subElementToDelete = _subElementRepository.GetSubElementById(id);
            if (subElementToDelete == null)
                return NotFound();

            _subElementRepository.DeleteSubElement(id);

            return NoContent();//success
        }
    }
}
