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
        public string Name { get; set; } = string.Empty;

        public string Breed { get; set; } = string.Empty;

        public DateTime Birthday { get; set; } = new(2020, 1, 1);

        public string Sex { get; set; } = "Male";

        public int Weight { get; set; }

        public string Bio { get; set; } = string.Empty;

        public string Photo { get; set; } = "00000000-0000-0000-0000-000000000000.png";
        public int PhotoID { get; set; } = 1;

        public List<APIContact> Owners { get; set; } = new();
        public List<APIContact> Trainers { get; set; } = new();
    }

    public class APIDogBreeds
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public override string ToString()
        {
            return Name;
        }
    }

    public class APIPicture
    {

        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid unique_ID { get; set; }
        public int type_ID { get; set; }

        public string FileName()
        {
            return unique_ID.ToString() + (type_ID == 1 ? ".png" : ".jpg");
        }

    }

    public class APITrick
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string IconFileName { get; set; } = "11111111-1111-1111-1111-111111111111.png";
        public string Color {  get; set; } = "FFFFFFFF";
        public double Proficiency { get; set; }
    }




    public class APITraining
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int Repetitions { get; set; }
        public int ProficiencyCount { get; set; }
        public string Comment { get; set; } = string.Empty;
    }


    public class APITrickDetail : APITrick
    {
        public List<APITraining> Trainings { get; set; } = new();
        public string VerbalCue { get; set; } = string.Empty;
        public string VisualCue { get; set; } = string.Empty;
        public string VerbalRelease { get; set; } = string.Empty;
        public string VisualRelease { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
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

    public class DTOPicture : DTOData
    {
        public int type_ID { get; set; }

        public override string JsonText()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}
