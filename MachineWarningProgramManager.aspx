<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MachineWarningProgramManager.aspx.cs" Inherits="FlexiumOA.ServerRoom.MachineWarningProgramManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start" BoxConfigPadding="5" BoxConfigChildMargin="0 0 5 0">
            <Items>
                <f:Panel runat="server" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Start" BoxConfigPosition="Start" BoxConfigPadding="5">
                    <Items>
                        <f:SimpleForm ID="SimpleForm1" runat="server" Title="添加管理員" LabelWidth="120px" BodyPadding="5px"
                            Width="550px" LabelAlign="Left" ShowBorder="true"
                            ShowHeader="true">
                            <Items>
                                <f:TriggerBox ID="TriggerBox_Manager" EnableEdit="false" Width="350px" TriggerIcon="Search" Label="管理員" OnTriggerClick="TriggerBox_Manager_TriggerClick" runat="server"></f:TriggerBox>
                                <f:DropDownList ID="ddl_ProgramName" Label="報警组" runat="server" Width="350px" Required="true" ShowRedStar="true" EnableEdit="false" ForceSelection="true" >                                   
                                </f:DropDownList>
                                <f:Button ID="btnSave" runat="server" Icon="SystemSave" OnClick="btnSave_Click" ValidateForms="SimpleForm1" ValidateTarget="Top" Text="添加">
                                </f:Button>
                            </Items>
                        </f:SimpleForm>
                    </Items>
                </f:Panel>
                
                <f:Grid runat="server" ID="Grid1" BoxFlex="1" DataKeyNames="ID" ShowHeader="false" AllowPaging="true" PageSize="20"   OnRowCommand="Grid1_RowCommand" OnPageIndexChange="Grid1_PageIndexChange">
                    <PageItems>
                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </f:ToolbarSeparator>
                        <f:ToolbarText ID="ToolbarText1" runat="server" Text="每頁記錄數：">
                        </f:ToolbarText>
                        <f:DropDownList ID="ddlGridPageSize" Width="80px" AutoPostBack="true" runat="server">
                            <f:ListItem Text="20" Value="20"></f:ListItem>
                            <f:ListItem Text="50" Value="50"></f:ListItem>
                            <f:ListItem Text="100" Value="100"></f:ListItem>
                        </f:DropDownList>
                    </PageItems>
                    <Columns>
                        <f:BoundField DataField="Manager" HeaderText="管理員" Width="100px" ExpandUnusedSpace="true"/>
                        <f:BoundField DataField="ProgramName" HeaderText="類型" Width="300px" />
                        <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" HeaderText="刪除" ToolTip="刪除" ConfirmText="確定刪除？" ConfirmTarget="Self" CommandName="Delete" Width="100px">
                        </f:LinkButtonField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true"
            Target="Top" EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
            Width="545px" Height="330px" >
        </f:Window>
    </form>
</body>
</html>
