using Api_MarioKart.Models;

namespace Api_MarioKart.Dto
{
    public class PersonaggiDto
    {

        public int Cos { get; set; }

        public string? Cod { get; set; }

        public string Nom { get; set; } = null!;
        public string Cat { get; set; } = null!;

        public string? Img { get; set; }

        public int? SquadRif { get; set; }

        public Squadra? Squad { get; set; }
    }
}
