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
                <%: item.LastName %>
            </td>
            <td>
                <%: item.FirstName %>
            </td>
            <td>
                <%: item.Address %>
            </td>
            <td>
                <%: item.Status %>
            </td>
            <td>
                <%: item.Email %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
