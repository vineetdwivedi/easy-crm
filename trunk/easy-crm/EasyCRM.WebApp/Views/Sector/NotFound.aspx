<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Sector Not Found
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Sector Not Found</h2>
    <p>
        Sorry, but the sector you requested doesn't exist or was deleted.</p>
    <div>
        <%: Html.ActionLink("Back to all Sectors", "Index") %>
    </div>
</asp:Content>
