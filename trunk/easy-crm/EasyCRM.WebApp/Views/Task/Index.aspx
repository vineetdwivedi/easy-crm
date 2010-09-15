<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<EasyCRM.Model.Domains.Task>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    All Tasks
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        All Tasks</h2>
    <p>
        Number of Tasks Found: <b>
            <%: Model.Count() %></b></p>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
        |
        <%: Html.ActionLink("Search ...", "Search") %>
    </p>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Id
            </th>
            <th>
                Subject
            </th>
            <th>
                Status
            </th>
            <th>
                Start Date
            </th>
            <th>
                Limit Date
            </th>
            <th>
                End Date
            </th>
            <th>
                Priority
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %>
                |
                <%: Html.ActionLink("Details", "Details", new { id=item.Id })%>
                |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Subject %>
            </td>
            <td>
                <%: item.Status %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.StartDate) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.LimitDate) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.EndDate) %>
            </td>
            <td>
                <%: item.Priority %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
