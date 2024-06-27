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
    public class PeopleController : Controller
    {
        private readonly DataContext _context;

        public PeopleController(DataContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            return View(await _context.People.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People
                .FirstOrDefaultAsync(m => m.Id == id);
            if (people == null)
            {
                return NotFound();
            }

            people.HomeworldLink = LinkHelper.GetPlanetLink(_context.Planets.FirstOrDefault(planet => planet.url == people.homeworld));
            people.SpeciesLinks = LinkHelper.GetSpeciesLinks(_context.Species.Where(species => people.species.Contains(species.url)).ToList());
            people.StarShipLinks = LinkHelper.GetStarShipLinks(_context.StarShips.Where(starship => people.starships.Contains(starship.url)).ToList());
            people.VehicleLinks = LinkHelper.GetVehicleLinks(_context.Vehicles.Where(vehicle => people.vehicles.Contains(vehicle.url)).ToList());
            people.FilmLinks = LinkHelper.GetFilmLinks(_context.Films.Where(film => people.films.Contains(film.url)).ToList());

            return View(people);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            PeopleModel model = new PeopleModel();
            model.HomeworldOptions = _context.Planets.OrderBy(planet => planet.name).ToList();
            model.SpeciesOptions = _context.Species.OrderBy(species => species.name).ToList();
            model.StarShipOptions = _context.StarShips.OrderBy(starShip => starShip.name).ToList();
            model.VehicleOptions = _context.Vehicles.OrderBy(vehicles => vehicles.name).ToList();
            model.FilmOptions = _context.Films.OrderBy(film => film.episode_id).ToList();
            return View(model);
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,height,mass,hair_color,skin_color,eye_color,birth_year,gender,homeworld,films,species,vehicles,starships,created,edited,url")] PeopleModel people, string SelectedHomeworld, List<string> selectedFilms, List<string> selectedSpecies, List<string> selectedVehicles, List<string> selectedStarShips)
        {
            if (ModelState.IsValid)
            {
                people.homeworld = SelectedHomeworld;
                people.films = selectedFilms;
                people.species = selectedSpecies;
                people.starships = selectedStarShips;
                people.vehicles = selectedVehicles;

                _context.Add(people);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(people);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            people.HomeworldOptions = _context.Planets.OrderBy(planet => planet.name).ToList();
            people.SpeciesOptions = _context.Species.OrderBy(species => species.name).ToList();
            people.StarShipOptions = _context.StarShips.OrderBy(starShip => starShip.name).ToList();
            people.VehicleOptions = _context.Vehicles.OrderBy(vehicles => vehicles.name).ToList();
            people.FilmOptions = _context.Films.OrderBy(film => film.episode_id).ToList();

            return View(people);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,height,mass,hair_color,skin_color,eye_color,birth_year,gender,homeworld,films,species,vehicles,starships,created,edited,url")] PeopleModel people, string SelectedHomeworld, List<string> selectedFilms, List<string> selectedSpecies, List<string> selectedVehicles, List<string> selectedStarShips)
        {
            if (id != people.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    people.homeworld = SelectedHomeworld;
                    people.films = selectedFilms;
                    people.species = selectedSpecies;
                    people.starships = selectedStarShips;
                    people.vehicles = selectedVehicles;

                    _context.Update(people);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeopleExists(people.Id))
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
            return View(people);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People
                .FirstOrDefaultAsync(m => m.Id == id);
            if (people == null)
            {
                return NotFound();
            }

            people.HomeworldLink = LinkHelper.GetPlanetLink(_context.Planets.FirstOrDefault(planet => planet.url == people.homeworld));
            people.SpeciesLinks = LinkHelper.GetSpeciesLinks(_context.Species.Where(species => people.species.Contains(species.url)).ToList());
            people.StarShipLinks = LinkHelper.GetStarShipLinks(_context.StarShips.Where(starship => people.starships.Contains(starship.url)).ToList());
            people.VehicleLinks = LinkHelper.GetVehicleLinks(_context.Vehicles.Where(vehicle => people.vehicles.Contains(vehicle.url)).ToList());
            people.FilmLinks = LinkHelper.GetFilmLinks(_context.Films.Where(film => people.films.Contains(film.url)).ToList());

            return View(people);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var people = await _context.People.FindAsync(id);
            if (people != null)
            {
                _context.People.Remove(people);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeopleExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
