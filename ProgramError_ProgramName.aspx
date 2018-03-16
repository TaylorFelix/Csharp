<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramError_ProgramName.aspx.cs" Inherits="FlexiumOA.MIS.ProgramError.ProgramError_ProgramName" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="false" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start" ShowHeader="false" Title="報警維護">
            <Items>                
               <f:Form ID="Form" runat="server" ShowHeader="false" ShowBorder="false" LabelWidth="90px">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:Label ID="Label2" Text="" Width="100" MarginRight="8" runat="server"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false" DataKeyNames="ProgramName,Remark" EnableRowDoubleClickEvent="true" OnRowCommand="Grid1_RowCommand"  OnRowDoubleClick="Grid1_RowDoubleClick">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server">
                           <Items>
                               <f:TextBox ID="tbProgramName" runat="server" Label="報警類別" LabelWidth="70px" Width="260px" TabIndex="1"></f:TextBox>
                               <f:TextBox ID="tbRemark" runat="server" Label="信息備註" LabelWidth="70px" Width="260px" TabIndex="1"></f:TextBox>
                            </Items>
                        </f:Toolbar>
                         <f:Toolbar ID="Toolbar2" runat="server">
                           <Items>
                               <f:Button ID="btnSave" runat="server" Text="新增" OnClick="btnSave_Click" Icon="Add" ValidateForms="Form" ></f:Button>
                               <f:Button ID="btnSearch" runat="server" Text="查詢" OnClick="btnSearch_Click" Icon="Zoom" ></f:Button>
                               <f:HiddenField ID="hidLx" runat="server"></f:HiddenField> 
                               <f:HiddenField ID="HidCb" runat="server"></f:HiddenField> 
                               <f:HiddenField ID="HidQxDm" runat="server"></f:HiddenField>
                               <f:HiddenField ID="HidDeptId" runat="server"></f:HiddenField> 
                           </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField Width="40px" />                        
                        <f:BoundField DataField="ProgramName" HeaderText="報警類別"  Width="100px"  HeaderTextAlign="Center"  />
                        <f:BoundField DataField="Remark" HeaderText="信息維護" Width="100px"  HeaderTextAlign="Center" />
                        <f:BoundField DataField="C_USER" HeaderText="錄入人" Width="160px"  HeaderTextAlign="Center" />                  
                        <f:BoundField DataField="C_Date" HeaderText="錄入時間" Width="140px" DataFormatString="{0:yyyy/MM/dd}" HeaderTextAlign="Center" />
                        <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" HeaderText="刪除" ToolTip="刪除" ConfirmText="確定刪除？"
                                    ConfirmTarget="Self" CommandName="Delete" Width="100px">
                                </f:LinkButtonField>
                    </Columns> 
                </f:Grid>              
            </Items>
        </f:Panel>      
    </form>
</body>
</html>
