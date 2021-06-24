using System;
using System.Collections.Generic;
using Voyager.model;
using Voyager.service;
using Voyager.service.impl;

namespace Voyager
{
    class Program
    {
        static void Main(string[] args)
        {
            var productAPrice = new ProductPrice("A", 1.25m, 3, 3.0m);
            var productBPrice = new ProductPrice("B", 4.25m, 0, 0.0m);
            var productCPrice = new ProductPrice("C", 1.0m, 6, 5.0m);
            var productDPrice = new ProductPrice("D", 0.75m, 0, 0.0m);
            IPointOfSaleTerminal pointOfSaleTerminal = new PointOfSaleTerminal();

            pointOfSaleTerminal.SetPrice(new List<ProductPrice>() { productAPrice, productBPrice, productCPrice, productDPrice });  //set product prices

            pointOfSaleTerminal.ScanProduct("A");
            pointOfSaleTerminal.ScanProduct("B");
            pointOfSaleTerminal.ScanProduct("C");
            pointOfSaleTerminal.ScanProduct("D");
            pointOfSaleTerminal.ScanProduct("A");
            pointOfSaleTerminal.ScanProduct("B");
            pointOfSaleTerminal.ScanProduct("A");

            Console.WriteLine($"The total price is {pointOfSaleTerminal.CalculateTotal()}");

            pointOfSaleTerminal.ClearProducts();

            pointOfSaleTerminal.ScanProduct("C");
            pointOfSaleTerminal.ScanProduct("C");
            pointOfSaleTerminal.ScanProduct("C");
            pointOfSaleTerminal.ScanProduct("C");
            pointOfSaleTerminal.ScanProduct("C");
            pointOfSaleTerminal.ScanProduct("C");
            pointOfSaleTerminal.ScanProduct("C");

            Console.WriteLine($"The total price is {pointOfSaleTerminal.CalculateTotal()}");

            pointOfSaleTerminal.ClearProducts();

            pointOfSaleTerminal.ScanProduct("A");
            pointOfSaleTerminal.ScanProduct("B");
            pointOfSaleTerminal.ScanProduct("C");
            pointOfSaleTerminal.ScanProduct("D");

            Console.WriteLine($"The total price is {pointOfSaleTerminal.CalculateTotal()}");
        }
    }
}
