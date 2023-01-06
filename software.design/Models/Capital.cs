namespace Software.Design.Models;

public class Capital
{
    public Capital()
    {
    }

    public Capital(CapitalDTO capitalDTO)
    {
        Id = Guid.NewGuid();
        Area = null;
        Language = null;
        Name = capitalDTO.Name;
        Country = capitalDTO.Country;
        Population = capitalDTO.Population;
    }

    public Guid Id { get; private set; }
    public int Area { get; private set; }
    public string Language { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string Quantity { get; private set; } = default!;
    public string ManufacturerId { get; private set; } = default!;
}