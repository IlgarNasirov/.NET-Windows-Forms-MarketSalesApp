using MarketSalesApp.Repository;
using MarketSalesApp.Entities;
using System;
using System.Windows.Forms;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace MarketSalesApp
{
    public partial class AddSell : Form
    {
        AddSellRepository addSellRepository=new AddSellRepository();
        SellerProductsRepository sellerProductsRepository=new SellerProductsRepository();
        Sell sell = new Sell();
        int id = -1;
        public AddSell()
        {
            InitializeComponent();
            if (sellerProductsRepository.AllSellerProduct().Rows.Count > 0)
            {
                comboBox1.Items.Clear();
                foreach (DataRow row in sellerProductsRepository.AllSellerProduct().Rows)
                {
                    comboBox1.Items.Add(row.ItemArray[1].ToString());
                }
            }
        }
        public AddSell(Sell sell, int id)
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            foreach (DataRow row in sellerProductsRepository.AllSellerProduct().Rows)
            {
                comboBox1.Items.Add(row.ItemArray[1].ToString());
            }
            textBox2.Text = sell.Quantity.ToString();
            comboBox1.Text = sell.Productname.ToString();
            textBox3.Text = sell.Price.ToString();
            textBox4.Text = sell.Total.ToString();
            this.id = id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text=="Məhsullar")
                MessageBox.Show("Bütün xanaları daxil etməyiniz xahiş olunur!", "Xəbərdarlıq");
            else
            {
                sell.Productname = comboBox1.Text;
                double quantity = Convert.ToDouble(textBox2.Text);
                double price = Convert.ToDouble(textBox3.Text);
                sell.Quantity = quantity;
                sell.Price = price;
                sell.Total = price * quantity;
                if (id >= 0)
                    addSellRepository.UpdateSell(sell, id);
                else
                    addSellRepository.AddSell(sell);
                Close();
            }
        }
    }
}
