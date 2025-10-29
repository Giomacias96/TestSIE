using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using TestSie;

namespace TestSIE
{
    public partial class AdqCars : Form
    {
        Persona ps;
        public AdqCars()
        {
            InitializeComponent();
            InitCtrls();
        }

        private void InitCtrls()
        {
            txtName.Enabled = false;
            txtLastName.Enabled = false;
            btnEditPerson.Enabled = false;
            LoadPersons();
            LoadCars();
        }

        private void LoadPersons()
        {
            gcPersons.DataSource = Persona.LoadPersons();
        }

        private void LoadCars()
        {
            gcCars.DataSource = Coche.LoadCars();
        }

        private void btnNewPerson_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtName.Enabled = true;
            txtLastName.Enabled = true;
            ps = new Persona();
        }

        private void gvPersons_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                btnEditPerson.Enabled = true;
                txtName.Enabled = false;
                txtLastName.Enabled = false;
                if (gvPersons.GetRowCellValue(e.RowHandle, "Id").ToString().Trim() != string.Empty)
                {
                    int idPerson = int.Parse(gvPersons.GetRowCellValue(e.RowHandle, "Id").ToString().Trim());
                    ps = new Persona(idPerson);
                    txtName.Text = ps.Nombre;
                    txtLastName.Text = ps.Apellido;
                    //txtName.Text = gvPersons.GetRowCellValue(e.RowHandle, "Nombre").ToString().Trim();
                    //txtLastName.Text = gvPersons.GetRowCellValue(e.RowHandle, "Apellido").ToString().Trim();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtLastName.Enabled = true;
        }

        private void btnSavePerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Enabled == true && txtLastName.Enabled == true)
                {
                    ps.Nombre = txtName.Text.Trim();
                    ps.Apellido = txtLastName.Text.Trim();
                    ps.Save();

                    if (ps.ObjStat == Stat.Saved)
                    {
                        XtraMessageBox.Show("Se ha guardado correctamente el registro.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                InitCtrls();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
