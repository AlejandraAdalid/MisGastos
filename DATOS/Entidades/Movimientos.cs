using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DATOS.Entidades
{
    public class Movimientos
    {
        [Key]
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public bool EsFijo { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdAhorro { get; set; }


        [ForeignKey(nameof(IdCategoria))]
        public Categorias? Categoria { get; set; }
        [ForeignKey(nameof(IdAhorro))]
        public Ahorros? Ahorro { get; set; }
    }
}
