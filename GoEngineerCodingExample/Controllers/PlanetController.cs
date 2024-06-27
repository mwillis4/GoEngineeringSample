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
    public class PlanetController : Controller
    {
        private readonly DataContext _context;

        public PlanetController(DataContext context)
        {
            _context = context;
        }

        // GET: PlanetModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planets.ToListAsync());
        }

        // GET: PlanetModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planetModel = await _context.Planets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planetModel == null)
            {
                return NotFound();
            }

            planetModel.FilmLinks = LinkHelper.GetFilmLinks(_context.Films.Where(film => planetModel.films.Contains(film.url)).ToList());
            planetModel.ResidentLinks = LinkHelper.GetPersonLinks(_context.People.Where(pilot => planetModel.residents.Contains(pilot.url)).ToList());

            return View(planetModel);
        }

        // GET: PlanetModels/Create
        public IActionResult Create()
        {
            PlanetModel model = new PlanetModel();
            model.FilmOptions = _context.Films.OrderBy(film => film.episode_id).ToList();
            model.ResidentOptions = _context.People.OrderBy(person => person.name).ToList();
            return View(model);
        }

        // POST: PlanetModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,rotation_period,orbital_period,diameter,climate,gravity,terrain,surface_water,population,residents,films,created,edited,url")] PlanetModel planetModel, List<string> selectedFilms, List<string> selectedResidents)
        {
            if (ModelState.IsValid)
            {
                planetModel.residents = selectedResidents;
                planetModel.films = selectedFilms;
                _context.Add(planetModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planetModel);
        }

        // GET: PlanetModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planetModel = await _context.Planets.FindAsync(id);
            if (planetModel == null)
            {
                return NotFound();
            }

            planetModel.FilmOptions = _context.Films.OrderBy(film => film.episode_id).ToList();
            planetModel.ResidentOptions = _context.People.OrderBy(person => person.name).ToList();

            return View(planetModel);
        }

        // POST: PlanetModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,rotation_period,orbital_period,diameter,climate,gravity,terrain,surface_water,population,residents,films,created,edited,url")] PlanetModel planetModel, List<string> selectedFilms, List<string> selectedResidents)
        {
            if (id != planetModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    planetModel.residents = selectedResidents;
                    planetModel.films = selectedFilms;
                    _context.Update(planetModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanetModelExists(planetModel.Id))
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
            return View(planetModel);
        }

        // GET: PlanetModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planetModel = await _context.Planets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planetModel == null)
            {
                return NotFound();
            }

            planetModel.FilmLinks = LinkHelper.GetFilmLinks(_context.Films.Where(film => planetModel.films.Contains(film.url)).ToList());
            planetModel.ResidentLinks = LinkHelper.GetPersonLinks(_context.People.Where(pilot => planetModel.residents.Contains(pilot.url)).ToList());

            return View(planetModel);
        }

        // POST: PlanetModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planetModel = await _context.Planets.FindAsync(id);
            if (planetModel != null)
            {
                _context.Planets.Remove(planetModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanetModelExists(int id)
        {
            return _context.Planets.Any(e => e.Id == id);
        }
    }
}
