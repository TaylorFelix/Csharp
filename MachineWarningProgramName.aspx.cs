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

namespace FlexiumOA.ServerRoom
{
    public partial class MachineWarningProgramName : PageBase
    {
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
            DataTable dt = Grid1.DataSource as DataTable;
            string programname = Grid1.DataKeys[e.RowIndex][0].ToString();
            // 選取programname所在行
            if (e.CommandName == "Delete")
            {
                string sql = "delete from ProgramError_ProgramName where programName ='" +
                dt.Rows[e.RowIndex]["programName"].ToString() + "'";
                DbHelperSQL.ExecuteSql(sql);
                Grid1Bind();
            };
            // command事件觸發delete，執行刪除數據
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
                sb.AppendLine(" values (N'" + tbProgramName.Text.Trim() + "','" + tbRemark.Text.Trim().Trim() + "' ");
                sb.AppendLine("  ,'" + GetIdentityName() + "',getdate() )");
            }
            //else
            //{
            //    sb.AppendLine(" update ProgramError_ProgramName  set ProgramName ='" + tbProgramName.Text.Trim() + "',Remark='" + tbRemark.Text.Trim().Trim() + "' ");
            //    sb.AppendLine(" ,U_USER='" + GetIdentityName() + "',U_DATE=getdate() ");
            //    sb.AppendLine(" where ProgramName ='" + HidCb.Text.Trim() + "'  ");
            //}
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
            // 標準加者式寫法
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