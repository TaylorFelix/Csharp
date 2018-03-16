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
using AspNet = System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace FlexiumOA.MIS.ProgramError
{
    public partial class ProgramError_AlertPeople : PageBase
    {
        #region ViewPower


        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
#if IgnorePowerCheck
                return "";
#endif
                return "ProgramError_AlertPeople";
            }
        }


        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GridDataBind();
            }
        }
        string sql;
        private void GridDataBind()
        {
            sql = "select ID,ProgramName,Empno from ProgramError_AlertPeople";
            string sql2 = "select isnull(count(*),0) from (" + sql + ") ProgramError_AlertPeople";
            DataTable dtcount = DbHelperSQL.Query(sql2).Tables[0];
            Grid1.RecordCount = Convert.ToInt32(dtcount.Rows[0][0].ToString());

            int startIndex = Grid1.PageIndex * Convert.ToInt32(ddlGridPageSize.SelectedValue) + 1;
            int EndIndex = (Grid1.PageIndex + 1) * Convert.ToInt32(ddlGridPageSize.SelectedValue);
            sql = "SELECT * FROM (SELECT ROW_NUMBER() OVER (order by ProgramName) as row,* from (" + sql + " )A )B where row between " + startIndex.ToString() + " and " + EndIndex.ToString();
            DataSet ds = DbHelperSQL.Query(sql);
            Grid1.DataSource = ds.Tables[0];
            Grid1.DataBind();

            string t = GetIdentityName();
            if (t.Trim() == "")
            {
                t = "flexiumcn\\felix_yang";
            }
            string strtID = "select a.ProgramName from ProgramError_ProgramName a,ProgramError_ProgramManager b where a.ProgramName=b.ProgramName and Manager ='" + t + "'";
            DataTable dttID = DbHelperSQL.Query(strtID).Tables[0];
            ddl_ProgramName.DataTextField = "ProgramName";
            ddl_ProgramName.DataValueField = "ProgramName";
            ddl_ProgramName.DataSource = dttID;
            ddl_ProgramName.DataBind();
        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string ProgramName = ddl_ProgramName.SelectedValue;
            string EmpNo = TriggerBox_EmpNo.Text.Trim();
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0] = new SqlParameter("ProgramName", ProgramName);
            sqlparams[1] = new SqlParameter("Empno", EmpNo);
            sql = "select * from ProgramError_AlertPeople where Empno=@Empno and ProgramName=@ProgramName";
            if (DbHelperSQL.Query(sql, sqlparams).Tables[0].Rows.Count > 0)
            {
                Alert.Show("此用戶對應報警類型已存在" + EmpNo);
                return;
            }

            sql = "insert into ProgramError_AlertPeople(Empno,ProgramName) " +
                "values(@Empno,@ProgramName)";
            sqlparams = new SqlParameter[2];
            sqlparams[0] = new SqlParameter("Empno", TriggerBox_EmpNo.Text.Trim());
            sqlparams[1] = new SqlParameter("ProgramName", ddl_ProgramName.SelectedValue);
            DbHelperSQL.ExecuteSql(sql, sqlparams);
            GridDataBind();
        }

        protected void TriggerBox_EmpNo_TriggerClick(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(Window1.GetSaveStateReference(TriggerBox_EmpNo.ClientID, tbEmpName.ClientID)
                    + Window1.GetShowReference("ProgramError_EmpNoSelect.aspx?param1=" + TriggerBox_EmpNo.Text.Trim() + "", "添加報警通知人員", 750, 600));
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int ID = int.Parse(Grid1.DataKeys[e.RowIndex][0].ToString());
                sql = "delete from ProgramError_AlertPeople where ID='" +
                int.Parse(Grid1.DataKeys[e.RowIndex][0].ToString()) + "'";
                DbHelperSQL.ExecuteSql(sql);
                GridDataBind();
            }

        }
    }
}