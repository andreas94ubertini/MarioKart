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

                Nom = p.Nome,

                Cat = p.Categoria,

                Img = p.Img,

                SquadRif = p.SquadraRif,

                Squad = p.SquadraRifNavigation
            }).ToList();

            return elenco;
        }

        public bool InsertPersonaggio(PersonaggiDto p)
        {

            Personaggi per = new Personaggi()
            {
                Categoria = p.Cat,
                Codice = Guid.NewGuid().ToString().ToUpper(),
                Nome = p.Nom,
                Costo = p.Cos,
                Img = p.Img,
            };

            return _repository.Create(per);
        }
        public bool ModifyPersonaggio(PersonaggiDto p)
        {
            if (p.Cod != null)
            {
                Personaggi? per = _repository.GetByCod(p.Cod);
                if(per != null)
                    return _repository.Update(per);
            }
            return false;
        }
    }
}
