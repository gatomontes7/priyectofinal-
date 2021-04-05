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
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
        }

        SQLConfig config = new SQLConfig();
        usableFunction funct = new usableFunction();
        string sql,categoryid;
        private void frmCategories_Load(object sender, EventArgs e)
        {
            btnnew_Click(sender, e);
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
            this.Text = Res.frmcategories;
            Label2.Text = Res.lbcategory;
            Label4.Text = Res.lbdeweydecimal;
            btnsave.Text = Res.btnsave;
            btnnew.Text = Res.btnnew;
            btnclose.Text = Res.btnclose;
            Label3.Text = Res.lbsearch;
            tabPage1.Text = Res.subtabcontrol1;
            tabPage2.Text = Res.submanage;
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            categoryid = "0";
            txtCategory.Clear();
            txtDeweyDecimal.Clear();
            sql = "Select CategoryId as '"+Res.colcategoryid+"',`Category` as '"+Res.lbcategory + "',`DDecimal` as '"+Res.lbdeweydecimal + "' From tblcategory WHERE Category !='ALL' AND `Category` Like '%" + txtSearch.Text + "%'";
            config.Load_DTG(sql, dtglist);
            txtCategory.Text = "";
            txtDeweyDecimal.Text = "";
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            if( txtCategory.Text == "")
            {
                funct.emptymessage();
            }

            sql = "Select * From tblcategory WHERE CategoryId = '" + categoryid + "'";
            config.singleResult(sql);
            if (config.dt.Rows.Count > 0)
            {
                sql = "UPDATE `tblcategory` SET `Category`='" + txtCategory.Text + "',`DDecimal`='" + txtDeweyDecimal.Text + "' WHERE CategoryId='" + categoryid + "'";
                config.Execute_CUD(sql, Res.msgerror, Res.msgupdated);
            }
            else
            {
                sql = "INSERT INTO `tblcategory` (`Category`,`DDecimal`) VALUES ('" + txtCategory.Text + "','" + txtDeweyDecimal.Text + "')";
                config.Execute_CUD(sql, Res.msgerror, Res.msgsave);
            } 
            btnnew_Click(sender, e);
            tabControl1.SelectedTab = tabPage1;

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            sql = "Delete From tblcategory WHERE CategoryId = " + dtglist.CurrentRow.Cells[0].Value;
            config.Execute_Query(sql);
            MessageBox.Show("Data has been deleted.");
            btnnew_Click(sender, e);
        }

        private void TxtCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            btnnew_Click(sender, e);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            btnnew_Click(sender, e);

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            categoryid = dtglist.CurrentRow.Cells[0].Value.ToString();
            txtCategory.Text = dtglist.CurrentRow.Cells[1].Value.ToString();
            txtDeweyDecimal.Text = dtglist.CurrentRow.Cells[2].Value.ToString();

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
                sql = "Delete From tblcategory WHERE CategoryId = " + dtglist.CurrentRow.Cells[0].Value;
                config.Execute_Query(sql);
                btnnew_Click(sender, e);
            }
        }

        private void Btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtglist_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
