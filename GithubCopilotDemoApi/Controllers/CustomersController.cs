using GithubCopilotDemoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GithubCopilotDemoApi.Controllers;

//generate an api controller to manage customers
[ApiController]
[Route("[controller]")]

public class CustomersController : ControllerBase
{
	private readonly AdventureWorksContext _context;

	public CustomersController(AdventureWorksContext context)
	{
		_context = context;
	}

	// GET: Customers
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
	{
		return await _context.Customers.AsNoTracking().ToListAsync();
	}

	// GET: Customers/5
	[HttpGet("{id}")]
	public async Task<ActionResult<Customer>> GetCustomer(int id)
	{
		var customer = await _context.Customers.FindAsync(id);

		return customer == null ? (ActionResult<Customer>)NotFound() : (ActionResult<Customer>)customer;
	}

	// PUT: Customers/5
	[HttpPut("{id}")]
	public async Task<IActionResult> PutCustomer(int id, Customer customer)
	{
		if (id != customer.CustomerId)
		{
			return BadRequest();
		}

		_context.Entry(customer).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!CustomerExists(id))
			{
				return NotFound();
			}
			else
			{
				throw;
			}
		}

		return NoContent();
	}

	// POST: Customers
	[HttpPost]
	public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
	{
		_context.Customers.Add(customer);
		await _context.SaveChangesAsync();

		return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
	}

	// DELETE: Customers/5
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteCustomer(int id)
	{
		var customer = await _context.Customers.FindAsync(id);
		if (customer == null)
		{
			return NotFound();
		}

		_context.Customers.Remove(customer);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool CustomerExists(int id)
	{
		return _context.Customers.Any(e => e.CustomerId == id);
	}
}