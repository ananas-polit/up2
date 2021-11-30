using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Windows.Forms;
using System.IO;

namespace up2
{
    public partial class add : Form
    {
        static string conStr = " Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=b1;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public add()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            service NewUser = new service { Title = textBox1.Text, Cost = Convert.ToInt32(textBox2.Text), DurationInSeconds = Convert.ToInt32(textBox3.Text), Description = textBox4.Text, Discount = Convert.ToInt32(textBox5.Text), MainImagePath = textBox6.Text };
            context.GetTable<service>().InsertOnSubmit(NewUser);
            context.SubmitChanges();
        }

        private byte[] SaveImage()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files: *.jpg, *.png|*.jpg;*.png";
            openFile.ShowDialog();
            if (openFile.FileName.Length != 0)
            {
                string nameFile = openFile.FileName;
                byte[] image = File.ReadAllBytes(nameFile);

                return image;
            }

            return null;
        }

        private void add_Load(object sender, EventArgs e)
        {

        }
    }
}
