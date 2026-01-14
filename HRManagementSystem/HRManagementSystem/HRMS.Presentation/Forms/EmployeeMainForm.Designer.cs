/*namespace HRMS.Presentation.HRMS.Presentation.Forms
{
    partial class EmployeeMainForm
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeMainForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblApp = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlCardSample = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlCardSample.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlHeader.Controls.Add(this.tableLayoutPanel1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1082, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.lblUser, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblApp, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1082, 64);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblUser.Location = new System.Drawing.Point(652, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(427, 64);
            this.lblUser.TabIndex = 1;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblApp
            // 
            this.lblApp.AutoSize = true;
            this.lblApp.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblApp.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblApp.ForeColor = System.Drawing.Color.White;
            this.lblApp.Location = new System.Drawing.Point(3, 0);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(79, 64);
            this.lblApp.TabIndex = 0;
            this.lblApp.Text = "HRMS";
            this.lblApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlCardSample);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 64);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(24);
            this.pnlContent.Size = new System.Drawing.Size(1082, 589);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlCardSample
            // 
            this.pnlCardSample.BackColor = System.Drawing.Color.White;
            this.pnlCardSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardSample.Controls.Add(this.label1);
            this.pnlCardSample.Location = new System.Drawing.Point(27, 27);
            this.pnlCardSample.Name = "pnlCardSample";
            this.pnlCardSample.Size = new System.Drawing.Size(300, 160);
            this.pnlCardSample.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(33, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Örnek Alan";
            // 
            // EmployeeMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "EmployeeMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HRMS | EMPLOYEE";
            this.Load += new System.EventHandler(this.EmployeeMainForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlCardSample.ResumeLayout(false);
            this.pnlCardSample.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlCardSample;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}*/

