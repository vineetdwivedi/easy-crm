<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.Model.Domains.Account>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Account Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Account Details</h2>
    <p>
        <%: Html.ActionLink("Add a Task", "AddTask", new { id = Model.Id })%>
        |
        <%: Html.ActionLink("Add a Contact", "AddContact", new { id = Model.Id })%>
    </p>
    <fieldset>
        <legend>Account Information</legend>
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
                    Name
                </td>
                <td class="display-field">
                    <%: Model.Name %>
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
                    Description
                </td>
                <td class="display-field">
                    <%: Model.Description %>
                </td>
            </tr>
            <tr>
                <td class="display-label">
                    Type
                </td>
                <td class="display-field">
                    <%: Model.Type %>
                </td>
            </tr>
            <tr>
                <td class="display-label">
                    Industrial Sector
                </td>
                <td class="display-field">
                    <%: Model.IndustrialSector.Sector %>
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
            <tr>
                <td class="display-label">
                    Contacts
                </td>
                <td class="display-field">
                    <% foreach (var contact in Model.Contacts)
                       {%>
                    <%: Html.ActionLink(contact.LastName + " " + contact.FirstName,"Details","Contact", new{ id=contact.Id},null) %>
                    |
                    <%} %>
                </td>
            </tr>
            <tr>
                <td class="display-label">
                    Opportunities
                </td>
                <td class="display-field">
                    <% foreach (var opp in Model.Opportunities)
                       {%>
                    <%: Html.ActionLink(opp.Description, "Details", "Opportunity", new { id = opp.Id }, null)%>
                    |
                    <%} %>
                </td>
            </tr>
        </table>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %>
        |
        <%: Html.ActionLink("Back to all Accounts", "Index") %>
    </p>
</asp:Content>
