using Microsoft.AspNetCore.Mvc;
using PaginaWebPrueba.Models; // Asegúrate de tener esta línea
using System.Diagnostics;

namespace PaginaWebPrueba.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Creamos la lista de productos aquí mismo
            var listaProductos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Leche Entera", Categoria = "Lácteos", Precio = 1.50m },
                new Producto { Id = 2, Nombre = "Pan Integral", Categoria = "Panadería", Precio = 2.10m },
                new Producto { Id = 3, Nombre = "Arroz 1kg", Categoria = "Abarrotes", Precio = 2.00m }
                // ... añade los demás aquí
            };

            // ¡ESTO ES LO QUE TE DABA EL ERROR! 
            // Debes pasar la lista a la vista:
            return View(listaProductos);
        }

        // Este método es para el Autocomplete que pediste antes
        [HttpGet]
        public JsonResult BuscarProductos(string term)
        {
            // Aquí deberías tener la misma lista para buscar, 
            // o una simulación rápida:
            var nombres = new[] { "Leche Entera", "Pan Integral", "Arroz 1kg" };
            var filtrados = nombres.Where(n => n.Contains(term, StringComparison.OrdinalIgnoreCase));
            return Json(filtrados);
        }
    }
}