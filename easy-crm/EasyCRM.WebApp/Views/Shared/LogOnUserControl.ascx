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
        [ <img src="../../Content/Images/key.png"  alt="Log On"/> <%: Html.ActionLink("Log On", "LogOn", "User") %> ]
<%
    }
%>
