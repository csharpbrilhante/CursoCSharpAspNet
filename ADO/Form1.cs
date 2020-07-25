using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ADO
{

    public partial class Form1 : Form
    {
        readonly DataSet _dataset = new DataSet();
        
        readonly List<Pessoa> pessoas = new List<Pessoa>()
        {
            new Pessoa()
            {
                Id = 1,
                Nome = "José da Silva",
                Cpf = "999.999.999-99"
            },
            new Pessoa()
            {
                Id = 2,
                Nome = "Maria da Silva",
                Cpf = "888.888.888-88"
            },
            new Pessoa()
            {
                Id = 3,
                Nome = "João de Souza",
                Cpf = "777.777.777-77"
            },
            new Pessoa()
            {
                Id = 4,
                Nome = "Filipe de Souza",
                Pai = 3
            }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using(var conexao = new SqlConnection("Server=localhost;Database=Escolar;User Id=sa;Password=DevEngegraph;"))
            {
                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM PESSOAS", conexao);
                adapter.Fill(_dataset, "Pessoas");
                adapter.SelectCommand = new SqlCommand("SELECT * FROM NOTAS", conexao);
                adapter.Fill(_dataset, "Notas");
                //invocar o dispose
            }

            var colunaPk = _dataset.Tables["Pessoas"].Columns["PessoaId"];
            var colunaFk = _dataset.Tables["Notas"].Columns["PessoaId"];

            _dataset.Relations.Add(new DataRelation("Pessoas_FK_Notas", colunaPk, colunaFk));

            gridPessoas.DataSource = new BindingSource(_dataset, "Pessoas");
            gridNotas.DataSource = new BindingSource(gridPessoas.DataSource, "Pessoas_FK_Notas");
        }
    }

    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int? Pai { get; set; }
    }
}
