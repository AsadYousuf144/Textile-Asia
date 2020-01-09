using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
//using System.Data.OleDb.OleDbConnection;
using System.Configuration;
using System.Drawing.Printing;
namespace Textile_Asia
{
    public partial class Desc : Form
    {
        public Desc()
        {
            InitializeComponent();
        }

       // SqlConnection con = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=Textile;User ID=sa;Password=ecg");

        SqlConnection con = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=March_Events;Persist Security Info=True;User ID=sa;Password=ecg");

        //SqlConnection con = new SqlConnection(@"Data Source=192.168.99.143;Initial Catalog=March_Events;Persist Security Info=True;User ID=sa;Password=ecg");

        SqlDataReader reader;
        private void Info_Load(object sender, EventArgs e)
        {
         //   label1.Text = Form1.ab;

          //  label1.Text = Companies.ab;
            //this.Close();

            Call();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Call() {

            try
            {
                con.Open();
                label1.Text = Companies.ab;
                SqlCommand command = new SqlCommand("select Email, Website,Country, Description from ITIF where Company = '" + Companies.ab + "' ;", con);
                reader = command.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                {

                    label4.Text = "-----";
                }
                else
                {
                    label4.Text = reader.GetString(0);
                }

                if (reader.IsDBNull(1))
                {

                    label6.Text = "-----";
                }
                else
                {
                    label6.Text = reader.GetString(1);
                }

                if (reader.IsDBNull(2))
                {

                    label8.Text = "-----";
                }
                else
                {
                    label8.Text = reader.GetString(2);
                }
                if (reader.IsDBNull(3))
                {

                    label9.Text = "-----";
                }
                else
                {
                    if (label9.Size.Width == 30)
                    {
                        //label9.Text = Environment.NewLine;
                        label9.Text = "Multi-line \r\n label";
                    }






                    label9.Text = reader.GetString(3);
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            reader.Close();
            con.Close();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
