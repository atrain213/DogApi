namespace DogApi
{
    public class APIContact
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class APIDog
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class APIDogDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }= string.Empty;

        public string Breed { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }

        public string Sex { get; set; } = string.Empty;

        public int Weight {  get; set; }

        public List<APIContact> Owners { get; set; } = new();
        public List<APIContact> Trainers { get; set; } = new();
    }
}
