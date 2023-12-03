using System.Text.Json;

namespace DogApi
{
    public class APIData
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public override string ToString()
        {
            return Name;
        }
    }
    public class APIContact : APIData
    {
        public string FName { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string CSZ { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int OwnerID { get; set; }
        public int TrainerID { get; set; }
    }
    public class APIDog : APIData
    {

    }

    public class APIDogDetail : APIData
    {
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

    public class APIDogBreeds : APIData
    {
    }

    public class APIPicture : APIData
    {

        public Guid unique_ID { get; set; }
        public int type_ID { get; set; }

        public string FileName()
        {
            return unique_ID.ToString() + (type_ID == 1 ? ".png" : ".jpg");
        }

    }

    public class APITrick : APIData
    {
        public string Category { get; set; } = string.Empty;
        public string IconFileName { get; set; } = "11111111-1111-1111-1111-111111111111.png";
        public string Color { get; set; } = "FFFFFFFF";
        public int Level { get; set; }
        public int Scale { get; set; }
    }




    public class APITraining : APIData
    {
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

    public class DTOData : APIData
    {
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

    public class DTOTrainingTrick
    {
        public int TrickID { get; set; }
        public int Repetitions { get; set; }
        public int ProficiencyCount { get; set; }
        public string Comment { get; set; } = string.Empty;

        public int Proficiency { get; set; }

    }



    public class DTOSession : DTOData
    {
        public int DogId { get; set; }
        public int TrainerID { get; set; }
        public string Mood { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string Weather { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public List<DTOTrainingTrick> Tricks { get; set; } = new();



        public override string JsonText()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}
