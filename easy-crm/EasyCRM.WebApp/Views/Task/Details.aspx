<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.Model.Domains.Task>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Task Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Task Details</h2>

    <fieldset>
        <legend>Task Information</legend>
        <table class="display-table">
			<tr>
				<td class="display-label">Id</td>
				<td class="display-field"><%: Model.Id %></td>
			</tr>
			<tr>
				<td class="display-label">Subject</td>
				<td class="display-field"><%: Model.Subject %></td>
			</tr>
			<tr>
				<td class="display-label">Status</td>
				<td class="display-field"><%: Model.Status %></td>
			</tr>
			<tr>
				<td class="display-label">Start Date</td>
				<td class="display-field"><%: String.Format("{0:g}", Model.StartDate) %></td>
			</tr>
			<tr>
				<td class="display-label">Limit Date</td>
				<td class="display-field"><%: String.Format("{0:g}", Model.LimitDate) %></td>
			</tr>
			<tr>
				<td class="display-label">End Date</td>
				<td class="display-field"><%: String.Format("{0:g}", Model.EndDate) %></td>
			</tr>
			<tr>
				<td class="display-label">Priority</td>
				<td class="display-field"><%: Model.Priority %></td>
			</tr>
		</table>
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
        <%: Html.ActionLink("Back to all Tasks", "Index") %>
    </p>

</asp:Content>

