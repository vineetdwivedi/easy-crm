<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<EasyCRM.Model.Domains.Account>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    All Accounts
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        All Accounts</h2>
    <p>
        Number of Accounts Found: <b>
            <%: Model.Count() %></b></p>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th>
            </th>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Address
            </th>
            <th>
                Description
            </th>
            <th>
                Type
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
                <%: item.Name %>
            </td>
            <td>
                <%: Html.Truncate(item.Address, 30) %>
            </td>
            <td>
                <%: Html.Truncate(item.Description, 30) %>
            </td>
            <td>
                <%: item.Type %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
