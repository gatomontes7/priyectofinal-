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
using LibrarySystem.Properties;
using System.IO;

namespace LibrarySystem
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        SQLConfig config = new SQLConfig();
        usableFunction funct = new usableFunction();
        string sql; 

        private void frmUser_Load(object sender, EventArgs e)
        {
            btn_New_Click(sender, e);
            GetText();
        }
        private void GetText()
        {
            if (Properties.Settings.Default.lenguaje == "en-US")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("");
            }
            this.Text = Res.frmuser;
            label5.Text = Res.frmuser;
            Label1.Text = Res.lbname;
            Label2.Text = Res.lbusername;
            Label3.Text = Res.lbpassword;
            Label4.Text = Res.lbtype;
            btn_saveuser.Text = Res.btnsave;
            btn_update.Text = Res.btnupdate;
            btn_New.Text = Res.btnnew;
            Button1.Text = Res.btnclose;
        }
        private void btn_New_Click(object sender, EventArgs e)
        {
            lbl_id.Text = "id";
            funct.clearTxt(this);
            cbo_type.Text = "Administrator";
            sql = "Select UserId as 'ID' ,Fullname as '"+Res.lbname + "',User_name as '"+Res.lbusername+ "',UserRole as '"+Res.lbtype+ "' From tbluser WHERE Status='Active' AND Fullname Like '%" + textBox1.Text + "%'";
            config.Load_DTG(sql, dtg_listUser);
            dtg_listUser.Columns[0].Visible = false;
            if(lbl_id.Text == "id")
            {
                btn_update.Enabled = false;
                btn_saveuser.Enabled = true;
            }
            else
            {
                btn_saveuser.Enabled = false;
                btn_update.Enabled = true;
            }
            txt_name.Text = "";
            txt_username.Text = "";
            txt_pass.Text = "";
        }

        private void btn_saveuser_Click(object sender, EventArgs e)
        {
            if( txt_name.Text == "" || txt_pass.Text == "" || txt_username.Text == "" ){
                funct.emptymessage();
            }

            sql = "insert into tbluser (`Fullname`, `User_name`, `Pass`, `UserRole`,`Status`,`rol`) "
             + "values('" + txt_name.Text + "','" + txt_username.Text 
             + "',sha1('" + txt_pass.Text + "'),'" + cbo_type.Text 
             + "','Active'," + cbo_type.SelectedIndex+ ")";
            config.Execute_CUD(sql, "error to execute query.", "New User has been saved in the database.");
            btn_New_Click(sender, e);
            tabControl1.SelectedTab = tabPage1;

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            sql = "update tbluser set Fullname = '" + txt_name.Text + "',User_name= '" + txt_username.Text
                + "',Pass= sha1('" + txt_pass.Text + "'),UserRole= '" + cbo_type.Text
                + "' where UserId = " + lbl_id.Text;

            config.Execute_CUD(sql, "error to execute query.", "Users has been updated in the database.");

            btn_New_Click(sender, e);
            tabControl1.SelectedTab = tabPage1;

        }

        private void dtg_listUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {    
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab=tabPage2;
            btn_New_Click(sender, e);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            lbl_id.Text = dtg_listUser.CurrentRow.Cells[0].Value.ToString();
            txt_name.Text = dtg_listUser.CurrentRow.Cells[1].Value.ToString();
            txt_username.Text = dtg_listUser.CurrentRow.Cells[2].Value.ToString();
            cbo_type.Text = dtg_listUser.CurrentRow.Cells[3].Value.ToString();
            btn_saveuser.Enabled = false;
            btn_update.Enabled = true;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string message = Res.msgeliminarreg;
            string caption = Res.msgconfirmacion;

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                    sql = "delete from tbluser where UserId = '" + dtg_listUser.CurrentRow.Cells[0].Value.ToString() + "'";
                    config.Execute_CUD(sql, Res.msgerror, Res.msgdelecorecto);
               

                btn_New_Click(sender, e);
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            btn_New_Click(sender, e);
        }
    }
}
