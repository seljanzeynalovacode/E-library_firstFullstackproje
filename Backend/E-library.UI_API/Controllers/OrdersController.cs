using E_library.BLL.DTOs;
using E_library.BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace E_library.UI_API.Controllers
{
 [Route("api/[controller]")]
 [ApiController]
 public class OrdersController : ControllerBase
 {
 private readonly IOrderService _service;
 public OrdersController(IOrderService service)
 {
 _service = service;
 }

 [HttpGet]
 public async Task<IActionResult> GetAll()
 {
 var items = await _service.GetAllAsync();
 return Ok(items);
 }

 [HttpGet("{id}")]
 public async Task<IActionResult> GetById(int id)
 {
 var item = await _service.GetByIdAsync(id);
 if (item == null) return NotFound();
 return Ok(item);
 }

 [HttpPost]
 public async Task<IActionResult> Create(OrderDto dto)
 {
 if (ModelState.IsValid)
 {
 await _service.AddAsync(dto);
 return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
 }
 return BadRequest(ModelState);
 }

 [HttpPut("{id}")]
 public async Task<IActionResult> Update(int id, OrderDto dto)
 {
 if (id != dto.Id) return BadRequest();
 if (ModelState.IsValid)
 {
 await _service.UpdateAsync(dto);
 return NoContent();
 }
 return BadRequest(ModelState);
 }

 [HttpDelete("{id}")]
 public async Task<IActionResult> Delete(int id)
 {
 await _service.DeleteAsync(id);
 return NoContent();
 }
 }
}
