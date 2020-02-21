using System;
using System.Web;
using System.Web.Security;
using OpenIDSampleApp.Components;

namespace OpenIDSampleApp.Web {
   public partial class Site : System.Web.UI.MasterPage {

       protected string GetUserName(string username)
       {
           MembershipUser user = Membership.GetUser(username);
           return user.DisplayName();
       }


   }
}
