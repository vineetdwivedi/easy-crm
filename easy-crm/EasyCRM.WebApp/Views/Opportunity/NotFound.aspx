<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Opportunity Not Found
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Opportunity Not Found</h2>
    <p>
        Sorry, but the opportunity you requested doesn't exist or was deleted.</p>
    <div>
        <%: Html.ActionLink("Back to all Opportunities", "Index") %>
    </div>
</asp:Content>
