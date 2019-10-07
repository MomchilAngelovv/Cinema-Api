using CinemAPI.Data;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Room;
using CinemAPI.Models.Input.Room;
using System;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class RoomsController : ApiController
    {
        private readonly IRoomRepository roomRepo;

        public RoomsController(IRoomRepository roomRepo)
        {
            this.roomRepo = roomRepo;
        }

        [HttpPost]
        public IHttpActionResult Index(RoomCreationModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("Invalid data provided");
            }

            IRoom room = roomRepo.GetByCinemaAndNumber(model.CinemaId, model.Number);

            if (room == null)
            {
                try
                {
                    roomRepo.Insert(new Room(model.Number, model.SeatsPerRow, model.Rows, model.CinemaId));

                }
                catch (ArgumentException)
                {
                    return BadRequest("Cinema does not exists");
                }

                return Ok();
            }

            return BadRequest("Room already exists");
        }
    }
}