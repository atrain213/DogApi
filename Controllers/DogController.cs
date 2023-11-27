﻿using Microsoft.AspNetCore.Http;
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

    }
   
}
