using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProyectoClientes.VistaWeb.Models;

namespace ProyectoClientes.VistaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ProyectoClientesContext _dbcontext;

        public ClienteController(ProyectoClientesContext dbcontext)
        {
            _dbcontext = dbcontext; 
        }

        [HttpGet]
        [Route("Listado")]
        public async Task<IActionResult> Listado()
        {
            List<Cliente> lista = await _dbcontext.Clientes.OrderByDescending(cliente => cliente.IdCliente).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody] Cliente cliente)
        {
            await _dbcontext.Clientes.AddAsync(cliente);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created, "Cliente ingresado");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Cliente cliente)
        {
            _dbcontext.Clientes.Update(cliente);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "Cliente actualizado");
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Cliente cliente = _dbcontext.Clientes.Find(id);
            _dbcontext.Clientes.Remove(cliente);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "Cliente actualizado");
        }
    }
}
