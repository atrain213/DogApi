using System.Text.Json;

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

        public string Bio { get; set; } = string.Empty;

        public List<APIContact> Owners { get; set; } = new();
        public List<APIContact> Trainers { get; set; } = new();
    }

    public class APIDogBreeds
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class DTOData
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual string JsonText()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public class DTODog : DTOData
    {
        public int BreedID { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsMale { get; set; }

        public int Weight { get; set; }

        public int PhotoID { get; set; }
        public string Bio { get; set; } = string.Empty;

        public override string JsonText()
        {
            return JsonSerializer.Serialize(this);
        }

    }

}
