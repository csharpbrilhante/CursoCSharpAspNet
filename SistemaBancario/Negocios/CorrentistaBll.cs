using SistemaBancario.Modelos;
using SistemaBancario.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Negocios
{
    public class CorrentistaBll
    {
        readonly CorrentistaRepository _dataset = CorrentistaRepository.ObterInstancia();

        public bool CriarOuAtualizarCorrentista(Correntista pCorrentista)
        {
            Validar(pCorrentista);
            
            var correntistaExistente = _dataset.Read().FirstOrDefault(x => x.Id == pCorrentista.Id);
            
            if(correntistaExistente == null)
            {
                _dataset.Create(pCorrentista);
            }
            else
            {
                _dataset.Update(pCorrentista);
            }

            return true;
        }

        public List<Correntista> ObterCorrentistas(bool pSomenteAtivos = false)
        {
            return (pSomenteAtivos ? _dataset.Read().Where(x => x.Ativo).ToList() : _dataset.Read());
        }

        //public List<Correntista> ObterCorrentistasAtivos()
        //{
        //    return _dataset.Read().Where(x => x.Ativo).ToList();
        //}

        //public List<Correntista> ObterCorrentistasAtivos2()
        //{
        //    return ObterCorrentistasAtivos().Where(x => x.Ativo).ToList();
        //}

        public void ExcluirCorrentista(Correntista pCorrentista)
        {
            _dataset.Delete(pCorrentista);
        }

        private void Validar(Correntista pCorrentista)
        {
            if(string.IsNullOrWhiteSpace(pCorrentista.Nome))
            {
                throw new Exception("O campo nome não foi preenchido.");
            }

            if (string.IsNullOrWhiteSpace(pCorrentista.CpfCnpj))
            {
                throw new Exception("O campo Cpf/Cnpj não foi preenchido.");
            }
        }

    }
}
