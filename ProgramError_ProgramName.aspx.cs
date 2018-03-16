using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUIPro;
using System.Data;
using Maticsoft.DBUtility;
using System.Text;
using System.Net;
using System.Data.Entity;
using EntityFramework.Extensions;
using System.Configuration;
using System.Data.SqlClient;
using AspNet = System.Web.UI.WebControls;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace FlexiumOA.MIS.ProgramError
{
    public partial class ProgramError_ProgramName : PageBase
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
                return "ProgramError_ProgramName";
            }
        }


        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Grid1Bind();
        }
        private void Grid1Bind()
        {
            string strDept = " select ProgramName,Remark,C_user,C_DATE from  ProgramError_ProgramName  " +
                            "  where ProgramName like '%" + tbProgramName.Text.Trim() + "%' and Remark like '%" + tbRemark.Text.Trim() + "%'";
            DataTable dt = DbHelperSQL.Query(strDept).Tables[0];
            Grid1.DataSource = dt;
            Grid1.DataBind();
            // 查詢programerror_programname表內所有programname數據
        }
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            string ProgramName = Grid1.DataKeys[e.RowIndex][0].ToString();
            SqlParameter[] sqlparams = new SqlParameter[1];
            sqlparams[0] = new SqlParameter("ProgramName", ProgramName);
            string sql = "delete from ProgramError_ProgramName where ProgramName=@ProgramName";
            DbHelperSQL.ExecuteSql(sql, sqlparams);
            Grid1Bind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Grid1Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (tbProgramName.Text.Trim() == "")
            {
                Alert.Show("報警類別不能為空!");
                return;
            }

            StringBuilder sb = new StringBuilder();
            if (hidLx.Text.Trim() == "")
            {
                string strSql = "select * from [ProgramError_ProgramName] where ProgramName ='" + tbProgramName.Text.Trim() + "' and [Remark]='" + tbRemark.Text.Trim().Trim() + " ' ";
                DataTable dt = DbHelperSQL.Query(strSql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Alert.Show("要保存的報警類別已存在，請不要重新增加！");
                    return;
                }
                sb.AppendLine(" insert into ProgramError_ProgramName (ProgramName,Remark,C_user,C_DATE)");
                sb.AppendLine(" values (N'" + tbProgramName.Text.Trim() + "',N'" + tbRemark.Text.Trim().Trim() + "' ");
                sb.AppendLine("  ,'" + GetIdentityName() + "',getdate() )");
            }
            try
            {
                int rows = DbHelperSQL.ExecuteSql(sb.ToString());
                if (rows > 0)
                {
                    tbProgramName.Text = "";
                    tbProgramName.Enabled = true;
                    tbRemark.Text = "";
                    hidLx.Text = "";
                    Grid1Bind();
                    Alert.Show("添加成功！");
                }
            }
            catch (Exception ex)
            {
                Alert.Show("添加失敗:" + ex);
                return;
            }
        }

        protected void Grid1_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            hidLx.Text = "1";
            HidCb.Text = Grid1.DataKeys[e.RowIndex][0].ToString();
            tbProgramName.Enabled = false;
            tbProgramName.Text = Grid1.DataKeys[e.RowIndex][0].ToString();
            tbRemark.Text = Grid1.DataKeys[e.RowIndex][1].ToString();
        }
    }
}