using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using creditcardcreation.Data;
using creditcardcreation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace creditcardcreation.Controllers
{
    [ApiController]
    [Route("api/v1/creditcards")]
    public class CreditCardController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<CreditCard>>> Get([FromServices] DataContext context)
        {
            var creditcards = await context.CreditCards.ToListAsync();
            return creditcards;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<CreditCard>>> Post(
            [FromServices] DataContext context,
            [FromBody]Client model)
        {
            context.Clients.Add(model);
            await context.SaveChangesAsync();
            Random rnd = new Random();
            int ccGroupOne = rnd.Next(4572, 9999);
            int ccGroupTwo = rnd.Next(1000, 9999);
            int ccGroupThree = rnd.Next(1000, 9999);
            int ccGroupFour = rnd.Next(1000, 9999);
            int secCode = rnd.Next(100, 999);
            int expMonth = rnd.Next(01, 12);
            int expYear = rnd.Next(2023, 2027);
            string ccNumber = ccGroupOne.ToString() + " "
                          + ccGroupTwo.ToString() + " "
                          + ccGroupThree.ToString() + " "
                          + ccGroupFour.ToString();
            string expiration = expMonth.ToString() + "/" + expYear.ToString();
            CreditCard creditCard = new CreditCard(ccNumber, expiration, secCode);
            context.CreditCards.Add(creditCard);
            await context.SaveChangesAsync();
            var creditcards = await context.CreditCards.ToListAsync();
            return creditcards;
        }
    }
}