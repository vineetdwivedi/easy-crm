<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.Model.Domains.Opportunity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Opportunity Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Opportunity Details</h2>
    <fieldset>
        <legend>Opportunity Information</legend>
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
                    Amount
                </td>
                <td class="display-field">
                    <%: String.Format("{0:F}", Model.Amount) %>
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
                    Account
                </td>
                <td class="display-field">
                    <%: Model.Account.Name %>
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
        </table>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %>
        |
        <%: Html.ActionLink("Back to all Opportunities", "Index") %>
    </p>
</asp:Content>
