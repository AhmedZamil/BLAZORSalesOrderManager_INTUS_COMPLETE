using Microsoft.AspNetCore.Mvc;
using SalesOrderManager.DAL;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : Controller
    {
        private readonly IWindowRepository _windowRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WindowController(IWindowRepository windowRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _windowRepository = windowRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult GetAllWindows()
        {
            return Ok(_windowRepository.GetAllWindows());
        }

        [HttpGet("GetByOrderId")]
        public IActionResult GetAllWindowsByOrderId(int orderId)
        {
            return Ok(_windowRepository.GetAllWindowsByOrderId(orderId));
        }

        [HttpGet("{id}")]
        public IActionResult GetWindowById(int id)
        {
            return Ok(_windowRepository.GetWindowById(id));
        }

        [HttpPost]
        public IActionResult CreateWindow([FromBody] Window window)
        {
            if (window == null)
                return BadRequest();

            if (string.IsNullOrEmpty(window.Name))
            {
                ModelState.AddModelError("Name", "The Name shouldn't be empty");
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

            var createdWindow = _windowRepository.AddWindow(window);

            return Created("subElement", window);
        }

        [HttpPut]
        public IActionResult UpdateWindow([FromBody] Window window)
        {
            if (window == null)
                return BadRequest();

            if (string.IsNullOrEmpty(window.Name))
            {
                ModelState.AddModelError("Name", "Name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var windowToUpdate = _windowRepository.GetWindowById(window.WindowId);

            if (windowToUpdate == null)
                return NotFound();

            _windowRepository.UpdateWindow(window);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWindow(int id)
        {
            if (id == 0)
                return BadRequest();

            var windowToDelete = _windowRepository.GetWindowById(id);
            if (windowToDelete == null)
                return NotFound();

            _windowRepository.DeleteWindow(id);

            return NoContent();//success
        }
    }
}
