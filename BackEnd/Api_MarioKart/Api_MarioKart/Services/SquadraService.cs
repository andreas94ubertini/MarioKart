using Api_MarioKart.Dto;
using Api_MarioKart.Models;
using Api_MarioKart.Repo;

namespace Api_MarioKart.Services
{
    public class SquadraService
    {
        private readonly SquadraRepo _repository;
        private readonly PersonaggiRepo _perRepo;

        public SquadraService(SquadraRepo repository, PersonaggiRepo perRepo)
        {
            _repository = repository;
            _perRepo = perRepo;
        }

        private List<PersonaggiDto> TransformListDto(List<Personaggi> PersoList)
        {
            List<PersonaggiDto> transformedList = new List<PersonaggiDto>();
            PersoList.ForEach(p =>
            {
                transformedList.Add(new PersonaggiDto()
                {
                    Cos = p.Costo,

                    Cod = p.Codice,

                    Nom = p.Nome,

                    Cat = p.Categoria,

                    Img = p.Img,

                    
                });
            });
            return transformedList;
        }
        public List<SquadraDto> GetAllPer()
        {
            List<SquadraDto> elenco = _repository.GetAll().Select(s => new SquadraDto()
            {
                Nom = s.NomeUtente,

                NomSquad = s.NomeSquadra,

                Cred = s.Crediti,

                Cod = s.Codice,

                Perso = TransformListDto(s.Personaggis)

            }).ToList();

            return elenco;
        }

        public bool InsertSquadra(SquadraDto s)
        {
            Squadra squad = new Squadra()
            {
                NomeUtente = s.Nom,
                NomeSquadra = s.NomSquad,
                Crediti = s.Cred,
                Codice = Guid.NewGuid().ToString().ToUpper(),
            };

            return _repository.Create(squad);
        }

        private List<Personaggi> TransformPersonaggi(List<PersonaggiDto> lista)
        {
            List<Personaggi> transformedList = new List<Personaggi>();
            lista.ForEach(p =>
            {
                transformedList.Add(new Personaggi()
                {
                    Costo = p.Cos,

                    Codice = p.Cod,

                    Nome = p.Nom,

                    Categoria = p.Cat,

                    Img = p.Img,
                    
                });
            });
            return transformedList;
        }
        public bool ModifySquadra(SquadraDto s)
        {
            if (s.Cod != null)
            {
                Squadra? squad = _repository.GetByCod(s.Cod);
                if (squad != null)
                    squad.Personaggis = TransformPersonaggi(s.Perso);
                    return _repository.Update(squad);
            }
            return false;
        }

        public bool InsertPersonaggiIntoSquad(string perCod, string codSquad)
        {
            Squadra? temp = _repository.GetByCod(codSquad);
            if (temp != null )
            {
                Personaggi? per= _perRepo.GetByCod(perCod);
                if (per != null && temp.Crediti >= per.Costo && CheckIfPresent(temp,per) && IsDispo(per))
                {
                    temp.Personaggis.Add(per);
                    temp.Crediti -= per.Costo;
                    if (_repository.Update(temp))
                        return true;
                }

            }
            return false;
        }
        private bool CheckIfPresent(Squadra s, Personaggi p)
        {
            
            if (s.Personaggis.FirstOrDefault(per => per.Categoria == p.Categoria) != null)
            {
                return false;
            }

            return true;
        }

        private bool IsDispo(Personaggi p)
        {
            if (_perRepo.GetByCod(p.Codice).SquadraRif != null)
            {
                return false;
            }

            return true;
        }
    }
}
