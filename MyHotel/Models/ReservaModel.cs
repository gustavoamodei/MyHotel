using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyHotel.Models
{
    public class ReservaModel
    {
        public int Id { get; set; }
        public int Cliente_id { get; set; }
        public int Quarto_id { get; set; }
        public string Entrada { get; set; }
        public string Saida { get; set; }
        public string Nome_Cliente { get; set; }
        public string Numero_quarto { get; set; }
        public string Nome_quarto { get; set; }
        public string Status { get; set; }

        public List<ReservaModel> ListaAcomodacao()
        {
            List<ReservaModel> lista = new List<ReservaModel>();
            ReservaModel item;
            DAL data = new DAL();
            string sql = "select id,nome,numero from quarto where disponibilidade = 'Disponível'";
            DataTable dt = data.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ReservaModel();
               
                item.Nome_quarto = dt.Rows[i]["nome"].ToString();
                item.Numero_quarto = dt.Rows[i]["numero"].ToString();
                item.Quarto_id = int.Parse(dt.Rows[i]["id"].ToString());
                lista.Add(item);
            }

            return lista;


        }
        public List<ReservaModel> ListaReservasAtivas()
        {
            List<ReservaModel> lista = new List<ReservaModel>();
            ReservaModel item;
            DAL data = new DAL();
            string sql = "SELECT c.nome as Nome_cliente ,c.id as id_cliente,c.cpf,q.nome as nome_quarto,q.numero as numero_quarto,r.entrada as entrada,r.saida as saida,r.id as id_reserva,r.status as status from reserva as r INNER JOIN cliente as c on r.cliente_id = c.id INNER JOIN quarto as q on q.id = r.quarto_id where r.status = 'Ativo';";
            DataTable dt = data.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ReservaModel();

                item.Id = int.Parse(dt.Rows[i]["id_reserva"].ToString());
                item.Nome_quarto = dt.Rows[i]["nome_quarto"].ToString();
                item.Numero_quarto = dt.Rows[i]["numero_quarto"].ToString();
                item.Nome_Cliente = dt.Rows[i]["Nome_cliente"].ToString();
                item.Cliente_id = int.Parse(dt.Rows[i]["id_cliente"].ToString());
                item.Entrada = DateTime.Parse(dt.Rows[i]["entrada"].ToString()).ToString("dd/MM/yyyy");
                item.Saida = DateTime.Parse(dt.Rows[i]["saida"].ToString()).ToString("dd/MM/yyyy");
                item.Status = dt.Rows[i]["status"].ToString();
                lista.Add(item);
            }

            return lista;


        }

        public List<ReservaModel> ListaReservasCanceladas()
        {
            List<ReservaModel> lista = new List<ReservaModel>();
            ReservaModel item;
            DAL data = new DAL();
            string sql = "SELECT c.nome as Nome_cliente ,c.id as id_cliente,c.cpf,q.nome as nome_quarto,q.numero as numero_quarto,r.entrada as entrada,r.saida as saida,r.id as id_reserva,r.status as status from reserva as r INNER JOIN cliente as c on r.cliente_id = c.id INNER JOIN quarto as q on q.id = r.quarto_id where r.status = 'Inativo';";
            DataTable dt = data.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ReservaModel();

                item.Id = int.Parse(dt.Rows[i]["id_reserva"].ToString());
                item.Nome_quarto = dt.Rows[i]["nome_quarto"].ToString();
                item.Numero_quarto = dt.Rows[i]["numero_quarto"].ToString();
                item.Nome_Cliente = dt.Rows[i]["Nome_cliente"].ToString();
                item.Cliente_id = int.Parse(dt.Rows[i]["id_cliente"].ToString());
                item.Entrada = DateTime.Parse(dt.Rows[i]["entrada"].ToString()).ToString("dd/MM/yyyy");
                item.Saida = DateTime.Parse(dt.Rows[i]["saida"].ToString()).ToString("dd/MM/yyyy");
                item.Status = dt.Rows[i]["status"].ToString();
                lista.Add(item);
            }

            return lista;


        }

        public string Verificar_Autorizacao_reserva(int id_cliente)
        {
                

                    string sql = $"select cliente_id from reserva where status = 'Ativo' and cliente_id = {id_cliente}";
                    DAL objDAL = new DAL();
                    DataTable dt = objDAL.RetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    int reservaExiste = int.Parse(dt.Rows[0]["cliente_id"].ToString());
                    return "Existe uma reserva em andamento para este cliente";
                }
                    return "";
              
         
        }

        public string Verifica_Cliente_Valido(int id_cliente)
        {
            string sql2 = $"select id from cliente where id={id_cliente}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql2);
            if (dt.Rows.Count > 0)
            {
                int cliente_existe = int.Parse(dt.Rows[0]["id"].ToString());
                return "";
            }
            return "Cliente não existe ou não está cadastrado";
        }
          
           
        

        public void Insert()
        {
            

            string e = DateTime.Parse(Entrada).ToString("yyyy-MM-dd");
            string s = DateTime.Parse(Saida).ToString("yyyy-MM-dd");


            
            string sql = $"insert into Reserva (cliente_id,quarto_id,entrada,saida,status) values('{Cliente_id}','{Quarto_id}','{e}','{s}','ativo')";
                DAL data = new DAL();
                data.ExecutarComandoSQL(sql);

            string sql2 = $"update quarto set disponibilidade = 'Indisponivel' where id = '{Quarto_id}'";
            DAL data2 = new DAL();
            data2.ExecutarComandoSQL(sql2);


            double precoHospedagem = CalculaValorHospedagem(e,s,Quarto_id);
            string sql3 = $"insert into conta (cliente_id,quarto_id,data,total,status) values ('{Cliente_id}','{Quarto_id}','{e}',{precoHospedagem},'Aberto')";
            DAL data3 = new DAL();
            data3.ExecutarComandoSQL(sql3);

            int id_conta = UltimoIdInseridoReserva();

            string sql4 = $"insert into detalheconta (conta_id,alimento_id,alimento_valor,total) values ('{id_conta}',0,0,0)";
            DAL data4 = new DAL();
            data4.ExecutarComandoSQL(sql4);

        }

        public int Verifica_id_quarto_da_Reserva(int id_reserva)
        {
            string sql2 = $"select quarto_id from reserva where id={id_reserva}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql2);
            if (dt.Rows.Count > 0)
            {
                int quarto_id = int.Parse(dt.Rows[0]["quarto_id"].ToString());
                return quarto_id;
            }
            return 0;
        }

        public void CancelarReserva(int id_reserva)
        {
            string sql = $"update reserva set status = 'Inativo' where id = '{id_reserva}'";

            DAL data = new DAL();
            data.ExecutarComandoSQL(sql);
             int quarto_id = Verifica_id_quarto_da_Reserva(id_reserva);

            string sql2 = $"update quarto set disponibilidade = 'Disponível' where id = '{quarto_id}'";
            DAL data2 = new DAL();
            data2.ExecutarComandoSQL(sql2);


            string sql3 = $"update  conta set status = 'Cancelado' where quarto_id = '{quarto_id}'";
            DAL data3 = new DAL();
            data3.ExecutarComandoSQL(sql3);
        }

        public double CalculaValorHospedagem(string entrada,string saida,int quarto_id)
        {
            double preco_quarto = 0;
            DateTime dataSaida = DateTime.Parse(saida);
            var aux = dataSaida.Subtract(DateTime.Parse(entrada));
            var total_diass = aux.TotalDays;


            string sql2 = $"select preco from quarto where id={quarto_id}";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql2);
            if (dt.Rows.Count > 0)
            {
                preco_quarto = double.Parse(dt.Rows[0]["preco"].ToString());
                
            }

            return preco_quarto * total_diass;
        }

        public int UltimoIdInseridoReserva()
        {

            string sql2 = "Select MAX(id) From conta";
            DAL objDAL = new DAL();
            int id =  objDAL.ExecuteEscalar(sql2);
            return id;
        }

    }
}
