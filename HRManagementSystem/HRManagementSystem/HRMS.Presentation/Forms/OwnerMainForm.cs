using HRMS.DAL;
using HRMS.Domain;
using HRMS.Domain.Auth;
using HRMS.Presentation.Context;
using HRMS.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HRMS.Presentation.HRMS.Presentation.Forms
{
    public partial class OwnerMainForm : Form
    {
        public OwnerMainForm()
        {
            InitializeComponent();
            this.Resize += (s, e) => CenterWelcome();

        }

        private void OwnerMainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"Kullanıcı: {UserContext.CurrentUser?.UserName} | Rol: Owner";
            ShowPage(pnlWelcome);
            CenterWelcome();
            ApplyNavByRole();


        }
        private void ApplyNavByRole()
        {
            bool isOwner = UserContext.HasRole(UserRole.Owner);
            bool isManager = UserContext.HasRole(UserRole.Manager);
            bool isEmployee = UserContext.HasRole(UserRole.Employee);

            // Home her zaman
            picHome.Visible = true;

            // Herkesin kişisel alanı
            btnMyInfo.Visible = isOwner || isManager || isEmployee;
            btnLeaveCreate.Visible = isOwner || isManager || isEmployee;
            btnMyLeaves.Visible = isOwner || isManager || isEmployee;

            // İzin talepleri / personel geçmiş izin: Owner ve Manager
            btnAllLeaveRequests.Visible = isOwner || isManager;
            btnAllLeavesHistory.Visible = isOwner || isManager;

            // Yönetim ekranları: sadece Owner
            btnEmployeeMgmt.Visible = isOwner;      // Manager kendi personelini Sprint 3’te ayrı butonla alacak
            btnDepartmentMgmt.Visible = isOwner;

            // Raporlar: Owner + Manager (Employee yok)
            btnReports.Visible = isOwner || isManager;
        }
        private void CenterWelcome()
        {
            if (!pnlWelcome.Visible) return;

            int centerX = pnlWelcome.Width / 2;

            picLogo.Left = centerX - picLogo.Width / 2;
            picLogo.Top = 120;

            lblWelcomeTitle.Left = centerX - lblWelcomeTitle.Width / 2;
            lblWelcomeTitle.Top = picLogo.Bottom + 24;

            lblWelcomeSubtitle.Left = centerX - lblWelcomeSubtitle.Width / 2;
            lblWelcomeSubtitle.Top = lblWelcomeTitle.Bottom + 12;
        }

        private void ShowPage(Control page)
        {
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            page.Visible = true;
            page.BringToFront();
        }
        private void RequireRole(params UserRole[] roles)
        {
            foreach (var r in roles)
                if (UserContext.HasRole(r)) return;

            throw new UnauthorizedAccessException("Bu işlemi yapmaya yetkiniz yok.");
        }
        // Gizlilik için Örnek Helper Metod
        private void btnReports_Click(object sender, EventArgs e)
        {
            try
            {
                RequireRole(UserRole.Owner, UserRole.Manager);

                var frm = new DailyDashboardForm(); 
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMyInfo_Click(object sender, EventArgs e)
        {
            ShowPage(pnlPageMyInfo);
            LoadMyInfo();
        }
        private void btnLeaveCreate_Click(object sender, EventArgs e)
        {
            ShowPage(pnlPageLeaveCreate);
            LoadLeaveTypes();
        }
        private void LoadLeaveTypes()
        {
            var types = _leaveService.GetLeaveTypes();
            cmbLeaveType.DisplayMember = "ltName";
            cmbLeaveType.ValueMember = "ltId";
            cmbLeaveType.DataSource = types;
        }
        
        private void btnLeaveCreateSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (UserContext.CurrentUser?.EmployeeId == null)
                    throw new Exception("EmployeeId bulunamadı.");

                if (cmbLeaveType.SelectedValue == null)
                    throw new Exception("İzin türü seçin.");

                int empId = UserContext.CurrentUser.EmployeeId.Value;
                int ltId = Convert.ToInt32(cmbLeaveType.SelectedValue);

                var start = dtpStart.Value.Date;
                var end = dtpEnd.Value.Date;
                
                _leaveService.CreateLeaveRequest(empId, ltId, start, end);

                MessageBox.Show("İzin talebi oluşturuldu.");

                // temizle
                txtNote.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnMyLeaves_Click(object sender, EventArgs e)
        {
            ShowPage(pnlPageMyLeaves);
            LoadMyLeaves();
        }
        private void LoadMyLeaves()
        {
            try
            {
                if (UserContext.CurrentUser?.EmployeeId == null)
                    throw new Exception("EmployeeId bulunamadı.");

                int empId = UserContext.CurrentUser.EmployeeId.Value;
                bool onlyApproved = chckMyLeavesOnlyApproved.Checked;

                var list = _leaveReqService.GetMyLeaveHistory(empId, onlyApproved);

                dgvMyLeaves.DataSource = null;
                dgvMyLeaves.DataSource = list;

                if (dgvMyLeaves.Columns["lrId"] != null) dgvMyLeaves.Columns["lrId"].HeaderText = "ID";
                if (dgvMyLeaves.Columns["LeaveTypeName"] != null) dgvMyLeaves.Columns["LeaveTypeName"].HeaderText = "İzin Türü";
                if (dgvMyLeaves.Columns["StartDate"] != null) dgvMyLeaves.Columns["StartDate"].HeaderText = "Başlangıç";
                if (dgvMyLeaves.Columns["EndDate"] != null) dgvMyLeaves.Columns["EndDate"].HeaderText = "Bitiş";
                if (dgvMyLeaves.Columns["Status"] != null) dgvMyLeaves.Columns["Status"].HeaderText = "Durum";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void chckMyLeavesOnlyApproved_CheckedChanged(object sender, EventArgs e)
        {
            LoadMyLeaves();
        }
        private void btnAllLeaveRequests_Click(object sender, EventArgs e)
        {
            ShowPage(pnlPageAllLeaveRequests);
            LoadLeaveRequestsForApproval(isManager: false);
        }
        private void LoadLeaveRequestsForApproval(bool isManager)
        {
            int? depId = null;
            int? excludeEmpId = null;

            // Owner => depId null (tümü)
            var list = _leaverequestService.GetRequestsForApproval(depId, excludeEmpId);

            BindLeaveRequestsSortable(list);

            if (dgvLeaveRequests.Columns["lrId"] != null) dgvLeaveRequests.Columns["lrId"].Visible = false;

            // Başlıklar
            dgvLeaveRequests.Columns["EmployeeName"].HeaderText = "Personel";
            dgvLeaveRequests.Columns["DepartmentName"].HeaderText = "Departman";
            dgvLeaveRequests.Columns["LeaveTypeName"].HeaderText = "İzin Türü";
            dgvLeaveRequests.Columns["StartDate"].HeaderText = "Başlangıç";
            dgvLeaveRequests.Columns["EndDate"].HeaderText = "Bitiş";
            dgvLeaveRequests.Columns["DayCount"].HeaderText = "Gün";
            dgvLeaveRequests.Columns["Status"].HeaderText = "Durum";

            // otomatik seç
            _selectedLrId = 0;
            if (dgvLeaveRequests.Rows.Count > 0)
            {
                dgvLeaveRequests.ClearSelection();
                dgvLeaveRequests.Rows[0].Selected = true;
                _selectedLrId = ((LeaveRequestApproveRowDto)dgvLeaveRequests.Rows[0].DataBoundItem).lrId;
            }
        }
        private BindingSource _leaveReqBs = new BindingSource();
        private bool _leaveReqSortAsc = true;

        private void BindLeaveRequestsSortable(List<LeaveRequestApproveRowDto> list)
        {
            // grid ilk kez bağlanıyorsa
            if (dgvLeaveRequests.DataSource == null)
                dgvLeaveRequests.DataSource = _leaveReqBs;

            _leaveReqBs.DataSource = list;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                _leaverequestService.Approve(_selectedLrId);
                LoadLeaveRequestsForApproval(isManager: true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                _leaverequestService.Reject(_selectedLrId);
                LoadLeaveRequestsForApproval(isManager: true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void dgvLeaveRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLeaveRequests.CurrentRow?.DataBoundItem is LeaveRequestApproveRowDto row)
                _selectedLrId = row.lrId;
        }

        private void btnEmployeeMgmt_Click(object sender, EventArgs e)
        {
            ShowPage(pnlPageEmployeeMgmt);

            LoadDepartmentsToCombo();  // önce combo
            LoadEmployees();           // sonra grid
        }

        private void btnDepartmentMgmt_Click(object sender, EventArgs e)
        {
            ShowPage(pnlPageDepartmentMgmt);
            LoadDepartments();
        }
        private readonly DepartmentService _depService = new DepartmentService(new MySqlDepartmentRepository());
        private int _selectedDepId = 0;
        private readonly ReportService _reportService;
        private readonly LeaveService _leaveService = new LeaveService(new MySqlLeaveRepository());
        private readonly LeaveRequestService _leaverequestService
            = new LeaveRequestService(new MySqlLeaveRequestRepository());

        private int _selectedLrId = 0;

        private void LoadDepartments()
        {
            var onlyActive = chckOnlyActive.Checked;
            var list = _depService.GetAll(onlyActive);

            dgvDepartments.DataSource = null;
            dgvDepartments.DataSource = list;
            dgvDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDepartments.ScrollBars = ScrollBars.Both;
            dgvDepartments.RowHeadersVisible = false;
            dgvDepartments.AllowUserToResizeColumns = false;

            // Kolon başlıklarını güzelleştir
            if (dgvDepartments.Columns["dId"] != null) dgvDepartments.Columns["dId"].HeaderText = "ID";
            if (dgvDepartments.Columns["dName"] != null) dgvDepartments.Columns["dName"].HeaderText = "Departman";
            if (dgvDepartments.Columns["dIsActive"] != null) dgvDepartments.Columns["dIsActive"].HeaderText = "Aktif";
            if (dgvDepartments.Columns["dCreatedAt"] != null) dgvDepartments.Columns["dCreatedAt"].HeaderText = "Oluşturma";
        }
        private void LoadDepartmentsToCombo()
        {
            // Employee ekranında departman seçebilmek için AKTİF departmanlar yeterli
            var deps = _depService.GetAll(onlyActive: true);

            cmbDepartment.DisplayMember = "dName";
            cmbDepartment.ValueMember = "dId";
            cmbDepartment.DataSource = deps;
        }

        private void dgvDepartments_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvDepartments.CurrentRow?.DataBoundItem is Departments dep)
            {
                _selectedDepId = dep.dId;
                txtDepName.Text = dep.dName;

                btnDepDelete.Text = dep.dIsActive ? "Pasife Çek" : "Aktifleştir";
            }
        }
        private void LoadMyInfo()
        {
            if (UserContext.CurrentUser?.EmployeeId == null)
            {
                MessageBox.Show("Bu kullanıcıya bağlı personel kaydı yok.");
                return;
            }

            int empId = UserContext.CurrentUser.EmployeeId.Value;

            // Burada EmployeeService’ten tek personeli çekmemiz lazım
            var emp = _empService.GetById(empId); // (birazdan ekleteceğim)

            txtMyFullName.Text = emp.eFullName;
            txtMyEmail.Text = emp.eMail;
            txtMyPhone.Text = emp.ePhone;
            txtMyTitle.Text = emp.eTitle;

            // Departman adını servisle çekiyoruz (Employees'ta DepartmentName yok)
            var deps = _depService.GetAll(onlyActive: false); // pasif de olabilir diye false
            var dep = deps.Find(d => d.dId == emp.eDepartmentId);
            txtMyDepartment.Text = dep?.dName ?? "";

        }
        private void btnMyInfoSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserContext.CurrentUser?.EmployeeId == null)
                {
                    MessageBox.Show("Bu kullanıcıya bağlı personel kaydı yok.");
                    return;
                }

                int empId = UserContext.CurrentUser.EmployeeId.Value;

                _empService.UpdateContact(empId, txtMyEmail.Text, txtMyPhone.Text);
                MessageBox.Show("Bilgileriniz güncellendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void picHome_Click(object sender, EventArgs e)
        {
            ShowPage(pnlWelcome);
        }
        private void picHome_MouseEnter(object sender, EventArgs e)
        {
            picHome.BackColor = Color.FromArgb(240, 243, 248);
        }

        private void picHome_MouseLeave(object sender, EventArgs e)
        {
            picHome.BackColor = Color.Transparent;
        }

        private void chckOnlyActive_CheckedChanged(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        private void btnDepAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _depService.Add(txtDepName.Text);
                txtDepName.Clear();
                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDepUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"SelectedDepId={_selectedDepId}, Name='{txtDepName.Text}'");

            try
            {
                _depService.Update(_selectedDepId, txtDepName.Text);
                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDepDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedDepId <= 0)
                {
                    MessageBox.Show("Lütfen bir departman seçin.");
                    return;
                }

                // Seçili satırın aktifliği
                if (dgvDepartments.CurrentRow?.DataBoundItem is Departments dep)
                {
                    if (dep.dIsActive)
                        _depService.Deactivate(_selectedDepId);
                    else
                        _depService.Activate(_selectedDepId);

                    LoadDepartments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private readonly EmployeeService _empService = new EmployeeService(new MySqlEmployeeRepository());
        private int _selectedEmpId = 0;
        private bool _selectedEmpIsActive = true;
        private readonly LeaveRequestService _leaveReqService
             = new LeaveRequestService(new MySqlLeaveRequestRepository());

        private void LoadEmployees()
        {
            dgvEmployees.RowHeadersVisible = false;

            int? depId = null; // Owner için filtre şimdilik yok
            var onlyActive = chckEmpOnlyActive.Checked;

            var list = _empService.GetAll(depId, onlyActive);

            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = list;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvEmployees.ScrollBars = ScrollBars.Both;
            dgvEmployees.AllowUserToResizeColumns = false; // kullanıcı sürükleyip bozmasın
            dgvEmployees.RowHeadersVisible = false;

            // Gridde görünmesini istemediğimiz alanlar
            if (dgvEmployees.Columns["eDepartmentId"] != null)
                dgvEmployees.Columns["eDepartmentId"].Visible = false;

            if (dgvEmployees.Columns["eNo"] != null)
                dgvEmployees.Columns["eNo"].Visible = false;

            // Başlıklar
            if (dgvEmployees.Columns["eId"] != null) dgvEmployees.Columns["eId"].HeaderText = "ID";
            if (dgvEmployees.Columns["eFullName"] != null) dgvEmployees.Columns["eFullName"].HeaderText = "Ad Soyad";
            if (dgvEmployees.Columns["DepartmentName"] != null) dgvEmployees.Columns["DepartmentName"].HeaderText = "Departman";
            if (dgvEmployees.Columns["eTitle"] != null) dgvEmployees.Columns["eTitle"].HeaderText = "Ünvan";
            if (dgvEmployees.Columns["eMail"] != null) dgvEmployees.Columns["eMail"].HeaderText = "E-posta";
            if (dgvEmployees.Columns["ePhone"] != null) dgvEmployees.Columns["ePhone"].HeaderText = "Telefon";
            if (dgvEmployees.Columns["eSalary"] != null) dgvEmployees.Columns["eSalary"].HeaderText = "Maaş";
            if (dgvEmployees.Columns["eIsActive"] != null) dgvEmployees.Columns["eIsActive"].HeaderText = "Aktif";
            dgvEmployees.Columns["eId"].Width = 50;
            dgvEmployees.Columns["eFullName"].Width = 160;
            dgvEmployees.Columns["DepartmentName"].Width = 130;
            dgvEmployees.Columns["eTitle"].Width = 110;
            dgvEmployees.Columns["eMail"].Width = 160;
            dgvEmployees.Columns["ePhone"].Width = 110;
            dgvEmployees.Columns["eSalary"].Width = 70;
            dgvEmployees.Columns["eIsActive"].Width = 60;
            dgvEmployees.Columns["PerformanceScore"].Width = 70;

            // otomatik seç
            if (dgvEmployees.Rows.Count > 0)
            {
                dgvEmployees.ClearSelection();
                dgvEmployees.Rows[0].Selected = true;
                dgvEmployees.CurrentCell = dgvEmployees.Rows[0].Cells[0];
            }
            else
            {
                _selectedEmpId = 0;
                btnEmpToggleActive.Text = "Pasife Çek";
            }
        }
        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow?.DataBoundItem is EmployeeGridRowDto row)
            {
                _selectedEmpId = row.eId;
                _selectedEmpIsActive = row.eIsActive;

                txtEmpNo.Text = row.eNo;
                txtFullName.Text = row.eFullName;
                txtTitle.Text = row.eTitle;
                txtMail.Text = row.eMail;
                txtPhone.Text = row.ePhone;
                txtSalary.Text = row.eSalary.ToString("0.00");

                // Departman seç
                cmbDepartment.SelectedValue = row.eDepartmentId;

                btnEmpToggleActive.Text = row.eIsActive ? "Pasife Çek" : "Aktifleştir";
            }
        }
        private void chkEmpOnlyActive_CheckedChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }
        private void chckEmpOnlyActive_CheckedChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }
        private void btnEmpAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDepartment.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen departman seçin.");
                    return;
                }
                int depId = (int)cmbDepartment.SelectedValue;
                var emp = new Employees
                {
                    eNo = (txtEmpNo.Text ?? "").Trim(),
                    eFullName = (txtFullName.Text ?? "").Trim(),
                    eDepartmentId = depId,
                    eTitle = (txtTitle.Text ?? "").Trim(),
                    eMail = (txtMail.Text ?? "").Trim(),
                    ePhone = (txtPhone.Text ?? "").Trim(),
                    eSalary = decimal.TryParse(txtSalary.Text, out var sal) ? sal : 0m,
                    eIsActive = true
                };
               

                _empService.Add(emp);
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEmpUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedEmpId <= 0)
                {
                    MessageBox.Show("Lütfen personel seçin.");
                    return;
                }

                var emp = new Employees
                {
                    eId = _selectedEmpId,
                    eNo = (txtEmpNo.Text ?? "").Trim(), // eNo güncellenmiyorsa DAL'da ignore edebilirsin
                    eFullName = (txtFullName.Text ?? "").Trim(),
                    eDepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue),
                    eTitle = (txtTitle.Text ?? "").Trim(),
                    eMail = (txtMail.Text ?? "").Trim(),
                    ePhone = (txtPhone.Text ?? "").Trim(),
                    eSalary = decimal.TryParse(txtSalary.Text, out var sal) ? sal : 0m,
                };
                emp.eDepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);

                _empService.Update(emp, canEditSalary: true);
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEmpToggleActive_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedEmpId <= 0)
                {
                    MessageBox.Show("Lütfen personel seçin.");
                    return;
                }

                _empService.SetActive(_selectedEmpId, !_selectedEmpIsActive);
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvLeaveRequests_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var prop = dgvLeaveRequests.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrWhiteSpace(prop)) return;

            if (!(_leaveReqBs.DataSource is List<LeaveRequestApproveRowDto> current)) return;

            List<LeaveRequestApproveRowDto> sorted;

            if (_leaveReqSortAsc)
                sorted = current.OrderBy(x => GetPropValue(x, prop)).ToList();
            else
                sorted = current.OrderByDescending(x => GetPropValue(x, prop)).ToList();

            _leaveReqSortAsc = !_leaveReqSortAsc;

            BindLeaveRequestsSortable(sorted);
        }
        private void btnAllLeavesHistory_Click(object sender, EventArgs e) 
        {
            ShowPage(pnlPageAllLeavesHistory);
            LoadAllLeavesHistoryForOwner();
        }


        // reflection ile property value al (string/date/int hepsini idare eder)
        private object GetPropValue(object obj, string propName)
        {
            var p = obj.GetType().GetProperty(propName);
            return p?.GetValue(obj, null) ?? "";
        }
        private readonly LeaveRequestService _leaveRequestService =
    new LeaveRequestService(new MySqlLeaveRequestRepository());

        private void LoadAllLeavesHistoryForOwner()
        {
            int? depId = null;      // Owner => tüm departmanlar
            int? empId = null;

            var list = _leaveRequestService.GetLeaveHistoryForEmployees(depId, empId);

            dgvAllLeaveHistory.DataSource = null;
            dgvAllLeaveHistory.DataSource = list;

            // kolon başlık tıklayınca sıralama
            dgvAllLeaveHistory.AllowUserToOrderColumns = true;
            foreach (DataGridViewColumn c in dgvAllLeaveHistory.Columns)
                c.SortMode = DataGridViewColumnSortMode.Automatic;

            if (dgvAllLeaveHistory.Columns["lrId"] != null)
                dgvAllLeaveHistory.Columns["lrId"].Visible = false;

            dgvAllLeaveHistory.Columns["EmployeeName"].HeaderText = "Personel";
            dgvAllLeaveHistory.Columns["LeaveTypeName"].HeaderText = "İzin Türü";
            dgvAllLeaveHistory.Columns["StartDate"].HeaderText = "Başlangıç";
            dgvAllLeaveHistory.Columns["EndDate"].HeaderText = "Bitiş";
            dgvAllLeaveHistory.Columns["DayCount"].HeaderText = "Gün";
            dgvAllLeaveHistory.Columns["Status"].HeaderText = "Durum";

            dgvAllLeaveHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllLeaveHistory.RowHeadersVisible = false;
        }

    }

}

