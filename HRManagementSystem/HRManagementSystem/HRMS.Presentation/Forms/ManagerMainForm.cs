using HRMS.DAL;
using HRMS.Domain;
using HRMS.Domain.Auth;
using HRMS.Presentation.Context;
using HRMS.Presentation.HRMS.Presentation.Forms;
using HRMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HRMS.Presentation.HRMS.Presentation.Forms
{
    public partial class ManagerMainForm : Form
    {
        public ManagerMainForm()
        {
            InitializeComponent();
        }

        private void ManagerMainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"Kullanıcı: {UserContext.CurrentUser?.UserName} | Rol: Manager";
            ApplyNavByRole();
            CenterWelcome();

        }
        private readonly EmployeeService _service;

        private void ShowPage(Control page)
        {
            foreach (Control c in pnlMain.Controls)
                c.Visible = false;

            page.Visible = true;
            page.BringToFront();
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

        private readonly LeaveRequestService _leaveReqService
                = new LeaveRequestService(new MySqlLeaveRequestRepository());

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
        private void btnApprove_Click(object sender, EventArgs e)
        {
            _leaverequestService.Approve(_selectedLrId);
            LoadLeaveRequestsForApproval(isManager: true);

        }
        private void btnReject_Click(object sender, EventArgs e)
        {
            _leaverequestService.Reject(_selectedLrId);
            LoadLeaveRequestsForApproval(isManager: true);

        }
        private void btnAllLeaveRequests_Click(object sender, EventArgs e)
        {
            ShowPage(pnlPageAllLeaveRequests);
            LoadLeaveRequestsForApproval(isManager: true);
        }
        private readonly LeaveRequestService _leaverequestService
          = new LeaveRequestService(new MySqlLeaveRequestRepository());

        private void LoadLeaveRequestsForApproval(bool isManager)
        {
            int? depId = null;
            int? excludeEmpId = null;

            if (isManager)
            {
                if (UserContext.CurrentUser?.EmployeeId == null)
                    throw new Exception("Manager'ın EmployeeId bilgisi yok.");

                int myEmpId = UserContext.CurrentUser.EmployeeId.Value;

                // kendisi hariç
                excludeEmpId = myEmpId;

                // sadece kendi departmanı
                depId = _empService.GetDepartmentIdByEmployeeId(myEmpId);
            }

            var list = _leaverequestService.GetRequestsForApproval(depId, excludeEmpId);

            dgvLeaveRequests.DataSource = null;
            dgvLeaveRequests.DataSource = list;

            // kolon gizle / başlıklar vs. (sende zaten vardı)
            if (dgvLeaveRequests.Columns["lrId"] != null) dgvLeaveRequests.Columns["lrId"].Visible = false;

            _selectedLrId = 0;
            if (dgvLeaveRequests.Rows.Count > 0)
            {
                dgvLeaveRequests.ClearSelection();
                dgvLeaveRequests.Rows[0].Selected = true;

                if (dgvLeaveRequests.Rows[0].DataBoundItem is LeaveRequestApproveRowDto row)
                    _selectedLrId = row.lrId;
            }
        }

        private void dgvLeaveRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLeaveRequests.CurrentRow?.DataBoundItem is LeaveRequestApproveRowDto row)
                _selectedLrId = row.lrId;
        }
        private BindingSource _leaveReqBs = new BindingSource();
        private bool _leaveReqSortAsc = true;

        private int _selectedLrId = 0;
        private void BindLeaveRequestsSortable(List<LeaveRequestApproveRowDto> list)
        {
            // grid ilk kez bağlanıyorsa
            if (dgvLeaveRequests.DataSource == null)
                dgvLeaveRequests.DataSource = _leaveReqBs;

            _leaveReqBs.DataSource = list;
        }
       
        private void dgvLeaveRequests_ColumnHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
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

        // reflection ile property value al (string/date/int hepsini idare eder)
        private object GetPropValue(object obj, string propName)
        {
            var p = obj.GetType().GetProperty(propName);
            return p?.GetValue(obj, null) ?? "";
        }

        private void btnEmployeeMgmt_Click(object sender, EventArgs e)
        {
            ShowPage(pnlPageEmployeeMgmt);

            // 1) Manager'ın EmployeeId'si (UserContext'ten)
            int empId = UserContext.CurrentUser.EmployeeId.Value;

            // 2) Bu EmployeeId'nin departmanı
            int depId = _service.GetDepartmentIdByEmployeeId(empId);

            // 3) Departman filtreli liste
            var list = _service.GetAll(depId, true);

            // 4) Grid'e bas
            //dgvEmployee.DataSource = list;
        }


        private void btnDepartmentMgmt_Click(object sender, EventArgs e) => ShowPage(pnlPageDepartmentMgmt);
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
        private readonly LeaveService _leaveService = new LeaveService(new MySqlLeaveRepository());

        private readonly EmployeeService _empService = new EmployeeService(new MySqlEmployeeRepository());
        private void btnReports_Click(object sender, EventArgs e)
        {
            try
            {
                RequireRole(UserRole.Owner, UserRole.Manager);

                int? depId = null;

                // Manager ise departman filtresi sabit
                if (UserContext.HasRole(UserRole.Manager) && UserContext.CurrentUser?.EmployeeId != null)
                {
                    int empId = UserContext.CurrentUser.EmployeeId.Value;
                    depId = _empService.GetDepartmentIdByEmployeeId(empId);
                }

                var frm = new DailyDashboardForm(depId);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void RequireRole(params UserRole[] roles)
        {
            foreach (var r in roles)
                if (UserContext.HasRole(r)) return;

            throw new UnauthorizedAccessException("Bu işlemi yapmaya yetkiniz yok.");
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
        private void btnMyInfo_Click_1(object sender, EventArgs e)
        {
            ShowPage(pnlPageMyInfo);
            LoadMyInfo();
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
        private readonly DepartmentService _depService = new DepartmentService(new MySqlDepartmentRepository());

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

        private void btnAllLeavesHistory_Click(object sender, EventArgs e)
        {
            ShowPage(pnlPageAllLeavesHistory);
            LoadAllLeavesHistoryForManager();
        }
        private void LoadAllLeavesHistoryForManager()
        {
            if (UserContext.CurrentUser?.EmployeeId == null)
                throw new Exception("Manager EmployeeId bulunamadı.");

            int empIdSelf = UserContext.CurrentUser.EmployeeId.Value;
            int? depId = _empService.GetDepartmentIdByEmployeeId(empIdSelf);

            var list = _leaveRequestService.GetLeaveHistoryForEmployees(depId, null);

            dgvAllLeaveHistory.DataSource = null;
            dgvAllLeaveHistory.DataSource = list;

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

        private readonly LeaveRequestService _leaveRequestService =
    new LeaveRequestService(new MySqlLeaveRequestRepository());
    }
}