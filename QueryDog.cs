using Azure.Core;
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

        public List<APIData> getAllContacts()
        {
            return _context.Contacts.Where(w => w.IsActive)
                .Select(s => new APIData { ID = s.ID, Name = s.Name})
                .OrderBy(o => o.Name)
                .ToList();
        }

        public List<APIData> getAllOwners()
        {
            return _context.Owners.Where(w => w.IsActive)
                .Select(s => new APIData { ID = s.Contact.ID, Name = s.Contact.Name })
                .OrderBy(o => o.Name)
                .ToList();
        }

        public List<APIData> getAllTrainers()
        {
            return _context.Trainers.Where(w => w.IsActive)
                .Select(s => new APIData { ID = s.Contact.ID, Name = s.Contact.Name })
                .OrderBy(o => o.Name)
                .ToList();
        }

        public APIContact? getContactInfo(int id)
        {
            return _context.Contacts.Where(w => w.ID == id)
                .Select(s => new APIContact { 
                    ID = s.ID,
                    Name = s.Name,
                    FName = s.First,
                    Address1 = s.Address,
                    Address2 = s.Address2,
                    CSZ = s.City + ", " + s.State + "  " + s.PostalCode,
                    Email = s.Email,
                    Phone = s.Phone,
                    OwnerID = s.Owners.Select(s => s.ID).FirstOrDefault(),
                    TrainerID = s.Trainers.Select(s => s.ID).FirstOrDefault()
                })
                .FirstOrDefault();
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

        public APIData? getTrainerbyDog(int id)
        {
            return _context.DogTrainers.Where(w => w.DogID == id)
                .Select( s => new APIData()
                {
                    ID = s.TrainerID,
                    Name = s.Trainer.Contact.Name
                }).FirstOrDefault();

        }

        public APIData? getOwnerbyDog(int id)
        {
            return _context.DogOwners.Where(w => w.DogID == id)
                .Select(s => new APIData()
                {
                    ID = s.OwnerID,
                    Name = s.Owner.Contact.Name
                }).FirstOrDefault();

        }

        public int getLastDogforTrainer(int id)
        {
            return _context.Trainings.Where(w => w.DogTrainer.TrainerID == id)
                .OrderByDescending(o => o.Date)
                .Select(s => s.DogTrainer.DogID)
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
                        Level = 1,
                        Scale = 1
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
                        Level=s.Proficiency,
                        Scale=s.ProficiencyScale
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
                        Level = s.Proficiency,
                        Scale = s.ProficiencyScale,
                        IconFileName = s.Trick.Category.Icon.Icon.unique_ID.ToString().ToLower() + (s.Trick.Category.Icon.Icon.type_ID == 1 ? ".png" : ".jpg"),
                        Trainings = s.TrainingTricks.Where(w => w.IsActive).Select(x => new APITrickTraining
                        {
                            ID = x.ID,
                            Date = x.Training.Date,
                            Comment = x.Training.Comment,
                            ProficiencyCount = x.ProficiencyCount,
                            Repetitions = x.Repetitions,
                            Name = x.Training.DogTrainer.Trainer.Contact.Name
                        }).ToList()

                    }).FirstOrDefault();
        }


        public List<APITrickDetail> getTrickDetailsByDog(int ID)
        {
            return _context.DogTricks.Where(w =>w.IsActive  &&  w.DogID  == ID)
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
                        Level = s.Proficiency,
                        Scale = s.ProficiencyScale,
                        IconFileName = s.Trick.Category.Icon.Icon.unique_ID.ToString().ToLower() + (s.Trick.Category.Icon.Icon.type_ID == 1 ? ".png" : ".jpg"),
                        Trainings = s.TrainingTricks.Where(w => w.IsActive).Select(x => new APITrickTraining
                        {
                            ID = x.ID,
                            Date = x.Training.Date,
                            Comment = x.Training.Comment,
                            ProficiencyCount = x.ProficiencyCount,
                            Repetitions = x.Repetitions,
                            Name = x.Training.DogTrainer.Trainer.Contact.Name
                        }).ToList()

                    }).ToList();
        }

        public List<ApiDogTraingHistory> GetHistorybyDog(int id)
        {
            return _context.Trainings.Where(w => w.IsActive && w.DogTrainer.DogID == id)
                                .OrderByDescending(o => o.Date)
                                .Select(s => new ApiDogTraingHistory
                                {
                                    ID = s.ID,
                                    Name = s.Location,
                                    Date = s.Date,
                                    Duration = s.Duration,
                                    Trainer = s.DogTrainer.Trainer.Contact.Name
                                }).ToList();
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
                Owner? owner = _context.Owners.FirstOrDefault(f => f.ID == 3);
                Trainer? trainer = _context.Trainers.FirstOrDefault(f => f.ID == 2);
                Trick? trick1 = _context.Tricks.FirstOrDefault(f => f.ID == 1);
                Trick? trick2 = _context.Tricks.FirstOrDefault(f => f.ID == 2);
                Trick? trick3 = _context.Tricks.FirstOrDefault(f => f.ID == 3);
                Trick? trick4 = _context.Tricks.FirstOrDefault(f => f.ID == 16);
                Trick? trick5 = _context.Tricks.FirstOrDefault(f => f.ID == 18);
                if (trick1 != null && trick2 != null && trick3 != null && trick4 != null && trick5 !=null && trainer != null && owner != null)
                {
                    _context.Add(new DogTrick 
                    {
                        Dog = dog,
                        Trick = trick1
                    });

                    _context.Add(new DogTrick
                    {
                        Dog = dog,
                        Trick = trick2
                    });

                    _context.Add(new DogTrick
                    {
                        Dog = dog,
                        Trick = trick3
                    });

                    _context.Add(new DogTrick
                    {
                        Dog = dog,
                        Trick = trick4
                    });

                    _context.Add(new DogTrick
                    {
                        Dog = dog,
                        Trick = trick5
                    });

                    _context.Add(new DogTrainer
                    {
                        Dog = dog,
                        Trainer = trainer
                    });

                    _context.Add(new DogOwner
                    {
                        Dog = dog,
                        Owner = owner
                    });
                }
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

        public int saveSession(DTOSession dto)
        {
            
            if (dto.ID == 0) 
            {
                DogTrainer? trainer = _context.DogTrainers.FirstOrDefault(f => f.IsActive && f.DogID == dto.DogId && f.TrainerID == dto.TrainerID);
                //Dog? dog = _context.Dogs.FirstOrDefault(f => f.ID == dto.DogId);
                //Trainer? trainer = _context.Trainers.FirstOrDefault(f => f.ID == dto.TrainerID);
                if (trainer == null)
                {
                    return -1;
                }
                Training trn = new()
                {
                    DogTrainer= trainer,
                    Date = dto.Date,
                    Duration = dto.Duration,
                    Comment = dto.Comment,
                    Mood = dto.Mood,
                    Weather = dto.Weather,
                    Location = dto.Location,
                    TrainingTricks = new(),
                };
                foreach (var item in dto.Tricks)
                {
                    DogTrick? dogTrick = _context.DogTricks.FirstOrDefault(f => f.ID == item.TrickID);
                    if(dogTrick == null)
                    {
                        return -2;
                    }
                    trn.TrainingTricks.Add(new TrainingTrick
                    {
                        Trick = dogTrick,
                        Repetitions = item.Repetitions,
                        ProficiencyCount = item.ProficiencyCount,
                        Comment = item.Comment
                    });
                    dogTrick.Proficiency = item.Proficiency;
                }
                _context.Add(trn);
                _context.SaveChanges();
                return trn.ID;
            }
            return 0;
        }

        //VUTC DATA

        public List<APIPersonnel> GetPersonnel()
        {
            return _context.Personnel.Where(w => w.IsActive)
                .Select(s => new APIPersonnel 
                { 
                    ID = s.ID, 
                    First = s.First,
                    Last = s.Last,
                    Name = s.First + " " + s.Last,
                    AHT = s.AHT,
                    VHT = s.VHT,
                    LHT = s.LHT,
                    Senior = s.Senior,
                    BannerID = s.BannerID,
                    PWD = s.Pwd,
                    Email = s.Email,
                    EmerContact = s.EmerContact,
                    EmerPhone = s.EmerPhone,
                    GradYear = s.GradYear,
                    Phone = s.Phone,
                    Residence = s.Residence,

                }).OrderBy(o => o.Name)
                .ToList();
        }

        public List<APIEventBasic> getEvents()
        {
            return _context.Events.Where(w => w.IsActive)
                .Select(s => new APIEventBasic 
                { 
                    ID = s.ID,
                    Date = s.Date,
                    EventName = s.EventName,
                    StaffCount = s.StaffCount,
                    CurrentSignUp = s.CurrentSignUp,
                    TimeFinish = s.TimeFinish,
                    TimeLoadIn = s.TimeLoadIn,
                    TimeStart  = s.TimeStart,
                    
                }).OrderBy(o => o.Date) .ToList();
        }

        public APIEvent? getEventbyID(int id)
        {
            return _context.Events.Where(w => w.ID == id)
                .Select(s => new APIEvent()
                {
                    ID = s.ID,
                    Date = s.Date,
                    EventName = s.EventName,
                    StaffCount = s.StaffCount,
                    CurrentSignUp = s.CurrentSignUp,
                    Description = s.Description,
                    Location = s.Location,
                    EventNeeds =s.EventNeeds,
                    Name = s.Name,
                    Email = s.Email,
                    AdvisorName = s.AdvisorName,
                    AdvisorEmail = s.AdvisorEmail,
                    Org = s.Org,
                    Phone = s.Phone,
                    TimeFinish = s.TimeFinish,
                    TimeLoadIn = s.TimeLoadIn,
                    TimeSoundCheck = s.TimeSoundCheck,
                    TimeStart = s.TimeStart,
                    Notes = s.Notes,
                    NotesHT = s.NotesHT,
                    Staff = s.EventSignUps.Where(w => w.IsActive).Select(x => new APIData { ID = x.Personnel.ID, Name = (x.Personnel.First + " " + x.Personnel.Last)}).OrderBy(o => o.Name).ToList(),
                    Packages = s.Packages.Where(w => w.IsActive).Select(x => new APIData { ID = x.Package.ID, Name = x.Package.Name }).OrderBy(o => o.Name).ToList(),
                }).FirstOrDefault();

        }

        public APIPersonnel? GetPersonnelbyID(int id)
        {
            return _context.Personnel.Where(w => w.ID == id)
                   .Select(s => new APIPersonnel()
                   {
                       ID = s.ID,
                       Email = s.Email,
                       EmerContact = s.EmerContact,
                       BannerID = s.BannerID,
                       PWD = s.Pwd,
                       AHT = s.AHT,
                       EmerPhone = s.EmerPhone,
                       First = s.First,
                       Last = s.Last,
                       Name = s.First + " " + s.Last,
                       GradYear = s.GradYear,
                       LHT = s.LHT,
                       Phone = s.Phone,
                       Residence = s.Residence,
                       Senior = s.Senior,
                       VHT = s.VHT,
                   }).FirstOrDefault();
        }

        public int PostSignUp(int evtID, int pid)
        {
            Events? evt = _context.Events.FirstOrDefault(f => f.ID == evtID);
            Personnel? pers = _context.Personnel.FirstOrDefault(f => f.ID == pid);
            if (evt == null || pers == null)
            {
                return -1;
            }
            EventSignUp esu = new() { Event = evt, Personnel = pers };
            _context.Add(esu);
            evt.CurrentSignUp++;
            _context.SaveChanges();
            return esu.ID;
        }

        public int PostAddPackage(int evtID, int pid)
        {
            Events? evt = _context.Events.FirstOrDefault(f => f.ID == evtID);
            Pricing? pack = _context.Pricings.FirstOrDefault(f => f.ID == pid);
            if (evt == null || pack == null)
            {
                return -1;
            }
            EventPackages esu = new() { Event = evt, Package = pack };
            _context.Add(esu);
            _context.SaveChanges();
            return esu.ID;
        }


    }

}
