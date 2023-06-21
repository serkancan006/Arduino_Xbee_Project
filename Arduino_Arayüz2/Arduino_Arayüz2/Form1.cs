using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace Arduino_Arayüz2
{
    public partial class Form1 : Form
    {
        arduinoEntities db = new arduinoEntities();
        String[] portlistesi;
        bool baglanti_durumu = false;
        private Timer myTimer = new Timer();
        private string data;

        public Form1()
        {
            InitializeComponent();
           
        }
        private void myTimer_Tick(object sender, EventArgs e)
        {
            gettblsensör();
            inserttblsensör();
        }
        void portlistele()
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            portlistesi = SerialPort.GetPortNames();
            foreach (string port in portlistesi)
            {
                comboBox1.Items.Add(port);
                if (portlistesi[0] != null)
                {
                    comboBox1.SelectedItem = portlistesi[0];
                }
            }
        }
        void gettblsensör()
        {
            //dataGridView1.DataSource = db.tblsensör.OrderByDescending(x => x.zaman).Take(30).ToList();
            dataGridView1.DataSource = db.birlestirme().Take(10).ToList();
        }
        void inserttblsensör()
        {
            tblsensör t = new tblsensör();
            t.ad = "Mq2";
            t.deger = Convert.ToInt16(data);
            t.zaman = DateTime.Now;
            t.esikid = 1;
            db.tblsensör.Add(t);
            db.SaveChanges();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            portlistele();
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            gettblsensör();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (baglanti_durumu == false)
            {
                serialPort1.PortName = comboBox1.GetItemText(comboBox1.SelectedItem);
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                button4.Enabled = false;
                button5.Text = "Baglantiyi Kes";
                baglanti_durumu = true;
                //timer
                myTimer.Interval = 1000; // 1 saniyede bir çalıştır
                myTimer.Tick += new EventHandler(myTimer_Tick);
                myTimer.Enabled = true;
            }
            else
            {
                serialPort1.Close();
                button4.Enabled = true;
                button5.Text = "Baglan";
                comboBox1.Enabled = true;
                baglanti_durumu = false;
                //timer
                myTimer.Enabled = false;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            portlistele();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
        }

       

    }
}
