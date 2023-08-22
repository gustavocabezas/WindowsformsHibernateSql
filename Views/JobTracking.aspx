<%@ Page Title="Job Tracking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobTracking.aspx.cs" Inherits="WindowsformsHibernateSql.JobTracking" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <div class="row">

            <div class="row">
                <asp:GridView ID="JobsGridView" runat="server" AutoGenerateColumns="False" OnRowDataBound="JobsGridView_RowDataBound" DataKeyNames="Id" CssClass="table table-striped">
                    <HeaderStyle CssClass="thead-dark" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Description" HeaderText="Description" /> 
                          <asp:BoundField DataField="NumberCandidates" HeaderText="NumberCandidates" /> 
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="DetailsButton" runat="server" Text="Details" CommandName="Details" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </main>
</asp:Content>
