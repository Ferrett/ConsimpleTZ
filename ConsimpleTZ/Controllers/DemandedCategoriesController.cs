using ConsimpleTZ.Models;
using ConsimpleTZ.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTZ.Controllers
{
    [ApiController]
    [Route("/DemandedCategories")]
    public class DemandedCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DemandedCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetPopularCategories(int customerId)
        {
            //Get all Purchases of selected customer
            var customerPurchases = await _context.Purchases
                .Where(p => p.CustomerID == customerId)
                .Select(p => p.PurchaseID).ToListAsync();

            //Get PurchaseProducts of a customer
            var purchaseItems = await _context.PurchaseProducts
                .Where(pi => customerPurchases.Contains(pi.PurchaseID))
                .ToListAsync();

            //Group by Categories
            var groupedCategories = purchaseItems.Join(
                    _context.Products,
                    pi => pi.ProductID,
                    p => p.ProductID,
                    (pi, p) => new { p.Category, pi.Quantity }

            ).GroupBy(x => x.Category);

            //Select required data
            var categories = groupedCategories.Select(g => new
            {
                Category = g.Key,
                TotalQuantity = g.Sum(x => x.Quantity)

            }).OrderByDescending(x=>x.TotalQuantity).ToList();

            return Ok(categories);
        }
    }
}
