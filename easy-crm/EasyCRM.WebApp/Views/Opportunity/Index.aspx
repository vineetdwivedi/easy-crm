<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<EasyCRM.Model.Domains.Opportunity>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    All Opportunities
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        All Opportunities</h2>
    <p>
        Number of Opportunities Found: <b>
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
                Amount
            </th>
            <th>
                Status
            </th>
            <th>
                Description
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.ActionLinkWithImage("Edit", "Edit", "../../Content/Images/edit.png", new { id=item.Id }) %>
                |
                <%: Html.ActionLink("Details", "Details", new { id=item.Id })%>
                |
                <%: Html.ActionLinkWithImage("Delete", "Delete", "../../Content/Images/delete.png", new { id = item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Amount) %>
            </td>
            <td>
                <%: item.Status %>
            </td>
            <td>
                <%: Html.Truncate(item.Description, 30) %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
