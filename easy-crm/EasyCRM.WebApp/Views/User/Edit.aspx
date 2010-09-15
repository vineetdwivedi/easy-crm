<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.Model.Domains.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit Profile
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <h2>
        Edit Profile
    </h2>
    <p>
        Passwords are required to be a minimum of <b>
            <%: ViewData["PasswordLength"] %></b> characters in length.
    </p>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>User Information</legend>
        <table class="editor-table">
            <tr>
                <td class="editor-label">
                    <%: Html.LabelFor(model => model.LastName) %>
                </td>
                <td class="editor-field">
                    <%: Html.TextBoxFor(model => model.LastName) %>
                    <%: Html.ValidationMessageFor(model => model.LastName) %>
                </td>
            </tr>
            <tr>
                <td class="editor-label">
                    <%: Html.LabelFor(model => model.FirstName) %>
                </td>
                <td class="editor-field">
                    <%: Html.TextBoxFor(model => model.FirstName) %>
                    <%: Html.ValidationMessageFor(model => model.FirstName) %>
                </td>
            </tr>
            <tr>
                <td class="editor-label">
                    <%: Html.LabelFor(model => model.UserName)%>
                </td>
                <td class="editor-field">
                    <%: Html.TextBoxFor(model => model.UserName, new { disabled = "true" })%>
                    <%: Html.ValidationMessageFor(model => model.UserName) %>
                </td>
            </tr>
            <tr>
                <td class="editor-label">
                    <%: Html.LabelFor(model => model.Password) %>
                </td>
                <td class="editor-field">
                    <%: Html.PasswordFor(model => model.Password, new { value = Model.Password })%>
                    <%: Html.ValidationMessageFor(model => model.Password) %>
                </td>
            </tr>
            <tr>
                <td class="editor-label">
                    <%: Html.LabelFor(model => model.ConfirmPassword) %>
                </td>
                <td class="editor-field">
                    <%: Html.PasswordFor(model => model.ConfirmPassword, new { value = Model.Password })%>
                    <%: Html.ValidationMessageFor(model => model.ConfirmPassword)%>
                </td>
            </tr>
            <tr>
                <td class="editor-label">
                    <%: Html.LabelFor(model => model.Email) %>
                </td>
                <td class="editor-field">
                    <%: Html.TextBoxFor(model => model.Email) %>
                    <%: Html.ValidationMessageFor(model => model.Email) %>
                </td>
            </tr>
        </table>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
</asp:Content>
