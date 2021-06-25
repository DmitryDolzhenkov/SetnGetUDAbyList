namespace SetnGetAttribute
{
    partial class ListofDefineAttribute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListofDefineAttribute));
            this.dGV_Main = new System.Windows.Forms.DataGridView();
            this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bCopyStr2MainForm = new System.Windows.Forms.Button();
            this.bOpenFullList = new System.Windows.Forms.Button();
            this.bOpenorCreateAttrList = new System.Windows.Forms.Button();
            this.bRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbKoef = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nUpDownDecimals = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownDecimals)).BeginInit();
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
            this.Type});
            this.dGV_Main.Location = new System.Drawing.Point(16, 15);
            this.dGV_Main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dGV_Main.Name = "dGV_Main";
            this.dGV_Main.Size = new System.Drawing.Size(467, 304);
            this.dGV_Main.TabIndex = 1;
            // 
            // Attribute
            // 
            this.Attribute.HeaderText = "Attribute";
            this.Attribute.Name = "Attribute";
            this.Attribute.ReadOnly = true;
            this.Attribute.Width = 200;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // bCopyStr2MainForm
            // 
            this.bCopyStr2MainForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCopyStr2MainForm.Location = new System.Drawing.Point(16, 377);
            this.bCopyStr2MainForm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCopyStr2MainForm.Name = "bCopyStr2MainForm";
            this.bCopyStr2MainForm.Size = new System.Drawing.Size(113, 46);
            this.bCopyStr2MainForm.TabIndex = 3;
            this.bCopyStr2MainForm.Text = "Copy to Main Form";
            this.bCopyStr2MainForm.UseVisualStyleBackColor = true;
            this.bCopyStr2MainForm.Click += new System.EventHandler(this.bCopyStr2MainForm_Click);
            // 
            // bOpenFullList
            // 
            this.bOpenFullList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpenFullList.Location = new System.Drawing.Point(387, 377);
            this.bOpenFullList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bOpenFullList.Name = "bOpenFullList";
            this.bOpenFullList.Size = new System.Drawing.Size(96, 46);
            this.bOpenFullList.TabIndex = 4;
            this.bOpenFullList.Text = "Open global list";
            this.bOpenFullList.UseVisualStyleBackColor = true;
            this.bOpenFullList.Click += new System.EventHandler(this.bOpenFullList_Click);
            // 
            // bOpenorCreateAttrList
            // 
            this.bOpenorCreateAttrList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpenorCreateAttrList.Location = new System.Drawing.Point(289, 377);
            this.bOpenorCreateAttrList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bOpenorCreateAttrList.Name = "bOpenorCreateAttrList";
            this.bOpenorCreateAttrList.Size = new System.Drawing.Size(85, 46);
            this.bOpenorCreateAttrList.TabIndex = 5;
            this.bOpenorCreateAttrList.Text = "Preloaded List";
            this.bOpenorCreateAttrList.UseVisualStyleBackColor = true;
            this.bOpenorCreateAttrList.Click += new System.EventHandler(this.bOpenorCreateAttrList_Click);
            // 
            // bRefresh
            // 
            this.bRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bRefresh.Image = global::SetnGetAttribute.Properties.Resources._refresh_button_icon;
            this.bRefresh.Location = new System.Drawing.Point(224, 377);
            this.bRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(57, 46);
            this.bRefresh.TabIndex = 6;
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 350);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Coefficient";
            // 
            // tbKoef
            // 
            this.tbKoef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbKoef.Location = new System.Drawing.Point(105, 345);
            this.tbKoef.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbKoef.Name = "tbKoef";
            this.tbKoef.Size = new System.Drawing.Size(124, 22);
            this.tbKoef.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 347);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Decimals";
            // 
            // nUpDownDecimals
            // 
            this.nUpDownDecimals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nUpDownDecimals.Location = new System.Drawing.Point(395, 345);
            this.nUpDownDecimals.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nUpDownDecimals.Name = "nUpDownDecimals";
            this.nUpDownDecimals.Size = new System.Drawing.Size(88, 22);
            this.nUpDownDecimals.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 324);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Settings for getting double reports attribute";
            // 
            // ListofDefineAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 436);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nUpDownDecimals);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbKoef);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.bOpenorCreateAttrList);
            this.Controls.Add(this.bOpenFullList);
            this.Controls.Add(this.bCopyStr2MainForm);
            this.Controls.Add(this.dGV_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ListofDefineAttribute";
            this.Text = "ListofDefineAttribute";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListofDefineAttribute_FormClosed);
            this.Load += new System.EventHandler(this.ListofDefineAttribute_Load);
            this.Shown += new System.EventHandler(this.ListofDefineAttribute_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownDecimals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV_Main;
        private System.Windows.Forms.Button bCopyStr2MainForm;
        private System.Windows.Forms.Button bOpenFullList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.Button bOpenorCreateAttrList;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKoef;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUpDownDecimals;
        private System.Windows.Forms.Label label3;
    }
}