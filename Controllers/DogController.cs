using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
