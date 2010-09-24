<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.WebApp.ViewModels.OpportunityViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit Opportunity
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <h2>
        <img src="../../Content/Images/edit.png" />Edit Opportunity</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true, "The modification of the opportunity was unsuccessful. Please, correct the errors and try again.")%>
    <fieldset>
        <legend>Opportunity Information</legend>
        <%: Html.EditorFor(model => model.Opportunity, new { Statuses = Model.Statuses, Accounts = Model.Accounts }) %>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to all Opportunities", "Index") %>
    </div>
</asp:Content>
