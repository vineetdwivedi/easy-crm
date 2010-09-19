<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <span class="green"><%: Page.User.Identity.Name %></span>! &nbsp;&nbsp;
        [ <%: Html.ActionLink("Profile", "Edit", "User", new { userName = Page.User.Identity.Name },null)%> ]
        [ <%: Html.ActionLink("Log Off", "LogOff", "User") %> ]
<%
    }
    else {
%> 
        [  <%: Html.ActionLinkWithImage("Log On", "LogOn", "User","../../../Content/Images/key.png") %> ]
<%
    }
%>
