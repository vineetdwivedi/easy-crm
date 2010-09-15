<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.WebApp.ViewModels.LogOnViewModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Log On</h2>
    <p>
        Please enter your user name and password.
        <%: Html.ActionLink("Register", "Register") %>
        if you don't have an user account.
    </p>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
    <div>
        <fieldset>
            <legend>User Information</legend>
            <table>
                <tr>
                    <td class="editor-label">
                        <%: Html.LabelFor(m => m.UserName) %>
                    </td>
                    <td class="editor-field">
                        <%: Html.TextBoxFor(m => m.UserName) %>
                        <%: Html.ValidationMessageFor(m => m.UserName) %>
                    </td>
                </tr>
                <tr>
                    <td class="editor-label">
                        <%: Html.LabelFor(m => m.Password) %>
                    </td>
                    <td class="editor-field">
                        <%: Html.PasswordFor(m => m.Password) %>
                        <%: Html.ValidationMessageFor(m => m.Password) %>
                    </td>
                </tr>
                <tr>
                    <td class="editor-label">
                        <%: Html.CheckBoxFor(m => m.RememberMe) %>
                        <%: Html.LabelFor(m => m.RememberMe) %>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <p>
                <input type="submit" value="Log On" />
            </p>
        </fieldset>
    </div>
    <% } %>
</asp:Content>
