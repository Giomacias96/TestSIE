namespace TestSIE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gcAqCars = new DevExpress.XtraGrid.GridControl();
            this.gvAqCars = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTestSie = new System.Windows.Forms.Label();
            this.lblPersonas = new System.Windows.Forms.Label();
            this.lblAssignedCars = new System.Windows.Forms.Label();
            this.lblCars = new System.Windows.Forms.Label();
            this.gcPersons = new DevExpress.XtraGrid.GridControl();
            this.gvPersons = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCars = new DevExpress.XtraGrid.GridControl();
            this.gvCars = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteCar = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnAssingCar = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVIN = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.btnCreateCar = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLastNamePerson = new System.Windows.Forms.TextBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.btnAddPerson = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAqCars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAqCars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCars)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 443F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.gcAqCars, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTestSie, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPersonas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAssignedCars, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCars, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.gcPersons, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gcCars, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(862, 685);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gcAqCars
            // 
            this.gcAqCars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAqCars.Location = new System.Drawing.Point(222, 56);
            this.gcAqCars.MainView = this.gvAqCars;
            this.gcAqCars.Name = "gcAqCars";
            this.gcAqCars.Size = new System.Drawing.Size(437, 471);
            this.gcAqCars.TabIndex = 7;
            this.gcAqCars.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAqCars});
            // 
            // gvAqCars
            // 
            this.gvAqCars.GridControl = this.gcAqCars;
            this.gvAqCars.Name = "gvAqCars";
            this.gvAqCars.OptionsView.ShowGroupPanel = false;
            // 
            // lblTestSie
            // 
            this.lblTestSie.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTestSie, 3);
            this.lblTestSie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTestSie.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestSie.Location = new System.Drawing.Point(3, 0);
            this.lblTestSie.Name = "lblTestSie";
            this.lblTestSie.Size = new System.Drawing.Size(856, 24);
            this.lblTestSie.TabIndex = 1;
            this.lblTestSie.Text = "TestSIE";
            this.lblTestSie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPersonas
            // 
            this.lblPersonas.AutoSize = true;
            this.lblPersonas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPersonas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonas.Location = new System.Drawing.Point(3, 33);
            this.lblPersonas.Name = "lblPersonas";
            this.lblPersonas.Size = new System.Drawing.Size(213, 20);
            this.lblPersonas.TabIndex = 2;
            this.lblPersonas.Text = "Personas";
            this.lblPersonas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblAssignedCars
            // 
            this.lblAssignedCars.AutoSize = true;
            this.lblAssignedCars.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAssignedCars.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignedCars.Location = new System.Drawing.Point(222, 33);
            this.lblAssignedCars.Name = "lblAssignedCars";
            this.lblAssignedCars.Size = new System.Drawing.Size(437, 20);
            this.lblAssignedCars.TabIndex = 3;
            this.lblAssignedCars.Text = "Coches Adquiridos";
            this.lblAssignedCars.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblCars
            // 
            this.lblCars.AutoSize = true;
            this.lblCars.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCars.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCars.Location = new System.Drawing.Point(665, 33);
            this.lblCars.Name = "lblCars";
            this.lblCars.Size = new System.Drawing.Size(194, 20);
            this.lblCars.TabIndex = 4;
            this.lblCars.Text = "Autos Disponibles";
            this.lblCars.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // gcPersons
            // 
            this.gcPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPersons.Location = new System.Drawing.Point(3, 56);
            this.gcPersons.MainView = this.gvPersons;
            this.gcPersons.Name = "gcPersons";
            this.gcPersons.Size = new System.Drawing.Size(213, 471);
            this.gcPersons.TabIndex = 5;
            this.gcPersons.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPersons});
            // 
            // gvPersons
            // 
            this.gvPersons.GridControl = this.gcPersons;
            this.gvPersons.Name = "gvPersons";
            this.gvPersons.OptionsView.ShowGroupPanel = false;
            // 
            // gcCars
            // 
            this.gcCars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCars.Location = new System.Drawing.Point(665, 56);
            this.gcCars.MainView = this.gvCars;
            this.gcCars.Name = "gcCars";
            this.gcCars.Size = new System.Drawing.Size(194, 471);
            this.gcCars.TabIndex = 6;
            this.gcCars.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCars});
            // 
            // gvCars
            // 
            this.gvCars.GridControl = this.gcCars;
            this.gvCars.Name = "gvCars";
            this.gvCars.OptionsView.ShowGroupPanel = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeleteCar);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAssingCar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(222, 533);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 149);
            this.panel1.TabIndex = 8;
            // 
            // btnDeleteCar
            // 
            this.btnDeleteCar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCar.Appearance.Options.UseFont = true;
            this.btnDeleteCar.AutoSize = true;
            this.btnDeleteCar.Location = new System.Drawing.Point(313, 70);
            this.btnDeleteCar.Name = "btnDeleteCar";
            this.btnDeleteCar.Size = new System.Drawing.Size(98, 23);
            this.btnDeleteCar.TabIndex = 2;
            this.btnDeleteCar.Text = "Retirar Coche";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Location = new System.Drawing.Point(176, 70);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(117, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Actualizar Listas";
            // 
            // btnAssingCar
            // 
            this.btnAssingCar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssingCar.Appearance.Options.UseFont = true;
            this.btnAssingCar.AutoSize = true;
            this.btnAssingCar.Location = new System.Drawing.Point(55, 70);
            this.btnAssingCar.Name = "btnAssingCar";
            this.btnAssingCar.Size = new System.Drawing.Size(102, 23);
            this.btnAssingCar.TabIndex = 0;
            this.btnAssingCar.Text = "Asignar Coche";
            this.btnAssingCar.Click += new System.EventHandler(this.btnAssingCar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtVIN);
            this.panel2.Controls.Add(this.txtBrand);
            this.panel2.Controls.Add(this.txtModel);
            this.panel2.Controls.Add(this.btnCreateCar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(665, 533);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 149);
            this.panel2.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "VIN:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Modelo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Marca:";
            // 
            // txtVIN
            // 
            this.txtVIN.Location = new System.Drawing.Point(56, 76);
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.Size = new System.Drawing.Size(100, 20);
            this.txtVIN.TabIndex = 4;
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(56, 8);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(100, 20);
            this.txtBrand.TabIndex = 3;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(56, 43);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(100, 20);
            this.txtModel.TabIndex = 3;
            // 
            // btnCreateCar
            // 
            this.btnCreateCar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateCar.Appearance.Options.UseFont = true;
            this.btnCreateCar.AutoSize = true;
            this.btnCreateCar.Location = new System.Drawing.Point(68, 117);
            this.btnCreateCar.Name = "btnCreateCar";
            this.btnCreateCar.Size = new System.Drawing.Size(88, 23);
            this.btnCreateCar.TabIndex = 2;
            this.btnCreateCar.Text = "Crear Coche";
            this.btnCreateCar.Click += new System.EventHandler(this.btnCreateCar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtLastNamePerson);
            this.panel3.Controls.Add(this.txtPersonName);
            this.panel3.Controls.Add(this.btnAddPerson);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 533);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(213, 149);
            this.panel3.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Apellido";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre:";
            // 
            // txtLastNamePerson
            // 
            this.txtLastNamePerson.Location = new System.Drawing.Point(79, 73);
            this.txtLastNamePerson.Name = "txtLastNamePerson";
            this.txtLastNamePerson.Size = new System.Drawing.Size(100, 20);
            this.txtLastNamePerson.TabIndex = 2;
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(79, 47);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(100, 20);
            this.txtPersonName.TabIndex = 1;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPerson.Appearance.Options.UseFont = true;
            this.btnAddPerson.AutoSize = true;
            this.btnAddPerson.Location = new System.Drawing.Point(77, 99);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(102, 23);
            this.btnAddPerson.TabIndex = 0;
            this.btnAddPerson.Text = "Crear Persona";
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 685);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAqCars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAqCars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCars)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTestSie;
        private System.Windows.Forms.Label lblPersonas;
        private System.Windows.Forms.Label lblAssignedCars;
        private System.Windows.Forms.Label lblCars;
        private DevExpress.XtraGrid.GridControl gcAqCars;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAqCars;
        private DevExpress.XtraGrid.GridControl gcPersons;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPersons;
        private DevExpress.XtraGrid.GridControl gcCars;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCars;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnDeleteCar;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnAssingCar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnAddPerson;
        private DevExpress.XtraEditors.SimpleButton btnCreateCar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLastNamePerson;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVIN;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtModel;
    }
}