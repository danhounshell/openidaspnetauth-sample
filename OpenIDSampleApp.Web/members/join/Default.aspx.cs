using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace OpenIDSampleApp.Web {
    public partial class JoinDefault : Page {

      protected void Page_Load(object sender, EventArgs e) {

          if (HttpContext.Current.User.Identity.IsAuthenticated)
           {
               lblJoined.Visible = true;
               pnlJoin.Visible = false;
               pnlOpenIdLogin.Visible = false;
           }

      }

   }
}
