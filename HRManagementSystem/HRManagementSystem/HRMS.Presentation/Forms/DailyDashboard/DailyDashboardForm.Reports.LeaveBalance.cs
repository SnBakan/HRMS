using HRMS.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HRMS.Presentation
{
    public partial class DailyDashboardForm : Form
    {
        private void FixLeaveBalanceLayout()
        {
            // 1) TableLayout adı sende neyse onu kullan:
            // tlpRptLeaveBalance varsayıyorum; sende farklıysa sadece ismi değiştir.
            var tlp = tlpRptLeaveBalance;

            tlp.SuspendLayout();

            // 2) 2 satır: Chart + Grid
            tlp.RowStyles.Clear();
            tlp.RowCount = 2;

            // Chart satırı: Absolute (320)
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 320F));

            // Grid satırı: kalan alanın tamamı
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // 3) Kontroller doğru satırlarda mı? garantiye al
            tlp.SetRow(chartLeaveBalance, 0);
            tlp.SetRow(dgvLeaveBalance, 1);

            // 4) Dock ayarlarını da garanti et
            chartLeaveBalance.Dock = DockStyle.Fill;
            dgvLeaveBalance.Dock = DockStyle.Fill;
            dgvLeaveBalance.ScrollBars = ScrollBars.Both;

            tlp.ResumeLayout(true);
        }

        private void EnsureLeaveBalanceUi()
        {
            if (_leaveBalanceUiReady) return;

            // Grid ayarları (DB gelince de kalsın, zararı yok)
            dgvLeaveBalance.AutoGenerateColumns = false;
            dgvLeaveBalance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeaveBalance.ReadOnly = true;
            dgvLeaveBalance.AllowUserToAddRows = false;
            dgvLeaveBalance.AllowUserToDeleteRows = false;
            dgvLeaveBalance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeaveBalance.MultiSelect = false;

            _leaveBalanceUiReady = true;
        }
        private void ShowLeaveBalance()
        {
            FixLeaveBalanceLayout();
            EnsureLeaveBalanceUi();
            HideAllReportPanels();
            pnlRptLeaveBalanceHost.BringToFront();

            // Doğru host paneli aç
            pnlRptLeaveBalanceHost.Visible = true;
            pnlRptLeaveBalanceHost.BringToFront();

            // scroll alanı arkada kalıyorsa öne al
            pnlReportsScroll.Visible = true;
            pnlReportsScroll.BringToFront();
        }

        private void RenderLeaveBalanceReport(List<LeaveBalanceRowDto> rows)
        {
            EnsureLeaveBalanceUi();

            dgvLeaveBalance.Rows.Clear();

            foreach (var r in rows)
            {
                dgvLeaveBalance.Rows.Add(
                    r.EmployeeName,
                    r.DepartmentName,
                    r.TotalDays,
                    r.UsedDays,
                    r.RemainingDays,
                    r.UsagePercentText,
                    r.LastUsedText
                );
            }

            
            chartLeaveBalance.Series.Clear();
            var s = chartLeaveBalance.Series.Add("Kalan İzin");
            s.Color = Color.FromArgb(218, 114, 77);
            s.Points.Clear();

            int c0_5 = 0, c6_10 = 0, c11_15 = 0, c16p = 0;

            foreach (var r in rows)
            {
                var rem = r.RemainingDays;
                if (rem <= 5) c0_5++;
                else if (rem <= 10) c6_10++;
                else if (rem <= 15) c11_15++;
                else c16p++;
            }

            s.Points.AddXY("0-5 gün", c0_5);
            s.Points.AddXY("6-10 gün", c6_10);
            s.Points.AddXY("11-15 gün", c11_15);
            s.Points.AddXY("16+ gün", c16p);
        }


    }
}

