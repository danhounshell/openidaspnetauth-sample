using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace OpenIDSampleApp.Web {
    public partial class LogoutDefault : Page {

      protected void Page_Load(object sender, EventArgs e) {

          FormsAuthentication.SignOut();

           if (Request.QueryString["returnurl"] != null) {
               Response.Redirect(Request.QueryString["returnurl"].ToString());
           } else {
               Response.Redirect("/");
           }

      }

   }
}
