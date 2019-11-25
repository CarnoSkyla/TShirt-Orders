using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TShirtAPI.Data;
using TShirtAPI.Models;
using TShirtOrders;

namespace ContosoPets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class tshirtController : ControllerBase
    {
        private readonly TshirtContext _context;

        public tshirtController(TshirtContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<tshirt>> GetAll() =>
            _context.TSHIRTS.ToList();

        // GET by ID action

        // POST action


        [HttpPost]
        public async Task<ActionResult<tshirt>> Create(tshirt[] products)
        {

           for(int index = 0; index < products.Length; index++)
            {
                if(products[index].Status == true)
                {
                    _context.TSHIRTS.Add(products[index]);
                    await _context.SaveChangesAsync();

                }
            }
                    

             return Ok();
        }

        // PUT action

        // DELETE action
    }
}
