using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetOpenId;
using DotNetOpenId.Extensions.SimpleRegistration;
using DotNetOpenId.RelyingParty;
using OpenIDSampleApp.Components;

namespace OpenIDSampleApp.Web.UserControls {
    public partial class OpenIdLoginForm : UserControl {

        protected void Page_Load(object sender, EventArgs e)
        {
            openid_identifier.Focus();
            OpenIdRelyingParty openid = new OpenIdRelyingParty();
            if (openid.Response != null)
            {
                switch (openid.Response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        // This is where you would look for any OpenID extension responses included  
                        // in the authentication assertion.  
                        // var extension = openid.Response.GetExtension<someextensionresponsetype>();  
                        string email = "";
                        string alias = "";

                        ClaimsResponse fetch = openid.Response.GetExtension(typeof(ClaimsResponse)) as ClaimsResponse;
                        alias = fetch.Nickname;
                        email = fetch.Email; 

                        if (string.IsNullOrEmpty(alias))
                            alias = openid.Response.ClaimedIdentifier;
                        if (string.IsNullOrEmpty(email))
                            email = openid.Response.ClaimedIdentifier;

                        //Now see if the user already exists, if not create them
                        if (Membership.GetUser(openid.Response.ClaimedIdentifier) == null)
                        {
                            MembershipCreateStatus membershipCreateStatus;
                            MembershipUser user = Membership.CreateUser(openid.Response.ClaimedIdentifier, Common.GetRandomString(5,7), email, "This is an OpenID account. What nickname did you supply?", alias, true, out membershipCreateStatus);
                            if (membershipCreateStatus != MembershipCreateStatus.Success) {
                                loginFailedLabel.Text += ": Unsuccessful creation of Account: " +
                                                         membershipCreateStatus.ToString();
                                loginFailedLabel.Visible = true;
                                break;
                            }
                            user.Comment = alias;
                            Membership.UpdateUser(user);
                        }
                        // Use FormsAuthentication to tell ASP.NET that the user is now logged in,  
                        // with the OpenID Claimed Identifier as their username. 
                        FormsAuthentication.RedirectFromLoginPage(openid.Response.ClaimedIdentifier, chkRememberMe.Checked);
                        break;
                    case AuthenticationStatus.Canceled:
                        loginCanceledLabel.Visible = true;
                        break;
                    case AuthenticationStatus.Failed:
                        loginFailedLabel.Visible = true;
                        break;
                        // We don't need to handle SetupRequired because we're not setting  
                        // IAuthenticationRequest.Mode to immediate mode.  
                        //case AuthenticationStatus.SetupRequired:  
                        //    break;  
                }
            }
        }

        protected void openidValidator_ServerValidate(object source, ServerValidateEventArgs args) {
            // This catches common typos that result in an invalid OpenID Identifier.  
            args.IsValid = Identifier.IsValid(args.Value);
        }

        protected void loginButton_Click(object sender, EventArgs e) {
            if (!openidValidator.IsValid) return; // don't login if custom validation failed.  
            OpenIdRelyingParty openid = new OpenIdRelyingParty();
            try {
                IAuthenticationRequest request = openid.CreateRequest(openid_identifier.Text);
                // Send your visitor to their Provider for authentication.  
                ClaimsRequest fetch = new ClaimsRequest();
                fetch.Nickname = DemandLevel.Require;
                fetch.Email = DemandLevel.Require;
                request.AddExtension(fetch);
                request.RedirectToProvider();
            } catch (OpenIdException ex) {
                // The user probably entered an Identifier that   
                // was not a valid OpenID endpoint.  
                openidValidator.Text = ex.Message;
                openidValidator.IsValid = false;
            }
        }     
    
    }
}