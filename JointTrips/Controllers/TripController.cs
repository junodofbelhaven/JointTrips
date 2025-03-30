using JointTrips.Data;
using JointTrips.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JointTrips.Controllers
{
    [Authorize]
    public class TripController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TripController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var trips = await _context.Trips
                .Include(t => t.Owner)
                .Include(t => t.Participants)
                .ToListAsync();

            return View(trips);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trip trip)
        {

            ModelState.Remove("OwnerId");
            ModelState.Remove("Owner");

            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                trip.OwnerId = currentUser.Id;
                trip.Owner = currentUser;
                _context.Trips.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trip);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var trip = await _context.Trips
                .Include(t => t.Owner)
                .Include(t => t.Participants)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Join(int id)
        {
            var trip = await _context.Trips
                .Include(t => t.Participants)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trip == null || trip.Participants.Count >= trip.Capacity)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);

            if (!trip.Participants.Any(p => p.Id == user.Id))
            {
                trip.Participants.Add(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Leave(int id)
        {
            var trip = await _context.Trips
                .Include(t => t.Participants)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trip == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);

            if (trip.Participants.Any(p => p.Id == user.Id))
            {
                trip.Participants.Remove(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var trip = await _context.Trips.FindAsync(id);

            var user = await _userManager.GetUserAsync(User);

            if (trip == null || trip.OwnerId != user.Id)
                return Unauthorized();

            return View(trip);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Trip trip)
        {
            if (id != trip.Id)
                return NotFound();

            ModelState.Remove("OwnerId");
            ModelState.Remove("Owner");

            var user = await _userManager.GetUserAsync(User);
            var existingTrip = await _context.Trips.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

            if (existingTrip == null || existingTrip.OwnerId != user.Id)
                return Unauthorized();

            if (ModelState.IsValid)
            {
                trip.OwnerId = existingTrip.OwnerId; 
                _context.Update(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = trip.Id });
            }

            return View(trip);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var trip = await _context.Trips
                .Include(t => t.Owner)
                .FirstOrDefaultAsync(t => t.Id == id);

            var user = await _userManager.GetUserAsync(User);
            if (trip == null || trip.OwnerId != user.Id)
                return Unauthorized();

            return View(trip);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trips.FindAsync(id);

            var user = await _userManager.GetUserAsync(User);
            if (trip == null || trip.OwnerId != user.Id)
                return Unauthorized();

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
