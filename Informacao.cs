using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;  // to use serial ports connection
using MySql.Data.MySqlClient; // to use MySQL connection to database
using System.Xml; // To read XML archive
using opcconn; // To connect to OPC server
using System.Threading;

namespace Teste_TAG_SERIAL
{
    public static class Informacao
    {
        public static string ConsultarAtividade(string pCor)
        {
            // consulta atividade correspondente a cor por meio do MySQL
            Database.Adaptador = new MySqlDataAdapter("SELECT * FROM base_1.comandos", Database.Conexao);
            Database.Conexao.Open();

            DataSet ds = new DataSet();
            Database.Adaptador.Fill(ds, "comandos");
            DataGridView.

            string resposta = "10";
            return resposta;
        }

        public static void Registra(string pCor)
        {   //incluir peca no SQL

            Database.Comando = new MySqlCommand("INSERT INTO TABLE registro (cor,entrada) values (null, x, y)", Database.Conexao);
            Database.Comando.Parameters.Add("@cor", MySqlDbType.VarChar, 40).Value = pCor;
            Database.Comando.Parameters.Add("entrada", MySqlDbType.VarChar, 40).Value = DateTime.Now.ToString("h:mm:ss tt");

        }

        public static void EscreveAtividade(string nova_ativ)
        {
            //escrever nova atividade no banco de dados

        }

        public static Atividade mockPedirAtividade(string pCor)
        {
            
            return Funcional.PedirAtividade(pCor);
        }

        public static void mockAtualizar()
        {
            Funcional.Atualizar();

        } 
    }




}
