namespace Consume_API_in_MVC_App.Models
{
    public class Product
    {
        public int product_id { get; set; }

        public string product_name { get; set; } = null!;

        public int brand_id { get; set; }

        public int category_id { get; set; }

        public short model_year { get; set; }

        public decimal list_price { get; set; }
    }
}
