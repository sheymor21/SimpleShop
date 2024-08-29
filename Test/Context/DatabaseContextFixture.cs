using Microsoft.EntityFrameworkCore;
using SimpleShop.Context;

namespace Test.Context;

public class DatabaseContextFixture
{
    private readonly DatabaseContext _context;
    public DatabaseContext Context => _context;

    public DatabaseContextFixture()
    {
        var builder = new DbContextOptionsBuilder<DatabaseContext>();
        var options = builder.UseSqlite("Data Source=Test.db").Options;
        _context = new DatabaseContext(options);
        DbConnection.TestOption = true;
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }
}