namespace HRMS.Presentation
{
    partial class DailyDashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyDashboardForm));
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnGetReport = new System.Windows.Forms.Button();
            this.pickDtEnd = new System.Windows.Forms.DateTimePicker();
            this.pickDtStart = new System.Windows.Forms.DateTimePicker();
            this.lblDtEnd = new System.Windows.Forms.Label();
            this.lblDtStart = new System.Windows.Forms.Label();
            this.chckEmployee = new System.Windows.Forms.CheckBox();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.chckDepartment = new System.Windows.Forms.CheckBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblFilterTitle = new System.Windows.Forms.Label();
            this.pnlRptSalaryDistHost = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tlpRptSalaryDist = new System.Windows.Forms.TableLayoutPanel();
            this.chartSalaryDist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvSalaryDist = new System.Windows.Forms.DataGridView();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlLeaveBoard = new System.Windows.Forms.Panel();
            this.pnlReportsScroll = new System.Windows.Forms.Panel();
            this.pnlReportHost = new System.Windows.Forms.Panel();
            this.pnlRptPerfDistHost = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tlpRptPerfDist = new System.Windows.Forms.TableLayoutPanel();
            this.chartPerfDist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvPerfDist = new System.Windows.Forms.DataGridView();
            this.pnlRptEmpDistHost = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpRptEmpDist = new System.Windows.Forms.TableLayoutPanel();
            this.chartEmployeeDist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvEmployeeDist = new System.Windows.Forms.DataGridView();
            this.pnlRptLeaveBalanceHost = new System.Windows.Forms.Panel();
            this.tlpRptLeaveBalance = new System.Windows.Forms.TableLayoutPanel();
            this.chartLeaveBalance = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvLeaveBalance = new System.Windows.Forms.DataGridView();
            this.colEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsedDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemainingDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsagePercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.separator = new System.Windows.Forms.Panel();
            this.flpLeaveCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLeaveHeader = new System.Windows.Forms.Panel();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSortLeave = new System.Windows.Forms.ComboBox();
            this.lblLeaveDate = new System.Windows.Forms.Label();
            this.lblLeaveTitle = new System.Windows.Forms.Label();
            this.pnlTopSummary = new System.Windows.Forms.Panel();
            this.flpSummaryCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCardTotalEmployee = new System.Windows.Forms.Panel();
            this.TotalEmployeeCard = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCardDepartmentCount = new System.Windows.Forms.Panel();
            this.TotalDepartmentCard = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCardAvgSalary = new System.Windows.Forms.Panel();
            this.AverageSalaryCard = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlCardActiveEmployee = new System.Windows.Forms.Panel();
            this.TotalActiveEmployeeCard = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.picFilter = new System.Windows.Forms.PictureBox();
            this.pnlFilter.SuspendLayout();
            this.pnlRptSalaryDistHost.SuspendLayout();
            this.tlpRptSalaryDist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalaryDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaryDist)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.pnlLeaveBoard.SuspendLayout();
            this.pnlReportsScroll.SuspendLayout();
            this.pnlReportHost.SuspendLayout();
            this.pnlRptPerfDistHost.SuspendLayout();
            this.tlpRptPerfDist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPerfDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfDist)).BeginInit();
            this.pnlRptEmpDistHost.SuspendLayout();
            this.tlpRptEmpDist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartEmployeeDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeDist)).BeginInit();
            this.pnlRptLeaveBalanceHost.SuspendLayout();
            this.tlpRptLeaveBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLeaveBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveBalance)).BeginInit();
            this.pnlLeaveHeader.SuspendLayout();
            this.pnlTopSummary.SuspendLayout();
            this.flpSummaryCards.SuspendLayout();
            this.pnlCardTotalEmployee.SuspendLayout();
            this.pnlCardDepartmentCount.SuspendLayout();
            this.pnlCardAvgSalary.SuspendLayout();
            this.pnlCardActiveEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlFilter.Controls.Add(this.btnGetReport);
            this.pnlFilter.Controls.Add(this.pickDtEnd);
            this.pnlFilter.Controls.Add(this.pickDtStart);
            this.pnlFilter.Controls.Add(this.lblDtEnd);
            this.pnlFilter.Controls.Add(this.lblDtStart);
            this.pnlFilter.Controls.Add(this.chckEmployee);
            this.pnlFilter.Controls.Add(this.cmbEmployee);
            this.pnlFilter.Controls.Add(this.lblEmployee);
            this.pnlFilter.Controls.Add(this.chckDepartment);
            this.pnlFilter.Controls.Add(this.cmbDepartment);
            this.pnlFilter.Controls.Add(this.lblDepartment);
            this.pnlFilter.Controls.Add(this.cmbReportType);
            this.pnlFilter.Controls.Add(this.lblReportType);
            this.pnlFilter.Controls.Add(this.lblFilterTitle);
            this.pnlFilter.Controls.Add(this.picFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(320, 858);
            this.pnlFilter.TabIndex = 0;
            // 
            // btnGetReport
            // 
            this.btnGetReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(20)))), ((int)(((byte)(100)))));
            this.btnGetReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetReport.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetReport.ForeColor = System.Drawing.Color.White;
            this.btnGetReport.Location = new System.Drawing.Point(20, 594);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(260, 40);
            this.btnGetReport.TabIndex = 14;
            this.btnGetReport.Text = "RAPORU GETİR";
            this.btnGetReport.UseVisualStyleBackColor = false;
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // pickDtEnd
            // 
            this.pickDtEnd.Location = new System.Drawing.Point(20, 525);
            this.pickDtEnd.Name = "pickDtEnd";
            this.pickDtEnd.Size = new System.Drawing.Size(200, 22);
            this.pickDtEnd.TabIndex = 13;
            // 
            // pickDtStart
            // 
            this.pickDtStart.Location = new System.Drawing.Point(20, 440);
            this.pickDtStart.Name = "pickDtStart";
            this.pickDtStart.Size = new System.Drawing.Size(200, 22);
            this.pickDtStart.TabIndex = 12;
            // 
            // lblDtEnd
            // 
            this.lblDtEnd.AutoSize = true;
            this.lblDtEnd.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDtEnd.Location = new System.Drawing.Point(20, 500);
            this.lblDtEnd.Name = "lblDtEnd";
            this.lblDtEnd.Size = new System.Drawing.Size(86, 23);
            this.lblDtEnd.TabIndex = 11;
            this.lblDtEnd.Text = "Bitiş Tarihi";
            // 
            // lblDtStart
            // 
            this.lblDtStart.AutoSize = true;
            this.lblDtStart.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDtStart.Location = new System.Drawing.Point(20, 415);
            this.lblDtStart.Name = "lblDtStart";
            this.lblDtStart.Size = new System.Drawing.Size(126, 23);
            this.lblDtStart.TabIndex = 10;
            this.lblDtStart.Text = "Başlangıç Tarihi";
            // 
            // chckEmployee
            // 
            this.chckEmployee.AutoSize = true;
            this.chckEmployee.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chckEmployee.Location = new System.Drawing.Point(20, 355);
            this.chckEmployee.Name = "chckEmployee";
            this.chckEmployee.Size = new System.Drawing.Size(124, 21);
            this.chckEmployee.TabIndex = 9;
            this.chckEmployee.Text = "Tüm Personeller";
            this.chckEmployee.UseVisualStyleBackColor = true;
            this.chckEmployee.CheckedChanged += new System.EventHandler(this.chckEmployee_CheckedChanged);
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(20, 325);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(260, 24);
            this.cmbEmployee.TabIndex = 8;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEmployee.Location = new System.Drawing.Point(20, 300);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(105, 23);
            this.lblEmployee.TabIndex = 7;
            this.lblEmployee.Text = "Personel Seç";
            // 
            // chckDepartment
            // 
            this.chckDepartment.AutoSize = true;
            this.chckDepartment.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chckDepartment.Location = new System.Drawing.Point(20, 240);
            this.chckDepartment.Name = "chckDepartment";
            this.chckDepartment.Size = new System.Drawing.Size(139, 21);
            this.chckDepartment.TabIndex = 6;
            this.chckDepartment.Text = "Tüm Departmanlar";
            this.chckDepartment.UseVisualStyleBackColor = true;
            this.chckDepartment.CheckedChanged += new System.EventHandler(this.chckDepartment_CheckedChanged);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(20, 210);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(260, 24);
            this.cmbDepartment.TabIndex = 5;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDepartment.Location = new System.Drawing.Point(20, 185);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(127, 23);
            this.lblDepartment.TabIndex = 4;
            this.lblDepartment.Text = "Departman Seç";
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(20, 135);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(260, 24);
            this.cmbReportType.TabIndex = 3;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblReportType.Location = new System.Drawing.Point(20, 110);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(95, 23);
            this.lblReportType.TabIndex = 2;
            this.lblReportType.Text = "Rapor Türü";
            // 
            // lblFilterTitle
            // 
            this.lblFilterTitle.AutoSize = true;
            this.lblFilterTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFilterTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFilterTitle.Location = new System.Drawing.Point(60, 30);
            this.lblFilterTitle.Name = "lblFilterTitle";
            this.lblFilterTitle.Size = new System.Drawing.Size(134, 31);
            this.lblFilterTitle.TabIndex = 1;
            this.lblFilterTitle.Text = "Filtre Paneli";
            // 
            // pnlRptSalaryDistHost
            // 
            this.pnlRptSalaryDistHost.AutoScroll = true;
            this.pnlRptSalaryDistHost.AutoSize = true;
            this.pnlRptSalaryDistHost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlRptSalaryDistHost.Controls.Add(this.panel2);
            this.pnlRptSalaryDistHost.Controls.Add(this.tlpRptSalaryDist);
            this.pnlRptSalaryDistHost.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRptSalaryDistHost.Location = new System.Drawing.Point(0, 1664);
            this.pnlRptSalaryDistHost.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRptSalaryDistHost.Name = "pnlRptSalaryDistHost";
            this.pnlRptSalaryDistHost.Size = new System.Drawing.Size(970, 827);
            this.pnlRptSalaryDistHost.TabIndex = 15;
            this.pnlRptSalaryDistHost.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 826);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(970, 1);
            this.panel2.TabIndex = 17;
            // 
            // tlpRptSalaryDist
            // 
            this.tlpRptSalaryDist.AutoSize = true;
            this.tlpRptSalaryDist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpRptSalaryDist.ColumnCount = 1;
            this.tlpRptSalaryDist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRptSalaryDist.Controls.Add(this.chartSalaryDist, 0, 0);
            this.tlpRptSalaryDist.Controls.Add(this.dgvSalaryDist, 0, 1);
            this.tlpRptSalaryDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpRptSalaryDist.Location = new System.Drawing.Point(0, 0);
            this.tlpRptSalaryDist.Name = "tlpRptSalaryDist";
            this.tlpRptSalaryDist.RowCount = 2;
            this.tlpRptSalaryDist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tlpRptSalaryDist.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRptSalaryDist.Size = new System.Drawing.Size(970, 826);
            this.tlpRptSalaryDist.TabIndex = 15;
            // 
            // chartSalaryDist
            // 
            this.chartSalaryDist.BorderlineColor = System.Drawing.Color.Gainsboro;
            this.chartSalaryDist.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea5.Name = "ChartArea1";
            this.chartSalaryDist.ChartAreas.Add(chartArea5);
            this.chartSalaryDist.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.chartSalaryDist.Legends.Add(legend5);
            this.chartSalaryDist.Location = new System.Drawing.Point(3, 3);
            this.chartSalaryDist.MinimumSize = new System.Drawing.Size(300, 200);
            this.chartSalaryDist.Name = "chartSalaryDist";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartSalaryDist.Series.Add(series5);
            this.chartSalaryDist.Size = new System.Drawing.Size(964, 314);
            this.chartSalaryDist.TabIndex = 0;
            this.chartSalaryDist.Text = "chart1";
            // 
            // dgvSalaryDist
            // 
            this.dgvSalaryDist.AllowUserToAddRows = false;
            this.dgvSalaryDist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalaryDist.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalaryDist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalaryDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSalaryDist.Location = new System.Drawing.Point(3, 323);
            this.dgvSalaryDist.MinimumSize = new System.Drawing.Size(300, 500);
            this.dgvSalaryDist.MultiSelect = false;
            this.dgvSalaryDist.Name = "dgvSalaryDist";
            this.dgvSalaryDist.ReadOnly = true;
            this.dgvSalaryDist.RowHeadersVisible = false;
            this.dgvSalaryDist.RowHeadersWidth = 51;
            this.dgvSalaryDist.RowTemplate.Height = 24;
            this.dgvSalaryDist.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvSalaryDist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalaryDist.Size = new System.Drawing.Size(964, 500);
            this.dgvSalaryDist.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlLeaveBoard);
            this.pnlContent.Controls.Add(this.pnlTopSummary);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(320, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(10);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(5);
            this.pnlContent.Size = new System.Drawing.Size(1061, 858);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlLeaveBoard
            // 
            this.pnlLeaveBoard.Controls.Add(this.pnlReportsScroll);
            this.pnlLeaveBoard.Controls.Add(this.flpLeaveCards);
            this.pnlLeaveBoard.Controls.Add(this.pnlLeaveHeader);
            this.pnlLeaveBoard.Location = new System.Drawing.Point(5, 145);
            this.pnlLeaveBoard.Name = "pnlLeaveBoard";
            this.pnlLeaveBoard.Padding = new System.Windows.Forms.Padding(20);
            this.pnlLeaveBoard.Size = new System.Drawing.Size(1051, 703);
            this.pnlLeaveBoard.TabIndex = 1;
            // 
            // pnlReportsScroll
            // 
            this.pnlReportsScroll.AutoScroll = true;
            this.pnlReportsScroll.Controls.Add(this.pnlReportHost);
            this.pnlReportsScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReportsScroll.Location = new System.Drawing.Point(20, 90);
            this.pnlReportsScroll.Name = "pnlReportsScroll";
            this.pnlReportsScroll.Padding = new System.Windows.Forms.Padding(10);
            this.pnlReportsScroll.Size = new System.Drawing.Size(1011, 593);
            this.pnlReportsScroll.TabIndex = 15;
            // 
            // pnlReportHost
            // 
            this.pnlReportHost.AutoSize = true;
            this.pnlReportHost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlReportHost.Controls.Add(this.pnlRptPerfDistHost);
            this.pnlReportHost.Controls.Add(this.pnlRptSalaryDistHost);
            this.pnlReportHost.Controls.Add(this.pnlRptEmpDistHost);
            this.pnlReportHost.Controls.Add(this.pnlRptLeaveBalanceHost);
            this.pnlReportHost.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportHost.Location = new System.Drawing.Point(10, 10);
            this.pnlReportHost.Margin = new System.Windows.Forms.Padding(0);
            this.pnlReportHost.Name = "pnlReportHost";
            this.pnlReportHost.Size = new System.Drawing.Size(970, 3318);
            this.pnlReportHost.TabIndex = 15;
            // 
            // pnlRptPerfDistHost
            // 
            this.pnlRptPerfDistHost.AutoScroll = true;
            this.pnlRptPerfDistHost.AutoSize = true;
            this.pnlRptPerfDistHost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlRptPerfDistHost.Controls.Add(this.panel3);
            this.pnlRptPerfDistHost.Controls.Add(this.tlpRptPerfDist);
            this.pnlRptPerfDistHost.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRptPerfDistHost.Location = new System.Drawing.Point(0, 2491);
            this.pnlRptPerfDistHost.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRptPerfDistHost.Name = "pnlRptPerfDistHost";
            this.pnlRptPerfDistHost.Size = new System.Drawing.Size(970, 827);
            this.pnlRptPerfDistHost.TabIndex = 16;
            this.pnlRptPerfDistHost.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 826);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(970, 1);
            this.panel3.TabIndex = 17;
            // 
            // tlpRptPerfDist
            // 
            this.tlpRptPerfDist.AutoSize = true;
            this.tlpRptPerfDist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpRptPerfDist.ColumnCount = 1;
            this.tlpRptPerfDist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRptPerfDist.Controls.Add(this.chartPerfDist, 0, 0);
            this.tlpRptPerfDist.Controls.Add(this.dgvPerfDist, 0, 1);
            this.tlpRptPerfDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpRptPerfDist.Location = new System.Drawing.Point(0, 0);
            this.tlpRptPerfDist.Name = "tlpRptPerfDist";
            this.tlpRptPerfDist.RowCount = 2;
            this.tlpRptPerfDist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tlpRptPerfDist.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRptPerfDist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRptPerfDist.Size = new System.Drawing.Size(970, 826);
            this.tlpRptPerfDist.TabIndex = 15;
            // 
            // chartPerfDist
            // 
            this.chartPerfDist.BorderlineColor = System.Drawing.Color.Gainsboro;
            this.chartPerfDist.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea6.Name = "ChartArea1";
            this.chartPerfDist.ChartAreas.Add(chartArea6);
            this.chartPerfDist.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chartPerfDist.Legends.Add(legend6);
            this.chartPerfDist.Location = new System.Drawing.Point(3, 3);
            this.chartPerfDist.MinimumSize = new System.Drawing.Size(300, 200);
            this.chartPerfDist.Name = "chartPerfDist";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartPerfDist.Series.Add(series6);
            this.chartPerfDist.Size = new System.Drawing.Size(964, 314);
            this.chartPerfDist.TabIndex = 0;
            this.chartPerfDist.Text = "chart1";
            // 
            // dgvPerfDist
            // 
            this.dgvPerfDist.AllowUserToAddRows = false;
            this.dgvPerfDist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPerfDist.BackgroundColor = System.Drawing.Color.White;
            this.dgvPerfDist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerfDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPerfDist.Location = new System.Drawing.Point(3, 323);
            this.dgvPerfDist.MinimumSize = new System.Drawing.Size(300, 500);
            this.dgvPerfDist.MultiSelect = false;
            this.dgvPerfDist.Name = "dgvPerfDist";
            this.dgvPerfDist.ReadOnly = true;
            this.dgvPerfDist.RowHeadersVisible = false;
            this.dgvPerfDist.RowHeadersWidth = 51;
            this.dgvPerfDist.RowTemplate.Height = 24;
            this.dgvPerfDist.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvPerfDist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerfDist.Size = new System.Drawing.Size(964, 500);
            this.dgvPerfDist.TabIndex = 0;
            // 
            // pnlRptEmpDistHost
            // 
            this.pnlRptEmpDistHost.AutoScroll = true;
            this.pnlRptEmpDistHost.AutoSize = true;
            this.pnlRptEmpDistHost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlRptEmpDistHost.Controls.Add(this.panel1);
            this.pnlRptEmpDistHost.Controls.Add(this.tlpRptEmpDist);
            this.pnlRptEmpDistHost.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRptEmpDistHost.Location = new System.Drawing.Point(0, 820);
            this.pnlRptEmpDistHost.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRptEmpDistHost.Name = "pnlRptEmpDistHost";
            this.pnlRptEmpDistHost.Size = new System.Drawing.Size(970, 844);
            this.pnlRptEmpDistHost.TabIndex = 4;
            this.pnlRptEmpDistHost.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 843);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 1);
            this.panel1.TabIndex = 17;
            // 
            // tlpRptEmpDist
            // 
            this.tlpRptEmpDist.AutoSize = true;
            this.tlpRptEmpDist.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpRptEmpDist.ColumnCount = 1;
            this.tlpRptEmpDist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRptEmpDist.Controls.Add(this.chartEmployeeDist, 0, 0);
            this.tlpRptEmpDist.Controls.Add(this.dgvEmployeeDist, 0, 1);
            this.tlpRptEmpDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpRptEmpDist.Location = new System.Drawing.Point(0, 0);
            this.tlpRptEmpDist.Name = "tlpRptEmpDist";
            this.tlpRptEmpDist.RowCount = 2;
            this.tlpRptEmpDist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpRptEmpDist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpRptEmpDist.Size = new System.Drawing.Size(970, 843);
            this.tlpRptEmpDist.TabIndex = 15;
            // 
            // chartEmployeeDist
            // 
            this.chartEmployeeDist.BorderlineColor = System.Drawing.Color.Gainsboro;
            this.chartEmployeeDist.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea7.Name = "ChartArea1";
            this.chartEmployeeDist.ChartAreas.Add(chartArea7);
            this.chartEmployeeDist.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.chartEmployeeDist.Legends.Add(legend7);
            this.chartEmployeeDist.Location = new System.Drawing.Point(3, 3);
            this.chartEmployeeDist.MinimumSize = new System.Drawing.Size(300, 200);
            this.chartEmployeeDist.Name = "chartEmployeeDist";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartEmployeeDist.Series.Add(series7);
            this.chartEmployeeDist.Size = new System.Drawing.Size(964, 331);
            this.chartEmployeeDist.TabIndex = 0;
            this.chartEmployeeDist.Text = "chart1";
            // 
            // dgvEmployeeDist
            // 
            this.dgvEmployeeDist.AllowUserToAddRows = false;
            this.dgvEmployeeDist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployeeDist.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployeeDist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvEmployeeDist.Location = new System.Drawing.Point(3, 340);
            this.dgvEmployeeDist.MinimumSize = new System.Drawing.Size(300, 500);
            this.dgvEmployeeDist.MultiSelect = false;
            this.dgvEmployeeDist.Name = "dgvEmployeeDist";
            this.dgvEmployeeDist.ReadOnly = true;
            this.dgvEmployeeDist.RowHeadersVisible = false;
            this.dgvEmployeeDist.RowHeadersWidth = 51;
            this.dgvEmployeeDist.RowTemplate.Height = 24;
            this.dgvEmployeeDist.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvEmployeeDist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeDist.Size = new System.Drawing.Size(964, 500);
            this.dgvEmployeeDist.TabIndex = 0;
            // 
            // pnlRptLeaveBalanceHost
            // 
            this.pnlRptLeaveBalanceHost.AutoSize = true;
            this.pnlRptLeaveBalanceHost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlRptLeaveBalanceHost.Controls.Add(this.tlpRptLeaveBalance);
            this.pnlRptLeaveBalanceHost.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRptLeaveBalanceHost.Location = new System.Drawing.Point(0, 0);
            this.pnlRptLeaveBalanceHost.Name = "pnlRptLeaveBalanceHost";
            this.pnlRptLeaveBalanceHost.Size = new System.Drawing.Size(970, 820);
            this.pnlRptLeaveBalanceHost.TabIndex = 2;
            this.pnlRptLeaveBalanceHost.Visible = false;
            // 
            // tlpRptLeaveBalance
            // 
            this.tlpRptLeaveBalance.AutoSize = true;
            this.tlpRptLeaveBalance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpRptLeaveBalance.ColumnCount = 1;
            this.tlpRptLeaveBalance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRptLeaveBalance.Controls.Add(this.chartLeaveBalance, 0, 0);
            this.tlpRptLeaveBalance.Controls.Add(this.dgvLeaveBalance, 0, 1);
            this.tlpRptLeaveBalance.Controls.Add(this.separator, 0, 2);
            this.tlpRptLeaveBalance.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpRptLeaveBalance.Location = new System.Drawing.Point(0, 0);
            this.tlpRptLeaveBalance.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRptLeaveBalance.Name = "tlpRptLeaveBalance";
            this.tlpRptLeaveBalance.RowCount = 1;
            this.tlpRptLeaveBalance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpRptLeaveBalance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpRptLeaveBalance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRptLeaveBalance.Size = new System.Drawing.Size(970, 820);
            this.tlpRptLeaveBalance.TabIndex = 1;
            // 
            // chartLeaveBalance
            // 
            this.chartLeaveBalance.BorderlineColor = System.Drawing.Color.Gainsboro;
            this.chartLeaveBalance.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea8.Name = "ChartArea1";
            this.chartLeaveBalance.ChartAreas.Add(chartArea8);
            this.chartLeaveBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Name = "Legend1";
            this.chartLeaveBalance.Legends.Add(legend8);
            this.chartLeaveBalance.Location = new System.Drawing.Point(3, 3);
            this.chartLeaveBalance.Name = "chartLeaveBalance";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartLeaveBalance.Series.Add(series8);
            this.chartLeaveBalance.Size = new System.Drawing.Size(964, 314);
            this.chartLeaveBalance.TabIndex = 2;
            this.chartLeaveBalance.Text = "chart1";
            // 
            // dgvLeaveBalance
            // 
            this.dgvLeaveBalance.AllowUserToAddRows = false;
            this.dgvLeaveBalance.AllowUserToDeleteRows = false;
            this.dgvLeaveBalance.AllowUserToResizeRows = false;
            this.dgvLeaveBalance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLeaveBalance.BackgroundColor = System.Drawing.Color.White;
            this.dgvLeaveBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeaveBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmployeeName,
            this.colDepartmentName,
            this.colTotalDays,
            this.colUsedDays,
            this.colRemainingDays,
            this.colUsagePercent,
            this.colLastUsed});
            this.dgvLeaveBalance.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvLeaveBalance.Location = new System.Drawing.Point(3, 323);
            this.dgvLeaveBalance.MultiSelect = false;
            this.dgvLeaveBalance.Name = "dgvLeaveBalance";
            this.dgvLeaveBalance.ReadOnly = true;
            this.dgvLeaveBalance.RowHeadersVisible = false;
            this.dgvLeaveBalance.RowHeadersWidth = 51;
            this.dgvLeaveBalance.RowTemplate.Height = 24;
            this.dgvLeaveBalance.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvLeaveBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLeaveBalance.Size = new System.Drawing.Size(964, 354);
            this.dgvLeaveBalance.TabIndex = 0;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.DataPropertyName = "EmployeeName";
            this.colEmployeeName.HeaderText = "Personel";
            this.colEmployeeName.MinimumWidth = 6;
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.ReadOnly = true;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.DataPropertyName = "DepartmentName";
            this.colDepartmentName.HeaderText = "Departman";
            this.colDepartmentName.MinimumWidth = 6;
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.ReadOnly = true;
            // 
            // colTotalDays
            // 
            this.colTotalDays.DataPropertyName = "TotalDays";
            this.colTotalDays.HeaderText = "Toplam Hak";
            this.colTotalDays.MinimumWidth = 6;
            this.colTotalDays.Name = "colTotalDays";
            this.colTotalDays.ReadOnly = true;
            // 
            // colUsedDays
            // 
            this.colUsedDays.DataPropertyName = "UsedDays";
            this.colUsedDays.HeaderText = "Kullanılan";
            this.colUsedDays.MinimumWidth = 6;
            this.colUsedDays.Name = "colUsedDays";
            this.colUsedDays.ReadOnly = true;
            // 
            // colRemainingDays
            // 
            this.colRemainingDays.DataPropertyName = "RemainingDays";
            this.colRemainingDays.HeaderText = "Kalan";
            this.colRemainingDays.MinimumWidth = 6;
            this.colRemainingDays.Name = "colRemainingDays";
            this.colRemainingDays.ReadOnly = true;
            // 
            // colUsagePercent
            // 
            this.colUsagePercent.DataPropertyName = "UsindPercentText";
            this.colUsagePercent.HeaderText = "Kullanım Oranı";
            this.colUsagePercent.MinimumWidth = 6;
            this.colUsagePercent.Name = "colUsagePercent";
            this.colUsagePercent.ReadOnly = true;
            // 
            // colLastUsed
            // 
            this.colLastUsed.DataPropertyName = "LastUsedText";
            this.colLastUsed.HeaderText = "Son Kullanma";
            this.colLastUsed.MinimumWidth = 6;
            this.colLastUsed.Name = "colLastUsed";
            this.colLastUsed.ReadOnly = true;
            // 
            // separator
            // 
            this.separator.BackColor = System.Drawing.Color.Gainsboro;
            this.separator.Dock = System.Windows.Forms.DockStyle.Top;
            this.separator.Location = new System.Drawing.Point(3, 803);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(964, 1);
            this.separator.TabIndex = 16;
            // 
            // flpLeaveCards
            // 
            this.flpLeaveCards.AutoScroll = true;
            this.flpLeaveCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLeaveCards.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpLeaveCards.Location = new System.Drawing.Point(20, 90);
            this.flpLeaveCards.Name = "flpLeaveCards";
            this.flpLeaveCards.Size = new System.Drawing.Size(1011, 593);
            this.flpLeaveCards.TabIndex = 1;
            this.flpLeaveCards.WrapContents = false;
            this.flpLeaveCards.SizeChanged += new System.EventHandler(this.flpLeaveCards_SizeChanged);
            // 
            // pnlLeaveHeader
            // 
            this.pnlLeaveHeader.Controls.Add(this.lblSort);
            this.pnlLeaveHeader.Controls.Add(this.cmbSortLeave);
            this.pnlLeaveHeader.Controls.Add(this.lblLeaveDate);
            this.pnlLeaveHeader.Controls.Add(this.lblLeaveTitle);
            this.pnlLeaveHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeaveHeader.Location = new System.Drawing.Point(20, 20);
            this.pnlLeaveHeader.Name = "pnlLeaveHeader";
            this.pnlLeaveHeader.Size = new System.Drawing.Size(1011, 70);
            this.pnlLeaveHeader.TabIndex = 0;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSort.Location = new System.Drawing.Point(718, 14);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(46, 20);
            this.lblSort.TabIndex = 3;
            this.lblSort.Text = "Sırala";
            // 
            // cmbSortLeave
            // 
            this.cmbSortLeave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSortLeave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortLeave.FormattingEnabled = true;
            this.cmbSortLeave.Items.AddRange(new object[] {
            "Bitişe En Az Kalan",
            "Bitişe En Çok Kalan",
            "Departmana Göre (A-Z)"});
            this.cmbSortLeave.Location = new System.Drawing.Point(769, 14);
            this.cmbSortLeave.Name = "cmbSortLeave";
            this.cmbSortLeave.Size = new System.Drawing.Size(230, 24);
            this.cmbSortLeave.TabIndex = 2;
            // 
            // lblLeaveDate
            // 
            this.lblLeaveDate.AutoSize = true;
            this.lblLeaveDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLeaveDate.ForeColor = System.Drawing.Color.Gray;
            this.lblLeaveDate.Location = new System.Drawing.Point(10, 40);
            this.lblLeaveDate.Name = "lblLeaveDate";
            this.lblLeaveDate.Size = new System.Drawing.Size(131, 20);
            this.lblLeaveDate.TabIndex = 1;
            this.lblLeaveDate.Text = "12.12.2025 - Cuma";
            // 
            // lblLeaveTitle
            // 
            this.lblLeaveTitle.AutoSize = true;
            this.lblLeaveTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLeaveTitle.Location = new System.Drawing.Point(10, 10);
            this.lblLeaveTitle.Name = "lblLeaveTitle";
            this.lblLeaveTitle.Size = new System.Drawing.Size(174, 28);
            this.lblLeaveTitle.TabIndex = 0;
            this.lblLeaveTitle.Text = "Günlük İzin Takibi";
            // 
            // pnlTopSummary
            // 
            this.pnlTopSummary.Controls.Add(this.flpSummaryCards);
            this.pnlTopSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopSummary.Location = new System.Drawing.Point(5, 5);
            this.pnlTopSummary.Name = "pnlTopSummary";
            this.pnlTopSummary.Size = new System.Drawing.Size(1051, 140);
            this.pnlTopSummary.TabIndex = 0;
            // 
            // flpSummaryCards
            // 
            this.flpSummaryCards.Controls.Add(this.pnlCardTotalEmployee);
            this.flpSummaryCards.Controls.Add(this.pnlCardDepartmentCount);
            this.flpSummaryCards.Controls.Add(this.pnlCardAvgSalary);
            this.flpSummaryCards.Controls.Add(this.pnlCardActiveEmployee);
            this.flpSummaryCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSummaryCards.Location = new System.Drawing.Point(0, 0);
            this.flpSummaryCards.Margin = new System.Windows.Forms.Padding(0);
            this.flpSummaryCards.Name = "flpSummaryCards";
            this.flpSummaryCards.Size = new System.Drawing.Size(1051, 140);
            this.flpSummaryCards.TabIndex = 0;
            // 
            // pnlCardTotalEmployee
            // 
            this.pnlCardTotalEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlCardTotalEmployee.Controls.Add(this.pictureBox1);
            this.pnlCardTotalEmployee.Controls.Add(this.TotalEmployeeCard);
            this.pnlCardTotalEmployee.Controls.Add(this.label1);
            this.pnlCardTotalEmployee.Location = new System.Drawing.Point(10, 20);
            this.pnlCardTotalEmployee.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.pnlCardTotalEmployee.Name = "pnlCardTotalEmployee";
            this.pnlCardTotalEmployee.Size = new System.Drawing.Size(240, 90);
            this.pnlCardTotalEmployee.TabIndex = 0;
            // 
            // TotalEmployeeCard
            // 
            this.TotalEmployeeCard.AutoSize = true;
            this.TotalEmployeeCard.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TotalEmployeeCard.Location = new System.Drawing.Point(108, 39);
            this.TotalEmployeeCard.Margin = new System.Windows.Forms.Padding(0);
            this.TotalEmployeeCard.Name = "TotalEmployeeCard";
            this.TotalEmployeeCard.Size = new System.Drawing.Size(0, 41);
            this.TotalEmployeeCard.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(62, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Toplam Personel";
            // 
            // pnlCardDepartmentCount
            // 
            this.pnlCardDepartmentCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.pnlCardDepartmentCount.Controls.Add(this.pictureBox2);
            this.pnlCardDepartmentCount.Controls.Add(this.TotalDepartmentCard);
            this.pnlCardDepartmentCount.Controls.Add(this.label4);
            this.pnlCardDepartmentCount.Location = new System.Drawing.Point(270, 20);
            this.pnlCardDepartmentCount.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.pnlCardDepartmentCount.Name = "pnlCardDepartmentCount";
            this.pnlCardDepartmentCount.Size = new System.Drawing.Size(240, 90);
            this.pnlCardDepartmentCount.TabIndex = 1;
            // 
            // TotalDepartmentCard
            // 
            this.TotalDepartmentCard.AutoSize = true;
            this.TotalDepartmentCard.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TotalDepartmentCard.Location = new System.Drawing.Point(113, 43);
            this.TotalDepartmentCard.Margin = new System.Windows.Forms.Padding(0);
            this.TotalDepartmentCard.Name = "TotalDepartmentCard";
            this.TotalDepartmentCard.Size = new System.Drawing.Size(0, 41);
            this.TotalDepartmentCard.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(64, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "Departman Sayısı";
            // 
            // pnlCardAvgSalary
            // 
            this.pnlCardAvgSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlCardAvgSalary.Controls.Add(this.pictureBox3);
            this.pnlCardAvgSalary.Controls.Add(this.AverageSalaryCard);
            this.pnlCardAvgSalary.Controls.Add(this.label6);
            this.pnlCardAvgSalary.Location = new System.Drawing.Point(530, 20);
            this.pnlCardAvgSalary.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.pnlCardAvgSalary.Name = "pnlCardAvgSalary";
            this.pnlCardAvgSalary.Size = new System.Drawing.Size(240, 90);
            this.pnlCardAvgSalary.TabIndex = 2;
            // 
            // AverageSalaryCard
            // 
            this.AverageSalaryCard.AutoSize = true;
            this.AverageSalaryCard.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AverageSalaryCard.Location = new System.Drawing.Point(57, 39);
            this.AverageSalaryCard.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.AverageSalaryCard.Name = "AverageSalaryCard";
            this.AverageSalaryCard.Size = new System.Drawing.Size(111, 41);
            this.AverageSalaryCard.TabIndex = 2;
            this.AverageSalaryCard.Text = "48.720";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(69, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ortalama Maaş";
            // 
            // pnlCardActiveEmployee
            // 
            this.pnlCardActiveEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.pnlCardActiveEmployee.Controls.Add(this.pictureBox4);
            this.pnlCardActiveEmployee.Controls.Add(this.TotalActiveEmployeeCard);
            this.pnlCardActiveEmployee.Controls.Add(this.label8);
            this.pnlCardActiveEmployee.Location = new System.Drawing.Point(790, 20);
            this.pnlCardActiveEmployee.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.pnlCardActiveEmployee.Name = "pnlCardActiveEmployee";
            this.pnlCardActiveEmployee.Size = new System.Drawing.Size(245, 90);
            this.pnlCardActiveEmployee.TabIndex = 3;
            // 
            // TotalActiveEmployeeCard
            // 
            this.TotalActiveEmployeeCard.AutoSize = true;
            this.TotalActiveEmployeeCard.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TotalActiveEmployeeCard.Location = new System.Drawing.Point(99, 39);
            this.TotalActiveEmployeeCard.Margin = new System.Windows.Forms.Padding(0);
            this.TotalActiveEmployeeCard.Name = "TotalActiveEmployeeCard";
            this.TotalActiveEmployeeCard.Size = new System.Drawing.Size(52, 41);
            this.TotalActiveEmployeeCard.TabIndex = 2;
            this.TotalActiveEmployeeCard.Text = "20";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(75, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 28);
            this.label8.TabIndex = 1;
            this.label8.Text = "Aktif Çalışan";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(18, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(13, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(18, 11);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // picFilter
            // 
            this.picFilter.Image = ((System.Drawing.Image)(resources.GetObject("picFilter.Image")));
            this.picFilter.Location = new System.Drawing.Point(24, 31);
            this.picFilter.Name = "picFilter";
            this.picFilter.Size = new System.Drawing.Size(30, 30);
            this.picFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFilter.TabIndex = 0;
            this.picFilter.TabStop = false;
            // 
            // DailyDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1381, 858);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DailyDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raporlar";
            this.Load += new System.EventHandler(this.DailyDashboardForm_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlRptSalaryDistHost.ResumeLayout(false);
            this.pnlRptSalaryDistHost.PerformLayout();
            this.tlpRptSalaryDist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSalaryDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaryDist)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlLeaveBoard.ResumeLayout(false);
            this.pnlReportsScroll.ResumeLayout(false);
            this.pnlReportsScroll.PerformLayout();
            this.pnlReportHost.ResumeLayout(false);
            this.pnlReportHost.PerformLayout();
            this.pnlRptPerfDistHost.ResumeLayout(false);
            this.pnlRptPerfDistHost.PerformLayout();
            this.tlpRptPerfDist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPerfDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfDist)).EndInit();
            this.pnlRptEmpDistHost.ResumeLayout(false);
            this.pnlRptEmpDistHost.PerformLayout();
            this.tlpRptEmpDist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartEmployeeDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeDist)).EndInit();
            this.pnlRptLeaveBalanceHost.ResumeLayout(false);
            this.pnlRptLeaveBalanceHost.PerformLayout();
            this.tlpRptLeaveBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLeaveBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveBalance)).EndInit();
            this.pnlLeaveHeader.ResumeLayout(false);
            this.pnlLeaveHeader.PerformLayout();
            this.pnlTopSummary.ResumeLayout(false);
            this.flpSummaryCards.ResumeLayout(false);
            this.pnlCardTotalEmployee.ResumeLayout(false);
            this.pnlCardTotalEmployee.PerformLayout();
            this.pnlCardDepartmentCount.ResumeLayout(false);
            this.pnlCardDepartmentCount.PerformLayout();
            this.pnlCardAvgSalary.ResumeLayout(false);
            this.pnlCardAvgSalary.PerformLayout();
            this.pnlCardActiveEmployee.ResumeLayout(false);
            this.pnlCardActiveEmployee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblFilterTitle;
        private System.Windows.Forms.PictureBox picFilter;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.CheckBox chckEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.CheckBox chckDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.DateTimePicker pickDtStart;
        private System.Windows.Forms.Label lblDtEnd;
        private System.Windows.Forms.Label lblDtStart;
        private System.Windows.Forms.Button btnGetReport;
        private System.Windows.Forms.DateTimePicker pickDtEnd;
        private System.Windows.Forms.Panel pnlTopSummary;
        private System.Windows.Forms.FlowLayoutPanel flpSummaryCards;
        private System.Windows.Forms.Panel pnlCardTotalEmployee;
        private System.Windows.Forms.Label TotalEmployeeCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlCardDepartmentCount;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label TotalDepartmentCard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlCardAvgSalary;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlLeaveBoard;
        private System.Windows.Forms.Panel pnlLeaveHeader;
        private System.Windows.Forms.ComboBox cmbSortLeave;
        private System.Windows.Forms.Label lblLeaveDate;
        private System.Windows.Forms.Label lblLeaveTitle;
        private System.Windows.Forms.FlowLayoutPanel flpLeaveCards;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.TableLayoutPanel tlpRptLeaveBalance;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLeaveBalance;
        private System.Windows.Forms.Label AverageSalaryCard;
        private System.Windows.Forms.Label TotalActiveEmployeeCard;
        private System.Windows.Forms.DataGridView dgvLeaveBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsedDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemainingDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsagePercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastUsed;
        private System.Windows.Forms.Panel pnlRptEmpDistHost;
        private System.Windows.Forms.TableLayoutPanel tlpRptEmpDist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEmployeeDist;
        private System.Windows.Forms.DataGridView dgvEmployeeDist;
        private System.Windows.Forms.Panel pnlRptSalaryDistHost;
        private System.Windows.Forms.TableLayoutPanel tlpRptSalaryDist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalaryDist;
        private System.Windows.Forms.DataGridView dgvSalaryDist;
        private System.Windows.Forms.Panel pnlRptPerfDistHost;
        private System.Windows.Forms.TableLayoutPanel tlpRptPerfDist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPerfDist;
        private System.Windows.Forms.DataGridView dgvPerfDist;
        private System.Windows.Forms.Panel pnlRptLeaveBalanceHost;
        private System.Windows.Forms.Panel pnlReportHost;
        private System.Windows.Forms.Panel pnlReportsScroll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel separator;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlCardActiveEmployee;
    }
}