namespace Restaurant.Application.UseCases.Shops.Queries.GetAllShops
{
    public class GetAllShopsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string LocalGovernmentArea { get; set; }
        public string Address { get; set; }
    }
}