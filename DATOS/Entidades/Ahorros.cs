using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATOS.Entidades
{
    public class Ahorros
    {
        [Key]
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int IdMovimiento { get; set; }


        [ForeignKey(nameof(IdMovimiento))]
        public Movimientos Movimiento { get; set; }
    }
}
