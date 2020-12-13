using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrewed.Models;

namespace HomeBrewed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {
        private static readonly Beer[] beers = new Beer[] {
            new Beer(0, "American Lager"),
            new Beer(1, "German Helles"),
            new Beer(2, "German Pilsner"),
        };
        private readonly ILogger<BeerController> logger;

        public BeerController(ILogger<BeerController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Beer> Get()
        {
            logger?.LogInformation(1, "Retrieved all beers");

            return beers;
        }

        [HttpGet("{id}")]
        public ActionResult<Beer> GetById([FromRoute] int id)
        {

            var beer = beers.FirstOrDefault(b => b.Id == id);

            if (beer != null)
            {
                logger?.LogInformation(2, "Retrieved beer {beer.Id}", beer.Id);
                return beer;
            }
            else
            {
                logger?.LogWarning(3, "Beer not retrieved");
                return NotFound();
            }
        }
    }
}
