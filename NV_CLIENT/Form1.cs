using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NV_CLIENT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account account = new Account()
            {
                Username = textBox1.Text.Trim(),
                Password = textBox2.Text.Trim()
            }; bool result = new AccountBUS().CheckAccount(account); if (result)
            {
                new Form2().Show();
                this.Hide();
            }
            else { MessageBox.Show("SORRY BABY!"); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account newAccount = new Account()
            {
                Username = textBox1.Text.Trim(),
                Password = textBox2.Text.Trim()
            };
            bool result = new AccountBUS().AddNew(newAccount); 
            if (result) MessageBox.Show("OK BABY!"); 
            else MessageBox.Show("SORRY BABY!");
        }
    }
}
