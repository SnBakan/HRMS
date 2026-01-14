using System;
using System.Drawing;
using System.Windows.Forms;

namespace HRMS.Presentation
{
    public partial class DailyDashboardForm : Form
    {
        private void LoadPerformanceDistReport()
        {
            var depId = SelectedDepartmentId();
            var empId = SelectedEmployeeId();

            var rows = _reportService.GetPerformanceRows(null, depId, empId);

           
            // Chart: skor aralıkları
            int c0_49 = 0, c50_69 = 0, c70_84 = 0, c85_100 = 0;

            foreach (var r in rows)
            {
                if (r.Score <= 49) c0_49++;
                else if (r.Score <= 69) c50_69++;
                else if (r.Score <= 84) c70_84++;
                else c85_100++;
            }

            chartPerfDist.Series.Clear();
            var s = chartPerfDist.Series.Add("Performans");
            s.Color = Color.FromArgb(0, 92, 167);
            s.Points.Clear();

            s.Points.AddXY("0-49", c0_49);
            s.Points.AddXY("50-69", c50_69);
            s.Points.AddXY("70-84", c70_84);
            s.Points.AddXY("85-100", c85_100);

            // Grid: kolon yoksa ekle
            if (dgvPerfDist.Columns.Count == 0)
            {
                dgvPerfDist.AutoGenerateColumns = false;
                dgvPerfDist.Columns.Add("colEmp", "Personel");
                dgvPerfDist.Columns.Add("colDept", "Departman");
                dgvPerfDist.Columns.Add("colScore", "Skor");
                dgvPerfDist.Columns.Add("colEval", "Değerlendirme");
                dgvPerfDist.Columns.Add("colDate", "Tarih");
            }

            dgvPerfDist.Rows.Clear();
            foreach (var r in rows)
            {
                dgvPerfDist.Rows.Add(
                    r.EmployeeName,
                    r.DepartmentName,
                    r.Score,
                    r.Evaluation,
                    r.ReviewedAt.ToString("dd.MM.yyyy")
                );
            }
        }
        private void FixPerfDistLayout()
        {
            var tlp = tlpRptPerfDist; // <-- sende neyse

            tlp.SuspendLayout();

            tlp.RowStyles.Clear();
            tlp.RowCount = 2;

            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 320F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tlp.SetRow(chartPerfDist, 0);
            tlp.SetRow(dgvPerfDist, 1);

            chartPerfDist.Dock = DockStyle.Fill;
            dgvPerfDist.Dock = DockStyle.Fill;
            dgvPerfDist.ScrollBars = ScrollBars.Both;

            tlp.ResumeLayout(true);
        }

        private void ShowPerfDist()
        {
            FixPerfDistLayout();
            HideAllReportPanels();
            pnlRptPerfDistHost.Visible = true;
            pnlRptPerfDistHost.BringToFront();
        }
    }
   
}

