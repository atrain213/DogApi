using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly DogContext _context;
        private readonly QueryDog _query;

        public EventController(DogContext context)
        {
            _context = context;
            _query = new QueryDog(_context);
        }

        [HttpGet("events")]
        public ActionResult<List<APIEventBasic>> GetEvents()
        {
            return Ok(_query.getEvents());
        }



        [HttpGet("events/{id}")]
        public ActionResult<List<APIEvent>> GetEventsByID(int id)
        {
            return Ok(_query.getEventbyID(id));
        }

        [HttpGet("personnel/{id}")]
        public ActionResult<APIPersonnel> GetPersonnelByID(int id)
        {
            return Ok(_query.GetPersonnelbyID(id));
        }

        [HttpPost("staff")]
        public ActionResult<int> AddEventStaff(DTOSignUP dto)
        {
            int retval = _query.PostSignUp(dto.EventID, dto.PersonnelID);
            if (retval < 1)
            {
                return BadRequest(retval);
            }
            return Ok(retval);
        }

        [HttpPost("eventpackage")]
        public ActionResult<int> AddEventPackage(DTOSignUP dto)
        {
            int retval = _query.PostAddPackage(dto.EventID, dto.PersonnelID);
            if (retval < 1)
            {
                return BadRequest(retval);
            }
            return Ok(retval);
        }


    }
}
