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
    public partial class frmListClient : Form
    {
        SQLConfig config = new SQLConfig();
        usableFunction funct = new usableFunction();
        string sql;
        int inc, maxrow;
        public frmListClient()
        {
            InitializeComponent();
        }

        private void FrmListClient_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void Btn_Bsave_Click(object sender, EventArgs e)
        {
            frmBorrow form = frmBorrow.GetInstancia();

            sql = "SELECT * FROM `tblborrower` WHERE `BorrowerId` = '" + dtg_BlistOfBooks.CurrentRow.Cells[0].Value.ToString() + "'";
            config.singleResult(sql);
            string id = dtg_BlistOfBooks.CurrentRow.Cells[0].Value.ToString();
            string nom = config.dt.Rows[0].Field<string>("Firstname") + " " + config.dt.Rows[0].Field<string>("Lastname");
            string nom2= config.dt.Rows[0].Field<string>("CourseYear");
            
            form.setDatos1(id, nom, nom2);
            this.Close();
        }

        public void cargar()
        {
            sql = "SELECT BorrowerId as '" + Res.lbborrowerid + "',`Firstname` as '" + Res.lbfirstname + "', `Lastname` as '" + Res.lblastname + "', `MiddleName` as '" + Res.lbmiddlename + "', `Address` as '" + Res.lbadress + "', `Sex` as '" + Res.lbsexo + "', `ContactNo` as '" + Res.lbcontactno + "', `CourseYear`  as '" + Res.lbcourse + "' FROM `tblborrower`  WHERE Stats='Active'";
            config.Load_ResultList(sql, dtg_BlistOfBooks);
        }
    }
}
