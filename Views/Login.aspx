<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WindowsformsHibernateSql.Login" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title" >
        <h2 id="title"><%: Title %></h2>
        <div class="row">
            <div class="form">
                <div class="form-group mb-3">
                    <label for="email" class="form-label">Email</label>
                    <asp:TextBox ID="TextBoxEmail" type="email" class="form-control" aria-describedby="Email" runat="server"></asp:TextBox>
                </div>
                <div class="form-group mb-3">
                    <label for="TextBoxPassword" class="form-label">Password</label>
                    <asp:TextBox ID="TextBoxPassword" type="password" class="form-control" runat="server"></asp:TextBox>
                </div> 

                <div class="form-group mb-3">
                    <asp:Label ID="LabelError" runat="server" Text="Contraseña o password incorrecto" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </div> 

                <asp:Button ID="ButtonLogin" class="btn btn-primary" runat="server" Text="Login" OnClick="ButtonLogin_Click" />

                <asp:Button ID="ButtonSignup" class="btn btn-primary" runat="server" Text="Signup" OnClick="ButtonSignup_Click" />
            </div>
        </div>
    </main>
</asp:Content>
