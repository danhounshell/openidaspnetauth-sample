<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OpenIDSampleApp.Web.LoginDefault" Title="Login to this site" %>
<%@ Register Src="~/UserControls/OpenIdLoginForm.ascx" TagName="Login" TagPrefix="OpenId" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Login</h1>
    
    <br />
    <p><b>You can login using your OpenID</b></p>
    <p><OpenId:Login runat="server" id="pnlOpenIdLogin" /></p>
    
    <h3>OR</h3>

    <p><b>You can login with your member account</b></p>    
    <p>
        <asp:Panel ID="pnlLogin" runat="server">
            <asp:Login ID="ctlLogin" runat="server" DisplayRememberMe="true" VisibleWhenLoggedIn="true" />
        </asp:Panel>
    </p>

    <h3>OR</h3>
    
    <p><b>If you don't have an account yet you can <a href="/members/join/">Click here to create one</a>.</b></p>

    <p><asp:Label ID="lblLoggedIn" runat="server" Visible="false"><br /><br /><br />You are already logged in.</asp:Label></p>

    <p>&nbsp;</p>

</asp:Content>
