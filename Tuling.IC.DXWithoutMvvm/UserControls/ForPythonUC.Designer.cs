namespace Tuling.IC.DXWithoutMvvm.UserControls
{
    partial class ForPythonUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleButtonHello = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSum = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonNumpy = new DevExpress.XtraEditors.SimpleButton();
            this.textEditNumber1 = new DevExpress.XtraEditors.TextEdit();
            this.textEditNumber2 = new DevExpress.XtraEditors.TextEdit();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNumber1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNumber2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtonHello
            // 
            this.simpleButtonHello.Location = new System.Drawing.Point(12, 15);
            this.simpleButtonHello.Name = "simpleButtonHello";
            this.simpleButtonHello.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonHello.TabIndex = 0;
            this.simpleButtonHello.Text = "Hello";
            this.simpleButtonHello.Click += new System.EventHandler(this.SimpleButtonHello_Click);
            // 
            // simpleButtonSum
            // 
            this.simpleButtonSum.Location = new System.Drawing.Point(12, 100);
            this.simpleButtonSum.Name = "simpleButtonSum";
            this.simpleButtonSum.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSum.TabIndex = 1;
            this.simpleButtonSum.Text = "两数之和";
            this.simpleButtonSum.Click += new System.EventHandler(this.SimpleButtonSum_Click);
            // 
            // simpleButtonNumpy
            // 
            this.simpleButtonNumpy.Location = new System.Drawing.Point(12, 185);
            this.simpleButtonNumpy.Name = "simpleButtonNumpy";
            this.simpleButtonNumpy.Size = new System.Drawing.Size(93, 23);
            this.simpleButtonNumpy.TabIndex = 2;
            this.simpleButtonNumpy.Text = "调用 Numpy 包";
            this.simpleButtonNumpy.Click += new System.EventHandler(this.SimpleButtonNumpy_Click);
            // 
            // textEditNumber1
            // 
            this.textEditNumber1.Location = new System.Drawing.Point(129, 16);
            this.textEditNumber1.Name = "textEditNumber1";
            this.textEditNumber1.Size = new System.Drawing.Size(100, 20);
            this.textEditNumber1.TabIndex = 3;
            // 
            // textEditNumber2
            // 
            this.textEditNumber2.Location = new System.Drawing.Point(248, 16);
            this.textEditNumber2.Name = "textEditNumber2";
            this.textEditNumber2.Size = new System.Drawing.Size(100, 20);
            this.textEditNumber2.TabIndex = 4;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(129, 58);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(219, 150);
            this.memoEdit1.TabIndex = 5;
            // 
            // ForPythonUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.textEditNumber2);
            this.Controls.Add(this.textEditNumber1);
            this.Controls.Add(this.simpleButtonNumpy);
            this.Controls.Add(this.simpleButtonSum);
            this.Controls.Add(this.simpleButtonHello);
            this.Name = "ForPythonUC";
            this.Size = new System.Drawing.Size(388, 255);
            this.Load += new System.EventHandler(this.ForPythonUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEditNumber1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNumber2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonHello;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSum;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNumpy;
        private DevExpress.XtraEditors.TextEdit textEditNumber1;
        private DevExpress.XtraEditors.TextEdit textEditNumber2;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
    }
}
