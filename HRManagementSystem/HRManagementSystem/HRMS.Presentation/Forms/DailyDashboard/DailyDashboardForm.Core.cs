using HRMS.DAL;
using HRMS.DAL.Database;
using HRMS.Domain;
using HRMS.Service;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HRMS.Presentation
{
    public partial class DailyDashboardForm : Form
    {
        private readonly int? _forcedDepartmentId;
        public DailyDashboardForm(int? forcedDepartmentId = null)
        {
            
            _forcedDepartmentId = forcedDepartmentId;

            InitializeComponent();
            try
            {
                _repo = new MySqlReportRepository(ConnectionStrings.Main);
                _reportService = new ReportService(_repo);

                // smoke test
                var empCount = _repo.GetEmployees().Count;
                var depCount = _repo.GetDepartments().Count;
                var ltCount = _repo.GetLeaveTypes().Count;

                _dbAvailable = true; // ✅ DB var

            }
            catch (Exception ex)
            {
                _dbAvailable = false;
                MessageBox.Show("DB bağlantısı kurulamadı: " + ex.Message);
            }
        }

        private void DailyDashboardForm_Load(object sender, EventArgs e)
        {
            _uiBooting = true;

            if (!_dbAvailable) return;

            _initializing = true;
            _isLoadingReport = true;

            LoadReportTypes();

            if (_dbAvailable)
            {
                FillFilters();
                UpdateLeaveDateLabel(DateTime.Today);
            }

            var today = DateTime.Today;

            pickDtStart.Value = today.AddDays(-7);
            pickDtEnd.Value = today.AddDays(7);

            cmbSortLeave.SelectionChangeCommitted -= cmbSortLeave_SelectionChangeCommitted;
            cmbSortLeave.SelectionChangeCommitted += cmbSortLeave_SelectionChangeCommitted;

            if (_dbAvailable)
            {
                AverageSalaryCard.Text = _reportService.GetAverageSalary(true).ToString("N2");
                TotalEmployeeCard.Text = _reportService.GetEmployeeCount(false).ToString();
                TotalActiveEmployeeCard.Text = _reportService.GetEmployeeCount(true).ToString();
                TotalDepartmentCard.Text = _reportService.GetDepartmentCount().ToString();
            }

            chckDepartment.Checked = true;
            chckEmployee.Checked = true;

            pnlReportsScroll.AutoScroll = true;
           
            _isLoadingReport = false;
            _initializing = false;

            cmbReportType.SelectedItem = RPT_DAILY;
            // Manager için departman filtresi zorunlu ise kilitle
            if (_forcedDepartmentId.HasValue)
            {
                cmbDepartment.SelectedValue = _forcedDepartmentId.Value;
                cmbDepartment.Enabled = false;
                chckDepartment.Checked = false;
                chckDepartment.Enabled = false;
                ReloadEmployeesForDepartment(_forcedDepartmentId.Value);
            }
            else
            {
                cmbDepartment.Enabled = true;
            }

            RenderCurrentReport();
            _uiBooting = false;
            
        }
        private bool _uiBooting = false;

        private void LoadLeaveBalanceReport()
        {
            var year = _reportService.GetMaxEntitlementYear();
            var depId = SelectedDepartmentId();
            var empId = SelectedEmployeeId();
            var rows = _reportService.GetLeaveBalances(year, depId, empId);

            int? departmentId = null;
            if (chckDepartment.Checked && cmbDepartment.SelectedItem != null)
            {
                var id = (int)cmbDepartment.SelectedValue;
                if (id > 0) departmentId = id;
            }
            int? employeeId = null;
            if (chckEmployee.Checked && cmbEmployee.SelectedItem != null)
            {
                var id = (int)cmbEmployee.SelectedValue;
                if (id > 0) employeeId = id;
            }

            ShowLeaveBalance();
            RenderLeaveBalanceReport(rows);
        }
        private void UpdateSortVisibility()
        {
            var type = cmbReportType.SelectedItem?.ToString() ?? "";

            bool show = (type == RPT_DAILY);

            // Panel varsa:
            // pnlSort.Visible = show;

            // Panel yoksa tek tek:
            lblSort.Visible = show;
            cmbSortLeave.Visible = show;
        }
        private void btnGetReport_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem == null) return;

            var selected = cmbReportType.SelectedItem.ToString().Trim();

            // Önce doğru paneli aç/kapat
            ApplySelectedReport();
            //RenderCurrentReport();
        }
        
        private void LoadReportTypes()
        {
            cmbReportType.DataSource = null;
            cmbReportType.Items.Clear();
            cmbReportType.Items.Add(RPT_DAILY);
            cmbReportType.Items.Add(RPT_LEAVE_BALANCE);
            cmbReportType.Items.Add(RPT_EMP_DIST);
            cmbReportType.Items.Add(RPT_SALARY_DIST);
            cmbReportType.Items.Add(RPT_PERF_DIST);
            cmbReportType.SelectedItem = RPT_DAILY; // default
            UpdateSortVisibility();
        }

        private void ApplySelectedReport()
        {
            if (cmbReportType.SelectedItem == null) return;

            var selected = cmbReportType.SelectedItem.ToString().Trim();
            //FillSortOptionsFor(selected);
            SetupSortUiForReport(selected);
            SetReportHeader(selected);
            ShowReport(selected);
        }

        private void HideAllReportPanels()
        {
            pnlRptPerfDistHost.Visible = false;
            pnlRptSalaryDistHost.Visible = false;
            pnlRptEmpDistHost.Visible = false;
            pnlRptLeaveBalanceHost.Visible = false;
            flpLeaveCards.Visible = false;
        }

        private void FillFilters()
        {
            _filtersLoading = true;
            try
            {
                // Departments
                var deps = _repo.GetDepartments();
                deps.Insert(0, new Departments { dId = 0, dName = "Hepsi" });

                cmbDepartment.DisplayMember = "dName";
                cmbDepartment.ValueMember = "dId";
                cmbDepartment.DataSource = deps;

                // Employees (ilk yüklemede "Hepsi")
                var emps = _repo.GetEmployees();
                emps.Insert(0, new Employees { eId = 0, eFullName = "Hepsi" });

                cmbEmployee.DisplayMember = "eFullName";
                cmbEmployee.ValueMember = "eId";
                cmbEmployee.DataSource = emps;
            }
            finally
            {
                _filtersLoading = false;
            }
        }

        private void RenderCurrentReport()
        {
            
            if (cmbReportType.SelectedItem == null) return;

            var rpt = cmbReportType.SelectedItem.ToString().Trim();

            _isLoadingReport = true;
            try
            {
                SetupSortUiForReport(rpt);
                SetReportHeader(rpt);

                if (rpt == RPT_DAILY)
                {
                    ShowDailyReport();
                    //flpLeaveCards.BackColor = System.Drawing.Color.LightPink;  // Açılış testi
                    LoadDailyReport();
                    return;
                }
                if (rpt == RPT_LEAVE_BALANCE)
                {
                    ShowLeaveBalance();
                    LoadLeaveBalanceReport();
                    return;
                }
                if (rpt == RPT_EMP_DIST)
                {
                    ShowEmpDist();
                    LoadEmployeeDistReport();
                    return;
                }
                if (rpt == RPT_SALARY_DIST)
                {
                    ShowSalaryDist();
                    LoadSalaryDistReport();
                    return;
                }
                if (rpt == RPT_PERF_DIST)
                {
                    ShowPerfDist();
                    LoadPerformanceDistReport();
                    return;
                }
            }
            finally
            {
                _isLoadingReport = false;
            }
        }

        private void SetReportHeader(string title)
        {
            lblLeaveTitle.Text = title;
        }
        private void UpdateLeaveDateLabel(DateTime date)
        {
            lblLeaveDate.Text = date.ToString("dd.MM.yyyy - dddd",
                new System.Globalization.CultureInfo("tr-TR"));
        }
        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_uiBooting) return;
            if (_initializing) return;

            if (_isLoadingReport) return;
            if (_filtersLoading) return; // init sırasında tetiklenmesin

            UpdateSortVisibility();
            RenderCurrentReport();
        }

        private void SetupSortUiForReport(string reportType)
        {
            _filtersLoading = true;
            try
            {
                cmbSortLeave.Items.Clear();

                if (reportType == RPT_DAILY)
                {
                    cmbSortLeave.Visible = true;
                    lblSort.Visible = true;

                    cmbSortLeave.Items.Add("Bitişe En Az Kalan");
                    cmbSortLeave.Items.Add("Bitişe En Çok Kalan");
                    cmbSortLeave.Items.Add("Departmana Göre (A-Z)");
                    cmbSortLeave.Items.Add("Başlangıç Tarihi (Yakın→Uzak)");
                    cmbSortLeave.Items.Add("Başlangıç Tarihi (Uzak→Yakın)");
                    cmbSortLeave.SelectedIndex = 0;
                }
                else
                {
                    // Günlük dışında Sırala yok
                    cmbSortLeave.Visible = false;
                    lblSort.Visible = false;
                }
            }
            finally
            {
                _filtersLoading = false;
            }
        }

        private void cmbSortLeave_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RenderCurrentReport(); // ApplySortForCurrentReport değil
        }
      
        private readonly IReportRepository _repo;
        private readonly ReportService _reportService;
        private bool _leaveBalanceUiReady = false;
        private bool _dbAvailable = false; // DB gelince true yapacağız
        private const string RPT_DAILY = "Günlük Rapor";
        private const string RPT_LEAVE_BALANCE = "Kalan İzin Hakları Dağılım Raporu";
        private const string RPT_EMP_DIST = "Personel Dağılım Raporu";
        private const string RPT_SALARY_DIST = "Maaş Dağılım Raporu";
        private const string RPT_PERF_DIST = "Performans Dağılım Raporu";
        private bool _initializing = true;


        private void ShowReport(string rpt)
        {
            HideAllReportPanels();

            if (rpt == RPT_DAILY)
            {
                flpLeaveCards.Visible = true;
                flpLeaveCards.BringToFront();   //  günlük rapor paneli üstte olsun
                return;
            }

            if (rpt == RPT_LEAVE_BALANCE)
            {
                pnlRptLeaveBalanceHost.Visible = true;
                pnlRptLeaveBalanceHost.BringToFront();
                return;
            }

            if (rpt == RPT_EMP_DIST)
            {
                pnlRptEmpDistHost.Visible = true;
                pnlRptEmpDistHost.BringToFront();
                return;
            }

            if (rpt == RPT_SALARY_DIST)
            {
                pnlRptSalaryDistHost.Visible = true;
                pnlRptSalaryDistHost.BringToFront();
                return;
            }

            if (rpt == RPT_PERF_DIST)
            {
                pnlRptPerfDistHost.Visible = true;
                pnlRptPerfDistHost.BringToFront();
                return;
            }
        }
        private int? SelectedDepartmentId()
        {
            // "Tüm Departmanlar" seçiliyse => null
            if (chckDepartment.Checked) return null;

            if (cmbDepartment.SelectedValue == null) return null;

            var id = Convert.ToInt32(cmbDepartment.SelectedValue);

            // "Hepsi" (0) => null say
            if (id <= 0) return null;

            return id;
        }


        private int? SelectedEmployeeId()
        {
            if (cmbEmployee.SelectedValue == null) return null;
            if (int.TryParse(cmbEmployee.SelectedValue.ToString(), out var id))
                return id <= 0 ? (int?)null : id;
            return null;
        }
        private void ReloadCurrentReport()
        {
            var type = cmbReportType.SelectedItem?.ToString() ?? "";
            SetupSortUiForReport(type);

            if (type == RPT_DAILY)
            {
                ShowDailyReport();
                LoadDailyReport();
                ApplySortingAndRender();
                return;
            }

            if (type == RPT_LEAVE_BALANCE)
            {
                ShowLeaveBalance();
                LoadLeaveBalanceReport();
                return;
            }

            if (type == RPT_EMP_DIST)
            {
                ShowEmpDist();
                LoadEmployeeDistReport();
                return;
            }

            if (type == RPT_SALARY_DIST)
            {
                ShowSalaryDist();
                LoadSalaryDistReport();
                return;
            }

            if (type == RPT_PERF_DIST)
            {
                ShowPerfDist();
                LoadPerformanceDistReport();
                return;
            }
        }

        private void SetReportTitle(string title)
        {
            lblLeaveTitle.Text = title;
        }
        private bool _isLoadingReport = false;
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_uiBooting) return;
            if (_filtersLoading) return;

            var depId = SelectedDepartmentId();

            ReloadEmployeesForDepartment(depId);

            _filtersLoading = true;
            try
            {
                chckDepartment.Checked = !depId.HasValue;
            }
            finally
            {
                _filtersLoading = false;
            }

            RenderCurrentReport(); // Reload yerine direkt render (tek yol)
        }


        private void ReloadEmployeesForDepartment(int? depId)
        {
            _filtersLoading = true;
            try
            {
                var all = _repo.GetEmployees();

                // depId null => hepsi
                if (depId.HasValue)
                    all = all.FindAll(x => x.eDepartmentId == depId.Value);

                all.Insert(0, new Employees { eId = 0, eFullName = "Hepsi" });

                cmbEmployee.DisplayMember = "eFullName";
                cmbEmployee.ValueMember = "eId";
                cmbEmployee.DataSource = all;

                // default "Hepsi"
                cmbEmployee.SelectedValue = 0;
            }
            finally
            {
                _filtersLoading = false;
            }
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            if (_filtersLoading) return;

            var empId = SelectedEmployeeId();
            _filtersLoading = true;
            try
            {
                chckEmployee.Checked = !empId.HasValue;
            }
            finally
            {
                _filtersLoading = false;
            }

            ReloadCurrentReport();
        }
        private bool _filtersLoading = false;

    }
}
