using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoEngineerCodingExample.Models;
using GoEngineerCodingExample.Database;
using GoEngineerCodingExample.Tools;

namespace GoEngineerCodingExample.Controllers
{
    public class StarShipModelsController : Controller
    {
        private readonly DataContext _context;

        public StarShipModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: StarShipModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.StarShips.ToListAsync());
        }

        // GET: StarShipModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starShipModel = await _context.StarShips
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starShipModel == null)
            {
                return NotFound();
            }

            starShipModel.FilmLinks = LinkHelper.GetFilmLinks(_context.Films.Where(film => starShipModel.films.Contains(film.url)).ToList());
            starShipModel.PilotLinks = LinkHelper.GetPersonLinks(_context.People.Where(pilot => starShipModel.pilots.Contains(pilot.url)).ToList());

            return View(starShipModel);
        }

        public async Task<IActionResult> Home()
        {
            int maxID = _context.StarShips.Count();
            Random random = new Random();
            int id = random.Next(1, maxID);

            var starShipModel = await _context.StarShips
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starShipModel == null)
            {
                return NotFound();
            }

            starShipModel.FilmLinks = LinkHelper.GetFilmLinks(_context.Films.Where(film => starShipModel.films.Contains(film.url)).ToList());
            starShipModel.PilotLinks = LinkHelper.GetPersonLinks(_context.People.Where(pilot => starShipModel.pilots.Contains(pilot.url)).ToList());

            return View(starShipModel);
        }

        // GET: StarShipModels/Create
        public IActionResult Create()
        {
            StarShipModel model = new StarShipModel();
            model.FilmOptions = _context.Films.OrderBy(film => film.episode_id).ToList();
            model.PilotOptions = _context.People.OrderBy(person => person.name).ToList();
            return View(model);
        }

        // POST: StarShipModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,model,manufacturer,cost_in_credits,length,max_atmosphering_speed,crew,passengers,cargo_capacity,consumables,hyperdrive_rating,MGLT,starship_class,pilots,films,created,edited,url")] StarShipModel starShipModel, List<string> selectedFilms, List<string> selectedPilots)
        {
            if (ModelState.IsValid)
            {
                starShipModel.films = selectedFilms;
                starShipModel.pilots = selectedPilots;
                _context.Add(starShipModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(starShipModel);
        }

        // GET: StarShipModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starShipModel = await _context.StarShips.FindAsync(id);
            if (starShipModel == null)
            {
                return NotFound();
            }

            starShipModel.FilmOptions = _context.Films.OrderBy(film => film.episode_id).ToList();
            starShipModel.PilotOptions = _context.People.OrderBy(person => person.name).ToList();

            return View(starShipModel);
        }

        // POST: StarShipModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,model,manufacturer,cost_in_credits,length,max_atmosphering_speed,crew,passengers,cargo_capacity,consumables,hyperdrive_rating,MGLT,starship_class,created,edited,url")] StarShipModel starShipModel, List<string> selectedFilms, List<string> selectedPilots)
        {
            if (id != starShipModel.Id)
            {
                return NotFound();
            }

            ModelState.MaxAllowedErrors = 6;

            if (ModelState.IsValid)
            {
                starShipModel.films = selectedFilms;
                starShipModel.pilots = selectedPilots;

                try
                {
                    _context.Update(starShipModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarShipModelExists(starShipModel.Id))
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

            starShipModel.FilmOptions = _context.Films.OrderBy(film => film.episode_id).ToList();
            starShipModel.PilotOptions = _context.People.OrderBy(person => person.name).ToList();
            return View(starShipModel);
        }

        // GET: StarShipModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starShipModel = await _context.StarShips
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starShipModel == null)
            {
                return NotFound();
            }

            starShipModel.FilmLinks = LinkHelper.GetFilmLinks(_context.Films.Where(film => starShipModel.films.Contains(film.url)).ToList());
            starShipModel.PilotLinks = LinkHelper.GetPersonLinks(_context.People.Where(pilot => starShipModel.pilots.Contains(pilot.url)).ToList());

            return View(starShipModel);
        }

        // POST: StarShipModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starShipModel = await _context.StarShips.FindAsync(id);
            if (starShipModel != null)
            {
                _context.StarShips.Remove(starShipModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarShipModelExists(int id)
        {
            return _context.StarShips.Any(e => e.Id == id);
        }
    }
}
