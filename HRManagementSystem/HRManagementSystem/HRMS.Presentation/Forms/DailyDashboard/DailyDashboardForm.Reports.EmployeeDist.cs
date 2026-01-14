using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace HRMS.Presentation
{
    public partial class DailyDashboardForm : Form
    {
        private void ShowEmpDist()
        {
            FixEmpDistLayout();
            HideAllReportPanels();
            pnlRptEmpDistHost.Visible = true;
            pnlRptEmpDistHost.BringToFront();
        }
        private void LoadEmployeeDistReport()
        {
           
            dgvEmployeeDist.Rows.Clear();
            dgvEmployeeDist.DataSource = null;

            var depId = SelectedDepartmentId();
            var empId = SelectedEmployeeId();

            var rows = _reportService.GetPerformanceRows(null, depId, empId);

            // Chart
            chartEmployeeDist.Series.Clear();
            var s = chartEmployeeDist.Series.Add("Personel");
            s.Color = Color.FromArgb(34, 138, 66);
            s.Points.Clear();

            var deptCounts = rows
                .GroupBy(x => x.DepartmentName)
                .Select(g => new { DepartmentName = g.Key, Count = g.Count() })
                .OrderBy(x => x.DepartmentName)
                .ToList();

            foreach (var d in deptCounts)
                s.Points.AddXY(d.DepartmentName, d.Count);

            dgvEmployeeDist.DataSource = null;
            dgvEmployeeDist.Rows.Clear();
            dgvEmployeeDist.Columns.Clear();
            dgvEmployeeDist.AutoGenerateColumns = false;

            dgvEmployeeDist.Columns.Add("colName", "Departman / Personel");
            dgvEmployeeDist.Columns.Add("colCount", "Kişi Sayısı");
            dgvEmployeeDist.Columns.Add("colAvgSalary", "Ort. Maaş");
            dgvEmployeeDist.Columns.Add("colAvgPerf", "Ort. Performans");

            var groups = rows
                .GroupBy(x => x.DepartmentName)
                .OrderBy(g => g.Key);

            foreach (var g in groups)
            {
                int count = g.Count();
                decimal avgSalary = count == 0 ? 0 : g.Average(x => x.Salary);
                double avgPerf = count == 0 ? 0 : g.Average(x => x.Score);

                // departman satırı (1 kez)
                int headerIndex = dgvEmployeeDist.Rows.Add(
                    g.Key,
                    count,
                    avgSalary.ToString("0.##"),
                    avgPerf.ToString("0.##")
                );

                if (headerIndex >= 0)
                {
                    dgvEmployeeDist.Rows[headerIndex].DefaultCellStyle.Font =
                        new System.Drawing.Font(dgvEmployeeDist.Font, System.Drawing.FontStyle.Bold);
                }

                // personeller (departman adı asla yazılmayacak)
                foreach (var emp in g.OrderBy(x => x.EmployeeName))
                {
                    dgvEmployeeDist.Rows.Add(
                        "   • " + emp.EmployeeName,
                        "", "", ""
                    );
                }
            }

        }
        private void FixEmpDistLayout()
        {
            var tlp = tlpRptEmpDist;  

            tlp.SuspendLayout();

            tlp.RowStyles.Clear();
            tlp.RowCount = 2;

            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 320F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tlp.SetRow(chartEmployeeDist, 0);
            tlp.SetRow(dgvEmployeeDist, 1);

            chartEmployeeDist.Dock = DockStyle.Fill;
            dgvEmployeeDist.Dock = DockStyle.Fill;
            dgvEmployeeDist.ScrollBars = ScrollBars.Both;

            tlp.ResumeLayout(true);
        }

    }

}
