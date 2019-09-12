using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Teste_TAG_SERIAL
{
    // classe com funcao para criar base de dados e duas tabelas: de registro e de instrucoes

    class Database
    {
        //CONEXAO COM BANCO DE DADOS
        public static MySqlConnection Conexao;

        //FUNCAO RESPONSAVEL POR INSTRUÇÕES A SEREM EXECUTADAS
        public static MySqlCommand Comando;

        //INSERIR DADOS NO DATATABLE
        public static MySqlDataAdapter Adaptador;

        //LIGA BANCO DE DADOS COM DATASOURCE
        public static DataTable datTabela;

        public static void conectar()
        {   // estabelece parametros para conexao c banco
            Conexao = new MySqlConnection("server=localhost; uid=root;pwd=tcc2019");

            // abre a conexao c banco de dados
            Conexao.Open();

            // informa a instrucao no MySql
            Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS bd_projeto; use bd_projeto", Conexao);

            // executa a query no MySql
            Comando.ExecuteNonQuery();

            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS registro" +
                "(id integer auto_increment primary key, " + "cor char(40)," + "entrada char(40))", Conexao);
                        
            Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS instrucao" +
                "(id integer auto_increment primary key," + "cor char(40)," + "atuadores char(40))", Conexao);

            Comando.ExecuteNonQuery();

            

            Conexao.Close();
        }

       
    }
}

