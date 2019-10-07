using System.ComponentModel.DataAnnotations;

namespace CinemAPI.Models.Input.Room
{
    public class RoomCreationModel
    {
        [Range(1,int.MaxValue)]
        public int Number { get; set; }

        [Range(1, short.MaxValue)]
        public short SeatsPerRow { get; set; }

        [Range(1, short.MaxValue)]
        public short Rows { get; set; }

        [Range(1, int.MaxValue)]
        public int CinemaId { get; set; }
    }
}