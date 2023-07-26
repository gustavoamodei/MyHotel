using System;
using System.Collections.Generic;
using System.Data;
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
            string sql = $"insert into cliente (nome,cpf,estado,cidade,celular,endereco) values('{Nome}','{Cpf}','{Estado}','{Cidade}','{Celular}','{Endereco}')";
            DAL data = new DAL();
            data.ExecutarComandoSQL(sql);
        }


        public List<ClienteModel> populaCidades(int estado)
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            string sql = $"select * from cidades where id_estado = {estado}";
            DAL data = new DAL();
            DataTable dt =  data.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ClienteModel();
                item.Cidade = dt.Rows[i]["nome"].ToString();
                
                lista.Add(item);
            }
            return lista;
        }


        public List<ClienteModel> populaEstados()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            string sql = "select id,nome from estados";
            DAL data = new DAL();
            DataTable dt = data.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ClienteModel();
                item.Id = int.Parse((dt.Rows[i]["id"].ToString()));
                item.Estado = dt.Rows[i]["nome"].ToString();
              

                lista.Add(item);
            }
            return lista;
        }

    }
}
