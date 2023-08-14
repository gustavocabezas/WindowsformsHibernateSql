<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="WindowsformsHibernateSql.Users" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Your application description page.</h3>
        <p>Use this area to provide additional information.</p>

        <asp:Button runat="server" class="mb-3 btn btn-primary" aria-label="Create" Text="Crear" OnClick="ButtonCreate_Click"></asp:Button> 

        <div class="row">
            <asp:GridView ID="UsersGridView" runat="server" AutoGenerateColumns="False" OnRowDataBound="UsersGridView_RowDataBound" DataKeyNames="Id" CssClass="table table-striped">
                <HeaderStyle CssClass="thead-dark" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Username" HeaderText="User Name" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="DetailsButton" runat="server" Text="Details" CommandName="Details" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </main>
</asp:Content>
