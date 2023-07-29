
namespace API.Dto;

public class FacturaDto
{
    public DateTime Fecha { get; set; }
    public int Id_cliente { get; set; }
    public List<VentaDto>? Ventas { get; set; }
}
