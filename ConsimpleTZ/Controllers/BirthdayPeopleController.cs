using ConsimpleTZ.Models;
using ConsimpleTZ.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTZ.Controllers
{
    [ApiController]
    [Route("/BirthdayPeople")]
    public class BirthdayPeopleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BirthdayPeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetBirthdayPeople(DateTime date)
        {
            //Customers with birthday today
            var birthdayPeopleQuery = await _context.Customers
                .Where(c => c.BirthDate.Month == date.Month && c.BirthDate.Day == date.Day).ToListAsync();

            //Select required data
            var birthdayPeople = birthdayPeopleQuery.Select(c => new
            {
                c.CustomerID,
                c.FullName
            });

            return Ok(birthdayPeople);
        }
    }
}
