namespace CoreAPIWeb.Models
{
    public class Common
    {
        public class Country
        {
            public int CountryId { get; set; }
            public string CountryName { get; set; }
            public string GeographyId { get; set; }
        }
        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string Language { get; set; }
        }
    }
}
