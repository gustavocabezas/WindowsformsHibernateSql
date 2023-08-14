<%@ Page Title="Item" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="WindowsformsHibernateSql.Item" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <div class="row">
            <div class="form">

                <div class="form-group mb-3">
                    <label for="TextBoxName" class="form-label">Name</label>
                    <asp:TextBox ID="TextBoxName" class="form-control" aria-describedby="Name" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label for="TextBoxDescription" class="form-label">Description</label>
                    <asp:TextBox ID="TextBoxDescription" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label for="TextBoxLabels" class="form-label">Labels</label>
                    <asp:TextBox ID="TextBox1" class="form-control" runat="server" ></asp:TextBox>
                </div>  

                <asp:Button ID="ButtonCreate" class="btn btn-primary" runat="server" Text="Create" OnClick="ButtonCreate_Click" />

            </div>
        </div>
    </main>
</asp:Content>
