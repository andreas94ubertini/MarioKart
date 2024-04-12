using Api_MarioKart.Dto;
using Api_MarioKart.Models;
using Api_MarioKart.Repo;

namespace Api_MarioKart.Services
{
    public class PersonaggiService
    {
        private readonly PersonaggiRepo _repository;

        public PersonaggiService(PersonaggiRepo repository)
        {
            _repository = repository;
        }

        public List<PersonaggiDto> GetAllPer()
        {
            List<PersonaggiDto> elenco = _repository.GetAll().Select(p => new PersonaggiDto()
            {
                Cos = p.Costo,

                Cod = p.Codice,

                Cat = p.Categoria,

                Img = p.Img,

                SquadRif = p.SquadraRif,

                Squad= p.SquadraRifNavigation
            }).ToList();

            return elenco;
        }

        public bool InsertPersonaggio(PersonaggiDto p) {

            Personaggi per = new Personaggi()
            {
                Categoria = p.Cat,
                Codice = Guid.NewGuid().ToString().ToUpper(),
                Costo = p.Cos,
                Img = p.Img,
                SquadraRif = p.SquadRif,
                SquadraRifNavigation = p.Squad
            };

            return _repository.Create(per);
        }
    }
}
