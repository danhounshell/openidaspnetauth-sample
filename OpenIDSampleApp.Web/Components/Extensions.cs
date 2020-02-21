using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace OpenIDSampleApp.Components {
    public static class Extensions {

        public static string DisplayName(this MembershipUser user)
        {
            string retval = user.UserName;
            if (user != null) {
                if (!string.IsNullOrEmpty(user.Comment)) {
                    retval = user.Comment;
                }
            }
            return retval;
        }

    }
}
