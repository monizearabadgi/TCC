using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient; // to use MySQL connection to database
using System.Xml; // To read XML archive
using opcconn; // To connect to OPC server
using System.Threading;

namespace Teste_TAG_SERIAL
{
    public partial class Form1 : Form
    {
        // Global Variables
        string RxString; //String to receive data from serial ports
        string connetionString; //String to connect to database
        string Log; //String to save information to be printed
        int processCount = 2; //int to show which process is the next one
        string ID; // tags ID
        string process;// saves the next process to be done
        //MySqlConnection cnn;// Connection object 
        //MySqlCommand command;// Commnand object
        private XmlDocument xmlDoc; // Xml document
        public opcClient opc; // OPC Client
        bool read = false;// shows when the serial is read
        int serial = 0;// shows which serial read the tag
       

        public Form1()
        {
            InitializeComponent(); // Initializing forms
        }

        // Execute when forms shown
        private void Form1_Shown(object sender, EventArgs e)
        {
            // Log
            textBox2.AppendText("Initializing components...\n");
            // Loading XML
            //CarregaXml();
            //// Connect to OPC Server
            //ConnectOpc();
            // Connect to Database
            //ConnectDatabase();
        }


        //function to create a log text and call a new thread to print logs
        private void createLog(string text, int textBox)
        {
            //using textBox1
            if (textBox == 1)
            {
                Log = text;
                this.Invoke(new EventHandler(printLogTextBox1));

            }
            //using textBox2
            else if (textBox == 2)
            {
                Log = text;
                this.Invoke(new EventHandler(printLogTextBox2));
            }
            //warning to wrong textBox
            else
            {
                MessageBox.Show("This TextBox does not exist");
            }
        }

        //Function to print texts on the textBoxes
        private void printLogTextBox2(object sender, EventArgs e)
        {
            //printing Log            
            textBox2.AppendText(Log);            
        }

        private void printLogTextBox1(object sender, EventArgs e)
        {
            //printing Log
            textBox1.Text = Log;
        }


        // Execute when text in textBox2 changes
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // do nothing
        }

        //private void CarregaXml()
        //{
        //    xmlDoc = new XmlDocument();
        //    xmlDoc.Load(@"C:\Users\moniz\Documents\POLI\TCC\AppFinal\XML\opcConfigSorting.xml");
        //    createLog("XML loaded...\n", 2);
        //}

        //private void ConnectOpc()
        //{
        //    int i = 0;

        //    XmlNode xmlServer = xmlDoc.GetElementsByTagName("server")[0];
        //    opc = new opcClient(xmlServer.Attributes.GetNamedItem("name").Value);
        //    if (opc.ErrorMessage.Length > 0)
        //    {
        //        opc.Dispose();
        //    }
        //    else
        //    {
        //        foreach (XmlNode xmlGroup in xmlServer.SelectNodes("group"))
        //        {
        //            opc.AddGroup(xmlGroup.Attributes.GetNamedItem("name").Value);
        //            if (opc.ErrorMessage.Length == 0)
        //            {
        //                foreach (XmlNode xmlItem in xmlGroup.SelectNodes("item"))
        //                {
        //                    opc.GetGroupByPosition(i).AddItem(xmlItem.Attributes.GetNamedItem("id").Value, xmlItem.Attributes.GetNamedItem("memory").Value);

        //                    if (opc.GetGroupByPosition(i).ErrorMessage.Length > 0)
        //                    {
        //                        MessageBox.Show(opc.GetGroupByPosition(i).ErrorMessage);
        //                    }
        //                }
        //                i++;
        //               }
        //            else
        //            {
        //                MessageBox.Show(opc.ErrorMessage);
        //            }
        //        }
        //        createLog("Conexão OPC montada...\n",2);
        //    }
        //}



        private void button1_Click(object sender, EventArgs e)
        {

            Comunicacao.Atualizar();
            Comunicacao.RunSystem(opc);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //opcClientGroup groupAt = opc.GetGroupByName("Atuadores");
            //groupAt.GetItemById("A013").Write("1");//Aciona esteira
            //opcClientGroup groupSen = opc.GetGroupByName("Sensores");
            //string ESTEIRA1 = groupSen.GetItemById("S016").Read();
            //string ESTEIRA2 = groupSen.GetItemById("S017").Read();
            //string ESTEIRA3 = groupSen.GetItemById("S019").Read();
            //string Cor;



            //if (ESTEIRA2 == "-1" && ESTEIRA3 == "0")
            //{
            //    Cor = "ROSA";
            //}

            //else if (ESTEIRA2 == "-1" && ESTEIRA3 == "-1")
            //{
            //    Cor = "PRATA";
            //}
            //else
            //{
            //    Cor = "PRETA";
            //}

            //Peca peca1 = new Peca(Cor);
            //createLog(Cor, 2);

            // folder paths
           
            
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
                string content = File.ReadAllText(@"C:\Users\moniz\Documents\POLI\TCC\AppFinal\PacoteTXT\" + latestfile, Encoding.UTF8);
               
                

                Console.WriteLine("LatestFileName:" + latestfile);
                Console.WriteLine("Conteudo:" + content);
                Console.ReadLine();
            





        }

        private void button3_Click(object sender, EventArgs e)
        {
            //opcClientGroup groupAt = opc.GetGroupByName("Atuadores");
            //groupAt.GetItemById("A013").Write("0"); //Desliga esteira

            string text = File.ReadAllText(@"C:\Users\moniz\Documents\PacoteTXT\Teste1.txt", Encoding.UTF8);
            Console.WriteLine(text);

        }
    }
}


    

    


    
