using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Data;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class OrdenesCompraProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdenesCompraProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdenesCompraProductos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrdenesCompraProductos.Include(o => o.OrdenCompra).Include(o => o.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrdenesCompraProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompraProducto = await _context.OrdenesCompraProductos
                .Include(o => o.OrdenCompra)
                .Include(o => o.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordenCompraProducto == null)
            {
                return NotFound();
            }

            return View(ordenCompraProducto);
        }

        // GET: OrdenesCompraProductos/Create
        public IActionResult Create()
        {
            ViewData["IdOrdenCompra"] = new SelectList(_context.OrdenesCompra, "Id", "Id");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id");
            return View();
        }

        // POST: OrdenesCompraProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProducto,IdOrdenCompra")] OrdenCompraProducto ordenCompraProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenCompraProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOrdenCompra"] = new SelectList(_context.OrdenesCompra, "Id", "Id", ordenCompraProducto.IdOrdenCompra);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", ordenCompraProducto.IdProducto);
            return View(ordenCompraProducto);
        }

        // GET: OrdenesCompraProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompraProducto = await _context.OrdenesCompraProductos.FindAsync(id);
            if (ordenCompraProducto == null)
            {
                return NotFound();
            }
            ViewData["IdOrdenCompra"] = new SelectList(_context.OrdenesCompra, "Id", "Id", ordenCompraProducto.IdOrdenCompra);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", ordenCompraProducto.IdProducto);
            return View(ordenCompraProducto);
        }

        // POST: OrdenesCompraProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProducto,IdOrdenCompra")] OrdenCompraProducto ordenCompraProducto)
        {
            if (id != ordenCompraProducto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenCompraProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenCompraProductoExists(ordenCompraProducto.Id))
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
            ViewData["IdOrdenCompra"] = new SelectList(_context.OrdenesCompra, "Id", "Id", ordenCompraProducto.IdOrdenCompra);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", ordenCompraProducto.IdProducto);
            return View(ordenCompraProducto);
        }

        // GET: OrdenesCompraProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompraProducto = await _context.OrdenesCompraProductos
                .Include(o => o.OrdenCompra)
                .Include(o => o.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordenCompraProducto == null)
            {
                return NotFound();
            }

            return View(ordenCompraProducto);
        }

        // POST: OrdenesCompraProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenCompraProducto = await _context.OrdenesCompraProductos.FindAsync(id);
            if (ordenCompraProducto != null)
            {
                _context.OrdenesCompraProductos.Remove(ordenCompraProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenCompraProductoExists(int id)
        {
            return _context.OrdenesCompraProductos.Any(e => e.Id == id);
        }
    }
}
