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
using System.IO;

namespace Teste_TAG_SERIAL
{
    public static class Funcional
    {
        public static Atividade PedirAtividade(string pCor)
        {
          
            string retornoconsulta;
            //acessar cor da nova peca peca1
            retornoconsulta = Informacao.ConsultarAtividade(pCor);
            Atividade ativ1 = new Atividade(retornoconsulta);
            // criar try catch que retorna uma atividade default caso o retornoconsulta seja algo invalido
            return ativ1;
        }

        //public static void IniciarTemp(Boolean)
        //{
        //criar tag de deteccao de peca

        //}



        public static void Atualizar()
        {            
            //verificar se ha atualizacao; comparar arquivo novo com antigo (data de modif) e instalar atualizacao

            // pega o arquivo mais novo da pasta
            string Folder = @"C:\Users\moniz\Documents\POLI\TCC\AppFinal\PacoteTXT\";
            var files = new DirectoryInfo(Folder).GetFiles("*.*");
            string latestfile = "";
                        
            DateTime lastupdated = DateTime.MinValue;

            foreach (FileInfo file in files)
            {

                if (file.LastWriteTime > lastupdated)
                {
                    lastupdated = file.LastWriteTime;
                    latestfile = file.Name;

                }

            }

            //le o que está dentro do arquivo txt 
            string content = File.ReadAllText(@"C:\Users\moniz\Documents\POLI\TCC\AppFinal\PacoteTXT\" + latestfile, Encoding.UTF8);
                        
            Console.WriteLine("LatestFileName:" + latestfile);
            Console.WriteLine("Conteudo:" + content);
            Console.ReadLine();
        }

       
    }
}
