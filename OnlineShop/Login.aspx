<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineShop._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <div class="ui middle aligned center aligned grid">
          <div class="column">
            <div class="ui teal image header">
              <img src="assets/images/logo.png" class="image"/>
              <div class="content">
                Log-in to your account
              </div>
            </div>
                <div>
                    <h2>Login Page</h2>
                    <asp:Label ID="Label1" runat="server" Text="Please log in below to access the membership area."></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="Email" runat="server" placeholder="Email"></asp:TextBox>
                    <asp:TextBox ID="Password" runat="server" placeholder="Password"></asp:TextBox>
                    <asp:Button ID="btn_login" runat="server" OnClick="Login_Click" Text="Login" />
                    <br />
                    <div id="forgotten">
                        Forgot
                        <asp:HyperLink ID="forgotPass" NavigateUrl="#" runat="server"> Password </asp:HyperLink>
                        or
                        <asp:HyperLink ID="forgotEmail" NavigateUrl="#" runat="server"> Email</asp:HyperLink>
                        ?
                    </div>
                    <div id="LoginSystem">
                        <asp:Label ID="ID" runat="server" Text="User ID:"></asp:Label>
                        <asp:Label ID="UserID" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="AT" runat="server" Text="Account Type:"></asp:Label>
                        <asp:Label ID="AccType" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="ErrorMessage" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                    <br />
                </div>
          </div>
        </div>
</asp:Content>
