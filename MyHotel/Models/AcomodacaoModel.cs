using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyHotel.Models
{
    public class AcomodacaoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Numero { get; set; }
        public string Disponibilidade { get; set; }
        public string Descricao { get; set; }

        public List<AcomodacaoModel> ListarAcomodacao()
        {
            List<AcomodacaoModel> lista = new List<AcomodacaoModel>();
            AcomodacaoModel item;
            string sql = "select * from quarto";
            DAL data = new DAL();
            DataTable dt = data.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new AcomodacaoModel();
                item.Id = int.Parse(dt.Rows[i]["id"].ToString());
                item.Nome = dt.Rows[i]["nome"].ToString();
                item.Preco = item.Preco = double.Parse(dt.Rows[i]["preco"].ToString());
                item.Numero = dt.Rows[i]["numero"].ToString();
                item.Descricao = dt.Rows[i]["descricao"].ToString();
                item.Disponibilidade = dt.Rows[i]["disponibilidade"].ToString();
                lista.Add(item);
            }

            return lista;
        }



        public void Insert()
        {

            string aux = Preco.ToString("C");
            string aux2 = aux.Replace(".", "");
            string PrecoFinal = aux2.Replace(",", ".");
            string preco_semSigla = PrecoFinal.Replace("R$", "");
            if (Id == 0)
            {

                string sql = $"insert into quarto (nome,preco,descricao,numero,disponibilidade) values('{Nome}','{preco_semSigla}','{Descricao}','{Numero}','{Disponibilidade}')";
                DAL data = new DAL();
                data.ExecutarComandoSQL(sql);
            }
            else
            {
                string sql = $"update  quarto set nome='{Nome}',preco='{preco_semSigla}',descricao= '{Descricao}',numero = '{Numero}',disponibilidade = '{Disponibilidade}' where id = '{Id}'";
                DAL data = new DAL();
                data.ExecutarComandoSQL(sql);
            }
        }

        public AcomodacaoModel CarregarAcomodacao(int? id)
        {
            AcomodacaoModel item = new AcomodacaoModel();

            string sql = $"SELECT  id,nome,numero,descricao,disponibilidade,preco from quarto where id = '{id}'";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            item.Id = int.Parse(dt.Rows[0]["id"].ToString());
            item.Nome = dt.Rows[0]["nome"].ToString();
            item.Numero = dt.Rows[0]["numero"].ToString();
            item.Preco = double.Parse(dt.Rows[0]["preco"].ToString());
            item.Descricao = dt.Rows[0]["descricao"].ToString();
            item.Disponibilidade = dt.Rows[0]["disponibilidade"].ToString();
            return item;
        }

         public void ExcluirAcomodacao(string id)
        {
            string sql = $"delete from quarto where id = '{id}'";

            DAL data = new DAL();
            data.ExecutarComandoSQL(sql);


        }

    }
}
