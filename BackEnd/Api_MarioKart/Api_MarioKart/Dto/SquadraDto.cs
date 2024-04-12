using Api_MarioKart.Models;

namespace Api_MarioKart.Dto
{
    public class SquadraDto
    {

        public string Nom { get; set; } = null!;

        public string NomSquad { get; set; } = null!;

        public int? Cred { get; set; }

        public string? Cod { get; set; }

        public List<PersonaggiDto> Perso { get; set; } = new List<PersonaggiDto>();
    }
}
