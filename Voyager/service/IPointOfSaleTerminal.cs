using System.Collections.Generic;
using Voyager.model;

namespace Voyager.service
{
    /// <summary>
    /// Point Of Sale Terminal interface
    /// </summary>
    interface IPointOfSaleTerminal
    {
        /// <summary>
        /// Add the product price list to the terminal
        /// </summary>
        /// <param name="productPrices">product prices list</param>
        void SetPrice(List<ProductPrice> productPrices);

        /// <summary>
        /// Scan product to the terminal
        /// </summary>
        /// <param name="productCode">the product code</param>
        void ScanProduct(string productCode);

        /// <summary>
        /// Calculate the total price
        /// </summary>
        /// <returns></returns>
        decimal CalculateTotal();

        /// <summary>
        /// Clear all products in the terminal
        /// </summary>
        void ClearProducts();
    }
}
