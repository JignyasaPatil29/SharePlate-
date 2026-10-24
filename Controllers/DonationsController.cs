
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharePlate.Data;
using SharePlate.Models;

namespace SharePlate.Controllers;

public class DonationsController : Controller
{
    private readonly ApplicationDbContext _context;

    public DonationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? status)
    {
        if (status != null)
        {
            HttpContext.Session.SetString("DonationStatus", status);
        }
        else
        {
            status = HttpContext.Session.GetString("DonationStatus");
        }

        var query = _context.Donations.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(status) &&
            status != "All")
        {
            query = query.Where(d => d.Status == status);
        }

        ViewBag.SelectedStatus = status ?? "All";

        return View(await query
            .OrderByDescending(d => d.CreatedAt)
            .ToListAsync());
    }

    public IActionResult Create()
    {
        return View(new Donation
        {
            PickupDeadline = DateTime.Now.AddHours(2),
            Status = "Available"
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Donation donation)
    {
        if (donation.PickupDeadline <= DateTime.Now)
        {
            ModelState.AddModelError(
                nameof(donation.PickupDeadline),
                "Pickup deadline must be in the future.");
        }

        if (!ModelState.IsValid)
            return View(donation);

        donation.CreatedAt = DateTime.UtcNow;
        _context.Donations.Add(donation);
        await _context.SaveChangesAsync();

        TempData["Success"] = "Donation added successfully!";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var donation = await _context.Donations
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);

        if (donation == null) return NotFound();

        return View(donation);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var donation = await _context.Donations.FindAsync(id);
        if (donation == null) return NotFound();

        return View(donation);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id, Donation donation)
    {
        if (id != donation.Id) return NotFound();

        if (donation.PickupDeadline <= DateTime.Now)
        {
            ModelState.AddModelError(
                nameof(donation.PickupDeadline),
                "Pickup deadline must be in the future.");
        }

        if (!ModelState.IsValid)
            return View(donation);

        var existing = await _context.Donations.FindAsync(id);
        if (existing == null) return NotFound();

        existing.FoodName = donation.FoodName;
        existing.Quantity = donation.Quantity;
        existing.DonorName = donation.DonorName;
        existing.PickupLocation = donation.PickupLocation;
        existing.PickupDeadline = donation.PickupDeadline;
        existing.Status = donation.Status;
        existing.Description = donation.Description;

        await _context.SaveChangesAsync();

        TempData["Success"] = "Donation updated successfully!";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var donation = await _context.Donations
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);

        if (donation == null) return NotFound();

        return View(donation);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var donation = await _context.Donations.FindAsync(id);

        if (donation == null) return NotFound();

        _context.Donations.Remove(donation);
        await _context.SaveChangesAsync();

        TempData["Success"] = "Donation deleted successfully!";
        return RedirectToAction(nameof(Index));
    }
}
