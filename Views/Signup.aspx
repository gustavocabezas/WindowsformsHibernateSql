<%@ Page Title="Signup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="WindowsformsHibernateSql.Signup" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <div class="row">
            <div class="form">
                <div class="form-group mb-3">
                    <label for="email" class="form-label">Email</label>
                    <asp:TextBox ID="TextBoxEmail" type="email" class="form-control" aria-describedby="Email" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label for="identification" class="form-label">Identification</label>
                    <asp:TextBox ID="TextBoxIdentification" type="number" class="form-control" aria-describedby="Identification" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label for="TextBoxPassword" class="form-label">Password</label>
                    <asp:TextBox ID="TextBoxPassword" type="password" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <asp:Label ID="LabelError" runat="server" Text="The user already exists" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </div>

                <asp:Button ID="ButtonCreate" class="btn btn-primary" runat="server" Text="Create" OnClick="ButtonCreate_Click" />
            </div>
        </div>
    </main>
</asp:Content>
