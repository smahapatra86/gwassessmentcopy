namespace Domain.ValueObjects
{
    public class Address
    {
        public string Area { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int HouseNo { get; set; }
        public long Pin { get; set; }
    }
}
