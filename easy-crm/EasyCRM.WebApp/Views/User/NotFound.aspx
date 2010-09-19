<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    User Not Found
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        User Not Found</h2>
    <p>
        Sorry, but the user you requested doesn't exist or was deleted.</p>
    <div>
        <%: Html.ActionLink("Back to Home", "Index","Home") %>
    </div>
</asp:Content>
