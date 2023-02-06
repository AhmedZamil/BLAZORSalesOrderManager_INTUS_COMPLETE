using Microsoft.AspNetCore.Mvc;
using SalesOrderManager.DAL;
using SalesOrderManager.Shared.Domain;

namespace SalesOrderManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderController(IOrderRepository orderRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var allOrders = _orderRepository.GetAllOrders();
            return Ok(allOrders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            return Ok(_orderRepository.GetOrderById(id));
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();

            if (string.IsNullOrEmpty(order.Name))
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

            var createdOrder = _orderRepository.AddOrder(order);

            return Created("Order", order);
        }

        [HttpPut]
        public IActionResult UpdateOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();

            if (string.IsNullOrEmpty(order.Name))
            {
                ModelState.AddModelError("Name", "Name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var windowToUpdate = _orderRepository.GetOrderById(order.OrderId);

            if (windowToUpdate == null)
                return NotFound();

            _orderRepository.UpdateOrder(order);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            if (id == 0)
                return BadRequest();

            var orderToDelete = _orderRepository.GetOrderById(id);
            if (orderToDelete == null)
                return NotFound();

            _orderRepository.DeleteOrder(id);

            return NoContent();//success
        }

    }
}
