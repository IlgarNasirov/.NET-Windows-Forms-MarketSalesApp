using MarketSalesApp.Entities;
using MarketSalesApp.Repository;
using System;
using System.IO;
using System.Windows.Forms;

namespace MarketSalesApp
{
    public partial class Admin : Form
    {
        AdminProductsRepository adminProductsRepository = new AdminProductsRepository();
        AdminSellersRepository adminSellersRepository=new AdminSellersRepository();
        AdminSellsRepository adminSellsRepository = new AdminSellsRepository();
        public Admin(string userName)
        {
            InitializeComponent();
            label2.Text += ": " + userName;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            AddProduct addProduct=new AddProduct();
            addProduct.ShowDialog();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index >= 0)
                {
                    Product product = new Product { Name = dataGridView1.CurrentRow.Cells[1].Value.ToString(), Price = Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value), Quantity = Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value) };
                    AddProduct addProduct = new AddProduct(product, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    addProduct.ShowDialog();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Xəbərdarlıq");
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index >= 0)
                {
                    adminProductsRepository.DeleteProduct(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                    dataGridView1.DataSource = adminProductsRepository.AllAdminProduct();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Xəbərdarlıq");
            }
        }

        private void Admin_Activated(object sender, EventArgs e)
        {
            dataGridView1.DataSource = adminProductsRepository.AllAdminProduct();
            dataGridView2.DataSource = adminSellsRepository.AllAdminSell();
            dataGridView3.DataSource = adminSellersRepository.AllAdminSeller();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddSeller addSeller = new AddSeller();
            addSeller.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.CurrentRow.Index >= 0)
                {
                    Market_user market_User = new Market_user { Username = dataGridView3.CurrentRow.Cells[1].Value.ToString(), Password = dataGridView3.CurrentRow.Cells[2].Value.ToString()};
                    AddSeller addSeller = new AddSeller(market_User, Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value));
                    addSeller.ShowDialog();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Xəbərdarlıq");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.CurrentRow.Index >= 0)
                {
                    adminSellersRepository.DeleteSeller(Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value));
                    dataGridView3.DataSource = adminSellersRepository.AllAdminSeller();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Xəbərdarlıq");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
