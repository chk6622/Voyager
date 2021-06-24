using System.Collections.Generic;
using Voyager.model;

namespace Voyager.service.impl
{
    /// <summary>
    /// Point of Sale Terminal class
    /// </summary>
    class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private Dictionary<string, ProductPrice> productPriceDic = new Dictionary<string, ProductPrice>();
        private Dictionary<string, int> productDic = new Dictionary<string, int>();

        public decimal CalculateTotal()
        {
            decimal totalPrice = 0m;
            foreach(var product in productDic)
            {
                string productCode = product.Key;
                int productCount = product.Value;
                if (productPriceDic.ContainsKey(productCode))
                {
                    ProductPrice productPrice = productPriceDic[productCode];
                    int bulkSize = productPrice.BulkSize;
                    if (bulkSize > productCount || bulkSize == 0)   //if the number of the product is less than the size of the bulk, then the price of the product is to multiply the number of product by the unit price of the product.
                    {
                        totalPrice += productCount * productPrice.UnitPrice;
                    }
                    else  //if the number of the product is more than the size of the bulk, then the total price of the product is the total price of the bulk product adding the total unit price of the rest products
                    {
                        int bulkCount = productCount / bulkSize;  //get the number of bulks
                        int othersCount = productCount % bulkSize;  //get the number of the rest of the products
                        totalPrice += bulkCount * productPrice.BulkPrice + othersCount * productPrice.UnitPrice;
                    }
                }
            }
            return totalPrice;
        }

        public void ClearProducts()
        {
            productDic.Clear();
        }

        public void ScanProduct(string productCode)
        {
            if (!string.IsNullOrWhiteSpace(productCode))
            {
                if (productDic.ContainsKey(productCode))
                {
                    productDic.TryGetValue(productCode, out int count);
                    productDic[productCode] = count + 1;
                }
                else
                {
                    productDic[productCode] = 1;
                }
            }
        }

        public void SetPrice(List<ProductPrice> productPrices)
        {
            if (productPrices != null)
            {
                foreach(var productPrice in productPrices)  //map product prices
                {
                    productPriceDic.Add(productPrice.Code, productPrice);
                }
            }
        }
    }
}
