using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoEngineerCodingExample.Database;
using GoEngineerCodingExample.Models;
using GoEngineerCodingExample.Tools;

namespace GoEngineerCodingExample.Controllers
{
    public class VehicleController : Controller
    {
        private readonly DataContext _context;

        public VehicleController(DataContext context)
        {
            _context = context;
        }

        // GET: Vehicle
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        // GET: Vehicle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            vehicleModel.FilmLinks = LinkHelper.GetFilmLinks(_context.Films.Where(film => vehicleModel.films.Contains(film.url)).ToList());
            vehicleModel.PilotLinks = LinkHelper.GetPersonLinks(_context.People.Where(pilot => vehicleModel.pilots.Contains(pilot.url)).ToList());

            return View(vehicleModel);
        }

        // GET: Vehicle/Create
        public IActionResult Create()
        {
            VehicleModel model = new VehicleModel();
            model.FilmOptions = _context.Films.OrderBy(film => film.episode_id).ToList();
            model.PilotOptions = _context.People.OrderBy(person => person.name).ToList();
            return View(model);
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,model,manufacturer,cost_in_credits,length,max_atmosphering_speed,crew,passengers,cargo_capacity,consumables,vehicle_class,pilots,films,created,edited,url")] VehicleModel vehicleModel, List<string> selectedFilms, List<string> selectedPilots)
        {
            if (ModelState.IsValid)
            {
                vehicleModel.films = selectedFilms;
                vehicleModel.pilots = selectedPilots;
                _context.Add(vehicleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleModel);
        }

        // GET: Vehicle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.Vehicles.FindAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            vehicleModel.FilmOptions = _context.Films.OrderBy(film => film.episode_id).ToList();
            vehicleModel.PilotOptions = _context.People.OrderBy(person => person.name).ToList();

            return View(vehicleModel);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,model,manufacturer,cost_in_credits,length,max_atmosphering_speed,crew,passengers,cargo_capacity,consumables,vehicle_class,pilots,films,created,edited,url")] VehicleModel vehicleModel, List<string> selectedFilms, List<string> selectedPilots)
        {
            if (id != vehicleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vehicleModel.films = selectedFilms;
                    vehicleModel.pilots = selectedPilots;
                    _context.Update(vehicleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelExists(vehicleModel.Id))
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
            return View(vehicleModel);
        }

        // GET: Vehicle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            vehicleModel.FilmLinks = LinkHelper.GetFilmLinks(_context.Films.Where(film => vehicleModel.films.Contains(film.url)).ToList());
            vehicleModel.PilotLinks = LinkHelper.GetPersonLinks(_context.People.Where(pilot => vehicleModel.pilots.Contains(pilot.url)).ToList());

            return View(vehicleModel);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleModel = await _context.Vehicles.FindAsync(id);
            if (vehicleModel != null)
            {
                _context.Vehicles.Remove(vehicleModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModelExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
