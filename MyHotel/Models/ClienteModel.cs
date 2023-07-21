using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHotel.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public string Estado { get; set; }
        public string Cidade { get; set; }

        public string Celular { get; set; }

        public string Endereco { get; set; }


        public void insert()
        {
            string sql = $"insert into cliente values('{Nome}','{Cpf}','{Estado}','{Estado}','{Cidade}','{Celular}','{Endereco}')";
            DAL data = new DAL();
            data.ExecutarComandoSQL(sql);
        }


        public void populaCidades()
        {
            string sql = "select * from cidades";
        }

    }
}
