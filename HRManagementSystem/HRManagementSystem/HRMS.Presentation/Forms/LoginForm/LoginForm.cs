using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRMS.DAL;
using HRMS.Presentation.Context;
using HRMS.Service.Auth;
using HRMS.DAL.Auth;
using HRMS.Domain.Auth;
using HRMS.Presentation.HRMS.Presentation.Forms;

namespace HRMS.Presentation.HRMS.Presentation.Forms.LoginForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Resize += (s, e) => CenterCard();
            CenterCard();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;
                var repo = new AuthRepository();
                var service = new AuthService(repo);

                var (user, roles) = service.Login(
                    txtUsername.Text.Trim(),
                    txtPassword.Text
                );

                UserContext.SetUser(user, roles);

                // Login formunu gizle
                this.Hide();

                // Hangi role göre hangi ekran açılacak?
                Form next;

                if (UserContext.HasRole(UserRole.Owner))
                    next = new OwnerMainForm();
                else if (UserContext.HasRole(UserRole.Manager))
                    next = new ManagerMainForm();
                else
                    next = new EmployeeMainForm();

                // Ana form kapanınca uygulama da kapansın (Login gizli kalmasın)
                next.FormClosed += (s, args) => this.Close();

                // Formu aç
                next.Show();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
        private void CenterCard()
        {
            pnlLoginCard.Left = (this.ClientSize.Width - pnlLoginCard.Width) / 2;
            pnlLoginCard.Top = (this.ClientSize.Height - pnlLoginCard.Height) / 2;
            pnlIcon.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (var brush = new System.Drawing.SolidBrush(Color.SteelBlue))
                {
                    g.FillEllipse(brush, 0, 0, pnlIcon.Width - 1, pnlIcon.Height - 1);
                }
            };
            pnlIcon.Resize += (s, e) => MakeCircle(pnlIcon);
            MakeCircle(pnlIcon);

        }
        private void MakeCircle(Panel p)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, p.Width, p.Height);
            p.Region = new Region(path);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
