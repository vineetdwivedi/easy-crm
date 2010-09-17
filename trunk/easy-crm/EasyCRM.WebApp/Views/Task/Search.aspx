<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.WebApp.ViewModels.SearchTaskViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Search Tasks
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
                   <%: Html.LabelFor(model => model.Status) %>
                </td>
                <td class="editor-field">
                    <%: Html.DropDownListFor(model => model.Status, Model.Statuses)%>
                </td>
            </tr>
            <tr>
                <td class="editor-label">
                   <%: Html.LabelFor(model => model.Priority) %>
                </td>
                <td class="editor-field">
                    <%: Html.DropDownListFor(model => model.Priority, Model.Priorities)%>
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
