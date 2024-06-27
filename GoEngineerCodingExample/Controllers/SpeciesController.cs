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
    public class SpeciesController : Controller
    {
        private readonly DataContext _context;

        public SpeciesController(DataContext context)
        {
            _context = context;
        }

        // GET: Species
        public async Task<IActionResult> Index()
        {
            return View(await _context.Species.ToListAsync());
        }

        // GET: Species/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciesModel = await _context.Species
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speciesModel == null)
            {
                return NotFound();
            }

            speciesModel.HomeworldLink = LinkHelper.GetPlanetLink(_context.Planets.FirstOrDefault(planet => planet.url == speciesModel.homeworld));
            speciesModel.FilmLinks = LinkHelper.GetFilmLinks(_context.Films.Where(film => speciesModel.films.Contains(film.url)).ToList());
            speciesModel.CharacterLinks = LinkHelper.GetPersonLinks(_context.People.Where(pilot => speciesModel.people.Contains(pilot.url)).ToList());

            return View(speciesModel);
        }

        // GET: Species/Create
        public IActionResult Create()
        {
            SpeciesModel model = new SpeciesModel();
            model.HomeworldOptions = _context.Planets.OrderBy(planet => planet.name).ToList();
            model.CharacterOptions = _context.People.OrderBy(person => person.name).ToList();
            model.FilmOptions = _context.Films.OrderBy(film => film.episode_id).ToList();
            return View(model);
        }

        // POST: Species/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,classification,designation,average_height,skin_colors,hair_colors,eye_colors,average_lifespan,homeworld,language,people,films,created,edited,url")] SpeciesModel speciesModel, string SelectedHomeworld, List<string> selectedFilms, List<string> selectedCharacters)
        {
            if (ModelState.IsValid)
            {
                speciesModel.homeworld = SelectedHomeworld;
                speciesModel.films = selectedFilms;
                speciesModel.people = selectedCharacters;
                _context.Add(speciesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(speciesModel);
        }

        // GET: Species/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciesModel = await _context.Species.FindAsync(id);
            if (speciesModel == null)
            {
                return NotFound();
            }

            speciesModel.HomeworldOptions = _context.Planets.OrderBy(planet => planet.name).ToList();
            speciesModel.CharacterOptions = _context.People.OrderBy(person => person.name).ToList();
            speciesModel.FilmOptions = _context.Films.OrderBy(film => film.episode_id).ToList();

            return View(speciesModel);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,classification,designation,average_height,skin_colors,hair_colors,eye_colors,average_lifespan,homeworld,language,people,films,created,edited,url")] SpeciesModel speciesModel, string SelectedHomeworld, List<string> selectedFilms, List<string> selectedCharacters)
        {
            if (id != speciesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    speciesModel.homeworld = SelectedHomeworld;
                    speciesModel.films = selectedFilms;
                    speciesModel.people = selectedCharacters;
                    _context.Update(speciesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeciesModelExists(speciesModel.Id))
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
            return View(speciesModel);
        }

        // GET: Species/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciesModel = await _context.Species
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speciesModel == null)
            {
                return NotFound();
            }

            speciesModel.HomeworldLink = LinkHelper.GetPlanetLink(_context.Planets.FirstOrDefault(planet => planet.url == speciesModel.homeworld));
            speciesModel.FilmLinks = LinkHelper.GetFilmLinks(_context.Films.Where(film => speciesModel.films.Contains(film.url)).ToList());
            speciesModel.CharacterLinks = LinkHelper.GetPersonLinks(_context.People.Where(pilot => speciesModel.people.Contains(pilot.url)).ToList());

            return View(speciesModel);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speciesModel = await _context.Species.FindAsync(id);
            if (speciesModel != null)
            {
                _context.Species.Remove(speciesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeciesModelExists(int id)
        {
            return _context.Species.Any(e => e.Id == id);
        }
    }
}
