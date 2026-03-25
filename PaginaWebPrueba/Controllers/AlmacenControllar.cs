using Microsoft.AspNetCore.Mvc;
using PaginaWebPrueba.Models;

namespace PaginaWebPrueba.Controllers
{
    public class AlmacenController : Controller
    {
        // Simulamos una base de datos de supermercado
        private static List<Producto> _productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Leche Entera", Categoria = "Lácteos", Precio = 1.50m },
            new Producto { Id = 2, Nombre = "Leche Deslactosada", Categoria = "Lácteos", Precio = 1.70m },
            new Producto { Id = 3, Nombre = "Pan Integral", Categoria = "Panadería", Precio = 2.10m },
            new Producto { Id = 4, Nombre = "Pan Blanco", Categoria = "Panadería", Precio = 1.80m },
            new Producto { Id = 5, Nombre = "Detergente en Polvo", Categoria = "Limpieza", Precio = 5.40m },
            new Producto { Id = 6, Nombre = "Detergente Líquido", Categoria = "Limpieza", Precio = 6.20m }
        };

        public IActionResult Index() => View(_productos);

        // Endpoint para el Autocomplete
        [HttpGet]
        public JsonResult BuscarProductos(string term)
        {
            var sugerencias = _productos
                .Where(p => p.Nombre.Contains(term, StringComparison.OrdinalIgnoreCase))
                .Select(p => p.Nombre)
                .ToList();
            return Json(sugerencias);
        }
    }
}