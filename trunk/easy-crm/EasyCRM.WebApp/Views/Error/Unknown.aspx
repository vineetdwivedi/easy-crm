<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Unknown Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Unknown Page</h2>
    <div class="errorbox">
        <%: Response.StatusCode %>
    </div>

    <%:Html.ActionLink("Back to Home","Index") %>
</asp:Content>
