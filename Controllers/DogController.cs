using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly DogContext _context;
        private readonly QueryDog _query;

        public DogController(DogContext context)
        {
            _context = context;
            _query = new QueryDog(_context);
        }

        


        [HttpGet]
        public ActionResult<List<APIDog>> GetDogs()
        {
            return Ok(_query.getDogs());
        }

        [HttpGet("contact")]
        public ActionResult<List<APIData>> GetContacts()
        {
            return Ok(_query.getAllContacts());
        }

        [HttpGet("contact/owner")]
        public ActionResult<List<APIData>> GetOwners()
        {
            return Ok(_query.getAllOwners());
        }

        [HttpGet("contact/trainer")]
        public ActionResult<List<APIData>> GetTrainer()
        {
            return Ok(_query.getAllTrainers());
        }

        [HttpGet("contact/{id}")]
        public ActionResult<APIContact> GetContactByID(int id)
        {
            APIContact? api = _query.getContactInfo(id);
            if (api == null)
            {
                return NotFound();
            }
            return Ok(api);
        }

        [HttpGet("breeds")]
        public ActionResult<List<APIDogBreeds>> GetBreeds()
        {
            return Ok(_query.getBreeds());
        }


        [HttpGet("trainer/{id}")]
        public ActionResult<List<APIDogDetail>> GetDogByTrainer(int id)
        {
            return Ok(_query.getDogbyTrainer(id));
        }

        [HttpGet("mytrainer/{id}")]
        public ActionResult<APIData> GetTrainerByDog(int id)
        {
            APIData? api = _query.getTrainerbyDog(id);
            if (api == null)
            {
                return NotFound();
            }
            return Ok(api);
        }

        [HttpGet("myowner/{id}")]
        public ActionResult<APIData> GetOwnerByDog(int id)
        {
            APIData? api = _query.getOwnerbyDog(id);
            if (api == null)
            {
                return NotFound();
            }
            return Ok(api);
        }


        [HttpGet("trainer/lastdog/{id}")]
        public ActionResult<int> GetLastDogForTrainer(int id)
        {
            return Ok(_query.getLastDogforTrainer(id));
        }

        [HttpGet("owner/{id}")]
        public ActionResult<List<APIDogDetail>> GetDogByOwner(int id)
        {
            return Ok(_query.getDogbyOwner(id));
        }


        [HttpGet("{id}")]
        public ActionResult<APIDogDetail> GetDog(int id)
        {
            APIDogDetail? api = _query.getDog(id);
            if (api == null)
            {
                return NotFound();
            }
            return Ok(api);
        }

        [HttpGet("picture/{id}")]
        public ActionResult<APIPicture> GetPicture(int id)
        {
            APIPicture? api = _query.getPicture(id);
            if(api == null)
            {
                return NotFound(); 
            }
            return Ok(api);
        }

        [HttpGet("trick")]
        public ActionResult<List<APITrick>> GetTricks()
        {
            return Ok(_query.getTricks());
        }

        [HttpGet("dogtrick/{id}")]
        public ActionResult<List<APITrick>> GetTricksByDog(int id)
        {
            return Ok(_query.getTricksByDog(id));
        }

        [HttpGet("dogtrick/detail/{id}")]
        public ActionResult<APITrickDetail> GetDogTrickDetail(int id)
        {
            APITrickDetail? api = _query.getTrickDetailbyID(id);
            if (api == null)
            {
                return NotFound();
            }
            return Ok(api);
        }



        [HttpPost("dog")]
        public ActionResult<int> SaveDog(DTODog dto)
        {
            int retval = _query.saveDog(dto);
            if(retval < 1) 
            {
                return BadRequest(retval);
            }
            return Ok(retval);
        }

        [HttpPost("picture")]
        public ActionResult<int> SavePicture(DTOPicture dto)
        {
            int retval = _query.savePicture(dto);
            if (retval < 1)
            {
                return BadRequest(retval);
            }
            return Ok(retval);
        }

        [HttpPost("session")]
        public ActionResult<int> SaveSession(DTOSession dto)
        {
            int retval = _query.saveSession2(dto);
            if (retval < 1)
            {
                return BadRequest(retval);
            }
            return Ok(retval);
        }

    }
   
}
