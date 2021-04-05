using LibrarySystem.Includes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace LibrarySystem
{
    public partial class frmPrincipal : Form
    {
        SQLConfig config = new SQLConfig();
        usableFunction funct = new usableFunction();
        string sql;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form frm = new frmCategories();
            frm.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form frm = new frmBooks();
            frm.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form frm = new frmBorrower();
            frm.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form frm = new frmUser();
            frm.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Form frm = new frmReport();
            frm.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Form frm = new frmLogs();
            frm.ShowDialog();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            frm_login frm = new frm_login();
            frm.Show();
            frm.cargar();
            this.Close();
        }

        private void BtnBorrow_Click(object sender, EventArgs e)
        {
            frmBorrow form = frmBorrow.GetInstancia();
            form.ShowDialog();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Form frm = new frmReturned();
            frm.ShowDialog();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Form frm = new frmOverdue();
            frm.ShowDialog();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Form frm = new frmUser();
            frm.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            timer1.Start();
            GetText();
           // revisar();
        }
        DateTime formatdate;
        private void revisar()
        {


        }
        private void GetText()
        {
            sql = "SELECT `Fullname`, `User_name`, `UserRole`,`LogDate`, `LogMode` FROM `tbllogs` l, `tbluser` u WHERE l.`UserId`=u.`UserId`";
            reports(sql, Res.repusuarios);
            this.Text = Res.frmprincipal;
            label1.Text = Res.frmprincipal;
            //this.menuStrip1.Items[0].Text = Res.subfile;
            this.button1.Text = Res.subfilecategori;
            this.button2.Text = Res.subbook;
            this.button3.Text = Res.subborowers;
            this.button4.Text = Res.subusers;
            this.button5.Text = Res.subreports;
            this.button6.Text = Res.subuserlogs;
            btnBorrow.Text = Res.btnrorrow;
            button9.Text = Res.btnreturn;
            button10.Text = Res.btnoverdue;
            button8.Text = Res.sublogout;
            label3.Text = Res.sublenguaje;
            label2.Text = Res.sublogout;
            españolToolStripMenuItem.Text = Res.subspanish;
            inglesToolStripMenuItem.Text = Res.subenglis;
        }
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

        private void Label3_Click(object sender, EventArgs e)
        {
           
            contextMenuStrip1.Show(Cursor.Position);
        }

        private void Label3_MouseHover(object sender, EventArgs e)
        {
            label3.Font = new System.Drawing.Font(label3.Font, FontStyle.Underline);
        
        }

        private void Label3_MouseLeave(object sender, EventArgs e)
        {
            label3.Font = new System.Drawing.Font(label3.Font, FontStyle.Regular);
        }

        private void Label2_MouseHover(object sender, EventArgs e)
        {
            label2.Font = new System.Drawing.Font(label2.Font, FontStyle.Underline);
        }

        private void Label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Font = new System.Drawing.Font(label2.Font, FontStyle.Regular);
        }

        private void Button1_MouseHover(object sender, EventArgs e)
        {
            button1.Font = new System.Drawing.Font(button1.Font, FontStyle.Underline);
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Font = new System.Drawing.Font(button1.Font, FontStyle.Regular);
        }

        private void InglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = Res.msgcamidiomaingles;
            string caption = Res.msgconfirmacion;

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

        private void EspañolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = Res.msgcamidiomaespanol;
            string caption = Res.msgconfirmacion;

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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            formatdate = DateTime.Now;
            sql = "UPDATE `tblborrow` br SET br.Due=1 WHERE br.Status='Borrowed' AND br.DueDate<='"+ formatdate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            config.Execute_Query(sql);

            sql = "SELECT br.`BorrowerId` " +
             " FROM `tblborrow` br,`tblbooks` b,`tblborrower` bw  " +
             " WHERE br.AccessionNo=b.AccessionNo AND br.`BorrowerId`=bw.`BorrowerId` AND br.Status='Borrowed' AND Due=1 ";
            config.singleResult(sql);

            if (config.dt.Rows.Count > 0)
            {
                label4.Visible = true;
                label4.Text = config.dt.Rows.Count.ToString();
                if (Properties.Settings.Default.notifi!= config.dt.Rows.Count)
                {
                    if (config.dt.Rows.Count> Properties.Settings.Default.notifi)
                    {
                        SoundPlayer sonido = new SoundPlayer(@"C:\Windows\Media\notify.wav");
                        sonido.Play();
                    }
                    Properties.Settings.Default.notifi = config.dt.Rows.Count;
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                label4.Visible = false;
            }
        }
        internal void GetUser(int rol)
        {
            if (rol == 0)
            {
                button4.Visible = true;
            }
            else
            {
                button4.Visible = false;
            }
        }
        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        frmNotific frmnot = new frmNotific();
        private void Panel3_Click(object sender, EventArgs e)
        {

            frmnot.Location = Cursor.Position;
            frmnot.Hide();
            frmnot.recargar();
            frmnot.Show(); 
        }

        private void FrmPrincipal_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void FrmPrincipal_Click(object sender, EventArgs e)
        {
            frmnot.Hide();
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
