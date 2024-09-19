namespace Tuling.IC.DXWithoutMvvm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControlMain = new DevExpress.XtraEditors.PanelControl();
            this.panelControlMultiRefresh = new DevExpress.XtraEditors.PanelControl();
            this.labelControlTransform = new DevExpress.XtraEditors.LabelControl();
            this.multiRefreshUC1 = new Tuling.IC.DXWithoutMvvm.UserControls.MultiRefreshUC();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMultiRefresh)).BeginInit();
            this.panelControlMultiRefresh.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(990, 77);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(142, 23);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(79, 30);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "分页日志";
            this.simpleButton2.Click += new System.EventHandler(this.SimpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(12, 23);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(101, 30);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "多线程刷新";
            this.simpleButton1.Click += new System.EventHandler(this.SimpleButton1_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControlMain);
            this.panelControl2.Controls.Add(this.panelControlMultiRefresh);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 77);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(990, 491);
            this.panelControl2.TabIndex = 1;
            // 
            // panelControlMain
            // 
            this.panelControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlMain.Location = new System.Drawing.Point(224, 2);
            this.panelControlMain.Name = "panelControlMain";
            this.panelControlMain.Size = new System.Drawing.Size(764, 487);
            this.panelControlMain.TabIndex = 1;
            // 
            // panelControlMultiRefresh
            // 
            this.panelControlMultiRefresh.Controls.Add(this.labelControlTransform);
            this.panelControlMultiRefresh.Controls.Add(this.multiRefreshUC1);
            this.panelControlMultiRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControlMultiRefresh.Location = new System.Drawing.Point(2, 2);
            this.panelControlMultiRefresh.Name = "panelControlMultiRefresh";
            this.panelControlMultiRefresh.Size = new System.Drawing.Size(222, 487);
            this.panelControlMultiRefresh.TabIndex = 0;
            // 
            // labelControlTransform
            // 
            this.labelControlTransform.Location = new System.Drawing.Point(73, 94);
            this.labelControlTransform.Name = "labelControlTransform";
            this.labelControlTransform.Size = new System.Drawing.Size(72, 14);
            this.labelControlTransform.TabIndex = 1;
            this.labelControlTransform.Text = "暂无数据同步";
            // 
            // multiRefreshUC1
            // 
            this.multiRefreshUC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.multiRefreshUC1.Location = new System.Drawing.Point(2, 2);
            this.multiRefreshUC1.Name = "multiRefreshUC1";
            this.multiRefreshUC1.Size = new System.Drawing.Size(218, 86);
            this.multiRefreshUC1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 568);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "DevExpress Style";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMultiRefresh)).EndInit();
            this.panelControlMultiRefresh.ResumeLayout(false);
            this.panelControlMultiRefresh.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControlMultiRefresh;
        private DevExpress.XtraEditors.PanelControl panelControlMain;
        private UserControls.MultiRefreshUC multiRefreshUC1;
        private DevExpress.XtraEditors.LabelControl labelControlTransform;
    }
}

