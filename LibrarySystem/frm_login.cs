using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using LibrarySystem.Includes;
using LibrarySystem;

namespace LibrarySystem
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        SQLConfig config = new SQLConfig();
        string sql;

        private void OK_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM `tbluser` WHERE User_name= '" + UsernameTextBox.Text + "' and Pass = sha1('" + PasswordTextBox.Text + "')";
            config.singleResult(sql);

            if (config.dt.Rows.Count > 0)
            {
                Form frm = new frmPrincipal();
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Account does not exist. Please contact administrator.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            //PasswordLabel.Text = Properties.Settings.Default.lenguaje;
            //Properties.Settings.Default.lenguaje = PasswordLabel.Text;
            //Properties.Settings.Default.Save();
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            GetText();
        }

        internal void cargar()
        {
            GetText();
        }
        private void GetText()
        {
            if(Properties.Settings.Default.lenguaje == "en-US")
            {
               System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("");
            }
            this.Text = Res.frm_login;
            PasswordLabel.Text = Res.lbcontrasena;
            UsernameLabel.Text = Res.lbusuario;
            OK.Text = Res.btnok;
            Cancel.Text = Res.btncancelar;
        }
    }
}
