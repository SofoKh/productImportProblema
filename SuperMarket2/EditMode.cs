﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket2
{
    public partial class EditMode : Form
    {
        public EditMode()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.superMarketDataSet1);

        }

        private void EditMode_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'superMarketDataSet1.Products' table. You can move, or remove it, as needed.
            //this.productsTableAdapter.Fill(this.superMarketDataSet1.Products);
            this.productsDataGridView.DataSource = SQLprocedures.SelectProducts();

        }

        private void buttonImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";
            if( openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                productImagePictureBox.ImageLocation = openFileDialog.FileName;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            /*ImageConverter img = new ImageConverter();
            byte[] imgbyte = (byte[])img.ConvertTo(productImagePictureBox, typeof(byte[]));*/
            byte[] bytes = (byte[])(new global::System.Data.DataColumn("ProductImage", typeof(byte[]), null, global::System.Data.MappingType.Element));
            SQLprocedures.InsertProducts(productNameTextBox.Text, productDescriptionTextBox.Text, Convert.ToInt32(productPriceNumericUpDown.Value), Convert.ToInt32(productQuantityNumericUpDown.Value), bytes);
            this.productsDataGridView.DataSource = SQLprocedures.SelectProducts();
        }
    }
}
