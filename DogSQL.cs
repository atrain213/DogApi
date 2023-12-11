namespace DogApi
{
    public class Dog : BaseDog
    {
        public DogBreed Breed { get; set; } = new();
        public Picture Photo { get; set; } = new();
        //public List<Training> Trainings { get; set; } = new();
        public List<DogOwner> Owners { get; set; } = new();
        public List<DogTrainer> Trainers { get; set; } = new();
        public List<DogTrick> Tricks { get; set; } = new();
    }

    public class DogBreed: BaseDogBreed
    {
        public List<Dog?> Dogs { get;set; } = new();
    }

    public class Contact: BaseContact
    {
        public List<Owner> Owners { get; set; } = new();
        public List<Trainer> Trainers { get; set; } = new();
    }
    public class DogOwner : BaseDogOwner
    {
        public Dog Dog { get; set; } = new();
        public Owner Owner { get; set; } = new();
    }
    public class DogTrainer : BaseDogTrainer
    {
        public Dog Dog { get; set; } = new();
        public Trainer Trainer { get; set; } = new();
        public List<Training> Trainings { get; set; } = new();
    }
    public class Owner : BaseOwner
    {
        public List<DogOwner> Owners {get; set; } = new();
        public Contact Contact { get; set; } = new();
    }

    public class Picture : BasePicture
    {
        public List<Dog> Dogs { get; set; } = new();

        public List<TrickIcon> TrickIcons { get; set; } = new();
    }
    public class Trainer : BaseTrainer
    {
        public List<DogTrainer> Trainers { get; set; } = new();
        //public List<Training> Trainings { get; set; } = new();
        //public List<DogTrick> Tricks { get; set; } = new();
        public Contact Contact { get; set; } = new();
    }
    public class TrainingTrick : BaseTrainingTrick
    {
        public DogTrick Trick { get; set; } = new();
        public Training Training { get; set; } = new();

    }
    public class Training : BaseTraining
    {
        public List<TrainingTrick> TrainingTricks { get; set; } = new();
        public DogTrainer DogTrainer { get; set; } = new();
    }
    public class TrickCategory : BaseTrickCategory
    {
        public TrickIcon Icon { get; set; } = new();
        public List<Trick> Tricks { get; set; } = new();
    }
    public class TrickIcon : BaseTrickIcon
    {
        public List<TrickCategory> TrickCategories { get; set; } = new();
        public Picture Icon { get; set; } = new();
    }
    public class DogTrick : BaseDogTrick
    {
        public List<TrainingTrick> TrainingTricks { get; set; } = new();
        public Dog Dog { get; set; } = new();
        public Trick Trick { get; set; } = new();

    }

    public class Trick : BaseTrick
    {
        public List<DogTrick> DogTricks { get; set; } = new();
        public TrickCategory Category { get; set; } = new();
    }


    //VUTC DATA
    public class Events : BaseEvents
    {
        public List<EventPackages> Packages { get; set; } = new();
        public List<EventSignUp> EventSignUps { get; set; } = new();

    }

    public class EventSignUp : BaseEventSignUp
    {
        public Personnel Personnel { get; set; } = new();
        public Events Event { get; set; } = new();
    }

    public class EventPackages : BaseEventPackages
    {
        public Events Event { get; set; } = new(); 
        public Pricing Package { get; set; } = new();

    }

    public class Personnel : BasePersonnel
    {
        public List<EventSignUp> EventSignUps { get; set; } = new();

    }

    public class Pricing : BasePricing
    {
        //public Events Events { get; set; } = new();
        public List<EventPackages> EventPackages { get; set; } = new(); 

    }

}
