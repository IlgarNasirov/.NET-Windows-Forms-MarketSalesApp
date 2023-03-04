using MarketSalesApp.Entities;
using MarketSalesApp.Repository;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MarketSalesApp
{
    public partial class Seller : Form
    {
        SellerProductsRepository sellerProductsRepository = new SellerProductsRepository();
        SellerSellsRepository sellerSellsRepository = new SellerSellsRepository();
        SellerBillsRepository sellerBillsRepository = new SellerBillsRepository();
        string userName="User";
        public Seller(string userName)
        {
            InitializeComponent();
            label2.Text += ": " + userName;
            this.userName = userName;
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            AddSell addSell= new AddSell();
            addSell.ShowDialog();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow.Index >= 0)
                {
                    Sell sell = new Sell { Productname = dataGridView2.CurrentRow.Cells[1].Value.ToString(), Quantity = Convert.ToDouble(dataGridView2.CurrentRow.Cells[2].Value), Price=Convert.ToDouble(dataGridView2.CurrentRow.Cells[3].Value), Total = Convert.ToDouble(dataGridView2.CurrentRow.Cells[4].Value) };
                    AddSell addSell = new AddSell(sell, Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value));
                    addSell.ShowDialog();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Xəbərdarlıq");
            }
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow.Index >= 0)
                {
                    sellerSellsRepository.DeleteSell(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value));
                    dataGridView2.DataSource = sellerSellsRepository.AllSellerSell();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Xəbərdarlıq");
            }

        }

        private void Seller_Activated(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sellerProductsRepository.AllSellerProduct();
            dataGridView2.DataSource = sellerSellsRepository.AllSellerSell();
            dataGridView3.DataSource = sellerBillsRepository.AllSellerBill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result=sellerSellsRepository.SellToBill(userName);
            if (result > 0)
            {
                MessageBox.Show("Satılmamış məhsullar müvəffəqiyyətlə satıldı!", "Məlumat");
                dataGridView2.DataSource = sellerSellsRepository.AllSellerSell();
                dataGridView3.DataSource = sellerBillsRepository.AllSellerBill();
            }
            else
            {
                MessageBox.Show("Heç bir məhsul satılmadı!", "Məlumat");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.CurrentRow.Index >= 0)
                {
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                    
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Xəbərdarlıq");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Market", new Font("Sergoe UI", 25, FontStyle.Bold), Brushes.Red, new Point(357,30));
            e.Graphics.DrawString("Fakura ID: " + dataGridView3.CurrentRow.Cells[0].Value.ToString(), new Font("Sergoe UI", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 70));
            e.Graphics.DrawString("Satıcı adı: " + dataGridView3.CurrentRow.Cells[1].Value.ToString(), new Font("Sergoe UI", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 100));
            e.Graphics.DrawString("Faktura tarixi: " + dataGridView3.CurrentRow.Cells[2].Value.ToString(), new Font("Sergoe UI", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 130));
            e.Graphics.DrawString("Ümumi xərc: " + dataGridView3.CurrentRow.Cells[3].Value.ToString(), new Font("Sergoe UI", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 160));
            e.Graphics.DrawString("Bizi seçdiyiniz üçün təşəkkür edirik!", new Font("Sergoe UI", 25, FontStyle.Bold), Brushes.Red, new Point(120, 230));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
