using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace Curreny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

     

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldocument = new XmlDocument();                          /*var tum degiskenleri icine alır int string*/
            xmldocument.Load(bugun);

            string dolarbuy = xmldocument.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            label2.Text = dolarbuy;

            string dolarsell = xmldocument.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblDolarSell.Text = dolarsell;

            string eurobuy = xmldocument.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lblEuroBuy.Text= eurobuy;

            string eurosell = xmldocument.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lblEuroSell.Text = eurosell;


        }

        private void lblDollarbut_Click(object sender, EventArgs e)
        {
            txtRate.Text = label2.Text;
        }

        private void lblDollarsellbut_Click(object sender, EventArgs e)
        {
            txtRate.Text = lblDolarSell.Text;
        }

        private void lblEurobuybt_Click(object sender, EventArgs e)
        {
            txtRate.Text = lblEuroBuy.Text;
        }

        private void lblEurosellbt_Click(object sender, EventArgs e)
        {
            txtRate.Text = lblEuroSell.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double rate, quantity, sum;
            rate=Convert.ToDouble(txtRate.Text);
            quantity = Convert.ToDouble(txtQuantity.Text);
            sum = rate * quantity;
            txtSum.Text = sum.ToString();



        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            txtRate.Text=txtRate.Text.Replace(".",",");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           double rate= Convert.ToDouble(txtRate.Text);
           double quantity=Convert.ToInt32(txtQuantity.Text);
           double sum =Convert.ToInt32(quantity / rate);
           txtSum.Text = sum.ToString();
           double remainder1;
           
           double sum2 = Convert.ToDouble(quantity / rate);
           remainder1 = sum - sum2;
           txtRemainder.Text = remainder1.ToString();
           



        }
    }
}
