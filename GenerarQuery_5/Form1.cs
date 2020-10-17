using GenerarQuery_5.BLL;
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
    }
}
