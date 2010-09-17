<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.WebApp.ViewModels.AddContactViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Add a Contact to the Account
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Add a Contact to the Account</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Contacts</legend>
        <table class="editor-table">
            <tr>
                <td class="editor-label">
                    <%: Html.LabelFor(model => model.ContactId) %>
                </td>
                <td class="editor-field">
                    <%: Html.DropDownListFor(model => model.ContactId, Model.Contacts)%>
                </td>
            </tr>
        </table>
        <p>
            <input type="submit" value="Add" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to all Accounts", "Index") %>
    </div>
</asp:Content>
