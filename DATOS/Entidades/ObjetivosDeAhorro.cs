using System.ComponentModel.DataAnnotations;

namespace DATOS.Entidades
{
    public class ObjetivosDeAhorro
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }


        public ICollection<Ahorros> Ahorros { get; set; }
    }
}
