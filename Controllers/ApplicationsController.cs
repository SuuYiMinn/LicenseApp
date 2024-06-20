using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LicenseApp.Data;
using LicenseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using LicenseApp.ViewModels;
namespace LicenseApp.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ApplicationsController> _logger;

        public ApplicationsController(AppDbContext context, ILogger<ApplicationsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var applications = await _context.Applications
                .Include(a => a.Sakhan)
                .Include(a => a.LicenseItems)
                .ThenInclude(li => li.Item)
                .ToListAsync();
            return View(applications);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var (applicationNo, createDate, lastDate) = GenerateApplicationNo();

            var viewModel = new ApplicationCreateViewModel
            {
                ApplicationNo = applicationNo,
                CreateDate = createDate,
                LastDate = lastDate,
                Sakhans = await _context.Sakhans.ToListAsync(),
                Items = await _context.Items.ToListAsync(),
                Units = await _context.Units.ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationCreateViewModel model)
        {
            // Generate LicenseNo
            var sakhan = await _context.Sakhans.FindAsync(model.SakhanId);
            string licenseNo = await GenerateLicenseNo(sakhan.SakhanName);
            
            var application = new Application
            {
                ApplicationNo = model.ApplicationNo,
                CompanyName = model.CompanyName,
                SakhanId = model.SakhanId,
                LicenseNo = licenseNo, // Assign generated LicenseNo
                CreateDate = DateTime.Now.Date, // Set CreateDate
                LastDate = DateTime.Now.Date.AddDays(60), // Set LastDate to 60 days from today
                LicenseItems = model.LicenseItems.Select(li => new LicenseItem
                {
                    ItemId = li.ItemId,
                    Quantity = li.Quantity,
                    UnitId = li.UnitId
                }).ToList()
            };

            try
            {
                _context.Applications.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction("Payment", new { id = application.Id });
            }
            catch (DbUpdateException ex)
            {
                // Handle exception here (e.g., log error, handle user message)
                // Example: Log the exception message
                Console.WriteLine($"Error inserting application: {ex.Message}");

                // Reload the dropdown data in case of error
                model.Sakhans = await _context.Sakhans.ToListAsync();
                model.Items = await _context.Items.ToListAsync();
                model.Units = await _context.Units.ToListAsync();
                return View(model);
            }
        }

        private (string, DateTime, DateTime) GenerateApplicationNo()
        {
            DateTime currentDate = DateTime.Now;
            DateTime lastDate = currentDate.AddDays(-60); // Get the date 60 days ago

            string datePart = currentDate.ToString("ddMMyyyy");
            string lastDatePart = lastDate.ToString("ddMMyyyy");

            // Fetch application numbers ending with today's date as a string
            var todayApplications = _context.Applications
                .Where(a => a.ApplicationNo.EndsWith(datePart))
                .Select(a => a.ApplicationNo)
                .ToList();

            int maxSerial = 0;
            if (todayApplications.Any())
            {
                // Extract serial part safely
                maxSerial = todayApplications
                    .Select(a =>
                    {
                        var parts = a.Split('-');
                        int serial;
                        if (parts.Length == 3 && int.TryParse(parts[1], out serial))
                        {
                            return serial;
                        }
                        return 0;
                    })
                    .Max();
            }

            int newSerial = maxSerial + 1;
            string applicationNo = $"App-{newSerial:D3}-{datePart}";

            return (applicationNo, currentDate, lastDate);
        }


        public async Task<IActionResult> Payment(int id)
        {
            var licenseApplication = await _context.Applications.FindAsync(id);
            if (licenseApplication == null)
            {
                return NotFound();
            }

            var paymentViewModel = new PaymentViewModel
            {
                ApplicationId = licenseApplication.Id,
                ApplicationNo = licenseApplication.ApplicationNo,
                ApplicationFees = 100,
                LicenseFees = 30000,
                TransactionFees = 200
            };

            paymentViewModel.TotalFees = paymentViewModel.ApplicationFees + paymentViewModel.LicenseFees + paymentViewModel.TransactionFees;

            return View(paymentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakePayment(PaymentViewModel viewModel)
        {
            return RedirectToAction("LicenseDetails", new { applicationId = viewModel.ApplicationId });
        }

       
        public async Task<IActionResult> LicenseDetails(int applicationId)
        {
            var application = await _context.Applications
                .Include(a => a.Sakhan)
                .Include(a => a.LicenseItems)
                    .ThenInclude(li => li.Item)
                .Include(a => a.LicenseItems)
                    .ThenInclude(li => li.Unit)
                .FirstOrDefaultAsync(a => a.Id == applicationId);

            if (application == null)
            {
                return NotFound();
            }

            // Generate LicenseNo
            /*string licenseNo = await GenerateLicenseNo(application.Sakhan.SakhanName);*/

            var licenseDetailsViewModel = new LicenseDetailsViewModel
            {
                ApplicationNo = application.ApplicationNo,
                CompanyName = application.CompanyName,
                SakhanName = application.Sakhan.SakhanName,
                LicenseNo = application.LicenseNo,
                LicenseItems = application.LicenseItems.Select(li => new LicenseItemViewModel
                {
                    ItemName = li.Item.ItemName,
                    Quantity = li.Quantity,
                    UnitName = li.Unit.UnitName
                }).ToList()
            };

            return View(licenseDetailsViewModel);
        }

        private async Task<string> GenerateLicenseNo(string sakhanName)
        {
            string datePart = DateTime.Now.ToString("ddMMyyyy");
            string prefix = $"{sakhanName}-";

            // Fetch existing license numbers ending with today's date and the specified SakhanName
            var todayLicenseNos = await _context.Applications
                .Where(a => a.LicenseNo.StartsWith(prefix) && a.LicenseNo.EndsWith(datePart))
                .Select(a => a.LicenseNo)
                .ToListAsync();

            int maxSerial = 0;
            if (todayLicenseNos.Any())
            {
                // Extract serial part safely
                maxSerial = todayLicenseNos
                    .Select(a =>
                    {
                        var parts = a.Split('-');
                        int serial;
                        if (parts.Length == 3 && int.TryParse(parts[1], out serial))
                        {
                            return serial;
                        }
                        return 0;
                    })
                    .Max();
            }

            int newSerial = maxSerial + 1;
            string newLicenseNo = $"{sakhanName}-{newSerial:D3}-{datePart}";

            // Truncate if the generated LicenseNo exceeds the maximum length
            int maxLength = 50; // Example: Maximum length of LicenseNo column
            if (newLicenseNo.Length > maxLength)
            {
                newLicenseNo = newLicenseNo.Substring(0, maxLength);
            }

            // Ensure no duplicate LicenseNo with the same second part (three digits)
            while (todayLicenseNos.Contains(newLicenseNo))
            {
                newSerial++;
                newLicenseNo = $"{sakhanName}-{newSerial:D3}-{datePart}";

                // Truncate again if needed
                if (newLicenseNo.Length > maxLength)
                {
                    newLicenseNo = newLicenseNo.Substring(0, maxLength);
                }
            }

            return newLicenseNo;
        }

    }
}
