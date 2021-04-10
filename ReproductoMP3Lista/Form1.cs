using ReproductoMP3Lista.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductoMP3Lista
{
    public partial class Form1 : Form
    {

        OpenFileDialog CajaDeBusquedaDeArchivos = new OpenFileDialog();
        ListaOrdenada addpath = new ListaOrdenada();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            CajaDeBusquedaDeArchivos.Multiselect = true; //Esto va a permitir seleccionar varios archivos al mismo tiempo

            if (CajaDeBusquedaDeArchivos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                for (int i = 0; i < CajaDeBusquedaDeArchivos.FileNames.Length; i++)
                {
                    addpath.insertaOrden(CajaDeBusquedaDeArchivos.FileNames[i]);
                    listBox1.Items.Add(CajaDeBusquedaDeArchivos.SafeFileNames[i]);
                }

                axWindowsMediaPlayer1.URL = CajaDeBusquedaDeArchivos.FileNames[0];
                listBox1.SelectedIndex = 0;
                int pausa;
                pausa = 0;

            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                axWindowsMediaPlayer1.URL = CajaDeBusquedaDeArchivos.FileNames[listBox1.SelectedIndex];
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
            }

        }

        private void btnAfter_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex - 1;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void remover_Click(object sender, EventArgs e)
        {
            int eliminar = listBox1.SelectedIndex;
            addpath.eliminar(eliminar);

            listBox1.Items.RemoveAt(eliminar);
            axWindowsMediaPlayer1.Ctlcontrols.stop();

            int pausa;
            pausa = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
