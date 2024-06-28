using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Ensure this is included
using LicenseApp.Models;
using LicenseApp.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using LicenseApp.Data;

namespace LicenseApp.Controllers
{
    public class LicensesController : Controller
    {
        private readonly AppDbContext _context;

        public LicensesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: License/Details
        public IActionResult Details()
        {
            return View(new LicenseSearchViewModel());
        }

        // POST: License/GetDetails
        [HttpPost]
        public async Task<IActionResult> GetDetails(string licenseNo)
        {
            var application = await _context.Applications
                .Include(a => a.Sakhan)
                .Include(a => a.LicenseItems)
                    .ThenInclude(li => li.Item)
                .Include(a => a.LicenseItems)
                    .ThenInclude(li => li.Unit)
                .FirstOrDefaultAsync(a => a.LicenseNo == licenseNo);

            if (application == null)
            {
                return NotFound("License not found.");
            }

            var gates = await _context.Gates
                .Where(g => g.SakhanId == application.SakhanId)
                .ToListAsync();

            var viewModel = new LicenseSearchViewModel
            {
                LicenseNo = licenseNo,
                Application = application,
                Gates = gates,
                Items = application.LicenseItems.ToList()
            };

            return PartialView("_LicenseDetailsPartial", viewModel);
        }

        // POST: License/Save
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(LicenseSearchViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Details", viewModel);
            }

            // Implement save logic here

            return RedirectToAction("Details"); // Redirect to a relevant action
        }
*/
        // POST: License/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(LicenseSearchViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("_LicenseDetailsPartial", viewModel); // Return to details view with validation errors
            }

            // Assuming viewModel.Items contains all items related to the application
            foreach (var item in viewModel.Items)
            {
                // Update balances for each item in the database
                var licenseItem = await _context.LicenseItems.FirstOrDefaultAsync(li => li.Id == item.Id);
                if (licenseItem != null)
                {
                    licenseItem.Balance = item.Balance; // Update the balance
                }
            }

            await _context.SaveChangesAsync(); // Save changes to the database

            return RedirectToAction("Details"); // Redirect to a relevant action
        }
    }
}
