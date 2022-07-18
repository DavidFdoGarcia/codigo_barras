using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace codigo_barras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Zen.Barcode.Code128BarcodeDraw codigodebarra = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = codigodebarra.Draw(txtCodigo.Text, 40);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "JPEG|*.jpeg";

            if(saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                string varimg = saveFileDialog1.FileName;
                Bitmap varbmp = new Bitmap(pictureBox1.Image);
                varbmp.Save(varimg, ImageFormat.Jpeg);
            }
        }
    }
}
