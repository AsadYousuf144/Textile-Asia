﻿using System;
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
    public partial class Stalls : UserControl
    {
        public Stalls()
        {
            InitializeComponent();
        }

        //SqlConnection con = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=Textile;User ID=sa;Password=ecg");

        SqlConnection con = new SqlConnection(@"Data Source=ASAD-PC;Initial Catalog=March_Events;Persist Security Info=True;User ID=sa;Password=ecg");

        //SqlConnection con = new SqlConnection(@"Data Source=192.168.99.143;Initial Catalog=March_Events;Persist Security Info=True;User ID=sa;Password=ecg");
        
        public static string xy = "";

        private void Stalls_Load(object sender, EventArgs e)
        {

        }

        protected void l1_MouseEnter(object sender, EventArgs e)
        {
            //string cName = ((Label)sender).Name;
            Label lbl = sender as Label;
            // MessageBox.Show(cName.ToString());
            lbl.Font = new Font(lbl.Font.Name, lbl.Font.SizeInPoints, FontStyle.Underline);
        }

        protected void l1_MouseLeave(object sender, EventArgs e)
        {
            //string cName = ((Label)sender).Name;
            Label lbl = sender as Label;
            // MessageBox.Show(cName.ToString());
            lbl.Font = new Font(lbl.Font.Name, lbl.Font.SizeInPoints, FontStyle.Regular);
        }

        protected void l1_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("ECG");
            Label c = sender as Label;
            xy = c.Name.ToString();
            Stall_desc s = new Stall_desc();
            s.Show();

        }

        public void Stall()
        {

            int a = 8;
            try
            {
                con.Open();

                SqlCommand command = new SqlCommand("select distinct Stall from ITIF;", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Label l0 = new Label();
                    l0.Location = new Point(85, a);
                    // l0.BackColor = System.Drawing.ColorTranslator.FromHtml("#cccccc");
                    l0.Font = new System.Drawing.Font("Segoe UI Semibold", 14);
                    l0.Size = new Size(630, 25);
                    l0.ForeColor = System.Drawing.ColorTranslator.FromHtml("#189EE3");
                    l0.AutoEllipsis = true;
                    l0.UseMnemonic = false;



                    if (reader.IsDBNull(0))
                    {
                        l0.Text = "-----";
                    }
                    else
                    {
                        l0.Text = reader.GetString(0);
                    }

                    this.Controls.Add(l0);
                    panel1.Controls.Add(l0);



                    Label l1 = new Label();
                    l1.Location = new Point(120, a + 30);
                    l1.Text = "Show Details";
                    l1.Font = new System.Drawing.Font("Segoe UI Semibold", 12);
                    l1.Size = new Size(103, 25);
                    // l1.BackColor = System.Drawing.ColorTranslator.FromHtml("#cccccc");
                    l1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E74C3C");
                    l1.AutoEllipsis = true;
                    l1.UseMnemonic = false;

                    l1.MouseEnter += new EventHandler(l1_MouseEnter);
                    l1.MouseLeave += new EventHandler(l1_MouseLeave);
                    l1.Click += new EventHandler(l1_Click);
                    l1.Name = reader.GetString(0);

                    //if (reader.IsDBNull(1))
                    //{
                    //    l1.Text = "-----";
                    //}
                    //else
                    //{
                    //    l1.Text = reader.GetString(1);
                    //}

                    this.Controls.Add(l1);
                    panel1.Controls.Add(l1);


                    PictureBox pb3 = new PictureBox();
                   // pb3.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\d1.png"));
                    pb3.Image = Properties.Resources.d1;

                   // pb3.Image = Properties.Resources.Logo;

                    // panel1.Controls.Add(pb3);
                    pb3.Location = new Point(223, a + 38);
                    pb3.Size = new Size(18, 18);

                    this.Controls.Add(pb3);
                    panel1.Controls.Add(pb3);


                    PictureBox pb4 = new PictureBox();
                   // pb4.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\L12.png"));
                    pb4.Image = Properties.Resources.L12;
                    // panel1.Controls.Add(pb3);
                    // pb4.BackColor = System.Drawing.ColorTranslator.FromHtml("#cccccc");

                    pb4.Location = new Point(5, a + 60);
                    pb4.Size = new Size(725, 18);

                    this.Controls.Add(pb4);
                    panel1.Controls.Add(pb4);



                    PictureBox pb6 = new PictureBox();
                   // pb6.Image = Image.FromFile(string.Format(@"C:\Users\Asad\Downloads\B1.png"));
                    pb6.Image = Properties.Resources.B1;

                    // panel1.Controls.Add(pb3);
                    pb6.Location = new Point(20, a - 2);
                    pb6.Size = new Size(55, 55);

                    this.Controls.Add(pb6);
                    panel1.Controls.Add(pb6);



                    a = a + 80;
                }
                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
