using GenerarQuery_5.BLL;
using GenerarQuery_5.EE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerarQuery_5
{
    public partial class Form1 : Form
    {
        private GeneroBLL generoBLL = new GeneroBLL();
        public Form1()
        {
            InitializeComponent();
            RefrescarGrilla();
        }

        private void RefrescarGrilla()
        {
            grillaGenero.DataSource = null;
            grillaGenero.DataSource = generoBLL.ListarGenero();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Genero ListarGenero()
        {
            return new Genero
            {
                Nombre = txt_nombre_genero.Text.Trim(),
                Fecha_reg = DateTime.Now
            };
        }

        private void btn_alta_genero_Click(object sender, EventArgs e)
        {
            var genero = ListarGenero();
            generoBLL.Alta(genero);
            RefrescarGrilla();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txt_nombre_genero.Text = string.Empty;
        }

        private Genero SeleccionarGenero()
        {
            return (Genero)grillaGenero.SelectedRows[0].DataBoundItem;
        }

        private void btn_baja_genero_Click(object sender, EventArgs e)
        {
            var genero = SeleccionarGenero();
            generoBLL.Baja(genero);
            RefrescarGrilla();
            LimpiarCampos();
        }
    }
}
