using Bageriet.Context;
using Bageriet.Controllers;
using Bageriet.Intefaces;
using Bageriet.Models;
using Bageriet.Repositories;
using Bageriet.ViewModels;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProjectBaggerTest
{
    public class ProjectTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            Products products = new Products(10, "Bröd", "Surdeg bröd", "baguette.png");

            // Act                
            var product = (products.Name == "Bröd");

            // Assert
            Assert.True(product);
        }

        [Fact]
        public void Test2()
        {
            //Arrange
            var contacts = new Contacts
            {
                Address = "TestGaten 01",
                Phone = "0501-3450809"
            };

            // Act 
            var phone = (contacts.Phone.IndexOf("0501") != -1);

            // Assert
            Assert.True(phone);
        }

        // Test bageri 3.0
        [Fact]
        public void Test3()
        {
            // Arange
            var comments = new Comments
            {
                Text = "Test kommentar"
            };

            // Act
            var past_time = comments.Date < DateTime.Now;

            // Assert
            Assert.True(past_time);
        }
    }
}
