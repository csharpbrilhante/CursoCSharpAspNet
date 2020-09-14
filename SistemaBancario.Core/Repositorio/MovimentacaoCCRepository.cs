using SistemaBancario.Core.Modelos;
using SistemaBancario.Utils.Db;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Core.Repositorio
{
    public class MovimentacaoCCRepository : RepositoryBase<MovimentacaoCC>
    {
        public MovimentacaoCCRepository()
        {
            Tabela = "MOVIMENTACAOCC";
        }

        public override void Create(MovimentacaoCC pObjeto)
        {
            pObjeto.Id = ObterProxSequencial();

            var sql = @"INSERT INTO MOVIMENTACAOCC 
                        ( MOVIMENTACAOCCID
                        , CONTACORRENTEID 
                        , DATAMOVIMENTACAO
                        , VALOR
                        , HISTORICO
                        , DATACRIACAO) 
                          VALUES 
                        ( @MOVIMENTACAOCCID
                        , @CONTACORRENTEID 
                        , @DATAMOVIMENTACAO
                        , @VALOR
                        , @HISTORICO
                        , @DATACRIACAO)";

            try
            {
                _comando = _conexao.ObterComando();
                _comando.CommandText = sql;
                _comando.Parameters.Add(new SQLiteParameter("MOVIMENTACAOCCID", pObjeto.Id));
                _comando.Parameters.Add(new SQLiteParameter("CONTACORRENTEID", pObjeto.ContaCorrenteId));
                _comando.Parameters.Add(new SQLiteParameter("DATAMOVIMENTACAO", pObjeto.DataMovimentacao));
                _comando.Parameters.Add(new SQLiteParameter("VALOR", pObjeto.Valor));
                _comando.Parameters.Add(new SQLiteParameter("HISTORICO", pObjeto.Historico));
                _comando.Parameters.Add(new SQLiteParameter("DATACRIACAO", DateTime.Now));

                _comando.ExecuteNonQuery();
            }
            finally
            {
                _comando.Liberar();
            }
        }
        
        public override List<MovimentacaoCC> Read()
        {
            throw new NotImplementedException();
        }

        public override void Update(MovimentacaoCC pObjeto)
        {
            throw new NotImplementedException();
        }

        public override void Delete(MovimentacaoCC pObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
