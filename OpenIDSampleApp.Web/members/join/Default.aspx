<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OpenIDSampleApp.Web.JoinDefault" Title="Join this site" %>
<%@ Register Src="~/UserControls/OpenIdLoginForm.ascx" TagName="Login" TagPrefix="OpenId" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Join</h1>
    
    <br />
    <p><b>You can login using your OpenID</b></p>
    <p><OpenId:Login runat="server" id="pnlOpenIdLogin" /></p>
    
    <h3>OR</h3>
    
    <p><b>You can create a traditional account on this site</b></p>        
    <p>
        <asp:Panel ID="pnlJoin" runat="server">
            <asp:CreateUserWizard ID="ctrJoin" runat="server" 
                RequireEmail="true" 
                DisplayCancelButton="true" 
                CancelDestinationPageUrl="~/"
                ContinueDestinationPageUrl="~/"  />
        </asp:Panel>
    </p>
    
    <p><asp:Label ID="lblJoined" runat="server" Visible="false"><br /><br /><br />You are already a member.</asp:Label></p>

    <p>&nbsp;</p>

</asp:Content>
