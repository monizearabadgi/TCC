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
    public static class Comunicacao
    {
        public static void Atualizar()
        {
            //Informacao.mockAtualizar();
           
        }
        public static void RunSystem(opcClient pOpc)
        {
            Console.WriteLine("passou");

            // Inicia Stopper e esteira

            opcClientGroup groupAtua = pOpc.GetGroupByName("Atuadores");
            Console.WriteLine("passou2");
            groupAtua.GetItemById("A016").Write("0");//Aciona stopper
            Console.WriteLine("passou3");
            groupAtua.GetItemById("A013").Write("1");//Aciona esteira

            System.Threading.Thread.Sleep(5000); // wait

            // Inicia Comunicação e le sensores cor
            opcClientGroup groupSen = pOpc.GetGroupByName("Sensores");
            string ESTEIRA1 = groupSen.GetItemById("S016").Read();
            string ESTEIRA2 = groupSen.GetItemById("S017").Read();
            string ESTEIRA3 = groupSen.GetItemById("S019").Read();
            string Cor;

            //definição das cores pela leitura dos sensores           
            if (ESTEIRA2 == "-1" && ESTEIRA3 == "0")
            {
                Cor = "ROSA";
            }

            else if (ESTEIRA2 == "-1" && ESTEIRA3 == "-1")
            {
                Cor = "PRATA";
            }
            else
            {
                Cor = "PRETA";
            }

            //Atribui ao objeto Peca a cor detectada
            Peca peca1 = new Peca(Cor);

            //faz o registro da peça que chegou
            Informacao.Registra(Cor);

            ////Comando para inserir dados na tabela
            //Database.Comando = new MySqlCommand("INSERT INTO registro (id, cor, entrada) values (null, ?, ?)", Database.Conexao);

            ////inserir parametros de cor e hora 

            //Database.Comando.Parameters.Add("@cor", MySqlDbType.VarChar, 40).Value = Cor;
            //Database.Comando.Parameters.Add("@entrada", MySqlDbType.VarChar, 40).Value = DateTime.Now.ToString("h:mm:ss tt");

            //Database.Comando.ExecuteNonQuery();

            // comunicação com a camada informação
            //Pedido de atualização

            Atividade comandos_At;
            string comando;
            char[] listacomando;

            comandos_At=Informacao.mockPedirAtividade(Cor);
            comando = comandos_At.Descricao;
            //Quebra em comandos individuais
            listacomando = comando.ToCharArray();
            string pos0 = Char.ToString(listacomando[0]);
            string pos1 = Char.ToString(listacomando[1]);



            //passar comando p atuadores
            
            groupAtua.GetItemById("A014").Write(pos0);//Separador 1
            groupAtua.GetItemById("A015").Write(pos1);//Separador 2


            groupAtua.GetItemById("A016").Write("1");//STOPPER

            //Ler sensor de saida
            string SENSOR_SAIDA="0";
            while (SENSOR_SAIDA == "0")
            {
                SENSOR_SAIDA= groupSen.GetItemById("S018").Read();
                Console.WriteLine(SENSOR_SAIDA);
            }

           
            // Caso sensor seja 1, retorna todos os atuadores
            groupAtua.GetItemById("A013").Write("0");//Desliga esteira
            groupAtua.GetItemById("A014").Write("0");//Retorna Separador 1
            groupAtua.GetItemById("A015").Write("0");//Retorna Separador 2
            groupAtua.GetItemById("A016").Write("0");//Ligar stopper
            
        }

        
        

    }
}