namespace HRMS.Presentation.HRMS.Presentation.Forms
{
    partial class EmployeeMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeMainForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblApp = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlPageMyLeaves = new System.Windows.Forms.Panel();
            this.chckMyLeavesOnlyApproved = new System.Windows.Forms.CheckBox();
            this.dgvMyLeaves = new System.Windows.Forms.DataGridView();
            this.pnlPageLeaveCreate = new System.Windows.Forms.Panel();
            this.btnLeaveCreateSave = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cmbLeaveType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pnlPageMyInfo = new System.Windows.Forms.Panel();
            this.btnMyInfoSave = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMyPhone = new System.Windows.Forms.TextBox();
            this.txtMyEmail = new System.Windows.Forms.TextBox();
            this.txtMyTitle = new System.Windows.Forms.TextBox();
            this.txtMyDepartment = new System.Windows.Forms.TextBox();
            this.txtMyFullName = new System.Windows.Forms.TextBox();
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.lblWelcomeSubtitle = new System.Windows.Forms.Label();
            this.lblWelcomeTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlPageDepartmentMgmt = new System.Windows.Forms.Panel();
            this.pnlPageEmployeeMgmt = new System.Windows.Forms.Panel();
            this.pnlPageAllLeavesHistory = new System.Windows.Forms.Panel();
            this.pnlPageAllLeaveRequests = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.flpNav = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMyInfo = new System.Windows.Forms.Button();
            this.btnMyLeaves = new System.Windows.Forms.Button();
            this.btnLeaveCreate = new System.Windows.Forms.Button();
            this.btnAllLeaveRequests = new System.Windows.Forms.Button();
            this.btnAllLeavesHistory = new System.Windows.Forms.Button();
            this.btnEmployeeMgmt = new System.Windows.Forms.Button();
            this.btnDepartmentMgmt = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.pnlCardSample = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tlpHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlPageMyLeaves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyLeaves)).BeginInit();
            this.pnlPageLeaveCreate.SuspendLayout();
            this.pnlPageMyInfo.SuspendLayout();
            this.pnlWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.flpNav.SuspendLayout();
            this.pnlCardSample.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlHeader.Controls.Add(this.tlpHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1082, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // tlpHeader
            // 
            this.tlpHeader.ColumnCount = 2;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeader.Controls.Add(this.lblUser, 1, 0);
            this.tlpHeader.Controls.Add(this.lblApp, 0, 0);
            this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpHeader.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHeader.Size = new System.Drawing.Size(1082, 64);
            this.tlpHeader.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblUser.Location = new System.Drawing.Point(652, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblUser.Size = new System.Drawing.Size(427, 64);
            this.lblUser.TabIndex = 1;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblApp
            // 
            this.lblApp.AutoSize = true;
            this.lblApp.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblApp.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblApp.ForeColor = System.Drawing.Color.White;
            this.lblApp.Location = new System.Drawing.Point(3, 0);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(79, 64);
            this.lblApp.TabIndex = 0;
            this.lblApp.Text = "HRMS";
            this.lblApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlMain);
            this.pnlContent.Controls.Add(this.pnlNav);
            this.pnlContent.Controls.Add(this.pnlCardSample);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 64);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1082, 589);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlPageMyLeaves);
            this.pnlMain.Controls.Add(this.pnlPageLeaveCreate);
            this.pnlMain.Controls.Add(this.pnlPageMyInfo);
            this.pnlMain.Controls.Add(this.pnlWelcome);
            this.pnlMain.Controls.Add(this.pnlPageDepartmentMgmt);
            this.pnlMain.Controls.Add(this.pnlPageEmployeeMgmt);
            this.pnlMain.Controls.Add(this.pnlPageAllLeavesHistory);
            this.pnlMain.Controls.Add(this.pnlPageAllLeaveRequests);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(273, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(809, 589);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlPageMyLeaves
            // 
            this.pnlPageMyLeaves.BackColor = System.Drawing.Color.White;
            this.pnlPageMyLeaves.Controls.Add(this.chckMyLeavesOnlyApproved);
            this.pnlPageMyLeaves.Controls.Add(this.dgvMyLeaves);
            this.pnlPageMyLeaves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPageMyLeaves.Location = new System.Drawing.Point(0, 0);
            this.pnlPageMyLeaves.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPageMyLeaves.Name = "pnlPageMyLeaves";
            this.pnlPageMyLeaves.Size = new System.Drawing.Size(809, 589);
            this.pnlPageMyLeaves.TabIndex = 2;
            this.pnlPageMyLeaves.Visible = false;
            // 
            // chckMyLeavesOnlyApproved
            // 
            this.chckMyLeavesOnlyApproved.AutoSize = true;
            this.chckMyLeavesOnlyApproved.Location = new System.Drawing.Point(31, 31);
            this.chckMyLeavesOnlyApproved.Name = "chckMyLeavesOnlyApproved";
            this.chckMyLeavesOnlyApproved.Size = new System.Drawing.Size(166, 20);
            this.chckMyLeavesOnlyApproved.TabIndex = 4;
            this.chckMyLeavesOnlyApproved.Text = "Sadece Onaylanmışlar";
            this.chckMyLeavesOnlyApproved.UseVisualStyleBackColor = true;
            this.chckMyLeavesOnlyApproved.CheckedChanged += new System.EventHandler(this.chckMyLeavesOnlyApproved_CheckedChanged);
            // 
            // dgvMyLeaves
            // 
            this.dgvMyLeaves.AllowUserToAddRows = false;
            this.dgvMyLeaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyLeaves.BackgroundColor = System.Drawing.Color.White;
            this.dgvMyLeaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyLeaves.Location = new System.Drawing.Point(31, 70);
            this.dgvMyLeaves.Name = "dgvMyLeaves";
            this.dgvMyLeaves.ReadOnly = true;
            this.dgvMyLeaves.RowHeadersVisible = false;
            this.dgvMyLeaves.RowHeadersWidth = 51;
            this.dgvMyLeaves.RowTemplate.Height = 24;
            this.dgvMyLeaves.Size = new System.Drawing.Size(746, 488);
            this.dgvMyLeaves.TabIndex = 3;
            // 
            // pnlPageLeaveCreate
            // 
            this.pnlPageLeaveCreate.BackColor = System.Drawing.Color.White;
            this.pnlPageLeaveCreate.Controls.Add(this.btnLeaveCreateSave);
            this.pnlPageLeaveCreate.Controls.Add(this.txtNote);
            this.pnlPageLeaveCreate.Controls.Add(this.dtpEnd);
            this.pnlPageLeaveCreate.Controls.Add(this.dtpStart);
            this.pnlPageLeaveCreate.Controls.Add(this.cmbLeaveType);
            this.pnlPageLeaveCreate.Controls.Add(this.label18);
            this.pnlPageLeaveCreate.Controls.Add(this.label17);
            this.pnlPageLeaveCreate.Controls.Add(this.label16);
            this.pnlPageLeaveCreate.Controls.Add(this.label15);
            this.pnlPageLeaveCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPageLeaveCreate.Location = new System.Drawing.Point(0, 0);
            this.pnlPageLeaveCreate.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPageLeaveCreate.Name = "pnlPageLeaveCreate";
            this.pnlPageLeaveCreate.Size = new System.Drawing.Size(809, 589);
            this.pnlPageLeaveCreate.TabIndex = 1;
            this.pnlPageLeaveCreate.Visible = false;
            // 
            // btnLeaveCreateSave
            // 
            this.btnLeaveCreateSave.Location = new System.Drawing.Point(311, 455);
            this.btnLeaveCreateSave.Name = "btnLeaveCreateSave";
            this.btnLeaveCreateSave.Size = new System.Drawing.Size(140, 23);
            this.btnLeaveCreateSave.TabIndex = 17;
            this.btnLeaveCreateSave.Text = "TALEP OLUŞTUR";
            this.btnLeaveCreateSave.UseVisualStyleBackColor = true;
            this.btnLeaveCreateSave.Click += new System.EventHandler(this.btnLeaveCreateSave_Click_1);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(251, 272);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(200, 22);
            this.txtNote.TabIndex = 16;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(251, 213);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 22);
            this.dtpEnd.TabIndex = 15;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(251, 154);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 22);
            this.dtpStart.TabIndex = 14;
            // 
            // cmbLeaveType
            // 
            this.cmbLeaveType.FormattingEnabled = true;
            this.cmbLeaveType.Location = new System.Drawing.Point(251, 101);
            this.cmbLeaveType.Name = "cmbLeaveType";
            this.cmbLeaveType.Size = new System.Drawing.Size(200, 24);
            this.cmbLeaveType.TabIndex = 13;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(138, 278);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 16);
            this.label18.TabIndex = 12;
            this.label18.Text = "AÇIKLAMA";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(138, 219);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 16);
            this.label17.TabIndex = 11;
            this.label17.Text = "BİTİŞ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(138, 159);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 16);
            this.label16.TabIndex = 10;
            this.label16.Text = "BAŞLANGIÇ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(138, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 16);
            this.label15.TabIndex = 9;
            this.label15.Text = "İZİN TÜRÜ";
            // 
            // pnlPageMyInfo
            // 
            this.pnlPageMyInfo.BackColor = System.Drawing.Color.White;
            this.pnlPageMyInfo.Controls.Add(this.btnMyInfoSave);
            this.pnlPageMyInfo.Controls.Add(this.label14);
            this.pnlPageMyInfo.Controls.Add(this.label13);
            this.pnlPageMyInfo.Controls.Add(this.label12);
            this.pnlPageMyInfo.Controls.Add(this.label11);
            this.pnlPageMyInfo.Controls.Add(this.label10);
            this.pnlPageMyInfo.Controls.Add(this.txtMyPhone);
            this.pnlPageMyInfo.Controls.Add(this.txtMyEmail);
            this.pnlPageMyInfo.Controls.Add(this.txtMyTitle);
            this.pnlPageMyInfo.Controls.Add(this.txtMyDepartment);
            this.pnlPageMyInfo.Controls.Add(this.txtMyFullName);
            this.pnlPageMyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPageMyInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlPageMyInfo.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPageMyInfo.Name = "pnlPageMyInfo";
            this.pnlPageMyInfo.Size = new System.Drawing.Size(809, 589);
            this.pnlPageMyInfo.TabIndex = 0;
            this.pnlPageMyInfo.Visible = false;
            // 
            // btnMyInfoSave
            // 
            this.btnMyInfoSave.Location = new System.Drawing.Point(402, 430);
            this.btnMyInfoSave.Name = "btnMyInfoSave";
            this.btnMyInfoSave.Size = new System.Drawing.Size(90, 23);
            this.btnMyInfoSave.TabIndex = 21;
            this.btnMyInfoSave.Text = "KAYDET";
            this.btnMyInfoSave.UseVisualStyleBackColor = true;
            this.btnMyInfoSave.Click += new System.EventHandler(this.btnMyInfoSave_Click_1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(119, 359);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 16);
            this.label14.TabIndex = 20;
            this.label14.Text = "TELEFON NO";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(119, 294);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 16);
            this.label13.TabIndex = 19;
            this.label13.Text = "E-MAIL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(119, 229);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 16);
            this.label12.TabIndex = 18;
            this.label12.Text = "ÜNVAN";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(119, 169);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 16);
            this.label11.TabIndex = 17;
            this.label11.Text = "DEPARTMAN";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(119, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "AD SOYAD";
            // 
            // txtMyPhone
            // 
            this.txtMyPhone.Location = new System.Drawing.Point(261, 353);
            this.txtMyPhone.Name = "txtMyPhone";
            this.txtMyPhone.Size = new System.Drawing.Size(231, 22);
            this.txtMyPhone.TabIndex = 15;
            // 
            // txtMyEmail
            // 
            this.txtMyEmail.Location = new System.Drawing.Point(261, 288);
            this.txtMyEmail.Name = "txtMyEmail";
            this.txtMyEmail.Size = new System.Drawing.Size(231, 22);
            this.txtMyEmail.TabIndex = 14;
            // 
            // txtMyTitle
            // 
            this.txtMyTitle.Location = new System.Drawing.Point(261, 223);
            this.txtMyTitle.Name = "txtMyTitle";
            this.txtMyTitle.ReadOnly = true;
            this.txtMyTitle.Size = new System.Drawing.Size(231, 22);
            this.txtMyTitle.TabIndex = 13;
            // 
            // txtMyDepartment
            // 
            this.txtMyDepartment.Location = new System.Drawing.Point(261, 163);
            this.txtMyDepartment.Name = "txtMyDepartment";
            this.txtMyDepartment.ReadOnly = true;
            this.txtMyDepartment.Size = new System.Drawing.Size(231, 22);
            this.txtMyDepartment.TabIndex = 12;
            // 
            // txtMyFullName
            // 
            this.txtMyFullName.Location = new System.Drawing.Point(261, 104);
            this.txtMyFullName.Name = "txtMyFullName";
            this.txtMyFullName.ReadOnly = true;
            this.txtMyFullName.Size = new System.Drawing.Size(231, 22);
            this.txtMyFullName.TabIndex = 11;
            // 
            // pnlWelcome
            // 
            this.pnlWelcome.BackColor = System.Drawing.Color.White;
            this.pnlWelcome.Controls.Add(this.lblWelcomeSubtitle);
            this.pnlWelcome.Controls.Add(this.lblWelcomeTitle);
            this.pnlWelcome.Controls.Add(this.picLogo);
            this.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWelcome.Location = new System.Drawing.Point(0, 0);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(809, 589);
            this.pnlWelcome.TabIndex = 0;
            // 
            // lblWelcomeSubtitle
            // 
            this.lblWelcomeSubtitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWelcomeSubtitle.AutoSize = true;
            this.lblWelcomeSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcomeSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblWelcomeSubtitle.Location = new System.Drawing.Point(209, 465);
            this.lblWelcomeSubtitle.Name = "lblWelcomeSubtitle";
            this.lblWelcomeSubtitle.Size = new System.Drawing.Size(418, 25);
            this.lblWelcomeSubtitle.TabIndex = 2;
            this.lblWelcomeSubtitle.Text = "Sol Menüyü Kullanarak İşlemlerinize Başlayabilirsiniz";
            // 
            // lblWelcomeTitle
            // 
            this.lblWelcomeTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWelcomeTitle.AutoSize = true;
            this.lblWelcomeTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcomeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblWelcomeTitle.Location = new System.Drawing.Point(280, 150);
            this.lblWelcomeTitle.Name = "lblWelcomeTitle";
            this.lblWelcomeTitle.Size = new System.Drawing.Size(269, 50);
            this.lblWelcomeTitle.TabIndex = 1;
            this.lblWelcomeTitle.Text = "HOŞ GELDİNİZ";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::HRMS.Presentation.Properties.Resources.ChatGPT_Image_8_Oca_2026_06_00_23;
            this.picLogo.Location = new System.Drawing.Point(384, 242);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(120, 120);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlPageDepartmentMgmt
            // 
            this.pnlPageDepartmentMgmt.BackColor = System.Drawing.Color.White;
            this.pnlPageDepartmentMgmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPageDepartmentMgmt.Location = new System.Drawing.Point(0, 0);
            this.pnlPageDepartmentMgmt.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPageDepartmentMgmt.Name = "pnlPageDepartmentMgmt";
            this.pnlPageDepartmentMgmt.Size = new System.Drawing.Size(809, 589);
            this.pnlPageDepartmentMgmt.TabIndex = 6;
            this.pnlPageDepartmentMgmt.Visible = false;
            // 
            // pnlPageEmployeeMgmt
            // 
            this.pnlPageEmployeeMgmt.BackColor = System.Drawing.Color.White;
            this.pnlPageEmployeeMgmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPageEmployeeMgmt.Location = new System.Drawing.Point(0, 0);
            this.pnlPageEmployeeMgmt.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPageEmployeeMgmt.Name = "pnlPageEmployeeMgmt";
            this.pnlPageEmployeeMgmt.Size = new System.Drawing.Size(809, 589);
            this.pnlPageEmployeeMgmt.TabIndex = 5;
            this.pnlPageEmployeeMgmt.Visible = false;
            // 
            // pnlPageAllLeavesHistory
            // 
            this.pnlPageAllLeavesHistory.BackColor = System.Drawing.Color.White;
            this.pnlPageAllLeavesHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPageAllLeavesHistory.Location = new System.Drawing.Point(0, 0);
            this.pnlPageAllLeavesHistory.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPageAllLeavesHistory.Name = "pnlPageAllLeavesHistory";
            this.pnlPageAllLeavesHistory.Size = new System.Drawing.Size(809, 589);
            this.pnlPageAllLeavesHistory.TabIndex = 4;
            this.pnlPageAllLeavesHistory.Visible = false;
            // 
            // pnlPageAllLeaveRequests
            // 
            this.pnlPageAllLeaveRequests.BackColor = System.Drawing.Color.White;
            this.pnlPageAllLeaveRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPageAllLeaveRequests.Location = new System.Drawing.Point(0, 0);
            this.pnlPageAllLeaveRequests.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPageAllLeaveRequests.Name = "pnlPageAllLeaveRequests";
            this.pnlPageAllLeaveRequests.Size = new System.Drawing.Size(809, 589);
            this.pnlPageAllLeaveRequests.TabIndex = 3;
            this.pnlPageAllLeaveRequests.Visible = false;
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.White;
            this.pnlNav.Controls.Add(this.picHome);
            this.pnlNav.Controls.Add(this.flpNav);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(273, 589);
            this.pnlNav.TabIndex = 1;
            // 
            // picHome
            // 
            this.picHome.BackColor = System.Drawing.Color.Transparent;
            this.picHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHome.Image = global::HRMS.Presentation.Properties.Resources.home_heart_10786413;
            this.picHome.Location = new System.Drawing.Point(125, 20);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(35, 35);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHome.TabIndex = 8;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click_1);
            this.picHome.MouseEnter += new System.EventHandler(this.picHome_MouseEnter_1);
            this.picHome.MouseLeave += new System.EventHandler(this.picHome_MouseLeave_1);
            // 
            // flpNav
            // 
            this.flpNav.AutoSize = true;
            this.flpNav.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpNav.BackColor = System.Drawing.Color.Transparent;
            this.flpNav.Controls.Add(this.btnMyInfo);
            this.flpNav.Controls.Add(this.btnMyLeaves);
            this.flpNav.Controls.Add(this.btnLeaveCreate);
            this.flpNav.Controls.Add(this.btnAllLeaveRequests);
            this.flpNav.Controls.Add(this.btnAllLeavesHistory);
            this.flpNav.Controls.Add(this.btnEmployeeMgmt);
            this.flpNav.Controls.Add(this.btnDepartmentMgmt);
            this.flpNav.Controls.Add(this.btnReports);
            this.flpNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpNav.Location = new System.Drawing.Point(0, 70);
            this.flpNav.Name = "flpNav";
            this.flpNav.Size = new System.Drawing.Size(278, 448);
            this.flpNav.TabIndex = 9;
            this.flpNav.WrapContents = false;
            // 
            // btnMyInfo
            // 
            this.btnMyInfo.BackColor = System.Drawing.Color.SteelBlue;
            this.btnMyInfo.FlatAppearance.BorderSize = 0;
            this.btnMyInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMyInfo.ForeColor = System.Drawing.Color.White;
            this.btnMyInfo.Location = new System.Drawing.Point(20, 12);
            this.btnMyInfo.Margin = new System.Windows.Forms.Padding(20, 12, 20, 0);
            this.btnMyInfo.Name = "btnMyInfo";
            this.btnMyInfo.Size = new System.Drawing.Size(238, 44);
            this.btnMyInfo.TabIndex = 0;
            this.btnMyInfo.Text = "Bilgilerim";
            this.btnMyInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyInfo.UseVisualStyleBackColor = false;
            this.btnMyInfo.Click += new System.EventHandler(this.btnMyInfo_Click);
            // 
            // btnMyLeaves
            // 
            this.btnMyLeaves.BackColor = System.Drawing.Color.SteelBlue;
            this.btnMyLeaves.FlatAppearance.BorderSize = 0;
            this.btnMyLeaves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyLeaves.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMyLeaves.ForeColor = System.Drawing.Color.White;
            this.btnMyLeaves.Location = new System.Drawing.Point(20, 68);
            this.btnMyLeaves.Margin = new System.Windows.Forms.Padding(20, 12, 20, 0);
            this.btnMyLeaves.Name = "btnMyLeaves";
            this.btnMyLeaves.Size = new System.Drawing.Size(238, 44);
            this.btnMyLeaves.TabIndex = 2;
            this.btnMyLeaves.Text = "Geçmiş İzinlerim";
            this.btnMyLeaves.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyLeaves.UseVisualStyleBackColor = true;
            this.btnMyLeaves.Click += new System.EventHandler(this.btnMyLeaves_Click_1);
            // 
            // btnLeaveCreate
            // 
            this.btnLeaveCreate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLeaveCreate.FlatAppearance.BorderSize = 0;
            this.btnLeaveCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaveCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLeaveCreate.ForeColor = System.Drawing.Color.White;
            this.btnLeaveCreate.Location = new System.Drawing.Point(20, 124);
            this.btnLeaveCreate.Margin = new System.Windows.Forms.Padding(20, 12, 20, 0);
            this.btnLeaveCreate.Name = "btnLeaveCreate";
            this.btnLeaveCreate.Size = new System.Drawing.Size(238, 44);
            this.btnLeaveCreate.TabIndex = 1;
            this.btnLeaveCreate.Text = "İzin Oluştur";
            this.btnLeaveCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeaveCreate.UseVisualStyleBackColor = true;
            this.btnLeaveCreate.Click += new System.EventHandler(this.btnLeaveCreate_Click);
            // 
            // btnAllLeaveRequests
            // 
            this.btnAllLeaveRequests.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAllLeaveRequests.FlatAppearance.BorderSize = 0;
            this.btnAllLeaveRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllLeaveRequests.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAllLeaveRequests.ForeColor = System.Drawing.Color.White;
            this.btnAllLeaveRequests.Location = new System.Drawing.Point(20, 180);
            this.btnAllLeaveRequests.Margin = new System.Windows.Forms.Padding(20, 12, 20, 0);
            this.btnAllLeaveRequests.Name = "btnAllLeaveRequests";
            this.btnAllLeaveRequests.Size = new System.Drawing.Size(238, 44);
            this.btnAllLeaveRequests.TabIndex = 3;
            this.btnAllLeaveRequests.Text = "İzin Talepleri";
            this.btnAllLeaveRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllLeaveRequests.UseVisualStyleBackColor = true;
            // 
            // btnAllLeavesHistory
            // 
            this.btnAllLeavesHistory.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAllLeavesHistory.FlatAppearance.BorderSize = 0;
            this.btnAllLeavesHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllLeavesHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAllLeavesHistory.ForeColor = System.Drawing.Color.White;
            this.btnAllLeavesHistory.Location = new System.Drawing.Point(20, 236);
            this.btnAllLeavesHistory.Margin = new System.Windows.Forms.Padding(20, 12, 20, 0);
            this.btnAllLeavesHistory.Name = "btnAllLeavesHistory";
            this.btnAllLeavesHistory.Size = new System.Drawing.Size(238, 44);
            this.btnAllLeavesHistory.TabIndex = 4;
            this.btnAllLeavesHistory.Text = "Geçmiş Personel İzinleri";
            this.btnAllLeavesHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllLeavesHistory.UseVisualStyleBackColor = true;
            // 
            // btnEmployeeMgmt
            // 
            this.btnEmployeeMgmt.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEmployeeMgmt.FlatAppearance.BorderSize = 0;
            this.btnEmployeeMgmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeMgmt.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEmployeeMgmt.ForeColor = System.Drawing.Color.White;
            this.btnEmployeeMgmt.Location = new System.Drawing.Point(20, 292);
            this.btnEmployeeMgmt.Margin = new System.Windows.Forms.Padding(20, 12, 20, 0);
            this.btnEmployeeMgmt.Name = "btnEmployeeMgmt";
            this.btnEmployeeMgmt.Size = new System.Drawing.Size(238, 44);
            this.btnEmployeeMgmt.TabIndex = 5;
            this.btnEmployeeMgmt.Text = "Personel Yönetimi";
            this.btnEmployeeMgmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeeMgmt.UseVisualStyleBackColor = true;
            // 
            // btnDepartmentMgmt
            // 
            this.btnDepartmentMgmt.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDepartmentMgmt.FlatAppearance.BorderSize = 0;
            this.btnDepartmentMgmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartmentMgmt.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDepartmentMgmt.ForeColor = System.Drawing.Color.White;
            this.btnDepartmentMgmt.Location = new System.Drawing.Point(20, 348);
            this.btnDepartmentMgmt.Margin = new System.Windows.Forms.Padding(20, 12, 20, 0);
            this.btnDepartmentMgmt.Name = "btnDepartmentMgmt";
            this.btnDepartmentMgmt.Size = new System.Drawing.Size(238, 44);
            this.btnDepartmentMgmt.TabIndex = 6;
            this.btnDepartmentMgmt.Text = "Departman Yönetimi";
            this.btnDepartmentMgmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartmentMgmt.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(20, 404);
            this.btnReports.Margin = new System.Windows.Forms.Padding(20, 12, 20, 0);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(238, 44);
            this.btnReports.TabIndex = 7;
            this.btnReports.Text = "Raporlar";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // pnlCardSample
            // 
            this.pnlCardSample.BackColor = System.Drawing.Color.White;
            this.pnlCardSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardSample.Controls.Add(this.label1);
            this.pnlCardSample.Location = new System.Drawing.Point(500, 41);
            this.pnlCardSample.Name = "pnlCardSample";
            this.pnlCardSample.Size = new System.Drawing.Size(300, 160);
            this.pnlCardSample.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(33, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Örnek Alan";
            // 
            // EmployeeMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "EmployeeMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HRMS | EMPLOYEE";
            this.Load += new System.EventHandler(this.EmployeeMainForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.tlpHeader.ResumeLayout(false);
            this.tlpHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlPageMyLeaves.ResumeLayout(false);
            this.pnlPageMyLeaves.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyLeaves)).EndInit();
            this.pnlPageLeaveCreate.ResumeLayout(false);
            this.pnlPageLeaveCreate.PerformLayout();
            this.pnlPageMyInfo.ResumeLayout(false);
            this.pnlPageMyInfo.PerformLayout();
            this.pnlWelcome.ResumeLayout(false);
            this.pnlWelcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.flpNav.ResumeLayout(false);
            this.pnlCardSample.ResumeLayout(false);
            this.pnlCardSample.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlCardSample;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnDepartmentMgmt;
        private System.Windows.Forms.Button btnEmployeeMgmt;
        private System.Windows.Forms.Button btnAllLeavesHistory;
        private System.Windows.Forms.Button btnAllLeaveRequests;
        private System.Windows.Forms.Button btnMyLeaves;
        private System.Windows.Forms.Button btnLeaveCreate;
        private System.Windows.Forms.Button btnMyInfo;
        private System.Windows.Forms.Panel pnlPageMyInfo;
        private System.Windows.Forms.Panel pnlPageDepartmentMgmt;
        private System.Windows.Forms.Panel pnlPageEmployeeMgmt;
        private System.Windows.Forms.Panel pnlPageAllLeavesHistory;
        private System.Windows.Forms.Panel pnlPageAllLeaveRequests;
        private System.Windows.Forms.Panel pnlPageMyLeaves;
        private System.Windows.Forms.Panel pnlPageLeaveCreate;
        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblWelcomeTitle;
        private System.Windows.Forms.Label lblWelcomeSubtitle;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.FlowLayoutPanel flpNav;
        private System.Windows.Forms.Button btnMyInfoSave;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMyPhone;
        private System.Windows.Forms.TextBox txtMyEmail;
        private System.Windows.Forms.TextBox txtMyTitle;
        private System.Windows.Forms.TextBox txtMyDepartment;
        private System.Windows.Forms.TextBox txtMyFullName;
        private System.Windows.Forms.Button btnLeaveCreateSave;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.ComboBox cmbLeaveType;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chckMyLeavesOnlyApproved;
        private System.Windows.Forms.DataGridView dgvMyLeaves;
    }
}