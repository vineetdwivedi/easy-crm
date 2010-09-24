<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.WebApp.ViewModels.AccountViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create a new Account
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <h2>
        Create a new Account</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true, "The creation of the account was unsuccessful. Please, correct the errors and try again.")%>
    <fieldset>
        <legend>Account Information</legend>
        <%: Html.EditorFor(model => model.Account,
                              new { Sectors = Model.Sectors, Types = Model.Types})%>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to all Accounts", "Index") %>
    </div>
</asp:Content>
