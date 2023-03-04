using MarketSalesApp.Entities;
using MarketSalesApp.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MarketSalesApp
{
    public partial class AddSeller : Form
    {
        AddSellerRepository addSellerRepository=new AddSellerRepository();
        Market_user market_User = new Market_user();
        int id = -1;
        public AddSeller()
        {
            InitializeComponent();

        }
        public AddSeller(Market_user market_User, int id)
        {
            InitializeComponent();
            textBox1.Text = market_User.Username;
            textBox2.Text = market_User.Password;
            this.id = id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Bütün xanaları daxil etməyiniz xahiş olunur!", "Xəbərdarlıq");
            }
            else
            {
                market_User.Username = textBox1.Text;
                market_User.Password = textBox2.Text;
                if (id >= 0)
                    addSellerRepository.UpdateSeller(market_User,id);
                else
                    addSellerRepository.AddSeller(market_User);
                Close();
            }

        }
    }
}
