using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HRMS.Presentation
{
    public partial class DailyDashboardForm : Form
    {
        private void LoadSalaryDistReport()
        {
            var depId = SelectedDepartmentId();
            var empId = SelectedEmployeeId();

            // 1) Filtreli kaynak (detay + dağılım bunu kullanacak)
            var baseRows = _reportService.GetPerformanceRows(null, depId, empId);

            // 2) Chart: Maaş aralığı dağılımı (baseRows üzerinden)
            chartSalaryDist.Series.Clear();
            var s = chartSalaryDist.Series.Add("Maaş");
            s.Color = Color.FromArgb(120, 24, 185);
            s.Points.Clear();

            // Aralıklar (istersen değiştir)
            int c0_10 = 0, c10_20 = 0, c20_30 = 0, c30_40 = 0, c40p = 0;

            foreach (var r in baseRows)
            {
                var sal = r.Salary; // PerformanceRowDto içinde Salary olmalı

                if (sal <= 60000) c0_10++;
                else if (sal <= 70000) c10_20++;
                else if (sal <= 90000) c20_30++;
                else if (sal <= 100000) c30_40++;
                else c40p++;
            }

            s.Points.AddXY("60K-", c0_10);
            s.Points.AddXY("60-70K", c10_20);
            s.Points.AddXY("70-90K", c20_30);
            s.Points.AddXY("90-100K", c30_40);
            s.Points.AddXY("100K+", c40p);

            // 3) Grid: Detay tablo (Personel/Departman/Title/Performans/Maaş)
            dgvSalaryDist.Rows.Clear();
            dgvSalaryDist.Columns.Clear();
            dgvSalaryDist.AutoGenerateColumns = false;

            dgvSalaryDist.Columns.Add("colName", "Personel");
            dgvSalaryDist.Columns.Add("colDept", "Departman");
            dgvSalaryDist.Columns.Add("colTitle", "Title");
            dgvSalaryDist.Columns.Add("colPerf", "Performans");
            dgvSalaryDist.Columns.Add("colSalary", "Maaş");

            foreach (var x in baseRows.OrderByDescending(x => x.Salary))
            {
                dgvSalaryDist.Rows.Add(
                    x.EmployeeName,
                    x.DepartmentName,
                    x.Title,
                    x.Score,    
                    x.Salary
                );
            }
        }
      
        private void FixSalaryDistLayout()
        {
            var tlp = tlpRptSalaryDist; // <-- sende neyse

            tlp.SuspendLayout();

            tlp.RowStyles.Clear();
            tlp.RowCount = 2;

            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 320F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tlp.SetRow(chartSalaryDist, 0);
            tlp.SetRow(dgvSalaryDist, 1);

            chartSalaryDist.Dock = DockStyle.Fill;
            dgvSalaryDist.Dock = DockStyle.Fill;
            dgvSalaryDist.ScrollBars = ScrollBars.Both;

            tlp.ResumeLayout(true);
        }
        private void ShowSalaryDist()
        {
            FixSalaryDistLayout();
            HideAllReportPanels();
            pnlRptSalaryDistHost.Visible = true;
            pnlRptSalaryDistHost.BringToFront();
        }


    }
}