<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab08.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <title>AddStudent</title>
</head>
<body>
    <div class="container mt-5">
        <form id="form1" runat="server">
            <h1>Students</h1>
            <div class="form-group row mt-3">
                <asp:Label ID="NameLabel" runat="server" Text="Student Name:" class="col-sm-2 col-form-label"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="NameText" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="NameError" runat="server" Text="**Required: You must enter student name" CssClass="text-danger" Visible ="False"></asp:Label>
                </div>
            </div>
            <div class="form-group row mt-3">
                <asp:Label ID="TypeLabel" runat="server" Text="Student Type:" class="col-sm-2 col-form-label"></asp:Label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="TypeContainer" runat="server" CssClass="form-control">
                        <asp:ListItem Enabled="true" Text= "Select..." Value= "-1"></asp:ListItem>
                        <asp:ListItem Text= "Full-Time" Value="1"></asp:ListItem>
                        <asp:ListItem Text= "Part-Time" Value="2"></asp:ListItem>
                        <asp:ListItem Text= "Co-op" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="TypeError" runat="server" Text="**Required: You must select student type" CssClass="text-danger" Visible ="False"></asp:Label>
                </div>
            </div>
            <div class="mt-3">
                <asp:Button ID="AddBtn" runat="server" Text="Add" OnClick="AddBtn_Click" class="btn btn-secondary btn-lg" />
            </div>  
        </form>
        <asp:Panel ID="PanelResult" runat="server" CssClass="mt-5">
            <asp:Table ID="StudentTable" runat="server" CssClass ="table">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </asp:Panel>
        <div class="mt-5">
            <asp:HyperLink NavigateUrl="~/RegisterCourse.aspx" runat="server" Text="Register Courses" />
        </div>
    </div>

</body>
</html>
