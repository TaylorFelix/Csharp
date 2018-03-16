<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramError_EmpNoSelect.aspx.cs" Inherits="FlexiumOA.MIS.ProgramError.ProgramError_EmpNoSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="Region1" ShowBorder="false" ShowHeader="false"  Width="550px" Position="Left" Layout="Fit" BodyPadding="5px" runat="server" >
                    <Items>
                        <f:Grid ID="Grid1"   EnableCollapse="true" Width="550px" PageSize="20" ShowBorder="false" ShowHeader="false" AllowPaging="true" IsDatabasePaging="true" runat="server" 
                          EnableCheckBoxSelect="false" ShowPagingMessage="true" DataKeyNames="emp_no,emp_name" OnPageIndexChange="Grid1_PageIndexChange" OnRowClick="Grid1_RowClick" EnableRowClickEvent="true"
                            AllowSorting="true" OnSort="Grid1_Sort"  SortField="emp_name" SortDirection="ASC">
                             <Toolbars>
                                <f:Toolbar ID="Toolbar2" runat="server">
                                    <Items>
                                        <f:TextBox runat="server" LabelWidth="60px" Width="160px" ID="tbEmpNO" Label="工號"></f:TextBox>
                                        <f:TextBox runat="server" LabelWidth="60px" Width="160px" ID="tbEmpName" Label="姓名"></f:TextBox>
                                        <f:Button ID="Button1" runat="server"  Text="查找"  ValidateForms="Term" OnClick="btnCheck_Click"></f:Button>
                                        <f:Button ID="btnSelect" runat="server"  Text="選擇"  ValidateForms="Term"  OnClick="btnSelect_Click"></f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:RowNumberField Hidden="true"></f:RowNumberField>
                                <f:TemplateField HeaderText="選擇"  Width="60px" >
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckSelect"  runat="server" />
                                    </ItemTemplate>
                                </f:TemplateField>
                                <f:BoundField DataField="emp_no"    HeaderText="員工編號" DataSimulateTreeLevelField="TreeLevel" Width="100px" />
                                <f:BoundField DataField="emp_name"    HeaderText="員工姓名" DataSimulateTreeLevelField="TreeLevel" Width="100px" />
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <f:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true" Target="Top" EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank" Width="550px" Height="550px" OnClose="Window1_Close">
        </f:Window>
    </form>
</body>
</html>

