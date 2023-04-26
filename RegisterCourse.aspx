<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab08.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <title>Register Student</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1>Registration</h1>
            <div class="form-group row mt-3">
                <asp:Label ID="TypeLabel" runat="server" Text="Student:" class="col-sm-2 col-form-label"></asp:Label>
                <div class="col-sm-10">
                    <asp:DropDownList AutoPostBack="true" ID="StudentContainer" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownListChange" >
                        <asp:ListItem Enabled="true" Text="Select..." Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                    <%--Error message for dropdown--%>
                    <asp:Label ID="SelectStudentError" runat="server" Text="**Required: You must select student type" CssClass="text-danger" Visible="False"></asp:Label>
                </div>
                <div class="text-center">
                <asp:Label ID="RegisterStatus" runat="server" Text="" Class="text-success" Visible="false"></asp:Label>
                <asp:Label ID="RegisterError" runat="server" Text="" Class="text-danger" Visible="false"></asp:Label>
                </div>
            </div>
            <asp:Panel ID="PanelSelection" runat="server" CssClass="mt-5">
                <h4>Following courses are currently availble for registration</h4>
                <asp:CheckBoxList ID="CheckList" runat="server" CssClass="mt-3"></asp:CheckBoxList>
                <div class="mt-4">
                    <asp:Button ID="submitBtn" runat="server" Text="Save" Visible="True" OnClick="submit_Click" class="btn btn-secondary btn-lg" />
                </div>
            </asp:Panel>
            <div class="mt-5">
                <asp:HyperLink NavigateUrl="~/AddStudent.aspx" runat="server" Text="Add Students" />
            </div>
        </div>
    </form>
</body>
</html>
