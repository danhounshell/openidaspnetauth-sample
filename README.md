# openidaspnetauth-sample
An old sample application showing usage of OpenId authentication with ASP.NET Auth

*Note: everything following is from the old readme. Links, sites, etc. may no longer exist or be the same.*

OpenID Sample ASP.NET Web Application

By Dan Hounshell
http://danhounshell.com/blog/sample-openid-web-site/


This is a simple little web site with a login form consisting of built-in ASP.NET membership controls and an OpenID login control that works with ASP.NET membership.


1. In the web.config file set the MembershipConnectionString with a valid connection string to a database setup with ASP.NET Membership (either new or an existing database). 

2. Go to www.idselector.com* and create an account (with your OpenID! or get an OpenID if you do not have one) so that you can get the javascript for your OpenID selector used on the login form. 

3. Once you've created your account and have created your selector, open up the /UserControls/OpenIdLoginForm.ascx page and replace the [GetYourOwnID@idselector.com] text with the guid that you'll see in the javascript that idselector.com provided you.

3. Press F5 and give it a test. Go to the home page, create a new standard user account, logout, create a new user account using your OpenID. See how easy it is to use? Look in the aspnet_membership tables in the database. Check out the code and see how everything works. You'll be using OpenID and the IdSelector in every site you build from now on, won't you?!?!?

Who rocks? It's okay to say it. Oh yeah - right back atcha! 





Note: if you are going to use an existing ASP.NET membership database you may or may not want to update the ApplicationName settings of the Role, Membership and Profile providers to match your existing database.


* - having you sign up at idSelector.com is not a scam of any sort. You will not get spam email because of signing up there. I will not make any money because you signed up there, etc. You can read more about their javascript OpenID selector tool at the following:
http://danhounshell.com/blog/adding-openid-to-your-web-site-in-conjunction-with-asp-net-membership/
http://www.hanselman.com/blog/TheWeeklySourceCode25OpenIDEdition.aspx
