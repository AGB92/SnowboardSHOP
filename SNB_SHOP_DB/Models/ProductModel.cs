namespace SNB_SHOP_DB.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Product_Type1 { get; set; }
        public string Product_Type2 { get; set; }
        public string Sex { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
    }
}
