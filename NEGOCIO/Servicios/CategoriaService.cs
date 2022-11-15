using DATOS.Context;
using DATOS.Entidades;

namespace NEGOCIO.Servicios
{
    public class CategoriaService
    {
        private MisGastosDbContext _misGastosDbContext;

        public CategoriaService(MisGastosDbContext misGastosDbContext)
        {
            _misGastosDbContext = misGastosDbContext;
        }

        public void CrearCategoria(Categorias categoria)
        {
            _misGastosDbContext.Categorias.Add(categoria);
            _misGastosDbContext.SaveChanges();
        }

        public List<Categorias> GetAll(string? nombre)
        {
            return _misGastosDbContext.Categorias.Where(x =>
                string.IsNullOrEmpty(nombre) || x.Nombre.ToLower().Contains(nombre.ToLower())
            ).OrderBy(x => x.Nombre)
            .Take(30)
            .ToList();
        }

        public Categorias GetOne(int id)
        {
            var categoria = _misGastosDbContext.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                throw new Exception("No encontrado");
            }
            return categoria;
        }

        public void Delete(int id)
        {
            var categoria = GetOne(id);
            _misGastosDbContext.Categorias.Remove(categoria);
            _misGastosDbContext.SaveChanges();
        }

        public Categorias Update(Categorias data)
        {
            GetOne(data.Id);
            _misGastosDbContext.Update(data);
            _misGastosDbContext.SaveChanges();
            return data;
        }
    }
}
