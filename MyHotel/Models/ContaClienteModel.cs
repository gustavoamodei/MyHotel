using System;
using System.Collections.Generic;
using System.Data;

namespace MyHotel.Models
{
    
    public class ContaClienteModel
    {
        public int Id { get; set; }
        public string Nome_cliente { get; set; }
        public string Soma_pedidos { get; set; }
        public string Numero_quarto { get; set; }
        public string Nome_quarto { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }
        public int quarto_id { get; set; }
        public int Id_alimento { get; set; }
        public string Alimento { get; set; }
        public string ValorAlimento { get; set; }

       
        public List<ContaClienteModel> ListaContaCliente()
        {
            List<ContaClienteModel> lista = new List<ContaClienteModel>();
            ContaClienteModel item;
            DAL data = new DAL();
            string sql = "SELECT co.id as conta_id,cl.nome as cliente_nome,q.nome as nome_quarto, q.numero as numero_quarto,co.status as status,co.total as total from conta as co " +
                "INNER JOIN cliente as cl on cl.id = co.cliente_id " +
                "INNER join quarto as q on q.id = co.quarto_id " +
                "where co.status = 'Aberto';";
            DataTable dt = data.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ContaClienteModel();
                
                item.Id = int.Parse(dt.Rows[i]["conta_id"].ToString());
                item.Nome_quarto = dt.Rows[i]["nome_quarto"].ToString();
                item.Numero_quarto = dt.Rows[i]["numero_quarto"].ToString();
                item.Status = dt.Rows[i]["status"].ToString();
                item.Nome_cliente = dt.Rows[i]["cliente_nome"].ToString();
                item.Total = double.Parse(dt.Rows[i]["total"].ToString());
                lista.Add(item);
            }
            return lista;

        }
        public List<ContaClienteModel> PopulaAlimento()
        {
            List<ContaClienteModel> lista = new List<ContaClienteModel>();
            ContaClienteModel item;
            string sql = "select id,nome,preco from alimento";
            DAL data = new DAL();
            DataTable dt = data.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ContaClienteModel();
                item.Id_alimento = int.Parse((dt.Rows[i]["id"].ToString()));
                item.Alimento = dt.Rows[i]["nome"].ToString();
                item.ValorAlimento =  dt.Rows[i]["preco"].ToString();

                lista.Add(item);
            }
            return lista;
        }

        public void InsertItem(string conta_id, int alimento_id, string alimento_valor)
        {
            string v = string.Format("{0:0.0.00}", alimento_valor);
            // double p = double.Parse(v);
            string sql = $"insert into detalheconta (conta_id,alimento_id,alimento_valor) values('{conta_id}','{alimento_id}','{v}')";

            DAL data = new DAL();

            data.ExecutarComandoSQL(sql);
        }

        public ContaClienteModel ListaContaHospedage(int id)
        {
            ContaClienteModel item = new ContaClienteModel();

            string sql = $"SELECT c.id as id,cli.nome as cliente,q.numero as numero_quarto,q.nome as nome_quarto,c.quarto_id as quarto_id,c.total as valor_hospedagem " +
                $"from conta c " +
                $"INNER JOIN cliente cli ON cli.id = c.cliente_id " +
                $"INNER JOIN quarto q on q.id = c.quarto_id " +
                $"WHERE c.id  = '{id}'";
            
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);


            item.Id = int.Parse(dt.Rows[0]["id"].ToString());
            item.Nome_cliente = dt.Rows[0]["cliente"].ToString();
            item.Total = double.Parse(dt.Rows[0]["valor_hospedagem"].ToString());
            item.Nome_quarto = dt.Rows[0]["nome_quarto"].ToString();
            item.Numero_quarto = dt.Rows[0]["numero_quarto"].ToString();
            item.quarto_id = int.Parse(dt.Rows[0]["quarto_id"].ToString());
            return item;
        }
        
        public List<ContaClienteModel> listaContaAlimento(int id)
        {
            List<ContaClienteModel> lista = new List<ContaClienteModel>();
            ContaClienteModel item;
            string sql = $"SELECT a.id as id,a.nome as nome,dc.alimento_valor as preco FROM detalheconta dc INNER JOIN  alimento a on a.id = dc.alimento_id where dc.conta_id = '{id}'";
            DAL data = new DAL();
            DataTable dt = data.RetDataTable(sql);
            double totalpedido = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ContaClienteModel();
                item.Id_alimento = int.Parse((dt.Rows[i]["id"].ToString()));
                item.Alimento = dt.Rows[i]["nome"].ToString();
                totalpedido = totalpedido + double.Parse( dt.Rows[i]["preco"].ToString());
                item.ValorAlimento = string.Format("{0:C}", double.Parse(dt.Rows[i]["preco"].ToString())) ;
                item.Soma_pedidos = totalpedido.ToString();
                lista.Add(item);
            }
            InsertValorotalAlimento(id, totalpedido);
            return lista;


        }

        public void InsertValorotalAlimento(int conta_id,double total)
        {

           
           string sql = $"update  detalheconta set total = '{total}' where conta_id = '{conta_id}'";

            DAL data = new DAL();

            data.ExecutarComandoSQL(sql);
        }

        public ContaClienteModel Totalped(int id)
        {
            ContaClienteModel item = new ContaClienteModel();

            string sql = $"select total from detalheconta WHERE conta_id  = '{id}'";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
            item.Soma_pedidos = string.Format("{0:N}", double.Parse(dt.Rows[0]["total"].ToString()));
            //string.Format("{0:C}", double.Parse(dt.Rows[0]["total"].ToString()));
            return item;
        }

        public void FinalizarConta(int quarto_id)
        {
            string sql1 = $"update  conta set status = 'Pago' where quarto_id = '{quarto_id}'";
            string sql2 = $"update  reserva set status = 'Inativo' where quarto_id = '{quarto_id}'";
            string sql3 = $"update  quarto set disponibilidade = 'Disponivel' where id = '{quarto_id}'";
            DAL data = new DAL();
           

            data.ExecutarComandoSQL(sql1);
            data.ExecutarComandoSQL(sql2);
            data.ExecutarComandoSQL(sql3);
        }
    }
}
