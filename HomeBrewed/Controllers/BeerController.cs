using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBrewed.Models;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using NSwag.Annotations;
using System.Net;

namespace HomeBrewed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [OpenApiTag("Beer", Description = "The beer resource.")]
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

        /// <summary>
        /// Fetch all beers.
        /// </summary>
        /// <response code="200">Successfully fetched all beers.</response>
        [ProducesResponseType(typeof(Beer[]), StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<Beer>> Get()
        {
            logger?.LogInformation(1, "Retrieved all beers");

            return beers;
        }

        /// <summary>
        /// Fetch a beer with a given ID.
        /// </summary>
        /// <param name="id">ID of the beer to be fetched.</param>
        /// <response code="200">Successfully fetched beer.</response>
        /// <response code="400">Beer ID invalid.</response>
        /// <response code="404">Beer ID does not exist.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Beer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public ActionResult<Beer> GetById([FromRoute]int id)
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
