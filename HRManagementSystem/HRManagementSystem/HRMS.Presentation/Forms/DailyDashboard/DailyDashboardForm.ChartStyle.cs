using System;
using System.Drawing;
using System.Windows.Forms;

namespace HRMS.Presentation
{
    public partial class DailyDashboardForm : Form
    {
        private void InitStandardColumnChart(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();
            chart.Titles.Clear();

            var area = new System.Windows.Forms.DataVisualization.Charting.ChartArea("Main");
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = true;
            area.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            area.AxisY.Minimum = 0;

            chart.ChartAreas.Add(area);

            var s = new System.Windows.Forms.DataVisualization.Charting.Series("MainSeries");
            s.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            s.IsValueShownAsLabel = true;
            s.Font = new System.Drawing.Font("Segoe UI", 9f);

            chart.Series.Add(s);

            ApplyCleanChartStyle(chart);
        }

        private void ApplyCleanChartStyle(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            if (chart == null) return;

            // ChartArea garanti
            if (chart.ChartAreas.Count == 0)
                chart.ChartAreas.Add("Main");

            var ca = chart.ChartAreas[0];

            // Arka planı temizle
            chart.BackColor = Color.Transparent;
            ca.BackColor = Color.Transparent;

            // Border / çerçeve kapat
            ca.BorderWidth = 0;
            ca.BorderColor = Color.Transparent;

            // Gridline'ları yumuşat (dikeyleri kapat, yatayları açık bırak)
            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisX.MinorGrid.Enabled = false;

            ca.AxisY.MajorGrid.Enabled = true;
            ca.AxisY.MinorGrid.Enabled = false;
            ca.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            ca.AxisY.MajorGrid.LineWidth = 1;

            // Eksen çizgilerini yumuşat
            ca.AxisX.LineWidth = 1;
            ca.AxisY.LineWidth = 1;
            ca.AxisX.LineColor = Color.Gray;
            ca.AxisY.LineColor = Color.Gray;

            // Tick (çentik) çizgilerini azalt
            ca.AxisX.MajorTickMark.Enabled = false;
            ca.AxisY.MajorTickMark.Enabled = false;

            // Label fontları (istersen)
            ca.AxisX.LabelStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
            ca.AxisY.LabelStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);

            // Legend varsa temizle (yoksa dokunma -> index hatası buradan geliyordu)
            if (chart.Legends.Count > 0)
            {
                var lg = chart.Legends[0];
                lg.BackColor = Color.Transparent;
                lg.BorderWidth = 0;
                lg.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
            }

            // Series varsa kolon stili + değer etiketleri
            if (chart.Series.Count > 0)
            {
                foreach (var s in chart.Series)
                {
                    s.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    s.IsValueShownAsLabel = true;
                    s.Font = new Font("Segoe UI", 9f, FontStyle.Regular);

                    // bar kenarlarını yumuşat (çok keskin durmasın)
                    s.BorderWidth = 0;
                }
            }
        }
    }
}
