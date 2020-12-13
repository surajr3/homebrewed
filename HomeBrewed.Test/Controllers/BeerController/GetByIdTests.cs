using HomeBrewed.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace HomeBrewed.Test.Controllers.BeerController
{
    public class GetByIdTests
    {
        [Fact]
        public void GetAmericanLagerFirst()
        {
            // Arrange
            var controller = new HomeBrewed.Controllers.BeerController(null);

            // Act
            ActionResult<Beer> result = controller.GetById(0);

            // Assert
            Assert.NotNull(result.Value);
            Assert.Equal("American Lager", result.Value.Name);
        }

        [Fact]
        public void GetNonExistentBeerNotFound()
        {
            // Arrange
            var controller = new HomeBrewed.Controllers.BeerController(null);

            // Act
            ActionResult<Beer> result = controller.GetById(5);

            // Assert
            Assert.Null(result.Value);
            Assert.Equal((int)HttpStatusCode.NotFound, ((NotFoundResult)result.Result).StatusCode);
        }
    }
}
