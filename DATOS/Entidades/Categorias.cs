using System.ComponentModel.DataAnnotations;

namespace DATOS.Entidades
{
    public class Categorias
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }


        public ICollection<Movimientos> Movimientos { get; set; }
    }
}
