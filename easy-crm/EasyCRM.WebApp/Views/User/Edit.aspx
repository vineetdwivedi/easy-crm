<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.Model.Domains.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit Profile
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <h2>
        <img src="../../Content/Images/edit.png" />Edit Profile
    </h2>
    <p>
        Passwords are required to be a minimum of <b>
            <%: ViewData["PasswordLength"] %></b> characters in length.
    </p>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true, "The modification of the profile was unsuccessful. Please, correct the errors and try again.")%>
    <fieldset>
        <legend>User Information</legend>
            <%: Html.EditorFor( model => model, new { DisabledUserName = true}) %>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
</asp:Content>
