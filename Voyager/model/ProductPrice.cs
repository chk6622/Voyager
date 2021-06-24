namespace Voyager.model
{
    /// <summary>
    /// Product price class
    /// </summary>
    class ProductPrice
    {
        public ProductPrice(string code, decimal unitPrice,int bulkSize, decimal bulkPrice) {
            Code = code;
            UnitPrice = unitPrice;
            BulkSize = bulkSize;
            BulkPrice = bulkPrice;
        }

        public string Code { set; get; }    //product code
        public decimal UnitPrice { set; get; }  //product unit price
        public int BulkSize { set; get; }  //product bulk count
        public decimal BulkPrice { set; get; }  //product bulk price

    }
}
