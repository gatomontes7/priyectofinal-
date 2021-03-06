using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarySystem.Includes;

namespace LibrarySystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        SQLConfig config = new SQLConfig();
        usableFunction funct = new usableFunction();
        string sql;

        private void reports(string sql, string rptname)
        {
            try
            {
                config.loadReports(sql);
                string reportname, strReportPath;

                reportname = rptname;
                CrystalDecisions.CrystalReports.Engine.ReportDocument reportdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                strReportPath = Application.StartupPath + "\\report\\" + reportname + ".rpt";
                reportdoc.Load(strReportPath);
                reportdoc.SetDataSource(config.dt);

                crystalReportViewer1.ReportSource = reportdoc;
                crystalReportViewer1.ShowRefreshButton = false;
                crystalReportViewer1.ShowCloseButton = false;
                crystalReportViewer1.ShowGroupTreeButton = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " No crytal reports installed.");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetText();
            timer1.Start();
        }

        private void GetText()
        {
            sql = "SELECT `Fullname`, `User_name`, `UserRole`,`LogDate`, `LogMode` FROM `tbllogs` l, `tbluser` u WHERE l.`UserId`=u.`UserId`";
            if (Properties.Settings.Default.lenguaje == "en-US")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                reports(sql, "LogsReport");
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("");
                reports(sql, "Informederegistros");
            }
            this.Text = Res.frmprincipal;
            this.menuStrip1.Items[0].Text = Res.subfile;
            this.menuStrip1.Items[1].Text = Res.subfilecategori;
            this.menuStrip1.Items[2].Text = Res.subbook;
            this.menuStrip1.Items[3].Text = Res.subborowers;
            this.menuStrip1.Items[4].Text = Res.subusers;
            this.menuStrip1.Items[5].Text = Res.subreports;
            this.menuStrip1.Items[6].Text = Res.subuserlogs;
            btnBorrow.Text = Res.btnrorrow;
            button3.Text = Res.btnreturn;
            button2.Text = Res.btnoverdue;
            button4.Text = Res.sublogout;
            languageToolStripMenuItem.Text = Res.sublenguaje;
            logoutToolStripMenuItem.Text = Res.sublogout;
            spanishToolStripMenuItem.Text = Res.subspanish;
            englishToolStripMenuItem.Text = Res.subenglis;
        }

        private void ts_books_Click(object sender, EventArgs e)
        {
        }

        private void ts_BorrowItem_Click(object sender, EventArgs e)
        {
          
        }

        private void ts_returnItem_Click(object sender, EventArgs e)
        {
           
        }

        private void ts_overdueItem_Click(object sender, EventArgs e)
        {
         
        }

        private void ts_borrower_Click(object sender, EventArgs e)
        {
         
        }

        private void ts_categories_Click(object sender, EventArgs e)
        {
           
        }

        private void ts_users_Click(object sender, EventArgs e)
        {
           
        }

        private void ts_reports_Click(object sender, EventArgs e)
        {
           
        }

        private void ts_logs_Click(object sender, EventArgs e)
        {
           
        }

        private void ts_login_Click(object sender, EventArgs e)
        {
            Form frm = new frmLogin(this);

            //if (ts_login.Text == "Login")
            //{
            //    frm.ShowDialog();
            //}
            //else
            //{
            //    ts_login.Text = "Login";
            //    disabled_menu();
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Today;
            
            lblTIme.Text = time.ToLongTimeString();
            lblDate.Text = time.ToShortDateString();
        }

        private void manageCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmCategories();
            frm.ShowDialog();
        }

        private void manageBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new frmBooks();
            frm.ShowDialog();
        }

        private void manageBorowersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmBorrower();
            frm.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReport();
            frm.ShowDialog();
        }

        private void userLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmLogs();
            frm.ShowDialog();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            Form frm = new frmBorrow();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new frmReturned();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new frmOverdue();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form frm = new frm_login();
            frm.Show();
            this.Close();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUser();
            frm.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void spanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Estás seguro de que quieres cambiar el idioma a Español.";
            string caption = "Confirmacion";

            if (Properties.Settings.Default.lenguaje == "en-US")
            {
                message = "You are sure you want to change the Language to Spanich";
                caption = "Confirmation";
            }
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Properties.Settings.Default.lenguaje = "es";
                Properties.Settings.Default.Save();
                
                frm_login frm = new frm_login();
                         
                frm.Show();
                frm.cargar();
                this.Close();
            }

        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Estás seguro de que quieres cambiar el idioma a inglés.";
            string caption = "Confirmacion";

            if (Properties.Settings.Default.lenguaje == "en-US")
            {
                message = "You are sure you want to change the Language to English";
                caption = "Confirmation";
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Properties.Settings.Default.lenguaje = "en-US";
                Properties.Settings.Default.Save();
                frm_login frm = new frm_login();
                frm.Show();
                frm.cargar();
                this.Close();
            }
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
