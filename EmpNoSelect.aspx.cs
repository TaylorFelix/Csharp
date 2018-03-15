using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data.Entity;
using FineUIPro;
using EntityFramework.Extensions;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;
using System.Collections;
using System.IO;
using System.Data.OracleClient;
using AspNet = System.Web.UI.WebControls;

namespace FlexiumOA.ServerRoom
{
    public partial class EmpNoSelect : PageBase
    {
        

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                BindGrid1();

            }
        }
        private void BindGrid1()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append("  select emp_no,emp_name from door_emp");
            //sb.Append(" order by decode(a.factory,2011,'KS','KH'),a.wip_id   ");
            if (tbEmpNO.Text.Trim() != "")
            {
                sb.Append(@" where emp_no like '%" + tbEmpNO.Text.Trim() + "%'  ");
            }
            if (tbEmpName.Text.Trim() != "")
            {
                sb.Append(@" where emp_name like '%" + tbEmpName.Text.Trim() + "%'  ");
            }
            //sb.Append(" order by decode(a.factory,2011,'KS','KH'),a.wip_id   ");
            DataSet dscount = DbHelperSQL.Query(sb.ToString());

            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            Grid1.RecordCount = dscount.Tables[0].Rows.Count;

            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;

            DataView view1 = dscount.Tables[0].DefaultView;

            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
            DataTable dtGridBd = view1.ToTable();
            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize, dtGridBd);

            // 3.绑定到Grid
            Grid1.DataSource = table;
            Grid1.DataBind();
        }
        #region ///模拟数据库分页
        /// <summary>
        /// 模拟数据库分页
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize, DataTable dt)
        {
            DataTable source = dt;

            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Rows.Count)
            {
                rowend = source.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Rows[i]);
            }

            return paged;
        }
        #endregion
        
        #endregion

        #region Grid1 Events

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            //Grid1.PageIndex = e.NewPageIndex;
            BindGrid1();
        }
        protected void Grid1_Sort(object sender, GridSortEventArgs e)
        {
            
            BindGrid1();
        }

        protected void Grid1_RowClick(object sender, FineUIPro.GridRowClickEventArgs e)
        {

        }

        #endregion

        #region Window1_Close



        protected void Window1_Close(object sender, EventArgs e)
        {

        }
        #endregion

        //查询
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            BindGrid1();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            int x = 0;
            string emp_no = "";
            string emp_name = "";
            
            for (int i = 0; i < Grid1.Rows.Count; i++)
            {
                AspNet.CheckBox ddlJhJg = (AspNet.CheckBox)Grid1.Rows[i].FindControl("ckSelect");
                if (ddlJhJg.Checked == true)
                {
                    x++;
                    emp_no = Grid1.Rows[i].DataKeys[0].ToString();
                    emp_name = Grid1.Rows[i].DataKeys[1].ToString();
                    
                }
            }
            if (x == 0)
            {
                Alert.Show("請選擇數據！");
                return;
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(emp_no, emp_name) + ActiveWindow.GetHideReference());
        }

    }
}