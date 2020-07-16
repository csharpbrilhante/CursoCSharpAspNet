using SistemaBancario.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario.Repositorio
{
    public class CorrentistaRepository : RepositoryBase<Correntista>
    {
        public CorrentistaRepository(): base()
        {
            lista = DBMem.ObterCorrentistas();
        }

        public override void Update(Correntista pObjeto)
        {
            var correntistaAtualizar = lista.FirstOrDefault(x => x.Id == pObjeto.Id);

            correntistaAtualizar.Nome = pObjeto.Nome;
            correntistaAtualizar.CpfCnpj = pObjeto.CpfCnpj;
        }
    }
}
