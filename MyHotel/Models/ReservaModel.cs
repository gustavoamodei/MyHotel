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
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
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
                item.Entrada = DateTime.Parse(dt.Rows[i]["entrada"].ToString());
                item.Saida = DateTime.Parse(dt.Rows[i]["saida"].ToString());
                item.Status = dt.Rows[i]["status"].ToString();
                lista.Add(item);
            }

            return lista;


        }

        public bool verificar_Autorizacao_reserva(int id_cliente)
        {
            
                string sql2 = $"select id from cliente where id={id_cliente}";
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql2);
                 if(dt.Rows.Count > 0){
                     int cliente_existe = int.Parse(dt.Rows[0]["id"].ToString());
                    return true;
                }       
               

                    string sql = $"select cliente_id from reserva where status = 'Ativo' and cliente_id = {id_cliente}";
                    DAL objDAL2 = new DAL();
                    DataTable dt2 = objDAL.RetDataTable(sql);
                if (dt2.Rows.Count > 0)
                {
                    int reservaExiste = int.Parse(dt2.Rows[0]["cliente_id"].ToString());
                    return true;
                }
                    return false;
              
         
        }
          
           
        

        public void Insert()
        {

            bool autorizado = verificar_Autorizacao_reserva(Cliente_id);
            if (autorizado == true)
            {

                string sql2 = $"insert into Reserva (cliente_id,quarto_id,entrada,saida,staus) values('{Cliente_id}','{Quarto_id}','{Entrada}','{Saida}','Ativo')";
                DAL data = new DAL();
                data.ExecutarComandoSQL(sql2);
            }
           
        }

    }
}
