
using Microsoft.EntityFrameworkCore;
using SharePlate.Models;

namespace SharePlate.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Donation> Donations => Set<Donation>();
}
