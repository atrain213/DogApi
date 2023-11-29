using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DogApi
{
    public class QueryDog
    {
        private DogContext _context;

        public QueryDog(DogContext context)
        {
            _context = context;
        }

        public List<APIDog> getDogs()
        {
            return _context.Dogs.Where(w => w.IsActive)
                .Select(s => new APIDog { ID = s.ID, Name = s.Name })
                .OrderBy(o => o.Name)
                .ToList();
        }

        public APIDogDetail? getDog(int id)
        {
            return _context.Dogs.Where(w => w.ID == id)
                .Select(s => new APIDogDetail
                {
                    ID = s.ID,
                    Name = s.Name,
                    Birthday = s.Birthday,
                    Breed = s.Breed.Name,
                    Bio = s.Bio,
                    Photo = s.Photo.unique_ID.ToString().ToLower() + (s.Photo.type_ID == 1? ".png": ".jpg"),
                    PhotoID = s.PhotoID,                                               
                    Sex = s.IsMale ? "Male" : "Female" ,
                    Weight = s.Weight,
                    Owners = s.Owners.Where(w => w.IsActive)
                                        .Select(x => new APIContact { ID = x.Owner.Contact.ID, Name = x.Owner.Contact.First + " " + x.Owner.Contact.Last })
                                        .ToList(),
                    Trainers = s.Trainers.Where(w => w.IsActive)
                                        .Select(x => new APIContact { ID = x.Trainer.ContactID, Name = x.Trainer.Contact.First + " " + x.Trainer.Contact.Last })
                                        .ToList()

                }).FirstOrDefault();
        }

        public List<APIDogDetail> getDogbyTrainer(int id)
        {
            return _context.DogTrainers.Where(w => w.TrainerID == id)
                .Select(s => new APIDogDetail
                {


                    ID = s.Dog.ID,
                    Name = s.Dog.Name,
                    Birthday = s.Dog.Birthday,
                    Breed = s.Dog.Breed.Name,
                    Bio = s.Dog.Bio,
                    Photo = s.Dog.Photo.unique_ID.ToString().ToLower() + (s.Dog.Photo.type_ID == 1 ? ".png" : ".jpg"),
                    PhotoID = s.Dog.PhotoID,
                    Sex = s.Dog.IsMale ? "Male" : "Female",
                    Weight = s.Dog.Weight,
                    Owners = s.Dog.Owners.Where(w => w.IsActive)
                                        .Select(x => new APIContact { ID = x.Owner.Contact.ID, Name = x.Owner.Contact.First + " " + x.Owner.Contact.Last })
                                        .ToList(),
                    Trainers = s.Dog.Trainers.Where(w => w.IsActive)
                                        .Select(x => new APIContact { ID = x.Trainer.ContactID, Name = x.Trainer.Contact.First + " " + x.Trainer.Contact.Last })
                                        .ToList()

                })
                .OrderBy(o => o.Name)
                .ThenBy(o => o.Breed)
                .ToList();
        }

        public int getLastDogforTrainer(int id)
        {
            return _context.Trainings.Where(w => w.TrainerID == id)
                .OrderByDescending(o => o.Date)
                .Select(s => s.DogID)
                .FirstOrDefault();
        }

        public List<APIDogDetail> getDogbyOwner(int id)
        {
            return _context.DogOwners.Where(w => w.OwnerID == id)
                .Select(s => new APIDogDetail
                {


                    ID = s.Dog.ID,
                    Name = s.Dog.Name,
                    Birthday = s.Dog.Birthday,
                    Breed = s.Dog.Breed.Name,
                    Bio = s.Dog.Bio,
                    Photo = s.Dog.Photo.unique_ID.ToString().ToLower() + (s.Dog.Photo.type_ID == 1 ? ".png" : ".jpg"),
                    PhotoID = s.Dog.PhotoID,
                    Sex = s.Dog.IsMale ? "Male" : "Female",
                    Weight = s.Dog.Weight,
                    Owners = s.Dog.Owners.Where(w => w.IsActive)
                                        .Select(x => new APIContact { ID = x.Owner.Contact.ID, Name = x.Owner.Contact.First + " " + x.Owner.Contact.Last })
                                        .ToList(),
                    Trainers = s.Dog.Trainers.Where(w => w.IsActive)
                                        .Select(x => new APIContact { ID = x.Trainer.ContactID, Name = x.Trainer.Contact.First + " " + x.Trainer.Contact.Last })
                                        .ToList()

                })
                .OrderBy(o => o.Name)
                .ThenBy(o => o.Breed)
                .ToList();
        }

        public List<APIDogBreeds> getBreeds()
        {
            return _context.DogBreeds.Where(w => w.IsActive)
                .Select(s => new APIDogBreeds { ID = s.ID, Name = s.Name })
                .OrderBy(o => o.Name)
                .ToList();
        }

        public APIPicture? getPicture(int ID)
        {
            return _context.Pictures.Where(w => w.ID == ID)
                    .Select(s => new APIPicture { ID = s.ID, Name = s.Name, type_ID = s.type_ID, unique_ID = s.unique_ID})
                    .FirstOrDefault();
        }

        public List<APITrick> getTricks()
        {
            return _context.Tricks.Where(w => w.IsActive)
                    .OrderBy(o => o.Name)
                    .Select(s => new APITrick 
                    {
                        ID = s.ID,
                        Category = s.Category.Name,
                        Color = s.Category.Color,
                        IconFileName = s.Category.Icon.Icon.unique_ID.ToString().ToLower()+ (s.Category.Icon.Icon.type_ID == 1 ? ".png" : ".jpg"),
                        Name = s.Name,
                        Proficiency = 1.0
                    }).ToList();
        }

        public List<APITrick> getTricksByDog(int ID)
        {
            return _context.DogTricks.Where(w => w.DogID == ID)
                    .Select(s => new APITrick
                    {
                        ID = s.ID,
                        Category = s.Trick.Category.Name,
                        Color = s.Trick.Category.Color,
                        IconFileName = s.Trick.Category.Icon.Icon.unique_ID.ToString().ToLower() + (s.Trick.Category.Icon.Icon.type_ID == 1 ? ".png" : ".jpg"),
                        Name = s.Trick.Name,
                        Proficiency = ((double)s.Proficiency/ (double)s.ProficiencyScale)
                    }).ToList();
        }

        public APITrickDetail? getTrickDetailbyID(int ID)
        {
            return _context.DogTricks.Where(w => w.ID == ID)
                    .Select(s => new APITrickDetail
                    {
                        ID = s.TrickID,
                        VerbalCue = s.VerbalCue,
                        VerbalRelease = s.VerbalRelease,
                        VisualCue = s.VisualCue,
                        VisualRelease = s.VisualRelease,
                        Category = s.Trick.Category.Name,
                        Color = s.Trick.Category.Color,
                        Comment = s.Comment,
                        Name = s.Trick.Name,
                        Proficiency = s.Proficiency,
                        IconFileName = s.Trick.Category.Icon.Icon.unique_ID.ToString().ToLower() + (s.Trick.Category.Icon.Icon.type_ID == 1 ? ".png" : ".jpg"),
                        Trainings = s.TrainingTricks.Where(w => w.IsActive).Select(x => new APITraining
                                                                                                {
                        //                                                                            ID = x.ID,
                        //                                                                            Date = x.Training.Date,
                        //                                                                            Comment = x.Training.Comment,
                        //                                                                            ProficiencyCount = x.ProficiencyCount,
                        //                                                                            Repetitions = x.Repetitions,
                        //                                                                            Name = x.Training.Trainer.Contact.First + " " + x.Training.Trainer.Contact.Last
                                                                                                }).ToList()

                    }).FirstOrDefault();
        }

        public int saveDog(DTODog dto)
        {
            DogBreed? breed = _context.DogBreeds.FirstOrDefault(w => w.ID == dto.BreedID);
            Picture? photo = _context.Pictures.FirstOrDefault(w => w.ID == dto.PhotoID);
            if (breed == null || photo == null)
            {
                return -1;
            }
            Dog? dog;
            if (dto.ID > 0 )
            {
                dog = _context.Dogs.FirstOrDefault(w => w.ID == dto.ID);
                if(dog == null)
                {
                    return -2;
                }
            }
            else
            {
                dog = new() { JoinedAppDate = DateTime.Now, TrainingStartDate = DateTime.Now};
            }
            dog.Name = dto.Name;
            dog.Breed = breed;
            dog.Photo = photo;
            dog.Birthday = dto.Birthday;
            dog.IsMale = dto.IsMale;
            dog.Weight = dto.Weight;
            dog.Bio = dto.Bio;
            if(dto.ID == 0)
            {
                _context.Add(dog);
            }
            _context.SaveChanges();
            return dog.ID;

        }

        public int savePicture(DTOPicture dto)
        {
            
            Picture? pic;
            if (dto.ID > 0)
            {
                pic = _context.Pictures.FirstOrDefault(w => w.ID == dto.ID);
                if (pic == null)
                {
                    return -2;
                }
            }
            else
            {
                pic = new() { unique_ID = Guid.NewGuid()};
            }
            pic.Name = dto.Name;
            pic.type_ID = dto.type_ID;
            if (dto.ID == 0)
            {
                _context.Add(pic);
            }
            _context.SaveChanges();
            return pic.ID;

        }
    }
}
