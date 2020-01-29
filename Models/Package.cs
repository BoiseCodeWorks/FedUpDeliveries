namespace FedUp.Models
{
    class Package
    {
        public Package(string destinationCode, int value)
        {
            DestinationCode = destinationCode;
            Value = value;
        }

        public string DestinationCode { get; set; }
        public int Value { get; set; }
    }
}