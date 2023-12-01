using System.ComponentModel.DataAnnotations;

namespace DogApi
{
    public class BaseData
    {
        public int ID { get; set; }
        public bool IsActive { get; set; } = true;

    }

    public class BaseDogBreed : BaseData
    {
        [MaxLength(50)]public string Name { get; set; } = string.Empty;
    }
    public class BaseDog : BaseData
    {
        [MaxLength(50)]public string Name { get; set; } = string.Empty;
        public int BreedID { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsMale { get; set; }
        public int Weight { get; set; }
        public DateTime TrainingStartDate { get; set; }
        public DateTime JoinedAppDate { get; set; }
        public int PhotoID { get; set; }
        [MaxLength(500)] public string Bio { get; set; } = string.Empty;
    }


    public class BaseContact : BaseData
    {
        [MaxLength(50)] public string Name { get;set; } = string.Empty;
        [MaxLength(15)] public string First{ get; set; } = string.Empty;
        [MaxLength(15)] public string Last { get; set; } = string.Empty;
        [MaxLength(15)] public string Mi { get; set; } = string.Empty;
        [MaxLength(50)] public string Address { get; set; } = string.Empty;
        [MaxLength(150)] public string Address2 { get; set; } = string.Empty;
        [MaxLength(50)] public string City { get; set; } = string.Empty;
        [MaxLength(2)] public string State { get; set; } = string.Empty;
        [MaxLength(10)] public string PostalCode { get; set; } = string.Empty;
        [MaxLength(25)] public string Country { get; set; } = string.Empty;
        [MaxLength(15)] public string Phone { get; set; } = string.Empty;
        [MaxLength(50)] public string Email { get; set; } = string.Empty;
        public bool SMS { get; set; } = true;
        public DateTime JoinedAppDate { get; set; }
    }

    public class BaseOwner : BaseData
    {
        public int ContactID { get; set; }
    }

    public class BasePicture : BaseData
    {
        public string Name { get; set; } = string.Empty;
        public Guid unique_ID { get; set; }
        public int type_ID { get; set; }
    }

    public class BaseTrainer : BaseData
    {
        public int ContactID { get; set; }
        public int IntialYear { get; set; }
        [MaxLength(500)] public string Bio { get; set; } = string.Empty;

    }

    public class BaseTrick : BaseData
    {
        public string Name { get; set; } = string.Empty;
        public int CategoryID { get; set; }

    }

    public class BaseDogTrick: BaseData
    {
        public int DogID { get; set; }
        public int TrickID { get; set; }
        public int Proficiency { get; set; }
        public int ProficiencyScale { get; set; }
        [MaxLength(50)] public string VerbalCue { get; set; } = string.Empty;
        [MaxLength(50)] public string VisualCue { get; set; } = string.Empty;
        [MaxLength(50)] public string VerbalRelease { get; set; } = string.Empty;
        [MaxLength(50)] public string VisualRelease { get; set; } = string.Empty;
        [MaxLength(500)] public string Comment { get; set; } = string.Empty;
    }

    public class BaseTrickCategory : BaseData
    {
        [MaxLength(50)] public string Name { get; set; } = string.Empty;
        public int IconID { get; set; }
        [MaxLength(8)] public string Color { get; set; } = "FFFFFFFF";
    }

    public class BaseTrickIcon : BaseData
    {
        [MaxLength(50)] public string Name { get; set; } = string.Empty;

        public int PictureID { get; set; }

    }

    public class BaseDogOwner : BaseData
    {
        public int DogID { get; set; }
        public int OwnerID { get; set; }

    }

    public class BaseDogTrainer : BaseData
    {
        public int DogID { get; set; }
        public int TrainerID { get; set; }

    }

    public class BaseTrainingTrick : BaseData
    {
        public int TrickID { get; set;}
        public int TrainingID { get; set; }
        public int Repetitions { get; set; }
        public int ProficiencyCount { get; set; }
        [MaxLength(500)]public string Comment { get; set; } = string.Empty;

    }

    public class BaseTraining : BaseData
    {
        public DateTime Date { get; set; }
        public int DogID { get; set; }
        public int TrainerID { get; set; }
        [MaxLength(50)] public string Mood { get; set; } = string.Empty;
        public int Duration { get; set; }
        [MaxLength(50)] public string Weather { get; set; } = string.Empty;
        [MaxLength(100)] public string Location { get; set; } = string.Empty;
        [MaxLength(500)] public string Comment { get; set; } = string.Empty;
    }



}
