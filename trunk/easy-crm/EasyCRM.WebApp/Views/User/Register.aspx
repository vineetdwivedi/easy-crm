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
                <%: Html.EditorFor( model => model, new { DisabledUserName = false}) %>
            <p>
                <input type="submit" value="Register" />
            </p>
        </fieldset>
    </div>
    <% } %>
</asp:Content>
