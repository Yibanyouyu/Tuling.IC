namespace Tuling.IC.DXWithoutMvvm.UserControls
{
    partial class MultiRefreshUC
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
            this.labelControlThread = new DevExpress.XtraEditors.LabelControl();
            this.labelControlTask = new DevExpress.XtraEditors.LabelControl();
            this.textEditThread = new DevExpress.XtraEditors.TextEdit();
            this.textEditTask = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditThread.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTask.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControlThread
            // 
            this.labelControlThread.Location = new System.Drawing.Point(10, 23);
            this.labelControlThread.Name = "labelControlThread";
            this.labelControlThread.Size = new System.Drawing.Size(91, 14);
            this.labelControlThread.TabIndex = 0;
            this.labelControlThread.Text = "Thread 方式刷新";
            // 
            // labelControlTask
            // 
            this.labelControlTask.Location = new System.Drawing.Point(10, 49);
            this.labelControlTask.Name = "labelControlTask";
            this.labelControlTask.Size = new System.Drawing.Size(77, 14);
            this.labelControlTask.TabIndex = 1;
            this.labelControlTask.Text = "Task 方式刷新";
            // 
            // textEditThread
            // 
            this.textEditThread.Location = new System.Drawing.Point(107, 20);
            this.textEditThread.Name = "textEditThread";
            this.textEditThread.Size = new System.Drawing.Size(100, 20);
            this.textEditThread.TabIndex = 2;
            // 
            // textEditTask
            // 
            this.textEditTask.Location = new System.Drawing.Point(107, 46);
            this.textEditTask.Name = "textEditTask";
            this.textEditTask.Size = new System.Drawing.Size(100, 20);
            this.textEditTask.TabIndex = 3;
            // 
            // MultiRefreshUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEditTask);
            this.Controls.Add(this.textEditThread);
            this.Controls.Add(this.labelControlTask);
            this.Controls.Add(this.labelControlThread);
            this.Name = "MultiRefreshUC";
            this.Size = new System.Drawing.Size(217, 86);
            ((System.ComponentModel.ISupportInitialize)(this.textEditThread.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTask.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControlThread;
        private DevExpress.XtraEditors.LabelControl labelControlTask;
        private DevExpress.XtraEditors.TextEdit textEditThread;
        private DevExpress.XtraEditors.TextEdit textEditTask;
    }
}
