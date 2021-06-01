using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using creditcardcreation.Data;
using creditcardcreation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace creditcardcreation.Controllers
{
    [ApiController]
    [Route("api/v1/clients")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        
        public async Task<ActionResult<List<Client>>> Get([FromServices] DataContext context)
        {
            var clients = await context.Clients.Include(x => x.CreditCard).ToListAsync();
            return clients;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Client>> GetById([FromServices] DataContext context, int id)
        {
            var client = await context.Clients.Include(x => x.CreditCard).FirstOrDefaultAsync(x => x.Id == id);
            return client;
        }

        [HttpGet]
        [Route("creditcards/{id:int}")]
        public async Task<ActionResult<List<Client>>> GetByCreditCard([FromServices] DataContext context, int id)
        {
            var clients = await context.Clients
                .Include(x => x.CreditCard)
                .AsNoTracking()
                .Where(x => x.CreditCardId == id)
                .ToListAsync();
            return clients;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Client>> Post(
            [FromServices] DataContext context,
            [FromBody]Client model)
        {
            context.Clients.Add(model);
            await context.SaveChangesAsync();
            return model;
        }
    }
}