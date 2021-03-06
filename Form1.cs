using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void LoadDataSource()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            };
            _productDal.Add(product);
            LoadDataSource();
            MessageBox.Show("Product Added!");
        }
        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)

            };
            _productDal.Update(product);
            LoadDataSource();
            MessageBox.Show("Product Updated!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),

            };
            _productDal.Delete(product);
            LoadDataSource();
            MessageBox.Show("Product Deleted!");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            //dgwProducts.DataSource = _productDal.GetAll().Where(p => p.Name.ToLower().Contains(tbxSearch.Text.ToLower())).ToList();
            //dgwProducts.DataSource= _productDal.GetbyName(tbxSearch.Text);
            dgwProducts.DataSource = _productDal.GetbyUnitPrice(Convert.ToDecimal(tbxmin), Convert.ToDecimal(tbxmax.Text));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgwProducts.DataSource = _productDal.GetbyUnitPrice(Convert.ToDecimal(tbxmin.Text), Convert.ToDecimal(tbxmax.Text));
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            List<Product> product = new List<Product>();
            product.Add(_productDal.GetById(1));

            dgwProducts.DataSource = product;
        }
    }
}
