using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schoolProject
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\school.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select *  from std where name='"+textBox1.Text.ToString()+"' and age='"+textBox2.Text.ToString()+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                CS c = new CS();
                c.Show();
                this.Hide();
            }
            else
            {

            }

            con.Close();
        }
    }
}
