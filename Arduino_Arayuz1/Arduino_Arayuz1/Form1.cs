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


namespace Arduino_Arayuz1
{
    public partial class Form1 : Form
    {
        arduinoEntities db = new arduinoEntities();
        String[] portlistesi;
        bool baglanti_durumu = false;
        private Timer myTimer = new Timer();
        public Form1()
        {
            InitializeComponent();
        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            gettblsensör();
            gettblesik();
            esikgonder();
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
        void gettblesik()
        {
            dataGridView1.DataSource = db.tblesik.ToList();
        }
        void gettblsensör()
        {
            //dataGridView2.DataSource = db.tblsensör.OrderByDescending(x=>x.zaman).Take(30).ToList();
            dataGridView2.DataSource = db.birlestirme().Take(10).ToList();
        }
        public void esikgonder()
        {
            var sorgu = db.tblesik.Find(1);
            int esik = Convert.ToInt32(sorgu.esikdegeri) / 200 ;
            //MessageBox.Show(esik.ToString());
            serialPort1.Write(esik.ToString());
            //veri alma kısmı
            var data = serialPort1.ReadLine();
            var asci = Convert.ToInt32(data);
            char karakter = Convert.ToChar(asci);
            label3.Text = karakter.ToString();
            String[] renkler = { "Mavi", "Yeşil", "Sönük", "Mor", "Sarı", "Beyaz" };
            label4.Text = renkler[Convert.ToInt32(label3.Text)];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gettblesik();
            portlistele();
            gettblsensör();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var sorgu = db.tblesik.Find(1);
            sorgu.esikdegeri = Convert.ToInt32(textBox1.Text);
            db.SaveChanges();
            //esikgonder();
            MessageBox.Show("esik degeri güncellendi");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            portlistele();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            var sorgu = db.tblesik.Find(1);
            if (baglanti_durumu == false)
            {
                serialPort1.PortName = comboBox1.GetItemText(comboBox1.SelectedItem);
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                comboBox1.Enabled = false;
                button4.Enabled = false;
                baglanti_durumu = true;
                button5.Text = "Baglantiyi Kes";
                //timer
                myTimer.Interval = 1000; // 1 saniyede bir çalıştır
                myTimer.Tick += new EventHandler(myTimer_Tick);
                myTimer.Enabled = true;
            }
            else
            {
                serialPort1.Close();
                baglanti_durumu = false;
                button4.Enabled=true;
                button5.Text = "Baglan";
                comboBox1.Enabled = true;
                myTimer.Enabled=false;
            }
        }

    




    }
}
