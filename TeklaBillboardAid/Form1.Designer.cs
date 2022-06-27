using System.Text.RegularExpressions;

namespace TeklaBillboardAid
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.PictureBox pictureBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.ledCabinets = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.CabinetHeightLabel = new System.Windows.Forms.Label();
            this.CabinetLengthLabel = new System.Windows.Forms.Label();
            this.CabinetHeightSumLabel = new System.Windows.Forms.Label();
            this.CabinetLengthSumLabel = new System.Windows.Forms.Label();
            this.CabinetControl = new System.Windows.Forms.TabControl();
            this.CabinetAddTab = new System.Windows.Forms.TabPage();
            this.ColumnAddRadioButton = new System.Windows.Forms.RadioButton();
            this.RowAddRadioButton = new System.Windows.Forms.RadioButton();
            this.cabinetAddValue = new System.Windows.Forms.TextBox();
            this.cabinetValueAddButton = new System.Windows.Forms.Button();
            this.CabinetEditTab = new System.Windows.Forms.TabPage();
            this.CabinetResetButton = new System.Windows.Forms.Button();
            this.CabinetRemoveButton = new System.Windows.Forms.Button();
            this.ColumnEditRadioButton = new System.Windows.Forms.RadioButton();
            this.RowEditRadioButton = new System.Windows.Forms.RadioButton();
            this.CabinetEditValue = new System.Windows.Forms.TextBox();
            this.CabinetEditButton = new System.Windows.Forms.Button();
            this.columnSumLabel = new System.Windows.Forms.Label();
            this.columnLabel = new System.Windows.Forms.Label();
            this.rowSumLabel = new System.Windows.Forms.Label();
            this.rowLabel = new System.Windows.Forms.Label();
            this.columnList = new System.Windows.Forms.ListBox();
            this.rowList = new System.Windows.Forms.ListBox();
            this.MaterialAndProfile = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label33 = new System.Windows.Forms.Label();
            this.B5Profile = new System.Windows.Forms.TextBox();
            this.B2Profile = new System.Windows.Forms.TextBox();
            this.B2Material = new System.Windows.Forms.TextBox();
            this.B5Material = new System.Windows.Forms.TextBox();
            this.B1Profile = new System.Windows.Forms.TextBox();
            this.B1Material = new System.Windows.Forms.TextBox();
            this.BR1Profile = new System.Windows.Forms.TextBox();
            this.BR1Material = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.C1Profile = new System.Windows.Forms.TextBox();
            this.LEDProfile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LED = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LEDMaterial = new System.Windows.Forms.TextBox();
            this.C1Material = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.B3Material = new System.Windows.Forms.TextBox();
            this.B3Profile = new System.Windows.Forms.TextBox();
            this.WalerMaterial = new System.Windows.Forms.TextBox();
            this.WalerProfile = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.SeatingPlateMaterial = new System.Windows.Forms.TextBox();
            this.SeatingPlateProfile = new System.Windows.Forms.TextBox();
            this.EAMaterial = new System.Windows.Forms.TextBox();
            this.EAProfile = new System.Windows.Forms.TextBox();
            this.EALabel = new System.Windows.Forms.Label();
            this.ZBracketLabel = new System.Windows.Forms.Label();
            this.ZBracketMaterial = new System.Windows.Forms.TextBox();
            this.ZBracketProfile = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BillBoardDepth = new System.Windows.Forms.Label();
            this.HeightOffsetBottom = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.HeightOffsetTop = new System.Windows.Forms.TextBox();
            this.BillBoardHeight = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.BillBoardLength = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BoltDiameter = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HoleHorizontalOffset = new System.Windows.Forms.TextBox();
            this.HoleVerticalOffset = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.Welding = new System.Windows.Forms.TextBox();
            this.MeshThickLabel = new System.Windows.Forms.Label();
            this.MeshThickness = new System.Windows.Forms.TextBox();
            this.RailingSpace2 = new System.Windows.Forms.TextBox();
            this.RailingSpace1 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.validateButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.LowerWalerSpacing = new System.Windows.Forms.TextBox();
            this.UpperWalerSpacing = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.WalerNumberLabel = new System.Windows.Forms.Label();
            this.WalerManualRadio = new System.Windows.Forms.RadioButton();
            this.WalerAddValue = new System.Windows.Forms.TextBox();
            this.WalerAddButton = new System.Windows.Forms.Button();
            this.WalerAutoRadio = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.WalerResetButton = new System.Windows.Forms.Button();
            this.WalerRemoveButton = new System.Windows.Forms.Button();
            this.WalerEditValue = new System.Windows.Forms.TextBox();
            this.WalerEditButton = new System.Windows.Forms.Button();
            this.WalersSumLabel = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.WalersList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label23 = new System.Windows.Forms.Label();
            this.CornerOffset = new System.Windows.Forms.TextBox();
            this.CornerOffsetLabel = new System.Windows.Forms.Label();
            this.TopOffsetLabel = new System.Windows.Forms.Label();
            this.DiagonalBottomOffset = new System.Windows.Forms.TextBox();
            this.DiagonalTopOffset = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label21 = new System.Windows.Forms.Label();
            this.StructureControl = new System.Windows.Forms.TabControl();
            this.StructureAddTab = new System.Windows.Forms.TabPage();
            this.StructureManualRadio = new System.Windows.Forms.RadioButton();
            this.HorizontalBeamsAddValue = new System.Windows.Forms.TextBox();
            this.HorizontalBeamsAddButton = new System.Windows.Forms.Button();
            this.StructureAutoRadio = new System.Windows.Forms.RadioButton();
            this.StructureEditTab = new System.Windows.Forms.TabPage();
            this.HorizontalBeamsResetButton = new System.Windows.Forms.Button();
            this.HorizontalBeamsRemoveButton = new System.Windows.Forms.Button();
            this.HorizontalBeamsEditValue = new System.Windows.Forms.TextBox();
            this.HorizontalBeamsEditButton = new System.Windows.Forms.Button();
            this.BeamsSumLabel = new System.Windows.Forms.Label();
            this.BeamsLabel = new System.Windows.Forms.Label();
            this.HorizontalBeamsList = new System.Windows.Forms.ListBox();
            this.label22 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.BracketBoltDiameter = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.BracketBoltStandard = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.SeatingPlateOffButton = new System.Windows.Forms.RadioButton();
            this.SeatingPlateOnButton = new System.Windows.Forms.RadioButton();
            this.SeatingPlateOffset = new System.Windows.Forms.TextBox();
            this.ExtrusionLength = new System.Windows.Forms.TextBox();
            this.seatingplateextrusionlengthLabel = new System.Windows.Forms.Label();
            this.SeatingplateoffsetLabel = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.WalkwayMaterial = new System.Windows.Forms.TextBox();
            this.MeshMaterialLabel = new System.Windows.Forms.Label();
            this.WalkwayWidthLabel = new System.Windows.Forms.Label();
            this.WalkwayWidth = new System.Windows.Forms.TextBox();
            this.WalkwayClearanceLabel = new System.Windows.Forms.Label();
            this.EAclearanceLabel = new System.Windows.Forms.Label();
            this.WalkwayClearance = new System.Windows.Forms.TextBox();
            this.EAClearance = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.ZbracketEndSpacing = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.ZbracketSpacingA = new System.Windows.Forms.TextBox();
            this.ZbracketSpacingALabel = new System.Windows.Forms.Label();
            this.ZbracketSpacingB = new System.Windows.Forms.TextBox();
            this.ZbracketSpacingBLabel = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            this.ledCabinets.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.CabinetControl.SuspendLayout();
            this.CabinetAddTab.SuspendLayout();
            this.CabinetEditTab.SuspendLayout();
            this.MaterialAndProfile.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.StructureControl.SuspendLayout();
            this.StructureAddTab.SuspendLayout();
            this.StructureEditTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            pictureBox1.Location = new System.Drawing.Point(626, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(320, 313);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(565, 722);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 45);
            this.button1.TabIndex = 10;
            this.button1.Text = "Build";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // ledCabinets
            // 
            this.ledCabinets.Controls.Add(this.tableLayoutPanel5);
            this.ledCabinets.Controls.Add(this.CabinetControl);
            this.ledCabinets.Controls.Add(this.columnSumLabel);
            this.ledCabinets.Controls.Add(this.columnLabel);
            this.ledCabinets.Controls.Add(this.rowSumLabel);
            this.ledCabinets.Controls.Add(this.rowLabel);
            this.ledCabinets.Controls.Add(this.columnList);
            this.ledCabinets.Controls.Add(this.rowList);
            this.ledCabinets.Location = new System.Drawing.Point(12, 22);
            this.ledCabinets.Name = "ledCabinets";
            this.ledCabinets.Size = new System.Drawing.Size(364, 240);
            this.ledCabinets.TabIndex = 0;
            this.ledCabinets.TabStop = false;
            this.ledCabinets.Text = "LED Cabinets";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.CabinetHeightLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.CabinetLengthLabel, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.CabinetHeightSumLabel, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.CabinetLengthSumLabel, 1, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(201, 41);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(157, 43);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // CabinetHeightLabel
            // 
            this.CabinetHeightLabel.AutoSize = true;
            this.CabinetHeightLabel.Location = new System.Drawing.Point(3, 0);
            this.CabinetHeightLabel.Name = "CabinetHeightLabel";
            this.CabinetHeightLabel.Size = new System.Drawing.Size(75, 13);
            this.CabinetHeightLabel.TabIndex = 1;
            this.CabinetHeightLabel.Text = "Screen Height";
            // 
            // CabinetLengthLabel
            // 
            this.CabinetLengthLabel.AutoSize = true;
            this.CabinetLengthLabel.Location = new System.Drawing.Point(3, 21);
            this.CabinetLengthLabel.Name = "CabinetLengthLabel";
            this.CabinetLengthLabel.Size = new System.Drawing.Size(77, 13);
            this.CabinetLengthLabel.TabIndex = 0;
            this.CabinetLengthLabel.Text = "Screen Length";
            // 
            // CabinetHeightSumLabel
            // 
            this.CabinetHeightSumLabel.AutoSize = true;
            this.CabinetHeightSumLabel.Location = new System.Drawing.Point(86, 0);
            this.CabinetHeightSumLabel.Name = "CabinetHeightSumLabel";
            this.CabinetHeightSumLabel.Size = new System.Drawing.Size(13, 13);
            this.CabinetHeightSumLabel.TabIndex = 3;
            this.CabinetHeightSumLabel.Text = "0";
            // 
            // CabinetLengthSumLabel
            // 
            this.CabinetLengthSumLabel.AutoSize = true;
            this.CabinetLengthSumLabel.Location = new System.Drawing.Point(86, 21);
            this.CabinetLengthSumLabel.Name = "CabinetLengthSumLabel";
            this.CabinetLengthSumLabel.Size = new System.Drawing.Size(13, 13);
            this.CabinetLengthSumLabel.TabIndex = 2;
            this.CabinetLengthSumLabel.Text = "0";
            // 
            // CabinetControl
            // 
            this.CabinetControl.Controls.Add(this.CabinetAddTab);
            this.CabinetControl.Controls.Add(this.CabinetEditTab);
            this.CabinetControl.Location = new System.Drawing.Point(6, 19);
            this.CabinetControl.Name = "CabinetControl";
            this.CabinetControl.SelectedIndex = 0;
            this.CabinetControl.Size = new System.Drawing.Size(189, 109);
            this.CabinetControl.TabIndex = 0;
            // 
            // CabinetAddTab
            // 
            this.CabinetAddTab.Controls.Add(this.ColumnAddRadioButton);
            this.CabinetAddTab.Controls.Add(this.RowAddRadioButton);
            this.CabinetAddTab.Controls.Add(this.cabinetAddValue);
            this.CabinetAddTab.Controls.Add(this.cabinetValueAddButton);
            this.CabinetAddTab.Location = new System.Drawing.Point(4, 22);
            this.CabinetAddTab.Name = "CabinetAddTab";
            this.CabinetAddTab.Padding = new System.Windows.Forms.Padding(3);
            this.CabinetAddTab.Size = new System.Drawing.Size(181, 83);
            this.CabinetAddTab.TabIndex = 0;
            this.CabinetAddTab.Text = "Add";
            this.CabinetAddTab.UseVisualStyleBackColor = true;
            // 
            // ColumnAddRadioButton
            // 
            this.ColumnAddRadioButton.AutoSize = true;
            this.ColumnAddRadioButton.Location = new System.Drawing.Point(59, 6);
            this.ColumnAddRadioButton.Name = "ColumnAddRadioButton";
            this.ColumnAddRadioButton.Size = new System.Drawing.Size(60, 17);
            this.ColumnAddRadioButton.TabIndex = 3;
            this.ColumnAddRadioButton.TabStop = true;
            this.ColumnAddRadioButton.Text = "Column";
            this.ColumnAddRadioButton.UseVisualStyleBackColor = true;
            // 
            // RowAddRadioButton
            // 
            this.RowAddRadioButton.AutoSize = true;
            this.RowAddRadioButton.Checked = true;
            this.RowAddRadioButton.Location = new System.Drawing.Point(6, 6);
            this.RowAddRadioButton.Name = "RowAddRadioButton";
            this.RowAddRadioButton.Size = new System.Drawing.Size(47, 17);
            this.RowAddRadioButton.TabIndex = 2;
            this.RowAddRadioButton.TabStop = true;
            this.RowAddRadioButton.Text = "Row";
            this.RowAddRadioButton.UseVisualStyleBackColor = true;
            // 
            // cabinetAddValue
            // 
            this.cabinetAddValue.Location = new System.Drawing.Point(6, 29);
            this.cabinetAddValue.Name = "cabinetAddValue";
            this.cabinetAddValue.Size = new System.Drawing.Size(83, 20);
            this.cabinetAddValue.TabIndex = 0;
            // 
            // cabinetValueAddButton
            // 
            this.cabinetValueAddButton.Location = new System.Drawing.Point(6, 55);
            this.cabinetValueAddButton.Name = "cabinetValueAddButton";
            this.cabinetValueAddButton.Size = new System.Drawing.Size(83, 20);
            this.cabinetValueAddButton.TabIndex = 1;
            this.cabinetValueAddButton.Text = "Add";
            this.cabinetValueAddButton.UseVisualStyleBackColor = true;
            this.cabinetValueAddButton.Click += new System.EventHandler(this.CabinetValueAddButton_Click);
            // 
            // CabinetEditTab
            // 
            this.CabinetEditTab.Controls.Add(this.CabinetResetButton);
            this.CabinetEditTab.Controls.Add(this.CabinetRemoveButton);
            this.CabinetEditTab.Controls.Add(this.ColumnEditRadioButton);
            this.CabinetEditTab.Controls.Add(this.RowEditRadioButton);
            this.CabinetEditTab.Controls.Add(this.CabinetEditValue);
            this.CabinetEditTab.Controls.Add(this.CabinetEditButton);
            this.CabinetEditTab.Location = new System.Drawing.Point(4, 22);
            this.CabinetEditTab.Name = "CabinetEditTab";
            this.CabinetEditTab.Padding = new System.Windows.Forms.Padding(3);
            this.CabinetEditTab.Size = new System.Drawing.Size(181, 83);
            this.CabinetEditTab.TabIndex = 1;
            this.CabinetEditTab.Text = "Edit";
            this.CabinetEditTab.UseVisualStyleBackColor = true;
            // 
            // CabinetResetButton
            // 
            this.CabinetResetButton.Location = new System.Drawing.Point(6, 55);
            this.CabinetResetButton.Name = "CabinetResetButton";
            this.CabinetResetButton.Size = new System.Drawing.Size(83, 20);
            this.CabinetResetButton.TabIndex = 5;
            this.CabinetResetButton.TabStop = false;
            this.CabinetResetButton.Text = "Remove All";
            this.CabinetResetButton.UseVisualStyleBackColor = true;
            this.CabinetResetButton.Click += new System.EventHandler(this.CabinetResetButton_Click);
            // 
            // CabinetRemoveButton
            // 
            this.CabinetRemoveButton.Location = new System.Drawing.Point(92, 55);
            this.CabinetRemoveButton.Name = "CabinetRemoveButton";
            this.CabinetRemoveButton.Size = new System.Drawing.Size(80, 20);
            this.CabinetRemoveButton.TabIndex = 4;
            this.CabinetRemoveButton.Text = "Remove";
            this.CabinetRemoveButton.UseVisualStyleBackColor = true;
            this.CabinetRemoveButton.Click += new System.EventHandler(this.CabinetRemoveButton_Click);
            // 
            // ColumnEditRadioButton
            // 
            this.ColumnEditRadioButton.AutoSize = true;
            this.ColumnEditRadioButton.Location = new System.Drawing.Point(59, 6);
            this.ColumnEditRadioButton.Name = "ColumnEditRadioButton";
            this.ColumnEditRadioButton.Size = new System.Drawing.Size(60, 17);
            this.ColumnEditRadioButton.TabIndex = 1;
            this.ColumnEditRadioButton.Text = "Column";
            this.ColumnEditRadioButton.UseVisualStyleBackColor = true;
            this.ColumnEditRadioButton.CheckedChanged += new System.EventHandler(this.EditColumnRadioButton_CheckedChanged);
            // 
            // RowEditRadioButton
            // 
            this.RowEditRadioButton.AutoSize = true;
            this.RowEditRadioButton.Checked = true;
            this.RowEditRadioButton.Location = new System.Drawing.Point(6, 6);
            this.RowEditRadioButton.Name = "RowEditRadioButton";
            this.RowEditRadioButton.Size = new System.Drawing.Size(47, 17);
            this.RowEditRadioButton.TabIndex = 0;
            this.RowEditRadioButton.TabStop = true;
            this.RowEditRadioButton.Text = "Row";
            this.RowEditRadioButton.UseVisualStyleBackColor = true;
            this.RowEditRadioButton.CheckedChanged += new System.EventHandler(this.EditRowRadioButton_CheckedChanged);
            // 
            // CabinetEditValue
            // 
            this.CabinetEditValue.Location = new System.Drawing.Point(6, 29);
            this.CabinetEditValue.Name = "CabinetEditValue";
            this.CabinetEditValue.Size = new System.Drawing.Size(83, 20);
            this.CabinetEditValue.TabIndex = 2;
            // 
            // CabinetEditButton
            // 
            this.CabinetEditButton.Location = new System.Drawing.Point(92, 29);
            this.CabinetEditButton.Name = "CabinetEditButton";
            this.CabinetEditButton.Size = new System.Drawing.Size(80, 20);
            this.CabinetEditButton.TabIndex = 3;
            this.CabinetEditButton.Text = "Edit";
            this.CabinetEditButton.UseVisualStyleBackColor = true;
            this.CabinetEditButton.Click += new System.EventHandler(this.CabinetEditButton_Click);
            // 
            // columnSumLabel
            // 
            this.columnSumLabel.AutoSize = true;
            this.columnSumLabel.Location = new System.Drawing.Point(232, 219);
            this.columnSumLabel.Name = "columnSumLabel";
            this.columnSumLabel.Size = new System.Drawing.Size(13, 13);
            this.columnSumLabel.TabIndex = 7;
            this.columnSumLabel.Text = "0";
            // 
            // columnLabel
            // 
            this.columnLabel.AutoSize = true;
            this.columnLabel.Location = new System.Drawing.Point(182, 219);
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(53, 13);
            this.columnLabel.TabIndex = 6;
            this.columnLabel.Text = "Columns: ";
            // 
            // rowSumLabel
            // 
            this.rowSumLabel.AutoSize = true;
            this.rowSumLabel.Location = new System.Drawing.Point(40, 219);
            this.rowSumLabel.Name = "rowSumLabel";
            this.rowSumLabel.Size = new System.Drawing.Size(13, 13);
            this.rowSumLabel.TabIndex = 5;
            this.rowSumLabel.Text = "0";
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Location = new System.Drawing.Point(3, 219);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(40, 13);
            this.rowLabel.TabIndex = 4;
            this.rowLabel.Text = "Rows: ";
            // 
            // columnList
            // 
            this.columnList.FormattingEnabled = true;
            this.columnList.Location = new System.Drawing.Point(185, 134);
            this.columnList.Name = "columnList";
            this.columnList.Size = new System.Drawing.Size(169, 82);
            this.columnList.TabIndex = 7;
            this.columnList.SelectedIndexChanged += new System.EventHandler(this.ColumnList_SelectedIndexChanged);
            // 
            // rowList
            // 
            this.rowList.AllowDrop = true;
            this.rowList.FormattingEnabled = true;
            this.rowList.Location = new System.Drawing.Point(6, 134);
            this.rowList.Name = "rowList";
            this.rowList.Size = new System.Drawing.Size(169, 82);
            this.rowList.TabIndex = 6;
            this.rowList.SelectedIndexChanged += new System.EventHandler(this.RowList_SelectedIndexChanged);
            // 
            // MaterialAndProfile
            // 
            this.MaterialAndProfile.Controls.Add(this.tableLayoutPanel1);
            this.MaterialAndProfile.Location = new System.Drawing.Point(381, 22);
            this.MaterialAndProfile.Margin = new System.Windows.Forms.Padding(2);
            this.MaterialAndProfile.Name = "MaterialAndProfile";
            this.MaterialAndProfile.Padding = new System.Windows.Forms.Padding(2);
            this.MaterialAndProfile.Size = new System.Drawing.Size(240, 360);
            this.MaterialAndProfile.TabIndex = 2;
            this.MaterialAndProfile.TabStop = false;
            this.MaterialAndProfile.Text = "Material and Profile";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label33, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.B5Profile, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.B2Profile, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.B2Material, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.B5Material, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.B1Profile, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.B1Material, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.BR1Profile, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.BR1Material, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.C1Profile, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.LEDProfile, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.LED, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LEDMaterial, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.C1Material, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.B3Material, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.B3Profile, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.WalerMaterial, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.WalerProfile, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.label29, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.SeatingPlateMaterial, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.SeatingPlateProfile, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.EAMaterial, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.EAProfile, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.EALabel, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.ZBracketLabel, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.ZBracketMaterial, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.ZBracketProfile, 2, 13);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(233, 337);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(2, 188);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(35, 13);
            this.label33.TabIndex = 14;
            this.label33.Text = "Waler";
            // 
            // B5Profile
            // 
            this.B5Profile.Location = new System.Drawing.Point(128, 142);
            this.B5Profile.Margin = new System.Windows.Forms.Padding(2);
            this.B5Profile.Name = "B5Profile";
            this.B5Profile.Size = new System.Drawing.Size(84, 20);
            this.B5Profile.TabIndex = 11;
            this.B5Profile.Text = "SHS65*65*4.0";
            this.B5Profile.TextChanged += new System.EventHandler(this.B5Profile_TextChanged);
            this.B5Profile.Validating += new System.ComponentModel.CancelEventHandler(this.B5Profile_Validating);
            // 
            // B2Profile
            // 
            this.B2Profile.Location = new System.Drawing.Point(128, 94);
            this.B2Profile.Margin = new System.Windows.Forms.Padding(2);
            this.B2Profile.Name = "B2Profile";
            this.B2Profile.Size = new System.Drawing.Size(84, 20);
            this.B2Profile.TabIndex = 7;
            this.B2Profile.Text = "RHS75*50*4.0";
            this.B2Profile.TextChanged += new System.EventHandler(this.B2Profile_TextChanged);
            this.B2Profile.Validating += new System.ComponentModel.CancelEventHandler(this.B2Profile_Validating);
            // 
            // B2Material
            // 
            this.B2Material.Location = new System.Drawing.Point(72, 94);
            this.B2Material.Margin = new System.Windows.Forms.Padding(2);
            this.B2Material.Name = "B2Material";
            this.B2Material.Size = new System.Drawing.Size(52, 20);
            this.B2Material.TabIndex = 6;
            this.B2Material.Text = "C350L0";
            this.B2Material.TextChanged += new System.EventHandler(this.B2Material_TextChanged);
            // 
            // B5Material
            // 
            this.B5Material.Location = new System.Drawing.Point(72, 142);
            this.B5Material.Margin = new System.Windows.Forms.Padding(2);
            this.B5Material.Name = "B5Material";
            this.B5Material.Size = new System.Drawing.Size(52, 20);
            this.B5Material.TabIndex = 10;
            this.B5Material.Text = "C350L0";
            this.B5Material.TextChanged += new System.EventHandler(this.B5Material_TextChanged);
            // 
            // B1Profile
            // 
            this.B1Profile.Location = new System.Drawing.Point(128, 70);
            this.B1Profile.Margin = new System.Windows.Forms.Padding(2);
            this.B1Profile.Name = "B1Profile";
            this.B1Profile.Size = new System.Drawing.Size(84, 20);
            this.B1Profile.TabIndex = 5;
            this.B1Profile.Text = "SHS75*75*4.0";
            this.B1Profile.TextChanged += new System.EventHandler(this.B1Profile_TextChanged);
            this.B1Profile.Validating += new System.ComponentModel.CancelEventHandler(this.B1Profile_Validating);
            // 
            // B1Material
            // 
            this.B1Material.Location = new System.Drawing.Point(72, 70);
            this.B1Material.Margin = new System.Windows.Forms.Padding(2);
            this.B1Material.Name = "B1Material";
            this.B1Material.Size = new System.Drawing.Size(52, 20);
            this.B1Material.TabIndex = 4;
            this.B1Material.Text = "C350L0";
            this.B1Material.TextChanged += new System.EventHandler(this.B1Material_TextChanged);
            // 
            // BR1Profile
            // 
            this.BR1Profile.Location = new System.Drawing.Point(128, 166);
            this.BR1Profile.Margin = new System.Windows.Forms.Padding(2);
            this.BR1Profile.Name = "BR1Profile";
            this.BR1Profile.Size = new System.Drawing.Size(84, 20);
            this.BR1Profile.TabIndex = 13;
            this.BR1Profile.Text = "SHS50*50*3.0";
            this.BR1Profile.TextChanged += new System.EventHandler(this.BR1Profile_TextChanged);
            this.BR1Profile.Validating += new System.ComponentModel.CancelEventHandler(this.BR1Profile_Validating);
            // 
            // BR1Material
            // 
            this.BR1Material.Location = new System.Drawing.Point(72, 166);
            this.BR1Material.Margin = new System.Windows.Forms.Padding(2);
            this.BR1Material.Name = "BR1Material";
            this.BR1Material.Size = new System.Drawing.Size(52, 20);
            this.BR1Material.TabIndex = 12;
            this.BR1Material.Text = "C350L0";
            this.BR1Material.TextChanged += new System.EventHandler(this.BR1Material_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(2, 164);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 13);
            this.label16.TabIndex = 13;
            this.label16.Text = "BR1";
            // 
            // C1Profile
            // 
            this.C1Profile.Location = new System.Drawing.Point(128, 46);
            this.C1Profile.Margin = new System.Windows.Forms.Padding(2);
            this.C1Profile.Name = "C1Profile";
            this.C1Profile.Size = new System.Drawing.Size(84, 20);
            this.C1Profile.TabIndex = 3;
            this.C1Profile.Text = "RHS75*50*4.0";
            this.C1Profile.TextChanged += new System.EventHandler(this.C1Profile_TextChanged);
            this.C1Profile.Validating += new System.ComponentModel.CancelEventHandler(this.C1Profile_Validating);
            // 
            // LEDProfile
            // 
            this.LEDProfile.Location = new System.Drawing.Point(128, 22);
            this.LEDProfile.Margin = new System.Windows.Forms.Padding(2);
            this.LEDProfile.Name = "LEDProfile";
            this.LEDProfile.Size = new System.Drawing.Size(84, 20);
            this.LEDProfile.TabIndex = 1;
            this.LEDProfile.Text = "PLT170";
            this.LEDProfile.TextChanged += new System.EventHandler(this.LEDProfile_TextChanged);
            this.LEDProfile.Validating += new System.ComponentModel.CancelEventHandler(this.LEDProfile_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Profile";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Material";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 140);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "B5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "B2";
            // 
            // LED
            // 
            this.LED.AutoSize = true;
            this.LED.Location = new System.Drawing.Point(2, 20);
            this.LED.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LED.Name = "LED";
            this.LED.Size = new System.Drawing.Size(28, 13);
            this.LED.TabIndex = 0;
            this.LED.Text = "LED";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "C1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "B1";
            // 
            // LEDMaterial
            // 
            this.LEDMaterial.Location = new System.Drawing.Point(72, 22);
            this.LEDMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.LEDMaterial.Name = "LEDMaterial";
            this.LEDMaterial.Size = new System.Drawing.Size(52, 20);
            this.LEDMaterial.TabIndex = 0;
            this.LEDMaterial.Text = "digital";
            this.LEDMaterial.TextChanged += new System.EventHandler(this.LEDMaterial_TextChanged);
            // 
            // C1Material
            // 
            this.C1Material.Location = new System.Drawing.Point(72, 46);
            this.C1Material.Margin = new System.Windows.Forms.Padding(2);
            this.C1Material.Name = "C1Material";
            this.C1Material.Size = new System.Drawing.Size(52, 20);
            this.C1Material.TabIndex = 2;
            this.C1Material.Text = "C350L0";
            this.C1Material.TextChanged += new System.EventHandler(this.C1Material_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 116);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "B3";
            // 
            // B3Material
            // 
            this.B3Material.Location = new System.Drawing.Point(72, 118);
            this.B3Material.Margin = new System.Windows.Forms.Padding(2);
            this.B3Material.Name = "B3Material";
            this.B3Material.Size = new System.Drawing.Size(52, 20);
            this.B3Material.TabIndex = 8;
            this.B3Material.Text = "C350L0";
            this.B3Material.TextChanged += new System.EventHandler(this.B3Material_TextChanged);
            // 
            // B3Profile
            // 
            this.B3Profile.Location = new System.Drawing.Point(128, 118);
            this.B3Profile.Margin = new System.Windows.Forms.Padding(2);
            this.B3Profile.Name = "B3Profile";
            this.B3Profile.Size = new System.Drawing.Size(84, 20);
            this.B3Profile.TabIndex = 9;
            this.B3Profile.Text = "SHS50*50*3.0";
            this.B3Profile.TextChanged += new System.EventHandler(this.B3Profile_TextChanged);
            this.B3Profile.Validating += new System.ComponentModel.CancelEventHandler(this.B3Profile_Validating);
            // 
            // WalerMaterial
            // 
            this.WalerMaterial.Location = new System.Drawing.Point(72, 190);
            this.WalerMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.WalerMaterial.Name = "WalerMaterial";
            this.WalerMaterial.Size = new System.Drawing.Size(52, 20);
            this.WalerMaterial.TabIndex = 14;
            this.WalerMaterial.Text = "C350L0";
            this.WalerMaterial.TextChanged += new System.EventHandler(this.WalerMaterial_TextChanged);
            // 
            // WalerProfile
            // 
            this.WalerProfile.Location = new System.Drawing.Point(128, 190);
            this.WalerProfile.Margin = new System.Windows.Forms.Padding(2);
            this.WalerProfile.Name = "WalerProfile";
            this.WalerProfile.Size = new System.Drawing.Size(84, 20);
            this.WalerProfile.TabIndex = 15;
            this.WalerProfile.Text = "SHS75*75*4.0";
            this.WalerProfile.TextChanged += new System.EventHandler(this.WalerProfile_TextChanged);
            this.WalerProfile.Validating += new System.ComponentModel.CancelEventHandler(this.WalerProfile_Validating);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(2, 212);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(46, 26);
            this.label29.TabIndex = 17;
            this.label29.Text = "Seating Plate";
            // 
            // SeatingPlateMaterial
            // 
            this.SeatingPlateMaterial.Location = new System.Drawing.Point(72, 214);
            this.SeatingPlateMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.SeatingPlateMaterial.Name = "SeatingPlateMaterial";
            this.SeatingPlateMaterial.Size = new System.Drawing.Size(52, 20);
            this.SeatingPlateMaterial.TabIndex = 16;
            this.SeatingPlateMaterial.Text = "250";
            this.SeatingPlateMaterial.TextChanged += new System.EventHandler(this.SeatingPlateMaterial_TextChanged);
            // 
            // SeatingPlateProfile
            // 
            this.SeatingPlateProfile.Location = new System.Drawing.Point(128, 214);
            this.SeatingPlateProfile.Margin = new System.Windows.Forms.Padding(2);
            this.SeatingPlateProfile.Name = "SeatingPlateProfile";
            this.SeatingPlateProfile.Size = new System.Drawing.Size(84, 20);
            this.SeatingPlateProfile.TabIndex = 17;
            this.SeatingPlateProfile.Text = "FL8";
            this.SeatingPlateProfile.TextChanged += new System.EventHandler(this.SeatingPlateProfile_TextChanged);
            this.SeatingPlateProfile.Validating += new System.ComponentModel.CancelEventHandler(this.SeatingPlateProfile_Validating);
            // 
            // EAMaterial
            // 
            this.EAMaterial.Location = new System.Drawing.Point(72, 240);
            this.EAMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.EAMaterial.Name = "EAMaterial";
            this.EAMaterial.Size = new System.Drawing.Size(52, 20);
            this.EAMaterial.TabIndex = 18;
            this.EAMaterial.Text = "C350L0";
            this.EAMaterial.TextChanged += new System.EventHandler(this.EAMaterial_TextChanged);
            // 
            // EAProfile
            // 
            this.EAProfile.Location = new System.Drawing.Point(128, 240);
            this.EAProfile.Margin = new System.Windows.Forms.Padding(2);
            this.EAProfile.Name = "EAProfile";
            this.EAProfile.Size = new System.Drawing.Size(84, 20);
            this.EAProfile.TabIndex = 19;
            this.EAProfile.Text = "EA50*50*5";
            this.EAProfile.TextChanged += new System.EventHandler(this.EAProfile_TextChanged);
            this.EAProfile.Validating += new System.ComponentModel.CancelEventHandler(this.EAProfile_Validating);
            // 
            // EALabel
            // 
            this.EALabel.AutoSize = true;
            this.EALabel.Location = new System.Drawing.Point(2, 238);
            this.EALabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EALabel.Name = "EALabel";
            this.EALabel.Size = new System.Drawing.Size(61, 13);
            this.EALabel.TabIndex = 20;
            this.EALabel.Text = "EA Support";
            // 
            // ZBracketLabel
            // 
            this.ZBracketLabel.AutoSize = true;
            this.ZBracketLabel.Location = new System.Drawing.Point(2, 262);
            this.ZBracketLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ZBracketLabel.Name = "ZBracketLabel";
            this.ZBracketLabel.Size = new System.Drawing.Size(53, 13);
            this.ZBracketLabel.TabIndex = 23;
            this.ZBracketLabel.Text = "Z bracket";
            // 
            // ZBracketMaterial
            // 
            this.ZBracketMaterial.Location = new System.Drawing.Point(72, 264);
            this.ZBracketMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.ZBracketMaterial.Name = "ZBracketMaterial";
            this.ZBracketMaterial.Size = new System.Drawing.Size(52, 20);
            this.ZBracketMaterial.TabIndex = 20;
            this.ZBracketMaterial.Text = "250";
            this.ZBracketMaterial.TextChanged += new System.EventHandler(this.ZBracketMaterial_TextChanged);
            // 
            // ZBracketProfile
            // 
            this.ZBracketProfile.Location = new System.Drawing.Point(128, 264);
            this.ZBracketProfile.Margin = new System.Windows.Forms.Padding(2);
            this.ZBracketProfile.Name = "ZBracketProfile";
            this.ZBracketProfile.Size = new System.Drawing.Size(84, 20);
            this.ZBracketProfile.TabIndex = 21;
            this.ZBracketProfile.Text = "PLT12*75";
            this.ZBracketProfile.TextChanged += new System.EventHandler(this.ZBracketProfile_TextChanged);
            this.ZBracketProfile.Validating += new System.ComponentModel.CancelEventHandler(this.ZBracketProfile_Validating);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Location = new System.Drawing.Point(381, 386);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(239, 125);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BillBoard Dimensions";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.BillBoardDepth, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.HeightOffsetBottom, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label14, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.HeightOffsetTop, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.BillBoardHeight, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.BillBoardLength, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 18);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(230, 103);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // BillBoardDepth
            // 
            this.BillBoardDepth.AutoSize = true;
            this.BillBoardDepth.Location = new System.Drawing.Point(123, 26);
            this.BillBoardDepth.Name = "BillBoardDepth";
            this.BillBoardDepth.Size = new System.Drawing.Size(13, 13);
            this.BillBoardDepth.TabIndex = 22;
            this.BillBoardDepth.Text = "0";
            // 
            // HeightOffsetBottom
            // 
            this.HeightOffsetBottom.Location = new System.Drawing.Point(122, 65);
            this.HeightOffsetBottom.Margin = new System.Windows.Forms.Padding(2);
            this.HeightOffsetBottom.Name = "HeightOffsetBottom";
            this.HeightOffsetBottom.Size = new System.Drawing.Size(52, 20);
            this.HeightOffsetBottom.TabIndex = 1;
            this.HeightOffsetBottom.Text = "8.0";
            this.HeightOffsetBottom.TextChanged += new System.EventHandler(this.HeightOffsetBottom_TextChanged);
            this.HeightOffsetBottom.Validating += new System.ComponentModel.CancelEventHandler(this.HeightOffsetBottom_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Overall Height";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 63);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Screen Gap (Bottom)";
            // 
            // HeightOffsetTop
            // 
            this.HeightOffsetTop.Location = new System.Drawing.Point(122, 41);
            this.HeightOffsetTop.Margin = new System.Windows.Forms.Padding(2);
            this.HeightOffsetTop.Name = "HeightOffsetTop";
            this.HeightOffsetTop.Size = new System.Drawing.Size(52, 20);
            this.HeightOffsetTop.TabIndex = 0;
            this.HeightOffsetTop.Text = "8.0";
            this.HeightOffsetTop.TextChanged += new System.EventHandler(this.HeightOffsetTop_TextChanged);
            this.HeightOffsetTop.Validating += new System.ComponentModel.CancelEventHandler(this.HeightOffsetTop_Validating);
            // 
            // BillBoardHeight
            // 
            this.BillBoardHeight.AutoSize = true;
            this.BillBoardHeight.Location = new System.Drawing.Point(123, 0);
            this.BillBoardHeight.Name = "BillBoardHeight";
            this.BillBoardHeight.Size = new System.Drawing.Size(13, 13);
            this.BillBoardHeight.TabIndex = 8;
            this.BillBoardHeight.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 13);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Overall Length";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 39);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Screen Gap (Top)";
            // 
            // BillBoardLength
            // 
            this.BillBoardLength.AutoSize = true;
            this.BillBoardLength.Location = new System.Drawing.Point(123, 13);
            this.BillBoardLength.Name = "BillBoardLength";
            this.BillBoardLength.Size = new System.Drawing.Size(13, 13);
            this.BillBoardLength.TabIndex = 9;
            this.BillBoardLength.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 26);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Overall Depth";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Location = new System.Drawing.Point(382, 515);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(239, 98);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cabinet Bolts";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.BoltDiameter, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.HoleHorizontalOffset, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.HoleVerticalOffset, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(230, 74);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // BoltDiameter
            // 
            this.BoltDiameter.Location = new System.Drawing.Point(122, 50);
            this.BoltDiameter.Margin = new System.Windows.Forms.Padding(2);
            this.BoltDiameter.Name = "BoltDiameter";
            this.BoltDiameter.Size = new System.Drawing.Size(52, 20);
            this.BoltDiameter.TabIndex = 2;
            this.BoltDiameter.Text = "10.0";
            this.BoltDiameter.TextChanged += new System.EventHandler(this.BoltDiameter_TextChanged);
            this.BoltDiameter.Validating += new System.ComponentModel.CancelEventHandler(this.BoltDiameter_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 48);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Bolt Diameter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bolt Horizontal Offsets";
            // 
            // HoleHorizontalOffset
            // 
            this.HoleHorizontalOffset.Location = new System.Drawing.Point(122, 2);
            this.HoleHorizontalOffset.Margin = new System.Windows.Forms.Padding(2);
            this.HoleHorizontalOffset.Name = "HoleHorizontalOffset";
            this.HoleHorizontalOffset.Size = new System.Drawing.Size(52, 20);
            this.HoleHorizontalOffset.TabIndex = 0;
            this.HoleHorizontalOffset.Text = "65.0";
            this.HoleHorizontalOffset.TextChanged += new System.EventHandler(this.HoleHorizontalOffset_TextChanged);
            this.HoleHorizontalOffset.Validating += new System.ComponentModel.CancelEventHandler(this.HoleHorizontalOffset_Validating);
            // 
            // HoleVerticalOffset
            // 
            this.HoleVerticalOffset.Location = new System.Drawing.Point(122, 26);
            this.HoleVerticalOffset.Margin = new System.Windows.Forms.Padding(2);
            this.HoleVerticalOffset.Name = "HoleVerticalOffset";
            this.HoleVerticalOffset.Size = new System.Drawing.Size(52, 20);
            this.HoleVerticalOffset.TabIndex = 1;
            this.HoleVerticalOffset.Text = "60.0";
            this.HoleVerticalOffset.TextChanged += new System.EventHandler(this.HoleVerticalOffset_TextChanged);
            this.HoleVerticalOffset.Validating += new System.ComponentModel.CancelEventHandler(this.HoleVerticalOffset_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Bolt Vertical Offsets";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Welding, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(155, 31);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(2, 0);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 26);
            this.label17.TabIndex = 4;
            this.label17.Text = "Welding Offset";
            // 
            // Welding
            // 
            this.Welding.Location = new System.Drawing.Point(79, 2);
            this.Welding.Margin = new System.Windows.Forms.Padding(2);
            this.Welding.Name = "Welding";
            this.Welding.Size = new System.Drawing.Size(52, 20);
            this.Welding.TabIndex = 23;
            this.Welding.Text = "1.0";
            this.Welding.TextChanged += new System.EventHandler(this.Welding_TextChanged);
            this.Welding.Validating += new System.ComponentModel.CancelEventHandler(this.Welding_Validating);
            // 
            // MeshThickLabel
            // 
            this.MeshThickLabel.AutoSize = true;
            this.MeshThickLabel.Location = new System.Drawing.Point(2, 0);
            this.MeshThickLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MeshThickLabel.Name = "MeshThickLabel";
            this.MeshThickLabel.Size = new System.Drawing.Size(103, 13);
            this.MeshThickLabel.TabIndex = 5;
            this.MeshThickLabel.Text = "Walkway Thickness";
            // 
            // MeshThickness
            // 
            this.MeshThickness.Location = new System.Drawing.Point(122, 2);
            this.MeshThickness.Margin = new System.Windows.Forms.Padding(2);
            this.MeshThickness.Name = "MeshThickness";
            this.MeshThickness.Size = new System.Drawing.Size(52, 20);
            this.MeshThickness.TabIndex = 0;
            this.MeshThickness.Text = "14.0";
            this.MeshThickness.TextChanged += new System.EventHandler(this.MeshThickness_TextChanged);
            this.MeshThickness.Validating += new System.ComponentModel.CancelEventHandler(this.MeshThickness_Validating);
            // 
            // RailingSpace2
            // 
            this.RailingSpace2.Location = new System.Drawing.Point(87, 2);
            this.RailingSpace2.Margin = new System.Windows.Forms.Padding(2);
            this.RailingSpace2.Name = "RailingSpace2";
            this.RailingSpace2.Size = new System.Drawing.Size(52, 20);
            this.RailingSpace2.TabIndex = 0;
            this.RailingSpace2.Text = "550.0";
            this.RailingSpace2.TextChanged += new System.EventHandler(this.RailingSpace2_TextChanged);
            this.RailingSpace2.Validating += new System.ComponentModel.CancelEventHandler(this.RailingSpace2_Validating);
            // 
            // RailingSpace1
            // 
            this.RailingSpace1.Location = new System.Drawing.Point(258, 2);
            this.RailingSpace1.Margin = new System.Windows.Forms.Padding(2);
            this.RailingSpace1.Name = "RailingSpace1";
            this.RailingSpace1.Size = new System.Drawing.Size(52, 20);
            this.RailingSpace1.TabIndex = 1;
            this.RailingSpace1.Text = "560.0";
            this.RailingSpace1.TextChanged += new System.EventHandler(this.RailingSpace1_TextChanged);
            this.RailingSpace1.Validating += new System.ComponentModel.CancelEventHandler(this.RailingSpace1_Validating);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(173, 0);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 26);
            this.label19.TabIndex = 6;
            this.label19.Text = "Lower Railing Spacing";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(2, 0);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(74, 26);
            this.label20.TabIndex = 7;
            this.label20.Text = "Upper Railing Spacing";
            // 
            // validateButton
            // 
            this.validateButton.Location = new System.Drawing.Point(420, 721);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(135, 45);
            this.validateButton.TabIndex = 9;
            this.validateButton.Text = "Validate";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel8);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.tabControl1);
            this.groupBox4.Controls.Add(this.WalersSumLabel);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.WalersList);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.tableLayoutPanel7);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.StructureControl);
            this.groupBox4.Controls.Add(this.BeamsSumLabel);
            this.groupBox4.Controls.Add(this.BeamsLabel);
            this.groupBox4.Controls.Add(this.HorizontalBeamsList);
            this.groupBox4.Location = new System.Drawing.Point(12, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(364, 450);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Frame Structure";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 5;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.Controls.Add(this.LowerWalerSpacing, 4, 0);
            this.tableLayoutPanel8.Controls.Add(this.UpperWalerSpacing, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label31, 3, 0);
            this.tableLayoutPanel8.Controls.Add(this.label32, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(10, 184);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(345, 28);
            this.tableLayoutPanel8.TabIndex = 21;
            // 
            // LowerWalerSpacing
            // 
            this.LowerWalerSpacing.Location = new System.Drawing.Point(258, 2);
            this.LowerWalerSpacing.Margin = new System.Windows.Forms.Padding(2);
            this.LowerWalerSpacing.Name = "LowerWalerSpacing";
            this.LowerWalerSpacing.Size = new System.Drawing.Size(52, 20);
            this.LowerWalerSpacing.TabIndex = 13;
            this.LowerWalerSpacing.Text = "350.0";
            this.LowerWalerSpacing.TextChanged += new System.EventHandler(this.LowerWalerSpacing_TextChanged);
            this.LowerWalerSpacing.Validating += new System.ComponentModel.CancelEventHandler(this.LowerWalerSpacing_Validating);
            // 
            // UpperWalerSpacing
            // 
            this.UpperWalerSpacing.Location = new System.Drawing.Point(87, 2);
            this.UpperWalerSpacing.Margin = new System.Windows.Forms.Padding(2);
            this.UpperWalerSpacing.Name = "UpperWalerSpacing";
            this.UpperWalerSpacing.Size = new System.Drawing.Size(52, 20);
            this.UpperWalerSpacing.TabIndex = 12;
            this.UpperWalerSpacing.Text = "350.0";
            this.UpperWalerSpacing.TextChanged += new System.EventHandler(this.UpperWalerSpacing_TextChanged);
            this.UpperWalerSpacing.Validating += new System.ComponentModel.CancelEventHandler(this.UpperWalerSpacing_Validating);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(173, 0);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(70, 26);
            this.label31.TabIndex = 6;
            this.label31.Text = "Lower Waler Spacing";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(2, 0);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(70, 26);
            this.label32.TabIndex = 7;
            this.label32.Text = "Upper Waler Spacing";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(201, 224);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(40, 13);
            this.label28.TabIndex = 19;
            this.label28.Text = "Walers";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 218);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(188, 109);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.WalerNumberLabel);
            this.tabPage1.Controls.Add(this.WalerManualRadio);
            this.tabPage1.Controls.Add(this.WalerAddValue);
            this.tabPage1.Controls.Add(this.WalerAddButton);
            this.tabPage1.Controls.Add(this.WalerAutoRadio);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(180, 83);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // WalerNumberLabel
            // 
            this.WalerNumberLabel.AutoSize = true;
            this.WalerNumberLabel.Location = new System.Drawing.Point(95, 32);
            this.WalerNumberLabel.Name = "WalerNumberLabel";
            this.WalerNumberLabel.Size = new System.Drawing.Size(60, 13);
            this.WalerNumberLabel.TabIndex = 7;
            this.WalerNumberLabel.Text = "No. Walers";
            // 
            // WalerManualRadio
            // 
            this.WalerManualRadio.AutoSize = true;
            this.WalerManualRadio.Location = new System.Drawing.Point(59, 6);
            this.WalerManualRadio.Name = "WalerManualRadio";
            this.WalerManualRadio.Size = new System.Drawing.Size(60, 17);
            this.WalerManualRadio.TabIndex = 15;
            this.WalerManualRadio.TabStop = true;
            this.WalerManualRadio.Text = "Manual";
            this.WalerManualRadio.UseVisualStyleBackColor = true;
            // 
            // WalerAddValue
            // 
            this.WalerAddValue.Location = new System.Drawing.Point(6, 29);
            this.WalerAddValue.Name = "WalerAddValue";
            this.WalerAddValue.Size = new System.Drawing.Size(83, 20);
            this.WalerAddValue.TabIndex = 17;
            this.WalerAddValue.Text = "0";
            this.WalerAddValue.TextChanged += new System.EventHandler(this.WalerAddValue_TextChanged);
            // 
            // WalerAddButton
            // 
            this.WalerAddButton.Enabled = false;
            this.WalerAddButton.Location = new System.Drawing.Point(6, 55);
            this.WalerAddButton.Name = "WalerAddButton";
            this.WalerAddButton.Size = new System.Drawing.Size(83, 20);
            this.WalerAddButton.TabIndex = 18;
            this.WalerAddButton.Text = "Add";
            this.WalerAddButton.UseVisualStyleBackColor = true;
            this.WalerAddButton.Click += new System.EventHandler(this.WalerAddButton_Click);
            // 
            // WalerAutoRadio
            // 
            this.WalerAutoRadio.AutoSize = true;
            this.WalerAutoRadio.Checked = true;
            this.WalerAutoRadio.Location = new System.Drawing.Point(6, 6);
            this.WalerAutoRadio.Name = "WalerAutoRadio";
            this.WalerAutoRadio.Size = new System.Drawing.Size(47, 17);
            this.WalerAutoRadio.TabIndex = 15;
            this.WalerAutoRadio.TabStop = true;
            this.WalerAutoRadio.Text = "Auto";
            this.WalerAutoRadio.UseVisualStyleBackColor = true;
            this.WalerAutoRadio.CheckedChanged += new System.EventHandler(this.WalerAutoRadio_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.WalerResetButton);
            this.tabPage2.Controls.Add(this.WalerRemoveButton);
            this.tabPage2.Controls.Add(this.WalerEditValue);
            this.tabPage2.Controls.Add(this.WalerEditButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(180, 83);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // WalerResetButton
            // 
            this.WalerResetButton.Enabled = false;
            this.WalerResetButton.Location = new System.Drawing.Point(6, 55);
            this.WalerResetButton.Name = "WalerResetButton";
            this.WalerResetButton.Size = new System.Drawing.Size(83, 20);
            this.WalerResetButton.TabIndex = 10;
            this.WalerResetButton.Text = "Remove All";
            this.WalerResetButton.UseVisualStyleBackColor = true;
            this.WalerResetButton.Click += new System.EventHandler(this.WalerResetButton_Click);
            // 
            // WalerRemoveButton
            // 
            this.WalerRemoveButton.Enabled = false;
            this.WalerRemoveButton.Location = new System.Drawing.Point(92, 55);
            this.WalerRemoveButton.Name = "WalerRemoveButton";
            this.WalerRemoveButton.Size = new System.Drawing.Size(80, 20);
            this.WalerRemoveButton.TabIndex = 2021;
            this.WalerRemoveButton.Text = "Remove";
            this.WalerRemoveButton.UseVisualStyleBackColor = true;
            this.WalerRemoveButton.Click += new System.EventHandler(this.WalerRemoveButton_Click);
            // 
            // WalerEditValue
            // 
            this.WalerEditValue.Enabled = false;
            this.WalerEditValue.Location = new System.Drawing.Point(6, 29);
            this.WalerEditValue.Name = "WalerEditValue";
            this.WalerEditValue.Size = new System.Drawing.Size(83, 20);
            this.WalerEditValue.TabIndex = 19;
            // 
            // WalerEditButton
            // 
            this.WalerEditButton.Enabled = false;
            this.WalerEditButton.Location = new System.Drawing.Point(92, 29);
            this.WalerEditButton.Name = "WalerEditButton";
            this.WalerEditButton.Size = new System.Drawing.Size(80, 20);
            this.WalerEditButton.TabIndex = 20;
            this.WalerEditButton.Text = "Edit";
            this.WalerEditButton.UseVisualStyleBackColor = true;
            this.WalerEditButton.Click += new System.EventHandler(this.WalerEditButton_Click);
            // 
            // WalersSumLabel
            // 
            this.WalersSumLabel.AutoSize = true;
            this.WalersSumLabel.Location = new System.Drawing.Point(251, 325);
            this.WalersSumLabel.Name = "WalersSumLabel";
            this.WalersSumLabel.Size = new System.Drawing.Size(13, 13);
            this.WalersSumLabel.TabIndex = 18;
            this.WalersSumLabel.Text = "0";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(201, 325);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(46, 13);
            this.label30.TabIndex = 17;
            this.label30.Text = "Walers: ";
            // 
            // WalersList
            // 
            this.WalersList.AllowDrop = true;
            this.WalersList.FormattingEnabled = true;
            this.WalersList.Location = new System.Drawing.Point(204, 240);
            this.WalersList.Name = "WalersList";
            this.WalersList.Size = new System.Drawing.Size(151, 82);
            this.WalersList.TabIndex = 22;
            this.WalersList.SelectedIndexChanged += new System.EventHandler(this.WalersList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel6);
            this.groupBox1.Location = new System.Drawing.Point(190, 342);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(169, 103);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Diagonal Beam";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.label23, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.CornerOffset, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.CornerOffsetLabel, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.TopOffsetLabel, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.DiagonalBottomOffset, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.DiagonalTopOffset, 1, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(6, 17);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(155, 82);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(2, 48);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 13);
            this.label23.TabIndex = 18;
            this.label23.Text = "Bottom Offset";
            // 
            // CornerOffset
            // 
            this.CornerOffset.Location = new System.Drawing.Point(79, 2);
            this.CornerOffset.Margin = new System.Windows.Forms.Padding(2);
            this.CornerOffset.Name = "CornerOffset";
            this.CornerOffset.Size = new System.Drawing.Size(51, 20);
            this.CornerOffset.TabIndex = 26;
            this.CornerOffset.Text = "10.0";
            this.CornerOffset.TextChanged += new System.EventHandler(this.CornerOffset_TextChanged);
            this.CornerOffset.Validating += new System.ComponentModel.CancelEventHandler(this.CornerOffset_Validating);
            // 
            // CornerOffsetLabel
            // 
            this.CornerOffsetLabel.AutoSize = true;
            this.CornerOffsetLabel.Location = new System.Drawing.Point(2, 0);
            this.CornerOffsetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CornerOffsetLabel.Name = "CornerOffsetLabel";
            this.CornerOffsetLabel.Size = new System.Drawing.Size(69, 13);
            this.CornerOffsetLabel.TabIndex = 0;
            this.CornerOffsetLabel.Text = "Corner Offset";
            // 
            // TopOffsetLabel
            // 
            this.TopOffsetLabel.AutoSize = true;
            this.TopOffsetLabel.Location = new System.Drawing.Point(2, 24);
            this.TopOffsetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TopOffsetLabel.Name = "TopOffsetLabel";
            this.TopOffsetLabel.Size = new System.Drawing.Size(57, 13);
            this.TopOffsetLabel.TabIndex = 3;
            this.TopOffsetLabel.Text = "Top Offset";
            // 
            // DiagonalBottomOffset
            // 
            this.DiagonalBottomOffset.Location = new System.Drawing.Point(79, 50);
            this.DiagonalBottomOffset.Margin = new System.Windows.Forms.Padding(2);
            this.DiagonalBottomOffset.Name = "DiagonalBottomOffset";
            this.DiagonalBottomOffset.Size = new System.Drawing.Size(51, 20);
            this.DiagonalBottomOffset.TabIndex = 28;
            this.DiagonalBottomOffset.Text = "0.0";
            this.DiagonalBottomOffset.TextChanged += new System.EventHandler(this.DiagonalBottomOffset_TextChanged);
            this.DiagonalBottomOffset.Validating += new System.ComponentModel.CancelEventHandler(this.DiagonalBottomOffset_Validating);
            // 
            // DiagonalTopOffset
            // 
            this.DiagonalTopOffset.Location = new System.Drawing.Point(79, 26);
            this.DiagonalTopOffset.Margin = new System.Windows.Forms.Padding(2);
            this.DiagonalTopOffset.Name = "DiagonalTopOffset";
            this.DiagonalTopOffset.Size = new System.Drawing.Size(51, 20);
            this.DiagonalTopOffset.TabIndex = 27;
            this.DiagonalTopOffset.Text = "0.0";
            this.DiagonalTopOffset.TextChanged += new System.EventHandler(this.DiagonalTopOffset_TextChanged);
            this.DiagonalTopOffset.Validating += new System.ComponentModel.CancelEventHandler(this.DiagonalTopOffset_Validating);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel2);
            this.groupBox5.Location = new System.Drawing.Point(6, 342);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(169, 102);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Features";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 5;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.RailingSpace1, 4, 0);
            this.tableLayoutPanel7.Controls.Add(this.RailingSpace2, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.label19, 3, 0);
            this.tableLayoutPanel7.Controls.Add(this.label20, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(9, 19);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(345, 28);
            this.tableLayoutPanel7.TabIndex = 7;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(200, 59);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(117, 13);
            this.label21.TabIndex = 6;
            this.label21.Text = "Back Horizontal Beams";
            // 
            // StructureControl
            // 
            this.StructureControl.Controls.Add(this.StructureAddTab);
            this.StructureControl.Controls.Add(this.StructureEditTab);
            this.StructureControl.Location = new System.Drawing.Point(9, 53);
            this.StructureControl.Name = "StructureControl";
            this.StructureControl.SelectedIndex = 0;
            this.StructureControl.Size = new System.Drawing.Size(188, 109);
            this.StructureControl.TabIndex = 2;
            // 
            // StructureAddTab
            // 
            this.StructureAddTab.Controls.Add(this.StructureManualRadio);
            this.StructureAddTab.Controls.Add(this.HorizontalBeamsAddValue);
            this.StructureAddTab.Controls.Add(this.HorizontalBeamsAddButton);
            this.StructureAddTab.Controls.Add(this.StructureAutoRadio);
            this.StructureAddTab.Location = new System.Drawing.Point(4, 22);
            this.StructureAddTab.Name = "StructureAddTab";
            this.StructureAddTab.Padding = new System.Windows.Forms.Padding(3);
            this.StructureAddTab.Size = new System.Drawing.Size(180, 83);
            this.StructureAddTab.TabIndex = 0;
            this.StructureAddTab.Text = "Add";
            this.StructureAddTab.UseVisualStyleBackColor = true;
            // 
            // StructureManualRadio
            // 
            this.StructureManualRadio.AutoSize = true;
            this.StructureManualRadio.Location = new System.Drawing.Point(59, 6);
            this.StructureManualRadio.Name = "StructureManualRadio";
            this.StructureManualRadio.Size = new System.Drawing.Size(60, 17);
            this.StructureManualRadio.TabIndex = 4;
            this.StructureManualRadio.TabStop = true;
            this.StructureManualRadio.Text = "Manual";
            this.StructureManualRadio.UseVisualStyleBackColor = true;
            this.StructureManualRadio.CheckedChanged += new System.EventHandler(this.StructureManualRadio_CheckedChanged);
            // 
            // HorizontalBeamsAddValue
            // 
            this.HorizontalBeamsAddValue.Enabled = false;
            this.HorizontalBeamsAddValue.Location = new System.Drawing.Point(6, 29);
            this.HorizontalBeamsAddValue.Name = "HorizontalBeamsAddValue";
            this.HorizontalBeamsAddValue.Size = new System.Drawing.Size(83, 20);
            this.HorizontalBeamsAddValue.TabIndex = 5;
            // 
            // HorizontalBeamsAddButton
            // 
            this.HorizontalBeamsAddButton.Enabled = false;
            this.HorizontalBeamsAddButton.Location = new System.Drawing.Point(6, 55);
            this.HorizontalBeamsAddButton.Name = "HorizontalBeamsAddButton";
            this.HorizontalBeamsAddButton.Size = new System.Drawing.Size(83, 20);
            this.HorizontalBeamsAddButton.TabIndex = 6;
            this.HorizontalBeamsAddButton.Text = "Add";
            this.HorizontalBeamsAddButton.UseVisualStyleBackColor = true;
            this.HorizontalBeamsAddButton.Click += new System.EventHandler(this.HorizontalBeamsAddButton_Click);
            // 
            // StructureAutoRadio
            // 
            this.StructureAutoRadio.AutoSize = true;
            this.StructureAutoRadio.Checked = true;
            this.StructureAutoRadio.Location = new System.Drawing.Point(6, 6);
            this.StructureAutoRadio.Name = "StructureAutoRadio";
            this.StructureAutoRadio.Size = new System.Drawing.Size(47, 17);
            this.StructureAutoRadio.TabIndex = 3;
            this.StructureAutoRadio.TabStop = true;
            this.StructureAutoRadio.Text = "Auto";
            this.StructureAutoRadio.UseVisualStyleBackColor = true;
            // 
            // StructureEditTab
            // 
            this.StructureEditTab.Controls.Add(this.HorizontalBeamsResetButton);
            this.StructureEditTab.Controls.Add(this.HorizontalBeamsRemoveButton);
            this.StructureEditTab.Controls.Add(this.HorizontalBeamsEditValue);
            this.StructureEditTab.Controls.Add(this.HorizontalBeamsEditButton);
            this.StructureEditTab.Location = new System.Drawing.Point(4, 22);
            this.StructureEditTab.Name = "StructureEditTab";
            this.StructureEditTab.Padding = new System.Windows.Forms.Padding(3);
            this.StructureEditTab.Size = new System.Drawing.Size(180, 83);
            this.StructureEditTab.TabIndex = 1;
            this.StructureEditTab.Text = "Edit";
            this.StructureEditTab.UseVisualStyleBackColor = true;
            // 
            // HorizontalBeamsResetButton
            // 
            this.HorizontalBeamsResetButton.Enabled = false;
            this.HorizontalBeamsResetButton.Location = new System.Drawing.Point(6, 55);
            this.HorizontalBeamsResetButton.Name = "HorizontalBeamsResetButton";
            this.HorizontalBeamsResetButton.Size = new System.Drawing.Size(83, 20);
            this.HorizontalBeamsResetButton.TabIndex = 10;
            this.HorizontalBeamsResetButton.TabStop = false;
            this.HorizontalBeamsResetButton.Text = "Remove All";
            this.HorizontalBeamsResetButton.UseVisualStyleBackColor = true;
            this.HorizontalBeamsResetButton.Click += new System.EventHandler(this.HorizontalBeamsResetButton_Click);
            // 
            // HorizontalBeamsRemoveButton
            // 
            this.HorizontalBeamsRemoveButton.Enabled = false;
            this.HorizontalBeamsRemoveButton.Location = new System.Drawing.Point(92, 55);
            this.HorizontalBeamsRemoveButton.Name = "HorizontalBeamsRemoveButton";
            this.HorizontalBeamsRemoveButton.Size = new System.Drawing.Size(80, 20);
            this.HorizontalBeamsRemoveButton.TabIndex = 9;
            this.HorizontalBeamsRemoveButton.Text = "Remove";
            this.HorizontalBeamsRemoveButton.UseVisualStyleBackColor = true;
            this.HorizontalBeamsRemoveButton.Click += new System.EventHandler(this.HorizontalBeamsRemoveButton_Click);
            // 
            // HorizontalBeamsEditValue
            // 
            this.HorizontalBeamsEditValue.Enabled = false;
            this.HorizontalBeamsEditValue.Location = new System.Drawing.Point(6, 29);
            this.HorizontalBeamsEditValue.Name = "HorizontalBeamsEditValue";
            this.HorizontalBeamsEditValue.Size = new System.Drawing.Size(83, 20);
            this.HorizontalBeamsEditValue.TabIndex = 7;
            // 
            // HorizontalBeamsEditButton
            // 
            this.HorizontalBeamsEditButton.Enabled = false;
            this.HorizontalBeamsEditButton.Location = new System.Drawing.Point(92, 29);
            this.HorizontalBeamsEditButton.Name = "HorizontalBeamsEditButton";
            this.HorizontalBeamsEditButton.Size = new System.Drawing.Size(80, 20);
            this.HorizontalBeamsEditButton.TabIndex = 8;
            this.HorizontalBeamsEditButton.Text = "Edit";
            this.HorizontalBeamsEditButton.UseVisualStyleBackColor = true;
            this.HorizontalBeamsEditButton.Click += new System.EventHandler(this.HorizontalBeamsEditButton_Click);
            // 
            // BeamsSumLabel
            // 
            this.BeamsSumLabel.AutoSize = true;
            this.BeamsSumLabel.Location = new System.Drawing.Point(241, 160);
            this.BeamsSumLabel.Name = "BeamsSumLabel";
            this.BeamsSumLabel.Size = new System.Drawing.Size(13, 13);
            this.BeamsSumLabel.TabIndex = 5;
            this.BeamsSumLabel.Text = "0";
            // 
            // BeamsLabel
            // 
            this.BeamsLabel.AutoSize = true;
            this.BeamsLabel.Location = new System.Drawing.Point(200, 160);
            this.BeamsLabel.Name = "BeamsLabel";
            this.BeamsLabel.Size = new System.Drawing.Size(45, 13);
            this.BeamsLabel.TabIndex = 4;
            this.BeamsLabel.Text = "Beams: ";
            // 
            // HorizontalBeamsList
            // 
            this.HorizontalBeamsList.AllowDrop = true;
            this.HorizontalBeamsList.FormattingEnabled = true;
            this.HorizontalBeamsList.Location = new System.Drawing.Point(203, 75);
            this.HorizontalBeamsList.Name = "HorizontalBeamsList";
            this.HorizontalBeamsList.Size = new System.Drawing.Size(151, 82);
            this.HorizontalBeamsList.TabIndex = 11;
            this.HorizontalBeamsList.SelectedIndexChanged += new System.EventHandler(this.HorizontalBeamsList_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1048, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 13);
            this.label22.TabIndex = 9;
            this.label22.Text = "Version 3.1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(626, 347);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(482, 164);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(1042, 478);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(52, 13);
            this.label24.TabIndex = 12;
            this.label24.Text = "Top View";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(1042, 386);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(57, 13);
            this.label25.TabIndex = 13;
            this.label25.Text = "Front View";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(673, 331);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 13);
            this.label26.TabIndex = 14;
            this.label26.Text = "Side View 1";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(844, 331);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(63, 13);
            this.label27.TabIndex = 15;
            this.label27.Text = "Side View 2";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel9);
            this.groupBox6.Location = new System.Drawing.Point(381, 617);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(240, 101);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Bracket Bolts";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.Controls.Add(this.BracketBoltDiameter, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.label37, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.BracketBoltStandard, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.label34, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(5, 18);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(230, 53);
            this.tableLayoutPanel9.TabIndex = 3;
            // 
            // BracketBoltDiameter
            // 
            this.BracketBoltDiameter.Location = new System.Drawing.Point(122, 26);
            this.BracketBoltDiameter.Margin = new System.Windows.Forms.Padding(2);
            this.BracketBoltDiameter.Name = "BracketBoltDiameter";
            this.BracketBoltDiameter.Size = new System.Drawing.Size(52, 20);
            this.BracketBoltDiameter.TabIndex = 1;
            this.BracketBoltDiameter.Text = "12.0";
            this.BracketBoltDiameter.TextChanged += new System.EventHandler(this.BracketBoltDiameter_TextChanged);
            this.BracketBoltDiameter.Validating += new System.ComponentModel.CancelEventHandler(this.BracketBoltDiameter_Validating);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(2, 24);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(70, 13);
            this.label37.TabIndex = 5;
            this.label37.Text = "Bolt Diameter";
            // 
            // BracketBoltStandard
            // 
            this.BracketBoltStandard.Location = new System.Drawing.Point(122, 2);
            this.BracketBoltStandard.Margin = new System.Windows.Forms.Padding(2);
            this.BracketBoltStandard.Name = "BracketBoltStandard";
            this.BracketBoltStandard.Size = new System.Drawing.Size(52, 20);
            this.BracketBoltStandard.TabIndex = 0;
            this.BracketBoltStandard.Text = "8.8S";
            this.BracketBoltStandard.TextChanged += new System.EventHandler(this.BracketBoltStandard_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(2, 0);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(71, 13);
            this.label34.TabIndex = 1;
            this.label34.Text = "Bolt Standard";
            // 
            // SeatingPlateOffButton
            // 
            this.SeatingPlateOffButton.AutoSize = true;
            this.SeatingPlateOffButton.Location = new System.Drawing.Point(51, 19);
            this.SeatingPlateOffButton.Name = "SeatingPlateOffButton";
            this.SeatingPlateOffButton.Size = new System.Drawing.Size(39, 17);
            this.SeatingPlateOffButton.TabIndex = 1;
            this.SeatingPlateOffButton.TabStop = true;
            this.SeatingPlateOffButton.Text = "Off";
            this.SeatingPlateOffButton.UseVisualStyleBackColor = true;
            // 
            // SeatingPlateOnButton
            // 
            this.SeatingPlateOnButton.AutoSize = true;
            this.SeatingPlateOnButton.Checked = true;
            this.SeatingPlateOnButton.Location = new System.Drawing.Point(6, 19);
            this.SeatingPlateOnButton.Name = "SeatingPlateOnButton";
            this.SeatingPlateOnButton.Size = new System.Drawing.Size(39, 17);
            this.SeatingPlateOnButton.TabIndex = 0;
            this.SeatingPlateOnButton.TabStop = true;
            this.SeatingPlateOnButton.Text = "On";
            this.SeatingPlateOnButton.UseVisualStyleBackColor = true;
            this.SeatingPlateOnButton.CheckedChanged += new System.EventHandler(this.SeatingPlateOnButton_CheckedChanged);
            // 
            // SeatingPlateOffset
            // 
            this.SeatingPlateOffset.Location = new System.Drawing.Point(102, 2);
            this.SeatingPlateOffset.Margin = new System.Windows.Forms.Padding(2);
            this.SeatingPlateOffset.Name = "SeatingPlateOffset";
            this.SeatingPlateOffset.Size = new System.Drawing.Size(52, 20);
            this.SeatingPlateOffset.TabIndex = 2;
            this.SeatingPlateOffset.Text = "10.0";
            this.SeatingPlateOffset.TextChanged += new System.EventHandler(this.SeatingPlateOffset_TextChanged);
            this.SeatingPlateOffset.Validating += new System.ComponentModel.CancelEventHandler(this.SeatingPlateOffset_Validating);
            // 
            // ExtrusionLength
            // 
            this.ExtrusionLength.Location = new System.Drawing.Point(287, 2);
            this.ExtrusionLength.Margin = new System.Windows.Forms.Padding(2);
            this.ExtrusionLength.Name = "ExtrusionLength";
            this.ExtrusionLength.Size = new System.Drawing.Size(52, 20);
            this.ExtrusionLength.TabIndex = 3;
            this.ExtrusionLength.Text = "75.0";
            this.ExtrusionLength.TextChanged += new System.EventHandler(this.ExtrusionLength_TextChanged);
            this.ExtrusionLength.Validating += new System.ComponentModel.CancelEventHandler(this.ExtrusionLength_Validating);
            // 
            // seatingplateextrusionlengthLabel
            // 
            this.seatingplateextrusionlengthLabel.AutoSize = true;
            this.seatingplateextrusionlengthLabel.Location = new System.Drawing.Point(187, 0);
            this.seatingplateextrusionlengthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.seatingplateextrusionlengthLabel.Name = "seatingplateextrusionlengthLabel";
            this.seatingplateextrusionlengthLabel.Size = new System.Drawing.Size(86, 13);
            this.seatingplateextrusionlengthLabel.TabIndex = 1;
            this.seatingplateextrusionlengthLabel.Text = "Extrusion Length";
            this.seatingplateextrusionlengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeatingplateoffsetLabel
            // 
            this.SeatingplateoffsetLabel.AutoSize = true;
            this.SeatingplateoffsetLabel.Location = new System.Drawing.Point(2, 0);
            this.SeatingplateoffsetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SeatingplateoffsetLabel.Name = "SeatingplateoffsetLabel";
            this.SeatingplateoffsetLabel.Size = new System.Drawing.Size(62, 13);
            this.SeatingplateoffsetLabel.TabIndex = 0;
            this.SeatingplateoffsetLabel.Text = "Plate Offset";
            this.SeatingplateoffsetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tableLayoutPanel10);
            this.groupBox7.Location = new System.Drawing.Point(625, 516);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(239, 152);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Walkway Mesh";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.Controls.Add(this.MeshThickness, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.MeshThickLabel, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.WalkwayMaterial, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.MeshMaterialLabel, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.WalkwayWidthLabel, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.WalkwayWidth, 1, 3);
            this.tableLayoutPanel10.Controls.Add(this.WalkwayClearanceLabel, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.EAclearanceLabel, 0, 4);
            this.tableLayoutPanel10.Controls.Add(this.WalkwayClearance, 1, 2);
            this.tableLayoutPanel10.Controls.Add(this.EAClearance, 1, 4);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(5, 18);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 5;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(230, 123);
            this.tableLayoutPanel10.TabIndex = 3;
            // 
            // WalkwayMaterial
            // 
            this.WalkwayMaterial.Location = new System.Drawing.Point(122, 26);
            this.WalkwayMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.WalkwayMaterial.Name = "WalkwayMaterial";
            this.WalkwayMaterial.Size = new System.Drawing.Size(52, 20);
            this.WalkwayMaterial.TabIndex = 1;
            this.WalkwayMaterial.Text = "FM14";
            this.WalkwayMaterial.TextChanged += new System.EventHandler(this.WalkwayMaterial_TextChanged);
            // 
            // MeshMaterialLabel
            // 
            this.MeshMaterialLabel.AutoSize = true;
            this.MeshMaterialLabel.Location = new System.Drawing.Point(2, 24);
            this.MeshMaterialLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MeshMaterialLabel.Name = "MeshMaterialLabel";
            this.MeshMaterialLabel.Size = new System.Drawing.Size(91, 13);
            this.MeshMaterialLabel.TabIndex = 1;
            this.MeshMaterialLabel.Text = "Walkway Material";
            // 
            // WalkwayWidthLabel
            // 
            this.WalkwayWidthLabel.AutoSize = true;
            this.WalkwayWidthLabel.Location = new System.Drawing.Point(2, 72);
            this.WalkwayWidthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WalkwayWidthLabel.Name = "WalkwayWidthLabel";
            this.WalkwayWidthLabel.Size = new System.Drawing.Size(82, 13);
            this.WalkwayWidthLabel.TabIndex = 15;
            this.WalkwayWidthLabel.Text = "Walkway Width";
            // 
            // WalkwayWidth
            // 
            this.WalkwayWidth.Location = new System.Drawing.Point(122, 74);
            this.WalkwayWidth.Margin = new System.Windows.Forms.Padding(2);
            this.WalkwayWidth.Name = "WalkwayWidth";
            this.WalkwayWidth.Size = new System.Drawing.Size(52, 20);
            this.WalkwayWidth.TabIndex = 3;
            this.WalkwayWidth.Text = "600.0";
            this.WalkwayWidth.TextChanged += new System.EventHandler(this.WalkwayWidth_TextChanged);
            this.WalkwayWidth.Validating += new System.ComponentModel.CancelEventHandler(this.WalkwayWidth_Validating);
            // 
            // WalkwayClearanceLabel
            // 
            this.WalkwayClearanceLabel.AutoSize = true;
            this.WalkwayClearanceLabel.Location = new System.Drawing.Point(2, 48);
            this.WalkwayClearanceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WalkwayClearanceLabel.Name = "WalkwayClearanceLabel";
            this.WalkwayClearanceLabel.Size = new System.Drawing.Size(102, 13);
            this.WalkwayClearanceLabel.TabIndex = 16;
            this.WalkwayClearanceLabel.Text = "Walkway Clearance";
            // 
            // EAclearanceLabel
            // 
            this.EAclearanceLabel.AutoSize = true;
            this.EAclearanceLabel.Location = new System.Drawing.Point(2, 96);
            this.EAclearanceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EAclearanceLabel.Name = "EAclearanceLabel";
            this.EAclearanceLabel.Size = new System.Drawing.Size(112, 13);
            this.EAclearanceLabel.TabIndex = 5;
            this.EAclearanceLabel.Text = "EA Support Clearance";
            // 
            // WalkwayClearance
            // 
            this.WalkwayClearance.Location = new System.Drawing.Point(122, 50);
            this.WalkwayClearance.Margin = new System.Windows.Forms.Padding(2);
            this.WalkwayClearance.Name = "WalkwayClearance";
            this.WalkwayClearance.Size = new System.Drawing.Size(52, 20);
            this.WalkwayClearance.TabIndex = 2;
            this.WalkwayClearance.Text = "15.0";
            this.WalkwayClearance.TextChanged += new System.EventHandler(this.WalkwayClearance_TextChanged);
            this.WalkwayClearance.Validating += new System.ComponentModel.CancelEventHandler(this.WalkwayClearance_Validating);
            // 
            // EAClearance
            // 
            this.EAClearance.Location = new System.Drawing.Point(122, 98);
            this.EAClearance.Margin = new System.Windows.Forms.Padding(2);
            this.EAClearance.Name = "EAClearance";
            this.EAClearance.Size = new System.Drawing.Size(52, 20);
            this.EAClearance.TabIndex = 4;
            this.EAClearance.Text = "50.0";
            this.EAClearance.TextChanged += new System.EventHandler(this.EAClearance_TextChanged);
            this.EAClearance.Validating += new System.ComponentModel.CancelEventHandler(this.EAClearance_Validating);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox10);
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Location = new System.Drawing.Point(869, 516);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(239, 152);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Z Bracket";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tableLayoutPanel12);
            this.groupBox10.Location = new System.Drawing.Point(8, 95);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox10.Size = new System.Drawing.Size(222, 50);
            this.groupBox10.TabIndex = 6;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "End Bracket";
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.Controls.Add(this.ZbracketEndSpacing, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(214, 27);
            this.tableLayoutPanel12.TabIndex = 4;
            // 
            // ZbracketEndSpacing
            // 
            this.ZbracketEndSpacing.Location = new System.Drawing.Point(122, 2);
            this.ZbracketEndSpacing.Margin = new System.Windows.Forms.Padding(2);
            this.ZbracketEndSpacing.Name = "ZbracketEndSpacing";
            this.ZbracketEndSpacing.Size = new System.Drawing.Size(52, 20);
            this.ZbracketEndSpacing.TabIndex = 2;
            this.ZbracketEndSpacing.Text = "10.0";
            this.ZbracketEndSpacing.TextChanged += new System.EventHandler(this.ZbracketEndSpacing_TextChanged);
            this.ZbracketEndSpacing.Validating += new System.ComponentModel.CancelEventHandler(this.ZbracketEndSpacing_Validating);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(2, 0);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Z bracket Spacing a";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tableLayoutPanel11);
            this.groupBox9.Location = new System.Drawing.Point(8, 17);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(222, 74);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Middle Bracket";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.Controls.Add(this.ZbracketSpacingA, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.ZbracketSpacingALabel, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.ZbracketSpacingB, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.ZbracketSpacingBLabel, 0, 1);
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(214, 53);
            this.tableLayoutPanel11.TabIndex = 3;
            // 
            // ZbracketSpacingA
            // 
            this.ZbracketSpacingA.Location = new System.Drawing.Point(122, 2);
            this.ZbracketSpacingA.Margin = new System.Windows.Forms.Padding(2);
            this.ZbracketSpacingA.Name = "ZbracketSpacingA";
            this.ZbracketSpacingA.Size = new System.Drawing.Size(52, 20);
            this.ZbracketSpacingA.TabIndex = 0;
            this.ZbracketSpacingA.Text = "10.0";
            this.ZbracketSpacingA.TextChanged += new System.EventHandler(this.ZbracketSpacingA_TextChanged);
            this.ZbracketSpacingA.Validating += new System.ComponentModel.CancelEventHandler(this.ZbracketSpacingA_Validating);
            // 
            // ZbracketSpacingALabel
            // 
            this.ZbracketSpacingALabel.AutoSize = true;
            this.ZbracketSpacingALabel.Location = new System.Drawing.Point(2, 0);
            this.ZbracketSpacingALabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ZbracketSpacingALabel.Name = "ZbracketSpacingALabel";
            this.ZbracketSpacingALabel.Size = new System.Drawing.Size(104, 13);
            this.ZbracketSpacingALabel.TabIndex = 5;
            this.ZbracketSpacingALabel.Text = "Z bracket Spacing a";
            // 
            // ZbracketSpacingB
            // 
            this.ZbracketSpacingB.Location = new System.Drawing.Point(122, 26);
            this.ZbracketSpacingB.Margin = new System.Windows.Forms.Padding(2);
            this.ZbracketSpacingB.Name = "ZbracketSpacingB";
            this.ZbracketSpacingB.Size = new System.Drawing.Size(52, 20);
            this.ZbracketSpacingB.TabIndex = 1;
            this.ZbracketSpacingB.Text = "20.0";
            this.ZbracketSpacingB.TextChanged += new System.EventHandler(this.ZbracketSpacingB_TextChanged);
            this.ZbracketSpacingB.Validating += new System.ComponentModel.CancelEventHandler(this.ZbracketSpacingB_Validating);
            // 
            // ZbracketSpacingBLabel
            // 
            this.ZbracketSpacingBLabel.AutoSize = true;
            this.ZbracketSpacingBLabel.Location = new System.Drawing.Point(2, 24);
            this.ZbracketSpacingBLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ZbracketSpacingBLabel.Name = "ZbracketSpacingBLabel";
            this.ZbracketSpacingBLabel.Size = new System.Drawing.Size(104, 13);
            this.ZbracketSpacingBLabel.TabIndex = 1;
            this.ZbracketSpacingBLabel.Text = "Z bracket Spacing b";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(953, 26);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(155, 315);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(1033, 84);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(66, 13);
            this.label35.TabIndex = 20;
            this.label35.Text = "End Bracket";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(1021, 214);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(78, 13);
            this.label36.TabIndex = 21;
            this.label36.Text = "Middle Bracket";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.tableLayoutPanel13);
            this.groupBox11.Controls.Add(this.SeatingPlateOffButton);
            this.groupBox11.Controls.Add(this.SeatingPlateOnButton);
            this.groupBox11.Location = new System.Drawing.Point(626, 673);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(482, 45);
            this.groupBox11.TabIndex = 8;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Seating Plate";
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 6;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel13.Controls.Add(this.ExtrusionLength, 4, 0);
            this.tableLayoutPanel13.Controls.Add(this.SeatingPlateOffset, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.seatingplateextrusionlengthLabel, 3, 0);
            this.tableLayoutPanel13.Controls.Add(this.SeatingplateoffsetLabel, 0, 0);
            this.tableLayoutPanel13.Location = new System.Drawing.Point(96, 14);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(377, 24);
            this.tableLayoutPanel13.TabIndex = 2;
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(TeklaBillboardAid.Program);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1116, 771);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.validateButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.MaterialAndProfile);
            this.Controls.Add(this.ledCabinets);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tekla Billboard Aid";
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            this.ledCabinets.ResumeLayout(false);
            this.ledCabinets.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.CabinetControl.ResumeLayout(false);
            this.CabinetAddTab.ResumeLayout(false);
            this.CabinetAddTab.PerformLayout();
            this.CabinetEditTab.ResumeLayout(false);
            this.CabinetEditTab.PerformLayout();
            this.MaterialAndProfile.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.StructureControl.ResumeLayout(false);
            this.StructureAddTab.ResumeLayout(false);
            this.StructureAddTab.PerformLayout();
            this.StructureEditTab.ResumeLayout(false);
            this.StructureEditTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LEDProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(LEDProfile.Text))
            {
                errorProvider.SetError(LEDProfile, "Profile required");
            }
            else if (!Regex.IsMatch(LEDProfile.Text, @"^PLT\d+(?:\.\d+)?$"))
            {
                errorProvider.SetError(LEDProfile, "Profile invalid");
            }
            else
            {
                errorProvider.SetError(LEDProfile, null);
            }
        }

        private void B1Profile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateProfile(B1Profile);
        }

        private void B2Profile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateProfile(B2Profile);
        }
        private void B5Profile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateProfile(B5Profile);
        }

        private void B3Profile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateProfile(B3Profile);
        }

        private void C1Profile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateProfile(C1Profile);
        }
        private void BR1Profile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateProfile(BR1Profile);
        }

        private void WalerProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateProfile(WalerProfile);
        }

        private void SeatingPlateProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(SeatingPlateProfile.Text))
            {
                errorProvider.SetError(SeatingPlateProfile, "Profile required");
            }
            else if (!Regex.IsMatch(SeatingPlateProfile.Text, @"^(FL)\d+(?:\.\d+)?$"))
            {
                errorProvider.SetError(SeatingPlateProfile, "Profile invalid - Only FL profile");
            }
            else
            {
                errorProvider.SetError(SeatingPlateProfile, null);
            }
        }

        private void Welding_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(Welding);
        }

        private void MeshThickness_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(MeshThickness);
        }
        private void RailingSpace1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(RailingSpace1);
        }

        private void RailingSpace2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(RailingSpace2);
        }

        private void HoleHorizontalOffset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(HoleHorizontalOffset);
        }

        private void HoleVerticalOffset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(HoleVerticalOffset);
        }

        private void HeightOffsetTop_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(HeightOffsetTop);
        }

        private void HeightOffsetBottom_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(HeightOffsetBottom);
        }

        private void CornerOffset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(CornerOffset);
        }

        private void DiagonalTopOffset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(DiagonalTopOffset);
        }

        private void DiagonalBottomOffset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(DiagonalBottomOffset);
        }

        private void BoltDiameter_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(BoltDiameter);
        }

        private void SeatingPlateOffset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(SeatingPlateOffset);
        }

        private void ExtrusionLength_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(ExtrusionLength);
        }

        private void EAProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(EAProfile.Text))
            {
                errorProvider.SetError(EAProfile, "Profile required");
            }
            else if (!Regex.IsMatch(EAProfile.Text, @"^EA\d{2,3}\*\d{2,3}\*\d{1,2}$"))
            {
                errorProvider.SetError(EAProfile, "Profile invalid");
            }
            else
            {
                errorProvider.SetError(EAProfile, null);
            }
        }

        private void ZBracketProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(ZBracketProfile.Text))
            {
                errorProvider.SetError(ZBracketProfile, "Profile required");
            }
            else if (!Regex.IsMatch(ZBracketProfile.Text, @"^PLT\d{1,}(?:\.\d{1,})?(\*)?(?(1)\d{1,}(?:\.\d{1,})?$|$)"))
            {
                errorProvider.SetError(ZBracketProfile, "Profile invalid");
            }
            else
            {
                errorProvider.SetError(ZBracketProfile, null);
            }
        }

        private void LowerWalerSpacing_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(LowerWalerSpacing);
        }

        private void UpperWalerSpacing_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(UpperWalerSpacing);
        }

        private void EAClearance_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(EAClearance);
        }

        private void ZbracketSpacingA_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(ZbracketSpacingA);
        }

        private void ZbracketSpacingB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(ZbracketSpacingB);
        }
        private void ZbracketEndSpacing_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(ZbracketEndSpacing);
        }
        private void WalkwayClearance_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(WalkwayClearance);
        }
        private void WalkwayWidth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(WalkwayWidth);
        }
        private void BracketBoltDiameter_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validateDouble(BracketBoltDiameter);
        }

        private bool validateDouble(System.Windows.Forms.TextBox textbox)
        {
            if (string.IsNullOrEmpty(textbox.Text))
            {
                errorProvider.SetError(textbox, "Cannot be empty");
            }
            else if (!Regex.IsMatch(textbox.Text, @"^\d+(?:\.\d+)?$"))
            {
                errorProvider.SetError(textbox, "Invalid input");
            }
            else
            {
                errorProvider.SetError(textbox, null);
                return true;
            }
            return false;
        }

        // Profile string validation
        private bool validateProfile(System.Windows.Forms.TextBox textbox)
        {
            if (string.IsNullOrEmpty(textbox.Text))
            {
                errorProvider.SetError(textbox, "Profile required");
            }
            else if (!Regex.IsMatch(textbox.Text, @"^[SR]{1}HS\d{2,3}\*\d{2,3}\*\d{1,2}\.\d{1}$"))
            {
                errorProvider.SetError(textbox, "Profile invalid");
            }
            else
            {
                errorProvider.SetError(textbox, null);
                return true;
            }
            return false;
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox ledCabinets;
        private System.Windows.Forms.ListBox rowList;
        private System.Windows.Forms.Button cabinetValueAddButton;
        private System.Windows.Forms.TextBox cabinetAddValue;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.Label columnSumLabel;
        private System.Windows.Forms.Label columnLabel;
        private System.Windows.Forms.Label rowSumLabel;
        private System.Windows.Forms.Label rowLabel;
        private System.Windows.Forms.ListBox columnList;
        private System.Windows.Forms.RadioButton ColumnAddRadioButton;
        private System.Windows.Forms.RadioButton RowAddRadioButton;
        private System.Windows.Forms.TabControl CabinetControl;
        private System.Windows.Forms.TabPage CabinetAddTab;
        private System.Windows.Forms.TabPage CabinetEditTab;
        private System.Windows.Forms.Button CabinetRemoveButton;
        private System.Windows.Forms.RadioButton ColumnEditRadioButton;
        private System.Windows.Forms.RadioButton RowEditRadioButton;
        private System.Windows.Forms.TextBox CabinetEditValue;
        private System.Windows.Forms.Button CabinetEditButton;
        private System.Windows.Forms.Button CabinetResetButton;
        private System.Windows.Forms.GroupBox MaterialAndProfile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox B5Profile;
        private System.Windows.Forms.TextBox B5Material;
        private System.Windows.Forms.TextBox B2Profile;
        private System.Windows.Forms.TextBox B2Material;
        private System.Windows.Forms.TextBox B1Profile;
        private System.Windows.Forms.TextBox B1Material;
        private System.Windows.Forms.TextBox C1Profile;
        private System.Windows.Forms.TextBox LEDProfile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LED;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LEDMaterial;
        private System.Windows.Forms.TextBox C1Material;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HoleVerticalOffset;
        private System.Windows.Forms.TextBox HoleHorizontalOffset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox BoltDiameter;
        private System.Windows.Forms.Label BillBoardLength;
        private System.Windows.Forms.Label BillBoardHeight;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox HeightOffsetBottom;
        private System.Windows.Forms.TextBox HeightOffsetTop;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox B3Material;
        private System.Windows.Forms.TextBox B3Profile;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox RailingSpace2;
        private System.Windows.Forms.TextBox RailingSpace1;
        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabControl StructureControl;
        private System.Windows.Forms.TabPage StructureAddTab;
        private System.Windows.Forms.RadioButton StructureManualRadio;
        private System.Windows.Forms.TextBox HorizontalBeamsAddValue;
        private System.Windows.Forms.Button HorizontalBeamsAddButton;
        private System.Windows.Forms.RadioButton StructureAutoRadio;
        private System.Windows.Forms.TabPage StructureEditTab;
        private System.Windows.Forms.Button HorizontalBeamsResetButton;
        private System.Windows.Forms.Button HorizontalBeamsRemoveButton;
        private System.Windows.Forms.TextBox HorizontalBeamsEditValue;
        private System.Windows.Forms.Button HorizontalBeamsEditButton;
        private System.Windows.Forms.Label BeamsSumLabel;
        private System.Windows.Forms.Label BeamsLabel;
        private System.Windows.Forms.ListBox HorizontalBeamsList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label CabinetLengthLabel;
        private System.Windows.Forms.Label CabinetHeightLabel;
        private System.Windows.Forms.Label CabinetLengthSumLabel;
        private System.Windows.Forms.Label CabinetHeightSumLabel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox CornerOffset;
        private System.Windows.Forms.Label CornerOffsetLabel;
        private System.Windows.Forms.TextBox DiagonalTopOffset;
        private System.Windows.Forms.Label TopOffsetLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label MeshThickLabel;
        private System.Windows.Forms.TextBox MeshThickness;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox Welding;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox DiagonalBottomOffset;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox BR1Profile;
        private System.Windows.Forms.TextBox BR1Material;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox WalerMaterial;
        private System.Windows.Forms.TextBox WalerProfile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TextBox LowerWalerSpacing;
        private System.Windows.Forms.TextBox UpperWalerSpacing;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RadioButton WalerManualRadio;
        private System.Windows.Forms.TextBox WalerAddValue;
        private System.Windows.Forms.Button WalerAddButton;
        private System.Windows.Forms.RadioButton WalerAutoRadio;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button WalerResetButton;
        private System.Windows.Forms.Button WalerRemoveButton;
        private System.Windows.Forms.TextBox WalerEditValue;
        private System.Windows.Forms.Button WalerEditButton;
        private System.Windows.Forms.Label WalersSumLabel;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ListBox WalersList;
        private System.Windows.Forms.Label WalerNumberLabel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label SeatingplateoffsetLabel;
        private System.Windows.Forms.TextBox SeatingPlateOffset;
        private System.Windows.Forms.TextBox ExtrusionLength;
        private System.Windows.Forms.Label seatingplateextrusionlengthLabel;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox SeatingPlateMaterial;
        private System.Windows.Forms.TextBox SeatingPlateProfile;
        private System.Windows.Forms.RadioButton SeatingPlateOffButton;
        private System.Windows.Forms.RadioButton SeatingPlateOnButton;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TextBox EAClearance;
        private System.Windows.Forms.Label EAclearanceLabel;
        private System.Windows.Forms.TextBox WalkwayMaterial;
        private System.Windows.Forms.Label MeshMaterialLabel;
        private System.Windows.Forms.Label EALabel;
        private System.Windows.Forms.TextBox EAMaterial;
        private System.Windows.Forms.TextBox EAProfile;
        private System.Windows.Forms.Label ZBracketLabel;
        private System.Windows.Forms.TextBox ZBracketMaterial;
        private System.Windows.Forms.TextBox ZBracketProfile;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TextBox ZbracketSpacingA;
        private System.Windows.Forms.Label ZbracketSpacingALabel;
        private System.Windows.Forms.TextBox ZbracketSpacingB;
        private System.Windows.Forms.Label ZbracketSpacingBLabel;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TextBox ZbracketEndSpacing;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label WalkwayWidthLabel;
        private System.Windows.Forms.TextBox WalkwayWidth;
        private System.Windows.Forms.Label WalkwayClearanceLabel;
        private System.Windows.Forms.TextBox WalkwayClearance;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BillBoardDepth;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.TextBox BracketBoltDiameter;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox BracketBoltStandard;
        private System.Windows.Forms.Label label34;
    }
}

