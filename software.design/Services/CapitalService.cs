using Microsoft.EntityFrameworkCore;
using Software.Design.DataModels;
using Software.Design.Models;

namespace Software.Design.Services;

public class CapitalService
{
    private readonly CapitalContext _dbContext;

    public CapitalService(CapitalContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Capital>> GetCapitals()
    {
        var capitals = await _dbContext.Capitals.ToListAsync();
        return capitals;
    }

    public async Task<Capital> Create(CapitalDTO capitalDTO)
    {
        var capital = new Capital(capitalDTO);

        await _dbContext.Capitals.AddAsync(capital);
        await _dbContext.SaveChangesAsync();
        return capital;
    }
}