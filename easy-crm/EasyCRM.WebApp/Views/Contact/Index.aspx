<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<EasyCRM.Model.Domains.Contact>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    All Contacts
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        All Contacts</h2>
    <p>
        Number of Contacts Found: <b>
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
                Last Name
            </th>
            <th>
                First Name
            </th>
            <th>
                Address
            </th>
            <th>
                Status
            </th>
            <th>
                Email
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
                <%: item.LastName %>
            </td>
            <td>
                <%: item.FirstName %>
            </td>
            <td>
                <%: Html.Truncate(item.Address, 30) %>
            </td>
            <td>
                <%: item.Status %>
            </td>
            <td>
                <%: Html.Truncate(item.Email, 30) %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
