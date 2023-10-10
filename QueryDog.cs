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
                    Breed = s.Breed,
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
    }
}
