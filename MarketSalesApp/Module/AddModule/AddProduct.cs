using MarketSalesApp.Entities;
using MarketSalesApp.Repository;
using System;
using System.Windows.Forms;

namespace MarketSalesApp
{
    public partial class AddProduct : Form
    {
        AddProductRepository addProductRepository=new AddProductRepository();
        Product product= new Product();
        int id=-1;
        public AddProduct()
        {
            InitializeComponent();
        }
        public AddProduct(Product product, int id)
        {
            InitializeComponent();
            textBox1.Text = product.Name;
            textBox2.Text = product.Quantity.ToString();
            textBox3.Text = product.Price.ToString();
            this.id = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""|| textBox2.Text == ""|| textBox3.Text == "")
                MessageBox.Show("Bütün xanaları daxil etməyiniz xahiş olunur!", "Xəbərdarlıq");
            else
            {
                product.Name = textBox1.Text;
                product.Quantity = Convert.ToDouble(textBox2.Text);
                product.Price = Convert.ToDouble(textBox3.Text);
                if (id >= 0)
                    addProductRepository.UpdateProduct(product, id);
                else
                    addProductRepository.AddProduct(product);
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
