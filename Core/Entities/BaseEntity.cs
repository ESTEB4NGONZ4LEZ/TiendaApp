
namespace Core.Entities;
// * ----- Clase base para las Entidades -----
// Esta clase esta con el proposito de poder asignar el ID a todas nuestras entidades con el objetivo de optimizar el codigo y evitar la repeticion del mismo
public class BaseEntity
{
    public int Id { get; set; }
}
