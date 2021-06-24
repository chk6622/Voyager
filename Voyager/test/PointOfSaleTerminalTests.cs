using System.Collections.Generic;
using Voyager.model;
using Voyager.service;
using Voyager.service.impl;
using Xunit;

namespace Voyager.test
{
    public class PointOfSaleTerminalTests
    {
        IPointOfSaleTerminal pointOfSaleTerminal;

        public PointOfSaleTerminalTests()
        {
            var productAPrice = new ProductPrice("A", 1.25m, 3, 3.0m);
            var productBPrice = new ProductPrice("B", 4.25m, 0, 0.0m);
            var productCPrice = new ProductPrice("C", 1.0m, 6, 5.0m);
            var productDPrice = new ProductPrice("D", 0.75m, 0, 0.0m);

            pointOfSaleTerminal = new PointOfSaleTerminal();
            pointOfSaleTerminal.SetPrice(new List<ProductPrice>() { productAPrice, productBPrice, productCPrice, productDPrice });  //set product prices
        }

        [Theory]
        [InlineData("A", 1.25)]
        [InlineData("B", 4.25)]
        [InlineData("C", 1)]
        [InlineData("D", 0.75)]
        [InlineData("E", 0)]
        [InlineData("", 0)]
        [InlineData(null, 0)]
        public void ShouldHandleOneProduct(string product, decimal expectPrice)
        {
            pointOfSaleTerminal.ScanProduct(product);
            Assert.Equal(expectPrice, pointOfSaleTerminal.CalculateTotal());
        }

        [Theory]
        [InlineData("A,B", 5.5)]
        [InlineData("A,B,C", 6.5)]
        [InlineData("A,B,C,D", 7.25)]
        [InlineData("A,B,C,D,E", 7.25)]
        public void ShouldHandleUnitPrice(string products, decimal expectPrice)
        {
            string[] productArray = products.Split(',');
            foreach(var product in productArray)
            {
                pointOfSaleTerminal.ScanProduct(product);
            }
            Assert.Equal(expectPrice, pointOfSaleTerminal.CalculateTotal());
        }

        [Theory]
        [InlineData("A,A,A,A", 4.25)]
        [InlineData("C,C,C,C,C,C,C", 6)]
        [InlineData("C,C,A,C,C,A,C,C,A,C,A", 10.25)]
        public void ShouldHandleBulkPrice(string products, decimal expectPrice)
        {
            string[] productArray = products.Split(',');
            foreach (var product in productArray)
            {
                pointOfSaleTerminal.ScanProduct(product);
            }
            Assert.Equal(expectPrice, pointOfSaleTerminal.CalculateTotal());
        }
    }
}
