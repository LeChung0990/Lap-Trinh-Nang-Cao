using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.IO.Ports;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] baud = { "9600", "19200", "57600", "115200" };
        string[] databit = { "5", "6", "7", "8" };
        public int tong;
        public int x, y, z, t, u;
        public string data = "";
        double[] thoigian = new double[256];
        double[] dulieu = new double[256];
        private void Form1_Load(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Bieu do";
            myPane.YAxis.Title.Text = "Level";
            myPane.XAxis.Title.Text = "Timer";

            RollingPointPairList list1 = new RollingPointPairList(2000);
            RollingPointPairList list2 = new RollingPointPairList(2000);

            LineItem duongline1 = myPane.AddCurve("Level", list1, Color.Black, SymbolType.None);
            LineItem duongline2 = myPane.AddCurve("Level", list2, Color.Red, SymbolType.None);

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 256;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 1;

            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 10;
            myPane.YAxis.Scale.MinorStep = 1;
            myPane.YAxis.Scale.MajorStep = 1;

            zedGraphControl1.AxisChange();

            string[] myport = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(myport);
            comboBox2.Items.AddRange(baud);
            comboBox5.Items.AddRange(databit);
            comboBox3.Items.AddRange(Enum.GetNames(typeof(Parity)));

        }
        public void draw(double line1, double line2)
        {
            LineItem duongline1 = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            LineItem duongline2 = zedGraphControl1.GraphPane.CurveList[1] as LineItem;
            if (duongline1 == null)
                return;
            if (duongline2 == null)
                return;
            IPointListEdit list1 = duongline1.Points as IPointListEdit;
            IPointListEdit list2 = duongline2.Points as IPointListEdit;
            if (list1 == null)
                return;
            if (list2 == null)
                return;

            list1.Add(tong, line1);
            list2.Add(tong, line2);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            tong += 2;

        }

        private void BTNConnect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text;
                //serialPort1.BaudRate = int.Parse(comboBox2.Text);
                //serialPort1.DataBits = int.Parse(comboBox5.Text);
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                //serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), comboBox3.Text);
                //serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits ), comboBox4.Text);
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Open();
                progressBar1.Value = 100;
                BTNConnect.Enabled = false;
                BTNDisconnect.Enabled = true;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BTNDisconnect_Click(object sender, EventArgs e)
        {
            try
            { 
                serialPort1.Close();
                progressBar1.Value = 0;
                BTNConnect.Enabled = true;
                BTNDisconnect.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public override string ToString()
        {
            return y.ToString() + z.ToString() + t.ToString() + u.ToString();
        }
        //    //Invoke(new MethodInvoker(() => listBox1.Items.Add(data)));
        //    //Invoke(new MethodInvoker(() => draw(int.Parse(data), int.Parse(data))));
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //if (serialPort1.ReadExisting() == "S")
            //{
            //for (int i = 0; i < 10; i++)
            //{
            //    if (serialPort1.ReadExisting() != "")
            //    {
            //        if (i / 2 == 0)
            //        {
            //for(int i=0; i < 10; i++)
            //{

            x = serialPort1.ReadByte();
            if (x == 255) //tin hieu bat dau
            {
                for(int i = 0; i <256; i++)
                {
                    thoigian[i] = serialPort1.ReadByte();
                    dulieu[i] = serialPort1.ReadByte();
                }
                
            } 
            //data = x.ToString() + y.ToString() + z.ToString();

        }

        double[] xs = {0,1,2,3,4,5,6,7,8,9,10,0,1,2,3,4,5,6};
        double[] ys1 = {0,0,1,1,0,0,1,1,0,0,0,0,1,1,1,0,0,1,1 };
        
        private void BTNSend_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            var curve1 = zedGraphControl1.GraphPane.AddCurve("Series A",thoigian, dulieu, Color.Blue);
            curve1.Line.IsAntiAlias = true;
            curve1.Symbol.IsVisible = false;

            zedGraphControl1.GraphPane.Title.Text = "Bieu do";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Level";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Timer";

            zedGraphControl1.GraphPane.XAxis.ResetAutoScale(zedGraphControl1.GraphPane, CreateGraphics());
            zedGraphControl1.GraphPane.YAxis.ResetAutoScale(zedGraphControl1.GraphPane, CreateGraphics());
            zedGraphControl1.Refresh();


        }

        private void BTNRun_Click(object sender, EventArgs e)
        {
            serialPort1.Write("a");

            //data = serialPort1.ReadExisting();
            //x = (serialPort1.ReadByte()) - 48;
            //data = x.ToString();
        }


    }
}
