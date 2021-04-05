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

namespace LibrarySystem
{
    public partial class frmListBooks : Form
    {
        public frmListBooks()
        {
            InitializeComponent();
        }
        SQLConfig config = new SQLConfig();
        usableFunction funct = new usableFunction();
        string sql;
        private void FrmListBooks_Load(object sender, EventArgs e)
        {
            sql = " SELECT br.`AccessionNo` as '" + Res.colaccessionno + "', `BookTitle` as '" + Res.colbooktitle + "', `BookDesc` as '" + Res.coldescription + "',Concat(`Firstname`,' ', `Lastname`) as '" + Res.colborrower + "' ,`NoCopies` as '" + Res.colnocopies + "', `DateBorrowed` as '" + Res.coldateborrowed + "', `Purpose` as '" + Res.colpurpose + "' , `DueDate` as '" + Res.colduedate + "' FROM `tblborrow` br,`tblbooks` b,`tblborrower` bw  WHERE br.AccessionNo=b.AccessionNo AND br.`BorrowerId`=bw.`BorrowerId` AND  `BookTitle` Like '%" + txt_Search.Text + "%' ORDER BY BorrowId Desc";
            config.Load_ResultList(sql, dtg_BlistOfBooks);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void Txt_Search_TextChanged(object sender, EventArgs e)
        {
            sql = " SELECT br.`AccessionNo` as '" + Res.colaccessionno + "', `BookTitle` as '" + Res.colbooktitle + "', `BookDesc` as '" + Res.coldescription + "',Concat(`Firstname`,' ', `Lastname`) as '" + Res.colborrower + "' ,`NoCopies` as '" + Res.colnocopies + "', `DateBorrowed` as '" + Res.coldateborrowed + "', `Purpose` as '" + Res.colpurpose + "' , `DueDate` as '" + Res.colduedate + "' FROM `tblborrow` br,`tblbooks` b,`tblborrower` bw  WHERE br.AccessionNo=b.AccessionNo AND br.`BorrowerId`=bw.`BorrowerId` AND  `BookTitle` Like '%" + txt_Search.Text + "%' ORDER BY BorrowId Desc";
            config.Load_ResultList(sql, dtg_BlistOfBooks);
        }


        private void Btn_Bsave_Click(object sender, EventArgs e)
        {
            frmBorrow form = frmBorrow.GetInstancia();



            sql = "Select * From tblbooks b, tblcategory c WHERE b.CategoryId=c.CategoryId AND AccessionNo='" + dtg_BlistOfBooks.CurrentRow.Cells[0].Value.ToString() + "'";
            config.singleResult(sql);

            string id = dtg_BlistOfBooks.CurrentRow.Cells[0].Value.ToString();
            string txtTitl = config.dt.Rows[0].Field<string>("BookTitle");
            string txtAutho = config.dt.Rows[0].Field<string>("Author");
            string txtDateli = config.dt.Rows[0].Field<DateTime>("PublishDate").ToString();
            string txtpublisr = config.dt.Rows[0].Field<string>("BookPublisher");
            string txtbookte = config.dt.Rows[0].Field<string>("BookType");

            form.setDatos(id, txtTitl, txtAutho, txtDateli, txtpublisr, txtbookte);
            this.Close();
        }

        private void Dtg_BlistOfBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Btn_Bsave_Click( sender,  e);
        }
    }
}
