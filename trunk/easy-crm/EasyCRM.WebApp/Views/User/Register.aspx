<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.Model.Domains.User>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>
<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <h2>
        Register</h2>
    <p>
        Use the form below to create your user account.
    </p>
    <p>
        Passwords are required to be a minimum of <b>
            <%: ViewData["PasswordLength"] %></b> characters in length.
    </p>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true, "The user account creation was unsuccessful. Please correct the errors and try again.") %>
    <div>
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
                        <%: Html.LabelFor(model => model.UserName) %>
                    </td>
                    <td class="editor-field">
                        <%: Html.TextBoxFor(model => model.UserName)%>
                        <%: Html.ValidationMessageFor(model => model.UserName) %>
                    </td>
                </tr>
                <tr>
                    <td class="editor-label">
                        <%: Html.LabelFor(model => model.Password) %>
                    </td>
                    <td class="editor-field">
                        <%: Html.PasswordFor(model => model.Password) %>
                        <%: Html.ValidationMessageFor(model => model.Password) %>
                    </td>
                </tr>
                <tr>
                    <td class="editor-label">
                        <%: Html.LabelFor(model => model.ConfirmPassword) %>
                    </td>
                    <td class="editor-field">
                        <%: Html.PasswordFor(model => model.ConfirmPassword)%>
                        <%: Html.ValidationMessageFor(model => model.ConfirmPassword) %>
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
                <input type="submit" value="Register" />
            </p>
        </fieldset>
    </div>
    <% } %>
</asp:Content>
