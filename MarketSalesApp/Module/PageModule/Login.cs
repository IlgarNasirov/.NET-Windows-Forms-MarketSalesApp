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

namespace MarketSalesApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == ""||comboBox1.Text=="Rolunuzu seçin")
            {
                MessageBox.Show("Bütün xanaları daxil etməyiniz xahiş olunur!","Xəbərdarlıq");
            }
            else
            {
                bool isAdmin = comboBox1.Text == "Admin" ? true : false;
                Market_user market_User= new Market_user();
                market_User.Username= textBox1.Text;
                market_User.Password = textBox2.Text;
                market_User.Isadmin= isAdmin;
                LoginRepository loginRepository = new LoginRepository();
                switch (loginRepository.Login(market_User))
                {
                    case 1:
                        Hide();
                        Admin admin = new Admin(textBox1.Text);
                        admin.ShowDialog();
                        break;
                    case 0:
                        Hide();
                        Seller seller =new Seller(textBox1.Text);
                        seller.ShowDialog();
                        break;
                    default:
                        MessageBox.Show("İstifadəçi tapılmadı!","Xəbərdarlıq");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        break;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
