using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementApi.Data;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.DTOs;
using AutoMapper;

namespace EmployeeManagementApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // ✅ GET: api/v1/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(employees));
        }

        // ✅ GET: api/v1/Employees/1
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            return Ok(_mapper.Map<EmployeeDTO>(employee));
        }

        // ✅ POST: api/v1/Employees
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee(CreateEmployeeDTO dto)
        {
            var employee = _mapper.Map<Employee>(dto);

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            return CreatedAtAction(
                nameof(GetEmployee),
                new { id = employee.Id, version = "1" },
                employeeDTO
            );
        }

        // ✅ PUT: api/v1/Employees/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, CreateEmployeeDTO dto)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            _mapper.Map(dto, employee);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ DELETE: api/v1/Employees/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
