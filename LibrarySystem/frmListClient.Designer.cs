namespace LibrarySystem
{
    partial class frmListClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button7 = new System.Windows.Forms.Button();
            this.btn_Bsave = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtg_BlistOfBooks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_BlistOfBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(576, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(32, 29);
            this.button7.TabIndex = 57;
            this.button7.Text = "X";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // btn_Bsave
            // 
            this.btn_Bsave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Bsave.Location = new System.Drawing.Point(455, 32);
            this.btn_Bsave.Name = "btn_Bsave";
            this.btn_Bsave.Size = new System.Drawing.Size(101, 39);
            this.btn_Bsave.TabIndex = 56;
            this.btn_Bsave.Text = "Enviar";
            this.btn_Bsave.UseVisualStyleBackColor = true;
            this.btn_Bsave.Click += new System.EventHandler(this.Btn_Bsave_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(234, 39);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(73, 25);
            this.Label2.TabIndex = 55;
            this.Label2.Text = "Search :";
            // 
            // txt_Search
            // 
            this.txt_Search.BackColor = System.Drawing.Color.White;
            this.txt_Search.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(313, 36);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(122, 31);
            this.txt_Search.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 57);
            this.label4.TabIndex = 53;
            this.label4.Text = "Client List";
            // 
            // dtg_BlistOfBooks
            // 
            this.dtg_BlistOfBooks.AllowUserToAddRows = false;
            this.dtg_BlistOfBooks.AllowUserToDeleteRows = false;
            this.dtg_BlistOfBooks.AllowUserToResizeColumns = false;
            this.dtg_BlistOfBooks.AllowUserToResizeRows = false;
            this.dtg_BlistOfBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtg_BlistOfBooks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtg_BlistOfBooks.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtg_BlistOfBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg_BlistOfBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_BlistOfBooks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtg_BlistOfBooks.Location = new System.Drawing.Point(12, 85);
            this.dtg_BlistOfBooks.Name = "dtg_BlistOfBooks";
            this.dtg_BlistOfBooks.RowHeadersVisible = false;
            this.dtg_BlistOfBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_BlistOfBooks.Size = new System.Drawing.Size(581, 215);
            this.dtg_BlistOfBooks.TabIndex = 52;
            // 
            // frmListClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibrarySystem.Properties.Resources.blue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(620, 315);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btn_Bsave);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtg_BlistOfBooks);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListClient";
            this.Load += new System.EventHandler(this.FrmListClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_BlistOfBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button7;
        internal System.Windows.Forms.Button btn_Bsave;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DataGridView dtg_BlistOfBooks;
    }
}