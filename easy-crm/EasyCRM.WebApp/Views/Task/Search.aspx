<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.WebApp.ViewModels.SearchTaskViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Search
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Search Tasks</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Search Criteria</legend>
        <table class="editor-table">
            <tr>
                <td class="editor-label">
                    Status
                </td>
                <td class="editor-field">
                    <%: Html.DropDownList("Status", Model.Statuses) %>
                </td>
            </tr>
            <tr>
                <td class="editor-label">
                    Priority
                </td>
                <td class="editor-field">
                    <%: Html.DropDownList("Priority", Model.Priorities) %>
                </td>
            </tr>
        </table>
        <p>
            <input type="submit" value="Go" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to all Tasks", "Index") %>
    </div>
</asp:Content>
