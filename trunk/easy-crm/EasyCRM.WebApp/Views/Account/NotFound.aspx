<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Account Not Found
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Account Not Found</h2>
    <p>
        Sorry, but the account you requested doesn't exist or was deleted.</p>
    <div>
        <%: Html.ActionLink("Back to all Accounts", "Index") %>
    </div>
</asp:Content>
