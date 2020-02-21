using System;
using System.Web;
using System.Web.UI;

namespace OpenIDSampleApp.Web {
    public partial class LoginDefault : Page {

       protected override void OnInit(EventArgs e) {
           base.OnInit(e);
           ctlLogin.LoggedIn += new EventHandler(ctlLogin_LoggedIn);
       }

        protected void Page_Load(object sender, EventArgs e) {
           if (HttpContext.Current.User.Identity.IsAuthenticated) {
               lblLoggedIn.Visible = true;
               pnlLogin.Visible = false;
               pnlOpenIdLogin.Visible = false;
           } 
        }  

       void ctlLogin_LoggedIn(object sender, EventArgs e) {
           if (Request.QueryString["returnurl"] != null)
           {
               Response.Redirect(Request.QueryString["returnurl"].ToString());
           } else
           {
               Response.Redirect("/");
           }
       }

   }
}
