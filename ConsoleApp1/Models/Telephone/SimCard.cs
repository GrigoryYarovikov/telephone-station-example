namespace ConsoleApp1.Models
{
    internal class SimCard
    {
        private readonly string _id; // sim card uid
        private readonly string _number; // tel number

        public SimCard(string id, string number)
        {
            _id = id;
            _number = number;
        }

        public string Number { get { return _number; } }
        public string Id { get { return _id; } }
    }
}
