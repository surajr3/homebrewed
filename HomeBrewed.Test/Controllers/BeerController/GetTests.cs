using System;
using Xunit;
using HomeBrewed.Controllers;
using HomeBrewed.Models;
using System.Collections.Generic;
using System.Linq;

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
            IEnumerable<Beer> result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Equal("American Lager", result.ElementAt(0).Name);
            Assert.Equal("German Helles", result.ElementAt(1).Name);
            Assert.Equal("German Pilsner", result.ElementAt(2).Name);
        }
    }
}
