﻿using System;
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
            btndelete.Text = Res.btndelete;
            btnnew.Text = Res.btnnew;
            btnclose.Text = Res.btnclose;
            Label3.Text = Res.lbsearch;

        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            categoryid = "0";
            txtCategory.Clear();
            txtDeweyDecimal.Clear();
            sql = "Select CategoryId as '"+Res.colcategoryid+"',`Category` as '"+Res.lbcategory + "',`DDecimal` as '"+Res.lbdeweydecimal + "' From tblcategory WHERE Category !='ALL'";
            config.Load_DTG(sql, dtglist);
            btndelete.Enabled = false;
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
                config.Execute_CUD(sql, "error to execute the query.", "Category has been updated in the database.");
            }
            else
            {
                sql = "INSERT INTO `tblcategory` (`Category`,`DDecimal`) VALUES ('" + txtCategory.Text + "','" + txtDeweyDecimal.Text + "')";
                config.Execute_CUD(sql, "error to execute the query.", "New category has been saved in the database.");
            } 
            btnnew_Click(sender, e);

          
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            sql = "Delete From tblcategory WHERE CategoryId = " + dtglist.CurrentRow.Cells[0].Value;
            config.Execute_Query(sql);
            MessageBox.Show("Data has been deleted.");
            btnnew_Click(sender, e);
        }

        private void dtglist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            categoryid = dtglist.CurrentRow.Cells[0].Value.ToString();
            txtCategory.Text = dtglist.CurrentRow.Cells[1].Value.ToString();
            txtDeweyDecimal.Text = dtglist.CurrentRow.Cells[2].Value.ToString();
            btndelete.Enabled = true;
        }
    }
}
