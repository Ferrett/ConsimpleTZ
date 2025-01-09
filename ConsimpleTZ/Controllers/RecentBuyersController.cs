using ConsimpleTZ.Models;
using ConsimpleTZ.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTZ.Controllers
{
    [ApiController]
    [Route("/RecentBuyers")]
    public class RecentBuyersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecentBuyersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{days}")]
        public async Task<IActionResult> GetRecentBuyers(int days)
        {
            //Get Purchases in the last selected days
            var recentPurchasesQuery = await _context.Purchases
                .Where(p => p.Date >= DateTime.UtcNow.AddDays(days * -1)).ToListAsync();

            //Group Purchases by Customers
            var groupedPurchases = recentPurchasesQuery.GroupBy(p => p.CustomerID);

            //Select required data
            var recentBuyers = groupedPurchases.Select(g => new
            {
                CustomerID = g.Key,
                FullName = _context.Customers.Where(c => c.CustomerID == g.Key).Select(c => c.FullName).FirstOrDefault(),
                LastPurchaseDate = g.Max(p => p.Date)
            });

            return Ok(recentBuyers);
        }
    }
}
