using HRMS.DAL;
using HRMS.Domain.Auth;
using HRMS.Presentation.Context;
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

namespace HRMS.Presentation.HRMS.Presentation.Forms
{
    public partial class EmployeeMainForm : Form
    {
        public EmployeeMainForm()
        {
            InitializeComponent();
        }
        private void EmployeeMainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"Kullanıcı: {UserContext.CurrentUser?.UserName} | Rol: Employee";
            ApplyNavByRole();
            CenterWelcome();

        }
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

        private void btnMyLeaves_Click_1(object sender, EventArgs e)
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
        private void picHome_Click_1(object sender, EventArgs e)
        {
            ShowPage(pnlWelcome);
        }
        private void picHome_MouseEnter_1(object sender, EventArgs e)
        {
            picHome.BackColor = Color.FromArgb(240, 243, 248);
        }

        private void picHome_MouseLeave_1(object sender, EventArgs e)
        {
            picHome.BackColor = Color.Transparent;
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
        private readonly EmployeeService _empService = new EmployeeService(new MySqlEmployeeRepository());
        private readonly LeaveService _leaveService = new LeaveService(new MySqlLeaveRepository());

        private void btnMyInfoSave_Click_1(object sender, EventArgs e)
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

        private void btnMyInfo_Click(object sender, EventArgs e)
        {
            ShowPage(pnlPageMyInfo);
            LoadMyInfo();
        }

      
    }
}
