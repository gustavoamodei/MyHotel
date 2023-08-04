using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyHotel.Models
{
    public class CardapioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }


        public List<CardapioModel> ListarCardapio()
        {
            List<CardapioModel> lista = new List<CardapioModel>();
            CardapioModel item;
            string sql = "select * from alimento";
            DAL data = new DAL();
            DataTable dt = data.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new CardapioModel();
                item.Id = int.Parse(dt.Rows[i]["id"].ToString());
                item.Nome = dt.Rows[i]["nome"].ToString();
                item.Preco = double.Parse( dt.Rows[i]["preco"].ToString());
                item.Descricao = dt.Rows[i]["descricao"].ToString();
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
                 
                string sql = $"insert into alimento (nome,preco,descricao) values('{Nome}','{preco_semSigla}','{Descricao}')";
                DAL data = new DAL();
                data.ExecutarComandoSQL(sql);
            }
            else
            {
                string sql = $"update  alimento set nome='{Nome}',preco='{preco_semSigla}',descricao= '{Descricao}' where id = '{Id}'";
                DAL data = new DAL();
                data.ExecutarComandoSQL(sql);
            }
        }

        public CardapioModel CarregarCardapio(int? id)
        {
            CardapioModel item = new CardapioModel();

            string sql = $"SELECT  id,nome,preco,descricao from alimento where id = '{id}'";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            item.Id = int.Parse(dt.Rows[0]["id"].ToString());
            item.Nome = dt.Rows[0]["nome"].ToString();
            item.Preco = double.Parse( dt.Rows[0]["preco"].ToString());
            item.Descricao = dt.Rows[0]["Descricao"].ToString();

            return item;
        }

        public void ExcluirCardapio(string id)
        {
            string sql = $"delete from alimento where id = '{id}'";

            DAL data = new DAL();
            data.ExecutarComandoSQL(sql);


        }
    }
}
