<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.Model.Domains.Contact>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Contact Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Contact Details</h2>
    <p>
        <%: Html.ActionLink("Add a Task", "AddTask", new { id = Model.Id })%></p>
    <fieldset>
        <legend>Contact Information</legend>
        <table class="display-table">
            <tr>
                <td class="display-label">
                    Id
                </td>
                <td class="display-field">
                    <%: Model.Id %>
                </td>
            </tr>
            <tr>
                <td class="display-label">
                    Last Name
                </td>
                <td class="display-field">
                    <%: Model.LastName %>
                </td>
            </tr>
            <tr>
                <td class="display-label">
                    First Name
                </td>
                <td class="display-field">
                    <%: Model.FirstName %>
                </td>
            </tr>
            <tr>
                <td class="display-label">
                    Address
                </td>
                <td class="display-field">
                    <%: Model.Address %>
                </td>
            </tr>
            <tr>
                <td class="display-label">
                    Status
                </td>
                <td class="display-field">
                    <%: Model.Status %>
                </td>
            </tr>
            <tr>
                <td class="display-label">
                    Email
                </td>
                <td class="display-field">
                    <%: Model.Email %>
                </td>
            </tr>
            <tr>
                <td class="display-label">
                    Tasks
                </td>
                <td class="display-field">
                    <% foreach (var task in Model.Tasks)
                       {%>
                    <%: Html.ActionLink(task.Subject,"Details","Task", new{ id=task.Id},null) %>
                    |
                    <%} %>
                </td>
            </tr>
        </table>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %>
        |
        <%: Html.ActionLink("Back to all Contacts", "Index") %>
    </p>
</asp:Content>
