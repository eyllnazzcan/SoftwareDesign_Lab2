using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace DotNetCRUD.Models;

public class Capital
{
    public Capital(CapitalDTO capitalDTO)
    {
        Id = Guid.NewGuid();
        Area = 0;
        Language = null;
        Name = capitalDTO.Name;
        Country = capitalDTO.Country;
        Population = capitalDTO.Population;
    }

    public Guid Id { get; private set; }
    public int Area { get; private set; }
    public string Language { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string Country { get; private set; } = default!;
    public int Population { get; private set; }

}