namespace SetnGetAttribute
{
    partial class ListofExistUDAs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListofExistUDAs));
            this.dGV_Main = new System.Windows.Forms.DataGridView();
            this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bGetUDAList = new System.Windows.Forms.Button();
            this.bCopyStr2MainForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // dGV_Main
            // 
            this.dGV_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Attribute,
            this.Value,
            this.Type});
            this.dGV_Main.Location = new System.Drawing.Point(16, 26);
            this.dGV_Main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dGV_Main.Name = "dGV_Main";
            this.dGV_Main.Size = new System.Drawing.Size(457, 357);
            this.dGV_Main.TabIndex = 0;
            // 
            // Attribute
            // 
            this.Attribute.HeaderText = "Attribute";
            this.Attribute.Name = "Attribute";
            this.Attribute.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // bGetUDAList
            // 
            this.bGetUDAList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bGetUDAList.Location = new System.Drawing.Point(391, 390);
            this.bGetUDAList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bGetUDAList.Name = "bGetUDAList";
            this.bGetUDAList.Size = new System.Drawing.Size(83, 32);
            this.bGetUDAList.TabIndex = 1;
            this.bGetUDAList.Text = "Get";
            this.bGetUDAList.UseVisualStyleBackColor = true;
            this.bGetUDAList.Click += new System.EventHandler(this.bGetUDAList_Click);
            // 
            // bCopyStr2MainForm
            // 
            this.bCopyStr2MainForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCopyStr2MainForm.Location = new System.Drawing.Point(21, 390);
            this.bCopyStr2MainForm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCopyStr2MainForm.Name = "bCopyStr2MainForm";
            this.bCopyStr2MainForm.Size = new System.Drawing.Size(148, 32);
            this.bCopyStr2MainForm.TabIndex = 2;
            this.bCopyStr2MainForm.Text = "Copy to Main Form";
            this.bCopyStr2MainForm.UseVisualStyleBackColor = true;
            this.bCopyStr2MainForm.Click += new System.EventHandler(this.bCopyStr2MainForm_Click);
            // 
            // ListofExistUDAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 434);
            this.Controls.Add(this.bCopyStr2MainForm);
            this.Controls.Add(this.bGetUDAList);
            this.Controls.Add(this.dGV_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ListofExistUDAs";
            this.Text = "GetListofExistUDAs";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ListofExistUDAs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV_Main;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.Button bGetUDAList;
        private System.Windows.Forms.Button bCopyStr2MainForm;
    }
}