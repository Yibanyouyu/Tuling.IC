using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tuling.IC.DXWithoutMvvm.Models;

namespace Tuling.IC.DXWithoutMvvm.UserControls
{
    public partial class PageLogUC : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 页码
        /// </summary>
        private int _page = 1;
        /// <summary>
        /// 页宽
        /// </summary>
        private int _pageSize = 20;
        /// <summary>
        /// 总数
        /// </summary>
        private int _totalRecord = 2000;
        /// <summary>
        /// 总页数
        /// </summary>
        private int _totalPage = 100;
        /// <summary>
        /// 数据
        /// </summary>
        private BindingList<LogModel> _records;
        /// <summary>
        /// 是否为用户操作引起变更 加载数据时会更新分页页码值
        /// </summary>
        private bool _isChangedByUser;

        public PageLogUC()
        {
            InitializeComponent();
        }

        private void PageLogUC_Load(object sender, EventArgs e)
        {
            //开启双缓冲，减少闪烁
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();

            InitUI();
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void InitUI()
        {
            DateTime nowTime = DateTime.Now;
            DateTime oneWeekAgo = nowTime.AddDays(-7);
            dateEditStartTime.DateTime = new DateTime(oneWeekAgo.Year, oneWeekAgo.Month, oneWeekAgo.Day, 0, 0, 0);
            dateEditEndTime.DateTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 0, 0, 0);
            barStaticItemStatus.Caption = "数据加载中...";

            List<LogModel> records = FindRecords();
            _totalRecord = records.Count;
            _records = new BindingList<LogModel>(records);
            SetPage(1, _totalRecord);
            BindDataSource();

            barStaticItemStatus.Caption = "数据加载完成";
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <returns></returns>
        private List<LogModel> FindRecords()
        {
            List<LogModel> logModels = new List<LogModel>();

            Random random = new Random();
            DateTime now = DateTime.Now;

            for (int i = 0; i < 2000; i++)
            {
                //生成小于一周的随机时间间隔
                TimeSpan randomTimeSpan = new TimeSpan(0, random.Next(0, 7 * 24 * 60), 0);
                DateTime dateTime = now - randomTimeSpan;

                logModels.Add(new LogModel
                {
                    Id = i,
                    UserName = "Admin",
                    Operate = $"登录 {i + 1}",
                    OperateTime = dateTime,
                    IPAddress = "127.0.0.1"
                });
            }

            return logModels;
        }

        /// <summary>
        /// 设置分页信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="totalRecord">总数</param>
        private void SetPage(int page, int totalRecord)
        {
            _totalPage = (int)Math.Ceiling((double)totalRecord / _pageSize);

            //仅有一页数据
            if (_totalPage <= 1)
            {
                barButtonItemFirst.Enabled = false;
                barButtonItemPrevious.Enabled = false;
                barButtonItemNext.Enabled = false;
                barButtonItemLast.Enabled = false;
                barEditItemPage.Enabled = false;
            }
            //为第一页
            else if (page == 1)
            {
                barButtonItemFirst.Enabled = false;
                barButtonItemPrevious.Enabled = false;
                barButtonItemNext.Enabled = true;
                barButtonItemLast.Enabled = true;
                barEditItemPage.Enabled = true;
            }
            //最后一页
            else if (page == _totalPage)
            {
                barButtonItemFirst.Enabled = true;
                barButtonItemPrevious.Enabled = true;
                barButtonItemNext.Enabled = false;
                barButtonItemLast.Enabled = false;
                barEditItemPage.Enabled = true;
            }
            //中间页
            else
            {
                barButtonItemFirst.Enabled = true;
                barButtonItemPrevious.Enabled = true;
                barButtonItemNext.Enabled = true;
                barButtonItemLast.Enabled = true;
                barEditItemPage.Enabled = true;
            }

            _page = page;
            _isChangedByUser = false;
            barEditItemPage.EditValue = page;
            _isChangedByUser = true;

            if (totalRecord == 0)
            {
                barStaticItemPageInfo.Caption = "暂无数据";
            }
            else
            {
                barStaticItemPageInfo.Caption = $"共 {_totalPage:N0} 页　第 {(_pageSize * (page - 1) + 1):N0} 到 {(page == _totalPage ? totalRecord : _pageSize * page):N0} 条　共 {totalRecord:N0} 条";
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDataSource()
        {
            gridControlDataSource.DataSource = _records.Skip((_page - 1) * _pageSize).Take(_pageSize).ToList();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SimpleButtonSearch_Click(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            barStaticItemStatus.Caption = "数据加载中...";

            List<LogModel> records = FindRecords().FindAll(x => x.OperateTime >= dateEditStartTime.DateTime && x.OperateTime <= dateEditEndTime.DateTime);
            _totalRecord = records.Count;
            _records = new BindingList<LogModel>();
            SetPage(1, _totalRecord);
            BindDataSource();

            barStaticItemStatus.Caption = "数据加载完成";
        }

        /// <summary>
        /// 重置查询时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButtonReset_Click(object sender, EventArgs e)
        {
            DateTime nowTime = DateTime.Now;
            DateTime oneWeekAgo = nowTime.AddDays(-7);
            dateEditStartTime.DateTime = new DateTime(oneWeekAgo.Year, oneWeekAgo.Month, oneWeekAgo.Day, 0, 0, 0);
            dateEditEndTime.DateTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 0, 0, 0);
        }

        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarButtonItemFirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetPage(1, _totalRecord);
            BindDataSource();
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarButtonItemPrevious_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetPage(_page - 1, _totalRecord);
            BindDataSource();
        }

        /// <summary>
        /// 页码输入框值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarEditItemPage_EditValueChanged(object sender, EventArgs e)
        {
            if (!_isChangedByUser) return;

            string pageNumberString = barEditItemPage.EditValue.ToString().Trim();

            if (!string.IsNullOrWhiteSpace(pageNumberString) && int.TryParse(pageNumberString, out int page))
            {
                if (page < 1)
                {
                    SetPage(1, _totalRecord);
                }
                else if (page > _totalPage)
                {
                    SetPage(_totalPage, _totalRecord);
                }
                else
                {
                    SetPage(page, _totalRecord);
                }

            }
            else
            {
                SetPage(1, _totalRecord);
            }

            BindDataSource();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarButtonItemNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetPage(_page + 1, _totalRecord);
            BindDataSource();
        }

        /// <summary>
        /// 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarButtonItemLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetPage(_totalPage, _totalRecord);
            BindDataSource();
        }
    }
}
