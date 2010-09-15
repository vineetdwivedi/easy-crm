<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.WebApp.ViewModels.TaskViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Task
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>

    <h2>Edit Task</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true,"The modification of the task was unsuccessful. Please, correct the errors and try again.") %>
        
        <fieldset>
            <legend>Task Information</legend>
            <%: Html.EditorFor(model => model.Task,
                  new { Statuses = Model.Statuses, Priorities = Model.Priorities}) %>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to all Tasks", "Index") %>
    </div>

</asp:Content>

