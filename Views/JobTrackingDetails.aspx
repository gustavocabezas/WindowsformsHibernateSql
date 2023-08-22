<%@ Page Title="Job Tracking Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobTrackingDetails.aspx.cs" Inherits="WindowsformsHibernateSql.JobTrackingDetails" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>

        <div class="row">

            <asp:GridView ID="JobsGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <HeaderStyle CssClass="thead-dark" />
                <Columns>
                    <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name" />
                    <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="JobTitle" HeaderText="Job Title" />
                    <asp:BoundField DataField="CandidateDocumentId" HeaderText="Candidate Document ID" />
                </Columns>
            </asp:GridView>

        </div>
    </main>
</asp:Content>
