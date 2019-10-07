using CinemAPI.Data;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Cinema;
using CinemAPI.Models.Input.Cinema;
using System.Web.Http;
using System.Collections.Generic;

namespace CinemAPI.Controllers
{
    public class CinemasController : ApiController
    {
        private readonly ICinemaRepository cinemaRepo;

        public CinemasController(ICinemaRepository cinemaRepo)
        {
            this.cinemaRepo = cinemaRepo;
        }

        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "Monkata", "Goshkata" };
        }

        [HttpPost]
        public IHttpActionResult Index(CinemaCreationModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("Invalid cinema name or address");
            }

            ICinema cinema = cinemaRepo.GetByNameAndAddress(model.Name, model.Address);

            if (cinema == null)
            {
                cinemaRepo.Insert(new Cinema(model.Name, model.Address));

                return Ok();
            }

            return BadRequest("Cinema already exists");
        }
    }
}