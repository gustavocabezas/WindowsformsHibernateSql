<%@ Page Title="Job Tracking Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobTrackingDetails.aspx.cs" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <div class="row">


            <div class="row">
                <div class="form">
                    <div class="form-group mb-3">
                        <label for="title" class="form-label">Title</label>
                        <asp:TextBox ID="TextBoxTitle" type="text" class="form-control" aria-describedby="Title" runat="server" OnTextChanged="TextBoxTitle_TextChanged"></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label for="TextBoxDescription" class="form-label">Description</label>
                        <asp:TextBox ID="TextBoxDescription" type="text" class="form-control" runat="server" OnTextChanged="TextBoxDescription_TextChanged"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <asp:GridView ID="JobsGridView" runat="server" AutoGenerateColumns="False" OnRowDataBound="JobsGridView_RowDataBound" DataKeyNames="Id" CssClass="table table-striped">
                    <HeaderStyle CssClass="thead-dark" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="JobTitle" HeaderText="Job Title" />
                        <asp:BoundField DataField="CandidateName" HeaderText="Candidate Name" />
                        <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="CurriculumPath" HeaderText="Curriculum Path" />
                        <asp:BoundField DataField="PresentationLetterPath" HeaderText="Presentation Letter Path" />

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
