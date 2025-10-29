using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
using TestSie;

namespace TestSIE
{
    public partial class AdqCars : Form
    {
        Persona ps;
        Coche cc;
        Propietario prop;
        private DataTable dtPersonas;
        private DataTable dtCoches;

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
            btnEditCar.Enabled = false;
            txtBrand.Enabled = false;
            txtModel.Enabled = false;
            txtVin.Enabled = false;
            LoadPersons();
            LoadCars();
            LoadOwners();
            LoadCmbPerson();
            LoadcmbCars();
        }

        private void LoadPersons()
        {
            gcPersons.DataSource = Persona.LoadPersons();
        }

        private void LoadCars()
        {
            gcCars.DataSource = Coche.LoadCars();
        }

        private void LoadOwners()
        {
            gcOwners.DataSource = Propietario.LoadPropietarios();
        }

        private void LoadCmbPerson()
        {
            cmbPersons.Properties.Items.Clear();
            dtPersonas = Persona.LoadPersons();

            foreach (DataRow row in dtPersonas.Rows)
            {
                cmbPersons.Properties.Items.Add($"{row["Nombre"]} {row["Apellido"]}");
            }
        }

        private void LoadcmbCars()
        {
            cmbCars.Properties.Items.Clear();
            dtCoches = Coche.LoadCars();

            foreach (DataRow row in dtCoches.Rows)
            {
                cmbCars.Properties.Items.Add($"{row["Marca"]} {row["Modelo"]}");
            }
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
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtLastName.Text))
                {
                    XtraMessageBox.Show("Debe ingresar nombre y apellido.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_Persona"))
                    XtraMessageBox.Show("Ya existe una persona con ese nombre y apellido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnNewCar_Click(object sender, EventArgs e)
        {
            txtBrand.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtVin.Text = string.Empty;
            txtBrand.Enabled = true;
            txtModel.Enabled = true;
            txtVin.Enabled = true;
            cc = new Coche();
        }

        private void gvCars_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                btnEditCar.Enabled = true;
                txtBrand.Enabled = false;
                txtModel.Enabled = false;
                txtVin.Enabled = false;
                if (gvCars.GetRowCellValue(e.RowHandle, "Id").ToString().Trim() != string.Empty)
                {
                    int idCar = int.Parse(gvCars.GetRowCellValue(e.RowHandle, "Id").ToString().Trim());
                    cc = new Coche(idCar);
                    txtBrand.Text = cc.Marca;
                    txtModel.Text = cc.Modelo;
                    txtVin.Text = cc.VIN;
                    //txtName.Text = gvPersons.GetRowCellValue(e.RowHandle, "Nombre").ToString().Trim();
                    //txtLastName.Text = gvPersons.GetRowCellValue(e.RowHandle, "Apellido").ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            txtBrand.Enabled = true;
            txtModel.Enabled = true;
            txtVin.Enabled = true;
        }

        private void btnSaveCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBrand.Enabled == true && txtModel.Enabled == true && txtVin.Enabled == true)
                {
                    cc.Marca = txtBrand.Text.Trim();
                    cc.Modelo = txtModel.Text.Trim();
                    cc.VIN = txtVin.Text.Trim();
                    cc.Save();

                    if (cc.ObjStat == Stat.Saved)
                    {
                        XtraMessageBox.Show("Se ha guardado correctamente el registro.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                InitCtrls();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_Coche_VIN"))
                    XtraMessageBox.Show("Ya existe un coche con ese VIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAssignCar_Click(object sender, EventArgs e)
        {
            try
            {
                int personaId = Convert.ToInt32(dtPersonas.Rows[cmbPersons.SelectedIndex]["Id"]);
                int cocheId = Convert.ToInt32(dtCoches.Rows[cmbCars.SelectedIndex]["Id"]);

                if (Propietario.IsCarUnassigned(cocheId))
                {
                    prop = new Propietario();
                    prop.PersonaId = personaId;
                    prop.CocheId = cocheId;
                    prop.Save();

                    if (prop.ObjStat == Stat.Saved)
                    {
                        XtraMessageBox.Show("Se ha asignado correctamente el coche.", "Asignacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    LoadOwners();
                }
                else
                {
                    XtraMessageBox.Show("Este coche ya tiene propietario.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvOwners_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (gvOwners.GetRowCellValue(e.RowHandle, "Id").ToString().Trim() != string.Empty)
                {
                    int idProp = int.Parse(gvOwners.GetRowCellValue(e.RowHandle, "Id").ToString().Trim());
                    prop = new Propietario(idProp);
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCarOwner_Click(object sender, EventArgs e)
        {
            try
            {
                prop.DeleteNow();
                if (prop.ObjStat == Stat.Saved)
                {
                    XtraMessageBox.Show("Se ha eliminado correctamente el coche del propietario.", "Eliminar Asignacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadOwners();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
