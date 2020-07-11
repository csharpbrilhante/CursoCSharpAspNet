using SistemaBancario.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario.Repositorio
{
    public class CorrentistaRepository
    {
        // a instancia singleton
        private static CorrentistaRepository _instancia;
        private static List<Correntista> _correntistas;

        CorrentistaRepository()
        {
            _correntistas = new List<Correntista>()
            {
                new Correntista(){Id = 1, Nome = "José da Silva", Ativo = true},
                new Correntista(){Id = 2, Nome = "Maria da Silva", Ativo = true}
            };
        }

        public static CorrentistaRepository ObterInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new CorrentistaRepository();
            }                
            
            return _instancia;
        }

        public void Create(Correntista pCorrentista)
        {
            pCorrentista.Id = _correntistas?.Count > 0 ? _correntistas.Max(x => x.Id) + 1 : 1;
            _correntistas.Add(pCorrentista);
        }

        public List<Correntista> Read()
        {
            return _correntistas;
        }

        public void Update(Correntista pCorrentista)
        {
            var correntistaCursor = _correntistas.FirstOrDefault(x => x.Id == pCorrentista.Id);

            correntistaCursor.Nome = pCorrentista.Nome;
            correntistaCursor.CpfCnpj = pCorrentista.CpfCnpj;
        }

        public void Delete(Correntista pCorrentista)
        {
            _correntistas.Remove(pCorrentista);
        }
    }
}
