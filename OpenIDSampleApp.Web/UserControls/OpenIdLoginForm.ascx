<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenIdLoginForm.ascx.cs" Inherits="OpenIDSampleApp.Web.UserControls.OpenIdLoginForm" %>


OpenID: <asp:TextBox ID="openid_identifier" runat="server" /> <asp:Button ID="loginButton" runat="server" Text="Log In" OnClick="loginButton_Click" />
<!-- BEGIN ID SELECTOR -->
<script type="text/javascript">
  <!--
      idselector_input_id = "<%= openid_identifier.ClientID %>";
    -->
</script>
<script type="text/javascript" id="__openidselector" src="https://www.idselector.com/selector/[GetYourOwnID@idselector.com]" charset="utf-8"></script>
<!-- END ID SELECTOR -->
<br />
<asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember me next time." />
<asp:CustomValidator runat="server" ID="openidValidator" ErrorMessage="Invalid OpenID Identifier" ControlToValidate="openid_identifier" EnableViewState="false" OnServerValidate="openidValidator_ServerValidate" />  
<asp:Label ID="loginFailedLabel" runat="server" EnableViewState="False" Text="Login failed" Visible="False" />  
<asp:Label ID="loginCanceledLabel" runat="server" EnableViewState="False" Text="Login canceled" Visible="False" />              
