
namespace API.Dto;

public class ClienteDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    // * ICollection
    public List<FacturaDto>? Facturas { get; set; }
}
