using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCRUD.Models;

namespace DotNetCRUD.Services;

public class CapitalService : ICapitalService
{
    private readonly IDbService _dbService;

    public CapitalService(IDbService dbService)
    {
        _dbService = dbService;
    }

    public async Task<bool> CreateCapital(Capital capital)
    {
        var result =
            await _dbService.EditData(
                "INSERT INTO public.capital (id,area, language, name, country, population) VALUES (@Id, @Area, @Language, @Name, @Country, @Population)",
                capital);
        return true;
    }

    public async Task<List<Capital>> GetCapitalList()
    {
        var capitalList = await _dbService.GetAll<Capital>("SELECT * FROM public.capital", new { });
        return capitalList;
    }


    public async Task<Capital> GetCapital(int id)
    {
        var capitalList = await _dbService.GetAsync<Capital>("SELECT * FROM public.capital where id=@id", new { id });
        return capitalList;
    }

    public async Task<Capital> UpdatePlaylist(Capital capital)
    {
        var updateCapital =
            await _dbService.EditData(
                "Update public.capital SET area =@Area, language=@Language, name=@Name, country=@Country, population=@Population WHERE id=@Id",
                capital);
        return capital;
    }

    public async Task<bool> DeleteCapital(int id)
    {
        var deleteCapital = await _dbService.EditData("DELETE FROM public.capital WHERE id=@Id", new { id });
        return true;
    }

    public Task<Capital> UpdateCapital(Capital capital)
    {
        throw new NotImplementedException();
    }
}