using LicenseApp.Data;
using LicenseApp.Models;
using LicenseApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LicenseApp.Controllers
{
    public class GatesController : Controller
    {
        private readonly AppDbContext _context;

        public GatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gates.Where(i => !i.IsDeleted).ToListAsync());
        }

        // GET: Items/Create
      /*  public IActionResult Create()
        {
            return View();
        }*/
        public async Task<IActionResult> Create()
        {
            var viewModel = new LicenseApp.ViewModels.GateCreateViewModel
            {
                Sakhans = await _context.Sakhans.Where(s => !s.IsDeleted).ToListAsync()
            };

            return View(viewModel);
        }

        /*// POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GateName,GateCode,SakhanId,SakhanName")] Gate item)
        {
            if (ModelState.IsValid)
            {
                
                // Check for uniqueness of ItemCode
                if (_context.Gates.Any(e => e.GateCode == item.GateCode))
                {
                    ModelState.AddModelError("GateCode", "GateCode must be unique.");
                    return View(item);
                }


                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }*/
        // POST: Gates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GateCreateViewModel viewModel)
        {
           /* if (ModelState.IsValid)
            {*/
                // Check for uniqueness of GateCode
                if (_context.Gates.Any(e => e.GateCode == viewModel.GateCode))
                {
                    ModelState.AddModelError("GateCode", "GateCode must be unique.");
                    viewModel.Sakhans = _context.Sakhans.ToList(); // Reload dropdown data
                    return View(viewModel);
                }

                var gate = new Gate
                {
                    GateName = viewModel.GateName,
                    GateCode = viewModel.GateCode,
                    SakhanId = viewModel.SakhanId,
                    SakhanName = _context.Sakhans.FirstOrDefault(s => s.Id == viewModel.SakhanId)?.SakhanName,
                    IsDeleted = false
                };

                _context.Add(gate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          /*  }

            viewModel.Sakhans = _context.Sakhans.ToList(); // Reload dropdown data in case of error
            return View(viewModel);*/
        }

        // GET: Items/Edit/5
        /*  public async Task<IActionResult> Edit(int? id)
          {
              if (id == null)
              {
                  return NotFound();
              }

              var item = await _context.Gates.FindAsync(id);
              if (item == null)
              {
                  return NotFound();
              }
              return View(item);
          }

          // POST: Items/Edit/5
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Edit(int id, [Bind("Id,GateName,GateCode,SakhanId,SakhanName")] Gate item)
          {
              if (id != item.Id)
              {
                  return NotFound();
              }

              if (ModelState.IsValid)
              {
                  try
                  {
                      _context.Update(item);
                      await _context.SaveChangesAsync();
                  }
                  catch (DbUpdateConcurrencyException)
                  {
                      if (!ItemExists(item.Id))
                      {
                          return NotFound();
                      }
                      else
                      {
                          throw;
                      }
                  }
                  return RedirectToAction(nameof(Index));
              }
              return View(item);
          }*/

        // GET: Gates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gate = await _context.Gates.FindAsync(id);
            if (gate == null)
            {
                return NotFound();
            }

            var viewModel = new GateCreateViewModel
            {
                Id = gate.Id,
                GateName = gate.GateName,
                GateCode = gate.GateCode,
                SakhanId = gate.SakhanId,
                SakhanName = gate.SakhanName,
                Sakhans = await _context.Sakhans.ToListAsync() // Load list of Sakhans for the dropdown
            };

            return View(viewModel);
        }

        // POST: Gates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GateCreateViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

          /*  if (ModelState.IsValid)
            {
               */ try
                {
                    var gate = await _context.Gates.FindAsync(id);
                    if (gate == null)
                    {
                        return NotFound();
                    }

                    gate.GateName = viewModel.GateName;
                    gate.GateCode = viewModel.GateCode;
                    gate.SakhanId = viewModel.SakhanId;
                    gate.SakhanName = _context.Sakhans.FirstOrDefault(s => s.Id == viewModel.SakhanId)?.SakhanName;

                    _context.Update(gate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GateExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            return RedirectToAction(nameof(Index));
       /* }

        // Reload dropdown data in case of error
        viewModel.Sakhans = await _context.Sakhans.ToListAsync();
            return View(viewModel);*/
    }

        private bool GateExists(int id)
        {
            return _context.Gates.Any(e => e.Id == id);
        }


        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Gates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Gates.FindAsync(id);
            if (item != null)
            {
                item.IsDeleted = true;
                _context.Gates.Update(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Gates.Any(e => e.Id == id);
        }
    }

   
}
