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
    public class FilmController : Controller
    {
        private readonly DataContext _context;

        public FilmController(DataContext context)
        {
            _context = context;
        }

        // GET: Film
        public async Task<IActionResult> Index()
        {
            List<FilmModel> films = await _context.Films.ToListAsync();
            return View(films.OrderBy(film => film.episode_id));
        }

        // GET: Film/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmModel = await _context.Films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmModel == null)
            {
                return NotFound();
            }

            filmModel.CharacterLinks = LinkHelper.GetPersonLinks(_context.People.Where(character => filmModel.characters.Contains(character.url)).ToList());
            filmModel.PlanetLinks = LinkHelper.GetPlanetLinks(_context.Planets.Where(planet => filmModel.planets.Contains(planet.url)).ToList());
            filmModel.StarShipLinks = LinkHelper.GetStarShipLinks(_context.StarShips.Where(starship => filmModel.starships.Contains(starship.url)).ToList());
            filmModel.VehicleLinks = LinkHelper.GetVehicleLinks(_context.Vehicles.Where(vehicle => filmModel.vehicles.Contains(vehicle.url)).ToList());
            filmModel.SpeciesLinks = LinkHelper.GetSpeciesLinks(_context.Species.Where(species => filmModel.species.Contains(species.url)).ToList());

            return View(filmModel);
        }

        // GET: Film/Create
        public IActionResult Create()
        {
            FilmModel filmModel = new FilmModel();  
            filmModel.CharacterOptions = _context.People.OrderBy(person => person.name).ToList();
            filmModel.PlanetOptions = _context.Planets.OrderBy(planet => planet.name).ToList();
            filmModel.StarShipOptions = _context.StarShips.OrderBy(starShip => starShip.name).ToList();
            filmModel.VehicleOptions = _context.Vehicles.OrderBy(vehicles => vehicles.name).ToList();
            filmModel.SpeciesOptions = _context.Species.OrderBy(species => species.name).ToList();

            return View(filmModel);
        }

        // POST: Film/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,title,episode_id,opening_crawl,director,producer,release_date,characters,planets,starships,vehicles,species,created,edited,url")] FilmModel filmModel, List<string> selectedCharacters, List<string> selectedPlanets, List<string> selectedStarShips, List<string> selectedVehicles, List<string> selectedSpecies)
        {
            if (ModelState.IsValid)
            {
                filmModel.characters = selectedCharacters;
                filmModel.planets = selectedPlanets;
                filmModel.starships = selectedStarShips;
                filmModel.vehicles = selectedVehicles;
                filmModel.species = selectedSpecies;
                _context.Add(filmModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmModel);
        }

        // GET: Film/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmModel = await _context.Films.FindAsync(id);
            if (filmModel == null)
            {
                return NotFound();
            }

            filmModel.CharacterOptions = _context.People.OrderBy(person => person.name).ToList();
            filmModel.PlanetOptions = _context.Planets.OrderBy(planet => planet.name).ToList();
            filmModel.StarShipOptions = _context.StarShips.OrderBy(starShip => starShip.name).ToList();
            filmModel.VehicleOptions = _context.Vehicles.OrderBy(vehicles => vehicles.name).ToList();
            filmModel.SpeciesOptions = _context.Species.OrderBy(species => species.name).ToList();

            return View(filmModel);
        }

        // POST: Film/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,title,episode_id,opening_crawl,director,producer,release_date,characters,planets,starships,vehicles,species,created,edited,url")] FilmModel filmModel, List<string> selectedCharacters, List<string> selectedPlanets, List<string> selectedStarShips, List<string> selectedVehicles, List<string> selectedSpecies)
        {
            if (id != filmModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    filmModel.characters = selectedCharacters;
                    filmModel.planets = selectedPlanets;
                    filmModel.starships = selectedStarShips;
                    filmModel.vehicles = selectedVehicles;
                    filmModel.species = selectedSpecies;
                    _context.Update(filmModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmModelExists(filmModel.Id))
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
            return View(filmModel);
        }

        // GET: Film/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmModel = await _context.Films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmModel == null)
            {
                return NotFound();
            }

            filmModel.CharacterLinks = LinkHelper.GetPersonLinks(_context.People.Where(character => filmModel.characters.Contains(character.url)).ToList());
            filmModel.PlanetLinks = LinkHelper.GetPlanetLinks(_context.Planets.Where(planet => filmModel.planets.Contains(planet.url)).ToList());
            filmModel.StarShipLinks = LinkHelper.GetStarShipLinks(_context.StarShips.Where(starship => filmModel.starships.Contains(starship.url)).ToList());
            filmModel.VehicleLinks = LinkHelper.GetVehicleLinks(_context.Vehicles.Where(vehicle => filmModel.vehicles.Contains(vehicle.url)).ToList());
            filmModel.SpeciesLinks = LinkHelper.GetSpeciesLinks(_context.Species.Where(species => filmModel.species.Contains(species.url)).ToList());

            return View(filmModel);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmModel = await _context.Films.FindAsync(id);
            if (filmModel != null)
            {
                _context.Films.Remove(filmModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmModelExists(int id)
        {
            return _context.Films.Any(e => e.Id == id);
        }
    }
}
