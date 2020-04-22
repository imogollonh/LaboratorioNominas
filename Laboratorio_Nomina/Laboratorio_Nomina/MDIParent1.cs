using Laboratorio_Nomina.Mantenimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_Nomina
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

       
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        bool ventanaConceptos = false;
        Frm_MantenimientoConcepto conceptos = new Frm_MantenimientoConcepto();
        private void conceptosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_MantenimientoConcepto);
            if (ventanaConceptos == false || frmC == null)
            {
                if (frmC == null)
                {
                    conceptos = new Frm_MantenimientoConcepto();
                }

                conceptos.MdiParent = this;
                conceptos.Show();
                Application.DoEvents();
                ventanaConceptos = true;
            }
            else
            {
                conceptos.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaDepartamento = false;
        Frm_MantenimietnoDepartamento departamento= new Frm_MantenimietnoDepartamento();
        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_MantenimietnoDepartamento);
            if (ventanaDepartamento == false || frmC == null)
            {
                if (frmC == null)
                {
                    departamento = new Frm_MantenimietnoDepartamento();
                }

                departamento.MdiParent = this;
                departamento.Show();
                Application.DoEvents();
                ventanaDepartamento = true;
            }
            else
            {
                departamento.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaPuestos = false;
        Frm_MantenimientoPuesto puestos = new Frm_MantenimientoPuesto();
        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_MantenimientoPuesto);
            if (ventanaPuestos == false || frmC == null)
            {
                if (frmC == null)
                {
                    puestos = new Frm_MantenimientoPuesto();
                }

                puestos.MdiParent = this;
                puestos.Show();
                Application.DoEvents();
                ventanaPuestos = true;
            }
            else
            {
                puestos.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        bool ventanaEmpleado = false;
        Frm_MantenimientoEmpleado empleado = new Frm_MantenimientoEmpleado();
        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmC = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_MantenimientoEmpleado);
            if (ventanaEmpleado == false || frmC == null)
            {
                if (frmC == null)
                {
                    empleado = new Frm_MantenimientoEmpleado();
                }

                empleado.MdiParent = this;
                empleado.Show();
                Application.DoEvents();
                ventanaEmpleado = true;
            }
            else
            {
                empleado.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
    }
}
