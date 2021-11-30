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

namespace up2
{
    public partial class redact : Form
    {
        static string conStr = " Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=b1;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        int Id;
        Form1 form1;
        public redact(Form1 form)
        {
            InitializeComponent();
            form1 = form;  
            //Table<service> service = context.GetTable<service>();
            service currentAccount = context.GetTable<service>().First(x => x.ID == Convert.ToInt32(form1.dataGridView1.CurrentRow.Cells[0].Value));
            textBox1.Text = currentAccount.Title;
            textBox2.Text = Convert.ToString(currentAccount.Cost);
            textBox3.Text = Convert.ToString(currentAccount.DurationInSeconds);
            textBox4.Text = currentAccount.Description;
            textBox5.Text = Convert.ToString(currentAccount.Discount);
            textBox6.Text = currentAccount.MainImagePath;
          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            service currentAccount = context.GetTable<service>().FirstOrDefault(
x => x.ID == Convert.ToInt32(form1.dataGridView1.CurrentRow.Cells[0].Value));
            currentAccount.Title = textBox1.Text;
            currentAccount.Cost = Convert.ToInt32(textBox2.Text);
            currentAccount.DurationInSeconds = Convert.ToInt32(textBox3.Text);
            currentAccount.Description = textBox4.Text;
            currentAccount.Discount = Convert.ToInt32(textBox5.Text);
            currentAccount.MainImagePath = textBox6.Text;
            context.SubmitChanges();
            


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "b1DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.b1DataSet.Service);

        }
    }
}
