namespace ReclutamientoSeleccionApp.Views
{
    partial class SearchCandidatoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchCandidatoView));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DepartamentoComboBox = new System.Windows.Forms.ComboBox();
            this.Departamento = new System.Windows.Forms.Label();
            this.PuestoComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loading = new System.Windows.Forms.PictureBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.NombreTxtBox = new System.Windows.Forms.TextBox();
            this.CompetenciasListBox2 = new System.Windows.Forms.ComboBox();
            this.CapacitacionesListBox2 = new System.Windows.Forms.ComboBox();
            this.IdiomaComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cédula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PuestoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Institucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstitucionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecomendadoPor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idiomas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Competencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacitaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Experiencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.IdiomaComboBox);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.CapacitacionesListBox2);
            this.groupBox5.Controls.Add(this.CompetenciasListBox2);
            this.groupBox5.Controls.Add(this.NombreTxtBox);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.DepartamentoComboBox);
            this.groupBox5.Controls.Add(this.Departamento);
            this.groupBox5.Controls.Add(this.PuestoComboBox);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(312, 146);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1013, 220);
            this.groupBox5.TabIndex = 55;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "FILTRAR CANDIDATOS POR";
            // 
            // DepartamentoComboBox
            // 
            this.DepartamentoComboBox.FormattingEnabled = true;
            this.DepartamentoComboBox.Location = new System.Drawing.Point(337, 72);
            this.DepartamentoComboBox.Name = "DepartamentoComboBox";
            this.DepartamentoComboBox.Size = new System.Drawing.Size(301, 31);
            this.DepartamentoComboBox.TabIndex = 107;
            this.DepartamentoComboBox.SelectedIndexChanged += new System.EventHandler(this.DepartamentocomboBox1_SelectedIndexChanged);
            // 
            // Departamento
            // 
            this.Departamento.AutoSize = true;
            this.Departamento.Location = new System.Drawing.Point(333, 41);
            this.Departamento.Name = "Departamento";
            this.Departamento.Size = new System.Drawing.Size(141, 23);
            this.Departamento.TabIndex = 106;
            this.Departamento.Text = "Departamentos";
            // 
            // PuestoComboBox
            // 
            this.PuestoComboBox.FormattingEnabled = true;
            this.PuestoComboBox.Location = new System.Drawing.Point(664, 72);
            this.PuestoComboBox.Name = "PuestoComboBox";
            this.PuestoComboBox.Size = new System.Drawing.Size(320, 31);
            this.PuestoComboBox.TabIndex = 103;
            this.PuestoComboBox.SelectedIndexChanged += new System.EventHandler(this.PuestoComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(660, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Capacitaciones";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Competencias";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(660, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Puestos";
            // 
            // loading
            // 
            this.loading.Image = ((System.Drawing.Image)(resources.GetObject("loading.Image")));
            this.loading.Location = new System.Drawing.Point(773, 329);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(177, 157);
            this.loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loading.TabIndex = 49;
            this.loading.TabStop = false;
            this.loading.Visible = false;
            this.loading.Click += new System.EventHandler(this.loading_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Maroon;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button12.Location = new System.Drawing.Point(29, 237);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(250, 40);
            this.button12.TabIndex = 31;
            this.button12.Text = "EXPERIENCIA LABORAL";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Maroon;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button11.Location = new System.Drawing.Point(56, 550);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(217, 40);
            this.button11.TabIndex = 30;
            this.button11.Text = "➣ INSTITUCIONES";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Maroon;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button10.Location = new System.Drawing.Point(59, 504);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(150, 40);
            this.button10.TabIndex = 29;
            this.button10.Text = "➣ NIVELES";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Maroon;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button9.Location = new System.Drawing.Point(0, 467);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(253, 40);
            this.button9.TabIndex = 28;
            this.button9.Text = "CAPACITACIONES";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Maroon;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button8.Location = new System.Drawing.Point(3, 421);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(228, 40);
            this.button8.TabIndex = 27;
            this.button8.Text = "COMPETENCIAS";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Location = new System.Drawing.Point(261, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(939, 10);
            this.panel2.TabIndex = 51;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1257, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 48;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Candara", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(1150, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 49);
            this.button2.TabIndex = 52;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Maroon;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button7.Location = new System.Drawing.Point(-3, 375);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(183, 40);
            this.button7.TabIndex = 26;
            this.button7.Text = "IDIOMAS";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Maroon;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(3, 329);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(183, 40);
            this.button5.TabIndex = 23;
            this.button5.Text = "PUESTOS";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.button12);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 733);
            this.panel1.TabIndex = 50;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Maroon;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Location = new System.Drawing.Point(-3, 157);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(137, 40);
            this.button6.TabIndex = 24;
            this.button6.Text = "GESTIONES";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Maroon;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(3, 283);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(250, 40);
            this.button4.TabIndex = 22;
            this.button4.Text = "DEPARTAMENTOS";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Maroon;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(0, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(222, 40);
            this.button3.TabIndex = 21;
            this.button3.Text = "CANDIDATOS";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 42.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(279, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(825, 66);
            this.label1.TabIndex = 47;
            this.label1.Text = "BUSQUEDA DE CANDIDATOS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Brown;
            this.label6.Location = new System.Drawing.Point(306, 397);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 34);
            this.label6.TabIndex = 95;
            this.label6.Text = "Candidatos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Cédula,
            this.Puesto,
            this.Id,
            this.PuestoId,
            this.Institucion,
            this.Salario,
            this.InstitucionId,
            this.RecomendadoPor,
            this.Idiomas,
            this.Competencias,
            this.Capacitaciones,
            this.Experiencias});
            this.dataGridView1.Location = new System.Drawing.Point(312, 451);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1013, 230);
            this.dataGridView1.TabIndex = 94;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 110;
            this.label5.Text = "Nombre";
            // 
            // NombreTxtBox
            // 
            this.NombreTxtBox.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreTxtBox.Location = new System.Drawing.Point(21, 76);
            this.NombreTxtBox.Name = "NombreTxtBox";
            this.NombreTxtBox.Size = new System.Drawing.Size(301, 27);
            this.NombreTxtBox.TabIndex = 111;
            // 
            // CompetenciasListBox2
            // 
            this.CompetenciasListBox2.FormattingEnabled = true;
            this.CompetenciasListBox2.Location = new System.Drawing.Point(337, 158);
            this.CompetenciasListBox2.Name = "CompetenciasListBox2";
            this.CompetenciasListBox2.Size = new System.Drawing.Size(301, 31);
            this.CompetenciasListBox2.TabIndex = 112;
            this.CompetenciasListBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // CapacitacionesListBox2
            // 
            this.CapacitacionesListBox2.FormattingEnabled = true;
            this.CapacitacionesListBox2.Location = new System.Drawing.Point(664, 158);
            this.CapacitacionesListBox2.Name = "CapacitacionesListBox2";
            this.CapacitacionesListBox2.Size = new System.Drawing.Size(320, 31);
            this.CapacitacionesListBox2.TabIndex = 113;
            this.CapacitacionesListBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // IdiomaComboBox
            // 
            this.IdiomaComboBox.FormattingEnabled = true;
            this.IdiomaComboBox.Location = new System.Drawing.Point(21, 158);
            this.IdiomaComboBox.Name = "IdiomaComboBox";
            this.IdiomaComboBox.Size = new System.Drawing.Size(301, 31);
            this.IdiomaComboBox.TabIndex = 115;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 23);
            this.label7.TabIndex = 114;
            this.label7.Text = "Idiomas";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "FullName";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Cédula
            // 
            this.Cédula.DataPropertyName = "Cedula";
            this.Cédula.HeaderText = "Cédula";
            this.Cédula.Name = "Cédula";
            // 
            // Puesto
            // 
            this.Puesto.DataPropertyName = "NombrePuesto";
            this.Puesto.HeaderText = "Puesto";
            this.Puesto.Name = "Puesto";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // PuestoId
            // 
            this.PuestoId.DataPropertyName = "PuestoId";
            this.PuestoId.HeaderText = "PuestoId";
            this.PuestoId.Name = "PuestoId";
            this.PuestoId.Visible = false;
            // 
            // Institucion
            // 
            this.Institucion.DataPropertyName = "NombreInstitucion";
            this.Institucion.HeaderText = "Institucion";
            this.Institucion.Name = "Institucion";
            // 
            // Salario
            // 
            this.Salario.DataPropertyName = "Salario";
            this.Salario.HeaderText = "Salario";
            this.Salario.Name = "Salario";
            // 
            // InstitucionId
            // 
            this.InstitucionId.DataPropertyName = "InstitucionId";
            this.InstitucionId.HeaderText = "InstitucionId";
            this.InstitucionId.Name = "InstitucionId";
            this.InstitucionId.Visible = false;
            // 
            // RecomendadoPor
            // 
            this.RecomendadoPor.DataPropertyName = "RecomendadoPor";
            this.RecomendadoPor.HeaderText = "RecomendadoPor";
            this.RecomendadoPor.Name = "RecomendadoPor";
            // 
            // Idiomas
            // 
            this.Idiomas.DataPropertyName = "TodosLosIdiomas";
            this.Idiomas.HeaderText = "Idiomas";
            this.Idiomas.Name = "Idiomas";
            // 
            // Competencias
            // 
            this.Competencias.DataPropertyName = "TodasLasCompetencias";
            this.Competencias.HeaderText = "Competencias";
            this.Competencias.Name = "Competencias";
            // 
            // Capacitaciones
            // 
            this.Capacitaciones.DataPropertyName = "TodasLasCapacitaciones";
            this.Capacitaciones.HeaderText = "Capacitaciones";
            this.Capacitaciones.Name = "Capacitaciones";
            // 
            // Experiencias
            // 
            this.Experiencias.DataPropertyName = "TodasLasExperiencias";
            this.Experiencias.HeaderText = "Experiencias";
            this.Experiencias.Name = "Experiencias";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Candara", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(956, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 49);
            this.button1.TabIndex = 96;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SearchCandidatoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1337, 693);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchCandidatoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchCandidatoView";
            this.Load += new System.EventHandler(this.SearchCandidatoView_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox loading;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PuestoComboBox;
        private System.Windows.Forms.ComboBox DepartamentoComboBox;
        private System.Windows.Forms.Label Departamento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NombreTxtBox;
        private System.Windows.Forms.ComboBox CapacitacionesListBox2;
        private System.Windows.Forms.ComboBox CompetenciasListBox2;
        private System.Windows.Forms.ComboBox IdiomaComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cédula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuestoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Institucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salario;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstitucionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecomendadoPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idiomas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Competencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacitaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Experiencias;
        private System.Windows.Forms.Button button1;
    }
}