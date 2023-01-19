using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCRUD.Models;

namespace DotNetCRUD.Services;

public interface ICapitalService
{
    Task<bool> CreateCapital(Capital capital);
    Task<Capital> GetCapital(int id);
    Task<List<Capital>> GetCapitalList();
    Task<Capital> UpdateCapital(Capital capital);
    Task<bool> DeleteCapital(int key);

}