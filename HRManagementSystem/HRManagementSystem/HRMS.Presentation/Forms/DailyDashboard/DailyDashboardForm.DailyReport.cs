using System;
using HRMS.Service;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HRMS.Presentation
{
    public partial class DailyDashboardForm : Form
    {
        private List<DailyLeaveItemDto> _leaveItems = new List<DailyLeaveItemDto>();
        private void LoadDailyReport()
        {

            if (_initializing) return;
          
            var from = pickDtStart.Value.Date;
            var to = pickDtEnd.Value.Date;

            // DB'den yeniden çek
            var fetched = _reportService.GetDailyLeaves(from, to, DateTime.Today);
            _leaveItems.Clear();
            _leaveItems.AddRange(fetched);
            flpLeaveCards.SuspendLayout();
            flpLeaveCards.Controls.Clear();
            flpLeaveCards.ResumeLayout();
            ApplySortingAndRender();
        }
        
        private void ShowDailyReport()
        {
            HideAllReportPanels();
            flpLeaveCards.Visible = true;
            flpLeaveCards.BringToFront(); 
        }
        private void ApplySortingAndRender()
        {
            IEnumerable<DailyLeaveItemDto> query = _leaveItems;

            // Tüm Departmanlar işaretli DEĞİLSE filtre uygula
            if (!chckDepartment.Checked)
            {
                int depId = Convert.ToInt32(cmbDepartment.SelectedValue);
                if (depId != 0)
                    query = query.Where(x => x.DepartmentId == depId);
            }

            // Tüm Personeller işaretli DEĞİLSE filtre uygula
            if (!chckEmployee.Checked)
            {
                int empId = Convert.ToInt32(cmbEmployee.SelectedValue);
                if (empId != 0)
                    query = query.Where(x => x.EmployeeId == empId);
            }


            // Sıralama 
            string sort = cmbSortLeave.SelectedItem != null ? cmbSortLeave.SelectedItem.ToString() : "";

            if (sort == "Bitişe En Çok Kalan")
                query = query.OrderByDescending(x => x.RemainingDays);
            else if (sort == "Departmana Göre (A-Z)")
                query = query.OrderBy(x => x.DepartmentName).ThenBy(x => x.EmployeeName);
            else if (sort == "Başlangıç Tarihi (Yakın→Uzak)")
            {
                query = query.OrderBy(x => x.StartDate).ToList();
            }
            else if (sort == "Başlangıç Tarihi (Uzak→Yakın)")
            {
                query = query.OrderByDescending(x => x.StartDate).ToList();
            }
            else
                query = query.OrderBy(x => x.RemainingDays); // Bitişe En Az Kalan (default)
            

            RenderLeaveCards(query.ToList());
        }
        private void RenderLeaveCards(List<DailyLeaveItemDto> items)
        {
            flpLeaveCards.SuspendLayout();
            flpLeaveCards.Controls.Clear();

            foreach (var item in items)
            {
                var card = CreateLeaveCard(item);
                flpLeaveCards.Controls.Add(card);

                // HER karttan sonra alt satıra geçmeyi zorla
                flpLeaveCards.SetFlowBreak(card, true);
            }

            flpLeaveCards.ResumeLayout(true);
        }
        private Control CreateLeaveCard(DailyLeaveItemDto item)
        {
            //Dahili
            var card = new Panel
            {
                Height = 110,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 12)
            };

            int scrollbar = flpLeaveCards.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0;

            card.Width = flpLeaveCards.ClientSize.Width
                        - flpLeaveCards.Padding.Left
                        - flpLeaveCards.Padding.Right
                        - scrollbar;

            var lblName = new Label
            {
                Text = item.EmployeeName,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };

            var lblDept = new Label
            {
                Text = item.DepartmentName,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.DimGray,
                Location = new Point(15, 45),
                AutoSize = true
            };

            var lblRange = new Label
            {
                Text = $"{item.StartDate:dd.MM.yyyy} - {item.EndDate:dd.MM.yyyy}",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.DimGray,
                Location = new Point(15, 70),
                AutoSize = true
            };

            // badge
            var badge = new Label
            {
                Text = item.LeaveTypeText,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                BackColor = Color.RoyalBlue,
                Width = 90,
                Height = 28
            };
            badge.BackColor = item.LeaveTypeText.Contains("Özel") ? Color.MediumPurple : Color.RoyalBlue;
            badge.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // lblRem
            var lblRem = new Label
            {
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true
            };

            lblRem.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Tarihten hesapla
            int daysToEnd = (item.EndDate.Date - DateTime.Today).Days;

            if (daysToEnd < 0)
            {
                lblRem.Text = "Bitti";
                lblRem.ForeColor = Color.Gray;
            }
            else if (daysToEnd == 0)
            {
                lblRem.Text = "Bugün bitiyor";
                lblRem.ForeColor = Color.DarkOrange;
            }
            else
            {
                lblRem.Text = $"Kalan {daysToEnd} Gün";
                lblRem.ForeColor = Color.RoyalBlue;
            }


            // konumlandırma fonksiyonu
            void LayoutRightSide()
            {
                badge.Location = new Point(card.ClientSize.Width - badge.Width - 20, 15);
                lblRem.Location = new Point(card.ClientSize.Width - lblRem.PreferredWidth - 20, 75);
            }

            LayoutRightSide();
            card.Resize += (s, e) => LayoutRightSide();

            card.Controls.Add(lblName);
            card.Controls.Add(lblDept);
            card.Controls.Add(lblRange);
            card.Controls.Add(badge);
            card.Controls.Add(lblRem);

            return card;
        }
     
        private void flpLeaveCards_SizeChanged(object sender, EventArgs e)
        {
            // FlowLayoutPanel scroll bar payı
            var w = flpLeaveCards.ClientSize.Width - 25;
            if (w < 300) w = 300;

        }

        private void chckDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (_filtersLoading) return;

            _filtersLoading = true;
            try
            {
                if (chckDepartment.Checked)
                {
                    // Tüm Departmanlar
                    cmbDepartment.SelectedValue = 0;

                    // Departman tüm olunca personel de tüm olsun (mantıklı)
                    cmbEmployee.SelectedValue = 0;
                    chckEmployee.Checked = true;
                }
            }
            finally
            {
                _filtersLoading = false;
            }

            ReloadCurrentReport();
           
        }

        private void chckEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (_filtersLoading) return;

            _filtersLoading = true;
            try
            {
                if (chckEmployee.Checked)
                {
                    // Tüm Personeller
                    cmbEmployee.SelectedValue = 0;
                }
            }
            finally
            {
                _filtersLoading = false;
            }

            ReloadCurrentReport();
           
        }

    }
}
