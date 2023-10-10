namespace DogApi
{
    public class Dog : BaseDog
    {
        public List<Training> Trainings { get; set; } = new();
        public List<DogOwner> Owners { get; set; } = new();
        public List<DogTrainer> Trainers { get; set; } = new();
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
    }
    public class Owner : BaseOwner
    {
        public List<DogOwner> Owners {get; set; } = new();
        public Contact Contact { get; set; } = new();
    }
    public class Trainer : BaseTrainer
    {
        public List<DogTrainer> Trainers { get; set; } = new();
        public List<Training> Trainings { get; set; } = new();
        public List<Trick> Tricks { get; set; } = new();
        public Contact Contact { get; set; } = new();
    }
    public class TrainingTrick : BaseTrainingTrick
    {
        public Trick Trick { get; set; } = new();
        public Training Training { get; set; } = new();

    }
    public class Training : BaseTraining
    {
        public List<TrainingTrick> TrainingTricks { get; set; } = new();
        public Dog Dog { get; set; } = new();
        public Trainer Trainer { get; set; } = new();
    }
    public class TrickCategory : BaseTrickCategory
    {
        public TrickIcon TrickIcon { get; set; } = new();
        public List<Trick> Tricks { get; set; } = new();
    }
    public class TrickIcon : BaseTrickIcon
    {
        public List<TrickCategory> TrickCategories { get; set; } = new();
    }
    public class Trick : BaseTrick
    {
        public List<TrainingTrick> TrainingTricks { get; set; } = new();
        public Trainer Trainer { get; set; } = new();
        public TrickCategory TrickCategory { get; set; }= new();

    }

}
