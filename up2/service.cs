using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;

namespace up2
{
    public partial class Form1 : Form
    {
        static string conStr = " Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=b1;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public int id;
        public Form1(bool isAdmin)
        {
            InitializeComponent();
            if(isAdmin == true)
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                comboBox1.Visible = true;
                label1.Visible = true;

            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                comboBox1.Visible = false;
                label1.Visible = false;
            }
            Table<service> Service = context.GetTable<service>();
            dataGridView1.DataSource = Service.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "b1DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.b1DataSet.Service);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add f3 = new add();
                f3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void serviseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            intel f2 = new intel();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            service currentAccount = context.GetTable<service>().FirstOrDefault(
x => x.ID == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            context.GetTable<service>().DeleteOnSubmit(currentAccount);
            context.SubmitChanges();

            dataGridView1.DataSource = context.GetTable<service>().ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<service> services = null;
            switch(comboBox1.SelectedIndex)
            {
                case 0: services = context.GetTable<service>().Where(x => x.Discount <= 0.05 && x.Discount > 0).ToList(); break;
                case 1: services = context.GetTable<service>().Where(x => x.Discount <= 0.15 && x.Discount > 0.05).ToList(); break;
                case 2: services = context.GetTable<service>().Where(x => x.Discount <= 0.3 && x.Discount > 0.15).ToList(); break;
                case 3: services = context.GetTable<service>().Where(x => x.Discount <= 0.7 && x.Discount > 0.3).ToList(); break;
                case 4: services = context.GetTable<service>().Where(x => x.Discount <= 1 && x.Discount > 0.7).ToList(); break;
                case 5: services = context.GetTable<service>().Where(x => x.Discount <= 1 && x.Discount > 0).ToList(); break;
                
            }

            dataGridView1.DataSource = services;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            redact f3 = new redact(this);
            f3.ShowDialog();
            dataGridView1.DataSource = context.GetTable<service>().ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            dataGridView1.DataSource = context.GetTable<service>().ToList();
        }
        public void Refrech()
        {
            context.SubmitChanges();
            dataGridView1.DataSource = context.GetTable<service>().ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            recording f1 = new recording();
            f1.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select *From [Service] Where [Title] Like N'%" + textBox1.Text + "%' ";
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void serviseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select *From [Service] Where [Description] Like N'%" + textBox2.Text + "%' ";
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
