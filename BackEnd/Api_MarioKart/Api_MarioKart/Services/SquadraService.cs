using Api_MarioKart.Dto;
using Api_MarioKart.Models;
using Api_MarioKart.Repo;

namespace Api_MarioKart.Services
{
    public class SquadraService
    {
        private readonly SquadraRepo _repository;

        public SquadraService(SquadraRepo repository)
        {
            _repository = repository;
        }

        public List<SquadraDto> GetAllPer()
        {
            List<SquadraDto> elenco = _repository.GetAll().Select(s => new SquadraDto()
            {
                Nom = s.NomeUtente,

                NomSquad = s.NomeSquadra,

                Cred = s.Crediti,

                Cod = s.Codice,

                Perso = s.Personaggis,

            }).ToList();

            return elenco;
        }

        public bool InsertSquadra(SquadraDto s)
        {
            Squadra squad = new Squadra()
            {
                NomeUtente = s.Nom,
                NomeSquadra = s.NomSquad,
                Codice = Guid.NewGuid().ToString().ToUpper(),
            };

            return _repository.Create(squad);
        }

        public bool ModifySquadra(SquadraDto s)
        {
            if (s.Cod != null)
            {
                Squadra? squad = _repository.GetByCod(s.Cod);
                if (squad != null)
                    squad.Personaggis = s.Perso;
                    return _repository.Update(squad);
            }
            return false;
        }
    }
}
