using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyHotel.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a Nome !")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a cpf !")]
        //[StringLength(11, MinimumLength = 11,ErrorMessage ="cpf deve conter 11 caracteres")]
        [RegularExpression(@"^\d{3}.\d{3}.\d{3}-\d{2}$", ErrorMessage = "cpf deve conter o padrão 111.111.111-11")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Informe a Estado !")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Informe a Cidade !")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Informe o celular !")]
       
        [RegularExpression(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage= "o padrão é (xx) xxxxx-xxxx ou somente números")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Informe a Endereco !")]
        public string Endereco { get; set; }


        public void Insert()
        {

            string sql2 = $"select nome from estados where id ={Estado}";
           
            DAL data2 = new DAL();
            DataTable dt =  data2.RetDataTable(sql2);
            string estadoNome = dt.Rows[0]["nome"].ToString();

            string sql = $"insert into cliente (nome,cpf,estado,cidade,celular,endereco) values('{Nome}','{Cpf}','{estadoNome}','{Cidade}','{Celular}','{Endereco}')";
            DAL data = new DAL();
            
            
            data2.ExecutarComandoSQL(sql2);
            data.ExecutarComandoSQL(sql);
        }

        public List<ClienteModel> ListarClientes()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            string sql = "select * from cliente"; 
            DAL data = new DAL();
            DataTable dt = data.RetDataTable(sql);
            for (int i = 0;i<dt.Rows.Count;i++)
            {
                item = new ClienteModel();
                item.Id = int.Parse(dt.Rows[i]["id"].ToString());
                item.Nome = dt.Rows[i]["nome"].ToString();
                item.Celular = dt.Rows[i]["celular"].ToString();
                item.Estado = dt.Rows[i]["estado"].ToString();
                item.Cidade = dt.Rows[i]["cidade"].ToString();
                lista.Add(item);
            }

            return lista;
        }    

        public List<ClienteModel> PopulaCidades(int estado)
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


        public List<ClienteModel> PopulaEstados()
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
