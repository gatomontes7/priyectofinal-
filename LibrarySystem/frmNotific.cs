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
    public partial class frmNotific : Form
    {
        public frmNotific()
        {
            InitializeComponent();
        }

        private void FrmNotific_Load(object sender, EventArgs e)
        {
           // cargar();
            //timer1.Start();
        }
        SQLConfig config = new SQLConfig();
        usableFunction funct = new usableFunction();
        string sql;
        private void cargar()
        {
            sql = "SELECT  `BookTitle` as '" + Res.colbooktitle + "',`DateBorrowed` as '" + Res.coldateborrowed + "',  `DueDate` as '" + Res.colduedate + "' " +
                  " FROM `tblborrow` br,`tblbooks` b,`tblborrower` bw  " +
                  " WHERE br.AccessionNo=b.AccessionNo AND br.`BorrowerId`=bw.`BorrowerId` AND br.Status='Borrowed' AND   br.Due=1 ";
            config.Load_ResultList(sql, dataGridView1);

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Form frm = new frmOverdue();
            this.Hide();
            frm.ShowDialog();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //cargar();
        }
        internal void recargar()
        {
            cargar();
        }
        private void FrmNotific_Shown(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
