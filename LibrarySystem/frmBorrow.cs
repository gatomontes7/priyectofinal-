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


namespace LibrarySystem
{
    public partial class frmBorrow : Form
    {
        public frmBorrow()
        {
            InitializeComponent();
        }


        private static frmBorrow _Instancia;

        public static frmBorrow GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmBorrow();
            }
            return _Instancia;
        }

        internal void setDatos(string id,string title, string auto, string date,string plublise, string book)
        {
            txtAccesionNumBorrow.Text = id;
            txtTitle.Text = title;
            txtAuthor.Text = auto;
            txtDatePublish.Text = date;
            txtpublisher.Text = plublise;
            txtbooktype.Text = book;
        }
        internal void setDatos1(string id, string title, string auto)
        {
            txtBorrowerId.Text = id;
            txtName.Text = title;
            txtCourse.Text = auto;
        }

        SQLConfig config = new SQLConfig();
        usableFunction funct = new usableFunction();
        string sql;

        private void txtAccesionNumBorrow_TextChanged(object sender, EventArgs e)
        {
            if(txtAccesionNumBorrow.Text == "")
            {
                txtTitle.Clear();
                txtAuthor.Clear();
                txtDatePublish.Clear();
                txtpublisher.Clear();
                txtbooktype.Clear();
            }
            else
            {
                sql = "Select * From tblbooks b, tblcategory c WHERE b.CategoryId=c.CategoryId AND AccessionNo='" + txtAccesionNumBorrow.Text + "'";
                config.singleResult(sql);
                if(config.dt.Rows.Count > 0)
                {
                    txtTitle.Text = config.dt.Rows[0].Field<string>("BookTitle");
                    txtAuthor.Text = config.dt.Rows[0].Field<string>("Author");
                    txtDatePublish.Text = config.dt.Rows[0].Field<DateTime>("PublishDate").ToString();
                    txtpublisher.Text = config.dt.Rows[0].Field<string>("BookPublisher");
                    txtbooktype.Text = config.dt.Rows[0].Field<string>("BookType");
                }
              
            }
        }

        private void frmBorrow_Load(object sender, EventArgs e)
        {
            btnNew_Click(sender, e);
            GetText();
        }

        private void GetText()
        {
            label4.Text = Res.frmborrowers;
            this.Text = Res.frmborrowers;
            lblAccessionNumBorrow.Text = Res.lbaccession;
            Label1.Text = Res.lbtitle;
            Label12.Text = Res.lbdate;
            Label3.Text = Res.lbpublisher;
            Label5.Text = Res.lbauthor;
            Label6.Text = Res.lbtypebooks;
            Label17.Text = Res.lbname;
            Label13.Text = Res.lbyessection;
            Label7.Text = Res.lbborrowerid;
            Label15.Text = Res.lbpurpose;
            btn_Bsave.Text = Res.btnrorrow;
            btnNew.Text = Res.btnclear;
            btnClose.Text = Res.btnclose;
            GroupBox1.Text = Res.groupbooksdetails;
            grp_Bgroup.Text = Res.frmborrowers;
            TabPage3.Text = Res.subdetail;
            TabPage4.Text = Res.subborrowedbooks;
            Label2.Text = Res.lbsearch;
            GroupBox6.Text = Res.grouplistofborrowedbooks;
            cboPurpose.Items.Clear();

            cboPurpose.Items.Add(Res.itemovernight);
  
            cboPurpose.Items.Add(Res.itemresearch);
            cboPurpose.Items.Add(Res.itemphotocopy);
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            funct.clearTxt(GroupBox1);
            funct.clearTxt(grp_Bgroup);
            sql = " SELECT br.`AccessionNo` as '" + Res.colaccessionno + "', `BookTitle` as '" + Res.colbooktitle + "', `BookDesc` as '" +Res.coldescription+"',Concat(`Firstname`,' ', `Lastname`) as '"+Res.colborrower+"' ,`NoCopies` as '"+Res.colnocopies+"', `DateBorrowed` as '"+Res.coldateborrowed+"', `Purpose` as '"+Res.colpurpose+"' , `DueDate` as '"+Res.colduedate+"' FROM `tblborrow` br,`tblbooks` b,`tblborrower` bw  WHERE br.AccessionNo=b.AccessionNo AND br.`BorrowerId`=bw.`BorrowerId` ORDER BY BorrowId Desc";
            config.Load_ResultList(sql, dtg_BlistOfBooks);

            sql = "SELECT AccessionNo From tblbooks Where Status = 'Available'";
            config.autocomplete(sql, txtAccesionNumBorrow);

            sql = "SELECT BorrowerId From tblborrower";
            config.autocomplete(sql, txtBorrowerId);
 
        }

        private void txtBorrowerId_TextChanged(object sender, EventArgs e)
        {
            if( txtBorrowerId.Text == "")
            {
                txtName.Clear();
                txtCourse.Clear();
            }
            else
            {
                sql = "SELECT * FROM `tblborrower` WHERE `BorrowerId` = '" + txtBorrowerId.Text + "'";
                config.singleResult(sql);
                if(config.dt.Rows.Count > 0)
                {
                    txtName.Text = config.dt.Rows[0].Field<string>("Firstname") + " " + config.dt.Rows[0].Field<string>("Lastname");
                    txtCourse.Text = config.dt.Rows[0].Field<string>("CourseYear");
                }
                else
                {
                    txtName.Clear();
                    txtCourse.Clear();
                }
            }
        }

        private void btn_Bsave_Click(object sender, EventArgs e)
        {
            if (txtAccesionNumBorrow.Text == "" || txtBorrowerId.Text == "")
            {
                MessageBox.Show("All fields are required.","Invalid",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(cboPurpose.Text == "Select")
            {
                MessageBox.Show("Pls. choose your porpuse.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DateTime formatdate;
            
       
            if(cboPurpose.SelectedItem.ToString()== Res.itemphotocopy)
            {
                formatdate = DateTime.Now.AddMinutes(30);
                txtdue.Text = formatdate.ToString("yyyy-MM-dd HH:mm:ss");             
            }
            else if (cboPurpose.SelectedItem.ToString() == Res.itemresearch)
            {

                if (DateTime.Now.ToString("tt") == "AM")
                {
                    txtdue.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 11:30:00";
                }
                else
                {
                    txtdue.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 17:30:00";
                }

            }
            else if (cboPurpose.SelectedItem.ToString() == Res.itemovernight)
            {
                formatdate = DateTime.Now.AddHours(24);
                txtdue.Text = formatdate.ToString("yyyy-MM-dd HH:mm:ss");
            }



            sql = "INSERT INTO  `tblborrow`  " +
                " (`AccessionNo`, `NoCopies`, `DateBorrowed`, `Purpose`, `Status`, `DueDate`, `BorrowerId`) " +
                " VALUES ('" + txtAccesionNumBorrow.Text + "',1,NOW(),'" + cboPurpose.Text + "', 'Borrowed','" + txtdue.Text + "','" + txtBorrowerId.Text + "')";
            config.Execute_CUD(sql, "error to execute query.", "Book has been borrowed in the library");
            config.Execute_Query("UPDATE tblbooks set Status = 'Not Available' Where AccessionNo='" + txtAccesionNumBorrow.Text + "'");

            btnNew_Click(sender, e);
        }

        private void check_due_Tick(object sender, EventArgs e)
        {
        //    sql = "SELECT MINUTE(TIMEDIFF(Now(),DateBorrowed)),BorrowId FROM tblborrow Where  Status='Borrowed' AND purpose = 'Photocopy' "
        //checkOverduePurposed(sql, "Photocopy")
        //sql = "SELECT BorrowId FROM tblborrow Where  Status='Borrowed' AND Purpose = 'Research'"
        //checkOverduePurposed(sql, "Research")
        //sql = "SELECT HOUR( TIMEDIFF( NOW( ) ,  `DateBorrowed` ) ) AS  'time',`BorrowId` FROM   `tblborrow` Where Status='Borrowed' AND Purpose = 'Overnight'"
        //checkOverduePurposed(sql, "Overnight")
        //sql = "SELECT HOUR( TIMEDIFF( NOW( ) ,  `DateBorrowed` ) ) AS  'time',`BorrowId` FROM   `tblborrow` Where Status='Borrowed' AND Purpose = 'Overnight'"
        //checkOverduePurposed(sql, "Borrowed for 3days")
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            sql = " SELECT br.`AccessionNo`, `BookTitle`, `BookDesc` as 'Description',Concat(`Firstname`,' ', `Lastname`) as 'Borrower', `DateBorrowed`, `Purpose`, `DueDate` " +
                    " FROM `tblborrow` br,`tblbooks` b,`tblborrower` bw  " +
                    " WHERE br.AccessionNo=b.AccessionNo AND br.`BorrowerId`=bw.`BorrowerId` AND (BookTitle Like '%" + txt_Search.Text + "' or br.AccessionNo Like '%" + txt_Search.Text + "%' OR Concat(`Firstname`,' ', `Lastname`)  Like '%" + txt_Search.Text + "') ORDER BY BorrowId Desc";
            config.Load_ResultList(sql, dtg_BlistOfBooks);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmListBooks frm = new frmListBooks();
            frm.ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBorrow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instancia = null;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmListClient frm = new frmListClient();
            frm.ShowDialog();
        }
    }
}
