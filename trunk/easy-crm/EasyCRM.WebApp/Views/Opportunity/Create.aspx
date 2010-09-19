<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.WebApp.ViewModels.OpportunityViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create a new Opportunity
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <h2>
        Create a new Opportunity</h2>
    <% using (Html.BeginForm()) {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Opportunity Information</legend>
        <%: Html.EditorFor( model => model.Opportunity, new { Statuses = Model.Statuses, Accounts = Model.Accounts} ) %>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to all Opportunities", "Index")%>
    </div>
</asp:Content>
