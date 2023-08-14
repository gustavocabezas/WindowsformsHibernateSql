<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WindowsformsHibernateSql._Default" Async="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

         <div class="row">
            <asp:GridView ID="ItemsGridView" runat="server" AutoGenerateColumns="False" OnRowDataBound="ItemsGridView_RowDataBound" DataKeyNames="Id" CssClass="table table-striped">
                <HeaderStyle CssClass="thead-dark" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="UserId" HeaderText="UserId" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
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
