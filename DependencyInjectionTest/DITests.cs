using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using DependencyInjection.Models;
using DependencyInjection.Controllers;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Infrastructure;

namespace DependencyInjectionTest
{
    public class DITests
    {
        [Fact]
        public void ControllerTest()
        {
            //Arrange
            var data = new[] { new Product { Name="Test", Price=100 } };
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(data);
            //TypeBroker.SetTestObject(mock.Object);
            HomeController controller = new HomeController(mock.Object);

            //Act
            ViewResult result = controller.Index();
            //Assert
            Assert.Equal(data, result.ViewData.Model);
            
        }
    }
}
