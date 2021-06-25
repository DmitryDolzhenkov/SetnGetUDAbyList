namespace SetnGetAttribute
{
    partial class SetAttributeFromList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetAttributeFromList));
            this.tbRepAttr = new System.Windows.Forms.TextBox();
            this.tbUserAttr = new System.Windows.Forms.TextBox();
            this.bCrtexcelList = new System.Windows.Forms.Button();
            this.bSetFromExcelList = new System.Windows.Forms.Button();
            this.tbLocationExcel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bBrowse = new System.Windows.Forms.Button();
            this.cBTypeOfList = new System.Windows.Forms.CheckBox();
            this.bOpenExcel = new System.Windows.Forms.Button();
            this.cBUDADatatype = new System.Windows.Forms.ComboBox();
            this.cBReportAttrDatatype = new System.Windows.Forms.ComboBox();
            this.bGetExistUDA = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.bRepAtt = new System.Windows.Forms.Button();
            this.cBTypeOfsecondcolumn = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBModelObj = new System.Windows.Forms.CheckBox();
            this.cBDrawingObj = new System.Windows.Forms.CheckBox();
            this.bOpenlog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbRepAttr
            // 
            this.tbRepAttr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRepAttr.Location = new System.Drawing.Point(147, 85);
            this.tbRepAttr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbRepAttr.Name = "tbRepAttr";
            this.tbRepAttr.Size = new System.Drawing.Size(277, 22);
            this.tbRepAttr.TabIndex = 3;
            // 
            // tbUserAttr
            // 
            this.tbUserAttr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserAttr.Location = new System.Drawing.Point(147, 117);
            this.tbUserAttr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbUserAttr.Name = "tbUserAttr";
            this.tbUserAttr.Size = new System.Drawing.Size(277, 22);
            this.tbUserAttr.TabIndex = 4;
            // 
            // bCrtexcelList
            // 
            this.bCrtexcelList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCrtexcelList.Location = new System.Drawing.Point(15, 182);
            this.bCrtexcelList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bCrtexcelList.Name = "bCrtexcelList";
            this.bCrtexcelList.Size = new System.Drawing.Size(124, 28);
            this.bCrtexcelList.TabIndex = 5;
            this.bCrtexcelList.Text = "Create excel list";
            this.bCrtexcelList.UseVisualStyleBackColor = true;
            this.bCrtexcelList.Click += new System.EventHandler(this.bCrtexcelList_Click);
            // 
            // bSetFromExcelList
            // 
            this.bSetFromExcelList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSetFromExcelList.Location = new System.Drawing.Point(439, 182);
            this.bSetFromExcelList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bSetFromExcelList.Name = "bSetFromExcelList";
            this.bSetFromExcelList.Size = new System.Drawing.Size(165, 28);
            this.bSetFromExcelList.TabIndex = 7;
            this.bSetFromExcelList.Text = "Set UDA From Excel";
            this.bSetFromExcelList.UseVisualStyleBackColor = true;
            this.bSetFromExcelList.Click += new System.EventHandler(this.bSetFromExcelList_Click);
            // 
            // tbLocationExcel
            // 
            this.tbLocationExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLocationExcel.Location = new System.Drawing.Point(15, 15);
            this.tbLocationExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLocationExcel.Name = "tbLocationExcel";
            this.tbLocationExcel.Size = new System.Drawing.Size(553, 22);
            this.tbLocationExcel.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Report Attribute";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "User Attribute";
            // 
            // bBrowse
            // 
            this.bBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bBrowse.Location = new System.Drawing.Point(577, 15);
            this.bBrowse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(29, 25);
            this.bBrowse.TabIndex = 11;
            this.bBrowse.Text = "...";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // cBTypeOfList
            // 
            this.cBTypeOfList.AutoSize = true;
            this.cBTypeOfList.Location = new System.Drawing.Point(16, 50);
            this.cBTypeOfList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBTypeOfList.Name = "cBTypeOfList";
            this.cBTypeOfList.Size = new System.Drawing.Size(204, 21);
            this.cBTypeOfList.TabIndex = 12;
            this.cBTypeOfList.Text = "List only with values of UDA";
            this.cBTypeOfList.UseVisualStyleBackColor = true;
            // 
            // bOpenExcel
            // 
            this.bOpenExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpenExcel.Location = new System.Drawing.Point(515, 47);
            this.bOpenExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bOpenExcel.Name = "bOpenExcel";
            this.bOpenExcel.Size = new System.Drawing.Size(91, 31);
            this.bOpenExcel.TabIndex = 13;
            this.bOpenExcel.Text = "Open";
            this.bOpenExcel.UseVisualStyleBackColor = true;
            this.bOpenExcel.Click += new System.EventHandler(this.bOpenExcel_Click);
            // 
            // cBUDADatatype
            // 
            this.cBUDADatatype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBUDADatatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBUDADatatype.FormattingEnabled = true;
            this.cBUDADatatype.Items.AddRange(new object[] {
            "string",
            "int",
            "double"});
            this.cBUDADatatype.Location = new System.Drawing.Point(433, 117);
            this.cBUDADatatype.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBUDADatatype.Name = "cBUDADatatype";
            this.cBUDADatatype.Size = new System.Drawing.Size(73, 24);
            this.cBUDADatatype.TabIndex = 14;
            // 
            // cBReportAttrDatatype
            // 
            this.cBReportAttrDatatype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBReportAttrDatatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBReportAttrDatatype.FormattingEnabled = true;
            this.cBReportAttrDatatype.Items.AddRange(new object[] {
            "string",
            "int",
            "double"});
            this.cBReportAttrDatatype.Location = new System.Drawing.Point(433, 85);
            this.cBReportAttrDatatype.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBReportAttrDatatype.Name = "cBReportAttrDatatype";
            this.cBReportAttrDatatype.Size = new System.Drawing.Size(73, 24);
            this.cBReportAttrDatatype.TabIndex = 15;
            // 
            // bGetExistUDA
            // 
            this.bGetExistUDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bGetExistUDA.Location = new System.Drawing.Point(515, 117);
            this.bGetExistUDA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bGetExistUDA.Name = "bGetExistUDA";
            this.bGetExistUDA.Size = new System.Drawing.Size(89, 26);
            this.bGetExistUDA.TabIndex = 16;
            this.bGetExistUDA.Text = "UDA";
            this.bGetExistUDA.UseVisualStyleBackColor = true;
            this.bGetExistUDA.Click += new System.EventHandler(this.bGetExistUDA_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessage.Enabled = false;
            this.tbMessage.Location = new System.Drawing.Point(148, 185);
            this.tbMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(282, 22);
            this.tbMessage.TabIndex = 17;
            // 
            // bRepAtt
            // 
            this.bRepAtt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRepAtt.Location = new System.Drawing.Point(518, 85);
            this.bRepAtt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bRepAtt.Name = "bRepAtt";
            this.bRepAtt.Size = new System.Drawing.Size(85, 26);
            this.bRepAtt.TabIndex = 18;
            this.bRepAtt.Text = "RepAttr";
            this.bRepAtt.UseVisualStyleBackColor = true;
            this.bRepAtt.Click += new System.EventHandler(this.bRepAtt_Click);
            // 
            // cBTypeOfsecondcolumn
            // 
            this.cBTypeOfsecondcolumn.AutoSize = true;
            this.cBTypeOfsecondcolumn.Location = new System.Drawing.Point(235, 50);
            this.cBTypeOfsecondcolumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBTypeOfsecondcolumn.Name = "cBTypeOfsecondcolumn";
            this.cBTypeOfsecondcolumn.Size = new System.Drawing.Size(278, 21);
            this.cBTypeOfsecondcolumn.TabIndex = 19;
            this.cBTypeOfsecondcolumn.Text = "Report Attributes for both (only for Get)";
            this.cBTypeOfsecondcolumn.UseVisualStyleBackColor = true;
            this.cBTypeOfsecondcolumn.CheckedChanged += new System.EventHandler(this.cBTypeOfsecondcolumn_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 152);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Object type";
            // 
            // cBModelObj
            // 
            this.cBModelObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cBModelObj.Appearance = System.Windows.Forms.Appearance.Button;
            this.cBModelObj.AutoSize = true;
            this.cBModelObj.Location = new System.Drawing.Point(147, 148);
            this.cBModelObj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBModelObj.Name = "cBModelObj";
            this.cBModelObj.Size = new System.Drawing.Size(56, 27);
            this.cBModelObj.TabIndex = 21;
            this.cBModelObj.Text = "Model";
            this.cBModelObj.UseVisualStyleBackColor = true;
            this.cBModelObj.CheckedChanged += new System.EventHandler(this.cBModelObj_CheckedChanged);
            this.cBModelObj.Click += new System.EventHandler(this.cBModelObj_Click);
            // 
            // cBDrawingObj
            // 
            this.cBDrawingObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cBDrawingObj.Appearance = System.Windows.Forms.Appearance.Button;
            this.cBDrawingObj.AutoSize = true;
            this.cBDrawingObj.Location = new System.Drawing.Point(216, 148);
            this.cBDrawingObj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBDrawingObj.Name = "cBDrawingObj";
            this.cBDrawingObj.Size = new System.Drawing.Size(69, 27);
            this.cBDrawingObj.TabIndex = 22;
            this.cBDrawingObj.Text = "Drawing";
            this.cBDrawingObj.UseVisualStyleBackColor = true;
            this.cBDrawingObj.CheckedChanged += new System.EventHandler(this.cBDrawingObj_CheckedChanged);
            this.cBDrawingObj.Click += new System.EventHandler(this.cBDrawingObj_Click);
            // 
            // bOpenlog
            // 
            this.bOpenlog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpenlog.Location = new System.Drawing.Point(514, 150);
            this.bOpenlog.Name = "bOpenlog";
            this.bOpenlog.Size = new System.Drawing.Size(90, 27);
            this.bOpenlog.TabIndex = 23;
            this.bOpenlog.Text = "Open log";
            this.bOpenlog.UseVisualStyleBackColor = true;
            this.bOpenlog.Click += new System.EventHandler(this.bOpenlog_Click);
            // 
            // SetAttributeFromList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 223);
            this.Controls.Add(this.bOpenlog);
            this.Controls.Add(this.cBDrawingObj);
            this.Controls.Add(this.cBModelObj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cBTypeOfsecondcolumn);
            this.Controls.Add(this.bRepAtt);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.bGetExistUDA);
            this.Controls.Add(this.cBReportAttrDatatype);
            this.Controls.Add(this.cBUDADatatype);
            this.Controls.Add(this.bOpenExcel);
            this.Controls.Add(this.cBTypeOfList);
            this.Controls.Add(this.bBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLocationExcel);
            this.Controls.Add(this.bSetFromExcelList);
            this.Controls.Add(this.bCrtexcelList);
            this.Controls.Add(this.tbUserAttr);
            this.Controls.Add(this.tbRepAttr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SetAttributeFromList";
            this.Text = "Set&Get Attributes by list";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetAttributeFromList_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetAttributeFromList_FormClosed);
            this.Load += new System.EventHandler(this.SetAttributeFromList_Load);
            this.ResizeEnd += new System.EventHandler(this.SetAttributeFromList_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bCrtexcelList;
        private System.Windows.Forms.Button bSetFromExcelList;
        private System.Windows.Forms.TextBox tbLocationExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.CheckBox cBTypeOfList;
        private System.Windows.Forms.Button bOpenExcel;
        private System.Windows.Forms.Button bGetExistUDA;
        public  System.Windows.Forms.TextBox tbUserAttr;
        public System.Windows.Forms.ComboBox cBUDADatatype;
        internal System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button bRepAtt;
        public System.Windows.Forms.TextBox tbRepAttr;
        public System.Windows.Forms.ComboBox cBReportAttrDatatype;
        public System.Windows.Forms.CheckBox cBTypeOfsecondcolumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cBModelObj;        
        private System.Windows.Forms.CheckBox cBDrawingObj;
        private System.Windows.Forms.Button bOpenlog;
    }
}

