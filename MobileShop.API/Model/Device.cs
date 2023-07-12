namespace MobileShop.API.Model
{
    public class Device
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Ram { get; set; }
        public int Rom { get; set; }
        public int Price { get; set; }
    }
}
