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
    public class Atividade
    {

        public string Descricao;
        public Atividade(string pDescricao)
        {

            Descricao = pDescricao;
        }

    }
}
