using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employee.Areas.Employee.Models;
using Employee.Data;

namespace Employee.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EMPsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EMPsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee/EMPs
        public async Task<IActionResult> Index()
        {
            return View(await _context.EMP.ToListAsync());
        }

        // GET: Employee/EMPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eMP = await _context.EMP
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eMP == null)
            {
                return NotFound();
            }

            return View(eMP);
        }

        // GET: Employee/EMPs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/EMPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] EMP eMP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eMP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eMP);
        }

     
    }
}
