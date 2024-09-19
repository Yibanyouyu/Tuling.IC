namespace Tuling.IC.DXWithoutMvvm.UserControls
{
    partial class PageLogUC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageLogUC));
            this.panelControlOperations = new DevExpress.XtraEditors.PanelControl();
            this.dateEditEndTime = new DevExpress.XtraEditors.DateEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItemFirst = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrevious = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItemPage = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonItemNext = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLast = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemPageInfo = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dateEditStartTime = new DevExpress.XtraEditors.DateEdit();
            this.simpleButtonReset = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlEndTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControlStartTime = new DevExpress.XtraEditors.LabelControl();
            this.panelControlMain = new DevExpress.XtraEditors.PanelControl();
            this.gridControlDataSource = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlOperations)).BeginInit();
            this.panelControlOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMain)).BeginInit();
            this.panelControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlOperations
            // 
            this.panelControlOperations.Controls.Add(this.dateEditEndTime);
            this.panelControlOperations.Controls.Add(this.dateEditStartTime);
            this.panelControlOperations.Controls.Add(this.simpleButtonReset);
            this.panelControlOperations.Controls.Add(this.simpleButtonSearch);
            this.panelControlOperations.Controls.Add(this.labelControlEndTime);
            this.panelControlOperations.Controls.Add(this.labelControlStartTime);
            this.panelControlOperations.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlOperations.Location = new System.Drawing.Point(0, 0);
            this.panelControlOperations.Name = "panelControlOperations";
            this.panelControlOperations.Size = new System.Drawing.Size(764, 54);
            this.panelControlOperations.TabIndex = 0;
            // 
            // dateEditEndTime
            // 
            this.dateEditEndTime.EditValue = null;
            this.dateEditEndTime.Location = new System.Drawing.Point(311, 17);
            this.dateEditEndTime.MenuManager = this.barManager1;
            this.dateEditEndTime.Name = "dateEditEndTime";
            this.dateEditEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEndTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEndTime.Properties.MaskSettings.Set("mask", "F");
            this.dateEditEndTime.Size = new System.Drawing.Size(150, 20);
            this.dateEditEndTime.TabIndex = 7;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemFirst,
            this.barButtonItemPrevious,
            this.barEditItemPage,
            this.barButtonItemNext,
            this.barButtonItemLast,
            this.barStaticItemPageInfo,
            this.barStaticItemStatus});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar2.FloatLocation = new System.Drawing.Point(390, 583);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemFirst),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemPrevious),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEditItemPage),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemNext),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemLast),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemPageInfo),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItemStatus)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItemFirst
            // 
            this.barButtonItemFirst.Caption = "首页";
            this.barButtonItemFirst.Id = 0;
            this.barButtonItemFirst.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemFirst.ImageOptions.Image")));
            this.barButtonItemFirst.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemFirst.ImageOptions.LargeImage")));
            this.barButtonItemFirst.Name = "barButtonItemFirst";
            this.barButtonItemFirst.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemFirst_ItemClick);
            // 
            // barButtonItemPrevious
            // 
            this.barButtonItemPrevious.Caption = "上一页";
            this.barButtonItemPrevious.Id = 1;
            this.barButtonItemPrevious.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemPrevious.ImageOptions.Image")));
            this.barButtonItemPrevious.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemPrevious.ImageOptions.LargeImage")));
            this.barButtonItemPrevious.Name = "barButtonItemPrevious";
            this.barButtonItemPrevious.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemPrevious_ItemClick);
            // 
            // barEditItemPage
            // 
            this.barEditItemPage.Caption = "页码";
            this.barEditItemPage.Edit = this.repositoryItemTextEdit1;
            this.barEditItemPage.Id = 2;
            this.barEditItemPage.Name = "barEditItemPage";
            this.barEditItemPage.EditValueChanged += new System.EventHandler(this.BarEditItemPage_EditValueChanged);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barButtonItemNext
            // 
            this.barButtonItemNext.Caption = "下一页";
            this.barButtonItemNext.Id = 3;
            this.barButtonItemNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemNext.ImageOptions.Image")));
            this.barButtonItemNext.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemNext.ImageOptions.LargeImage")));
            this.barButtonItemNext.Name = "barButtonItemNext";
            this.barButtonItemNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemNext_ItemClick);
            // 
            // barButtonItemLast
            // 
            this.barButtonItemLast.Caption = "最后一页";
            this.barButtonItemLast.Id = 4;
            this.barButtonItemLast.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemLast.ImageOptions.Image")));
            this.barButtonItemLast.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemLast.ImageOptions.LargeImage")));
            this.barButtonItemLast.Name = "barButtonItemLast";
            this.barButtonItemLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemLast_ItemClick);
            // 
            // barStaticItemPageInfo
            // 
            this.barStaticItemPageInfo.Caption = "共100页 第 1 到 20 条 共2000条";
            this.barStaticItemPageInfo.Id = 5;
            this.barStaticItemPageInfo.Name = "barStaticItemPageInfo";
            // 
            // barStaticItemStatus
            // 
            this.barStaticItemStatus.Caption = "数据加载中...";
            this.barStaticItemStatus.Id = 6;
            this.barStaticItemStatus.Name = "barStaticItemStatus";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(764, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 463);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(764, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 463);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(764, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 463);
            // 
            // dateEditStartTime
            // 
            this.dateEditStartTime.EditValue = null;
            this.dateEditStartTime.Location = new System.Drawing.Point(71, 17);
            this.dateEditStartTime.MenuManager = this.barManager1;
            this.dateEditStartTime.Name = "dateEditStartTime";
            this.dateEditStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStartTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStartTime.Properties.MaskSettings.Set("mask", "F");
            this.dateEditStartTime.Size = new System.Drawing.Size(150, 20);
            this.dateEditStartTime.TabIndex = 6;
            // 
            // simpleButtonReset
            // 
            this.simpleButtonReset.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonReset.ImageOptions.Image")));
            this.simpleButtonReset.Location = new System.Drawing.Point(671, 16);
            this.simpleButtonReset.Name = "simpleButtonReset";
            this.simpleButtonReset.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonReset.TabIndex = 5;
            this.simpleButtonReset.Text = "重置";
            this.simpleButtonReset.Click += new System.EventHandler(this.SimpleButtonReset_Click);
            // 
            // simpleButtonSearch
            // 
            this.simpleButtonSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSearch.ImageOptions.Image")));
            this.simpleButtonSearch.Location = new System.Drawing.Point(581, 16);
            this.simpleButtonSearch.Name = "simpleButtonSearch";
            this.simpleButtonSearch.Size = new System.Drawing.Size(59, 23);
            this.simpleButtonSearch.TabIndex = 4;
            this.simpleButtonSearch.Text = "查询";
            this.simpleButtonSearch.Click += new System.EventHandler(this.SimpleButtonSearch_Click);
            // 
            // labelControlEndTime
            // 
            this.labelControlEndTime.Location = new System.Drawing.Point(245, 20);
            this.labelControlEndTime.Name = "labelControlEndTime";
            this.labelControlEndTime.Size = new System.Drawing.Size(60, 14);
            this.labelControlEndTime.TabIndex = 2;
            this.labelControlEndTime.Text = "结束时间：";
            // 
            // labelControlStartTime
            // 
            this.labelControlStartTime.Location = new System.Drawing.Point(5, 20);
            this.labelControlStartTime.Name = "labelControlStartTime";
            this.labelControlStartTime.Size = new System.Drawing.Size(60, 14);
            this.labelControlStartTime.TabIndex = 0;
            this.labelControlStartTime.Text = "开始时间：";
            // 
            // panelControlMain
            // 
            this.panelControlMain.Controls.Add(this.gridControlDataSource);
            this.panelControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlMain.Location = new System.Drawing.Point(0, 54);
            this.panelControlMain.Name = "panelControlMain";
            this.panelControlMain.Size = new System.Drawing.Size(764, 409);
            this.panelControlMain.TabIndex = 1;
            // 
            // gridControlDataSource
            // 
            this.gridControlDataSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDataSource.Location = new System.Drawing.Point(2, 2);
            this.gridControlDataSource.MainView = this.gridView1;
            this.gridControlDataSource.Name = "gridControlDataSource";
            this.gridControlDataSource.Size = new System.Drawing.Size(760, 405);
            this.gridControlDataSource.TabIndex = 0;
            this.gridControlDataSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlDataSource;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // PageLogUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControlMain);
            this.Controls.Add(this.panelControlOperations);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "PageLogUC";
            this.Size = new System.Drawing.Size(764, 487);
            this.Load += new System.EventHandler(this.PageLogUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlOperations)).EndInit();
            this.panelControlOperations.ResumeLayout(false);
            this.panelControlOperations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMain)).EndInit();
            this.panelControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlOperations;
        private DevExpress.XtraEditors.PanelControl panelControlMain;
        private DevExpress.XtraEditors.LabelControl labelControlStartTime;
        private DevExpress.XtraEditors.LabelControl labelControlEndTime;
        private DevExpress.XtraEditors.SimpleButton simpleButtonReset;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSearch;
        private DevExpress.XtraGrid.GridControl gridControlDataSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItemFirst;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPrevious;
        private DevExpress.XtraBars.BarEditItem barEditItemPage;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemNext;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLast;
        private DevExpress.XtraBars.BarStaticItem barStaticItemPageInfo;
        private DevExpress.XtraBars.BarStaticItem barStaticItemStatus;
        private DevExpress.XtraEditors.DateEdit dateEditStartTime;
        private DevExpress.XtraEditors.DateEdit dateEditEndTime;
    }
}
