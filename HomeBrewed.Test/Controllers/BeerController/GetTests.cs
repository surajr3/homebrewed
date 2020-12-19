using System;
using Xunit;
using HomeBrewed.Controllers;
using HomeBrewed.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace HomeBrewed.Test.Controllers.BeerController
{
    public class GetTests
    {
        [Fact]
        public void GetThreeBeersDefault()
        {
            // Arrange
            var controller = new HomeBrewed.Controllers.BeerController(null);

            // Act
            ActionResult<IEnumerable<Beer>> result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Value.Count());
            Assert.Equal("American Lager", result.Value.ElementAt(0).Name);
            Assert.Equal("German Helles", result.Value.ElementAt(1).Name);
            Assert.Equal("German Pilsner", result.Value.ElementAt(2).Name);
        }
    }
}
