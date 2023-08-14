<%@ Page Title="Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="WindowsformsHibernateSql.Account" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <div class="row">
            <div class="form mt-3">
                <div class="form-group mb-3">
                    <asp:Image ID="ImageAvatar" Class="rounded-circle" Width="150" Height="150" runat="server"/>
                    <br /><br />
                    <asp:FileUpload ID="FileUploadImage" Classs="form-control" runat="server" accept="image/*"/> 
                </div>

                <div class="form-group mb-3">
                    <label for="username" class="form-label">Username</label>
                    <asp:TextBox ID="TextBoxUserName" class="form-control" aria-describedby="Username" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label for="firstname" class="form-label">First Name</label>
                    <asp:TextBox ID="TextBoxFirstName" class="form-control" aria-describedby="First Name" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label for="lastname" class="form-label">Last Name</label>
                    <asp:TextBox ID="TextBoxLastName" class="form-control" aria-describedby="Last Name" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label for="email" class="form-label">Email</label>
                    <asp:TextBox ID="TextBoxEmail" type="email" class="form-control" aria-describedby="Email" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label for="TextBoxPassword" class="form-label">Password</label>
                    <asp:TextBox ID="TextBoxPassword" type="password" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <asp:Label ID="LabelError" runat="server" Text="The user already exists" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                </div>

                <asp:Button ID="ButtonUpdate" class="btn btn-primary w-100" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
            </div>
        </div>
    </main>

    
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= FileUploadImage.ClientID %>").change(function (e) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $("#<%= ImageAvatar.ClientID %>").attr('src', e.target.result);
                }
                reader.readAsDataURL(e.target.files[0]);
            });
        });
    </script>

</asp:Content>

