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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\school.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
            show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.comboBox1.SelectedIndex= -1;
            this.textBox3.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String name = textBox1.Text.ToString();
                String ag = textBox2.Text.ToString();
                int age = Int32.Parse(ag);
                String district = comboBox1.SelectedItem.ToString();

                String qry = "update std set age='" + age + "',district = '" + district + "' where name='"+name+"'";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();

                if (i >= 1)
                {
                    MessageBox.Show(i + " student updated successfully: " + name);
                }
                else
                {
                    MessageBox.Show("Student no updated successfully: ");
                }
                Button1_Click(sender, e);
                show();


                con.Close();
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(" Error is " + exp.ToString());
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String name = textBox1.Text.ToString();
                String ag = textBox2.Text.ToString();
                int age = Int32.Parse(ag);
                String district = comboBox1.SelectedItem.ToString();

                String qry = "insert into std values('" + name + "','" + age + "','" + district + "')";
                SqlCommand sc = new SqlCommand(qry,con);
                int i = sc.ExecuteNonQuery();

                if (i >= 1)
                {
                    MessageBox.Show(i + " student registered successfully: " + name);
                }
                else
                {
                    MessageBox.Show("Student no registered successfully: ");
                }
                Button1_Click(sender, e);
                show();


                con.Close();
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(" Error is " + exp.ToString());
            }
        }
        void show()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from std",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
            }

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Age"].FormattedValue.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["District"].FormattedValue.ToString();
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String name = textBox1.Text.ToString();
                String qry = "delete from std where name='" + name + "'";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show("Deleted user: " + name);
                }
                else
                {
                    MessageBox.Show("Error deletion");
                }
                Button1_Click(sender, e);
                show();
                con.Close();
            }catch(System.Exception exp)
            {
                MessageBox.Show("Exception: " + exp.ToString());
            }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from std where name='%"+textBox3.Text.ToString()+"%'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
            }
        }
    }
}
