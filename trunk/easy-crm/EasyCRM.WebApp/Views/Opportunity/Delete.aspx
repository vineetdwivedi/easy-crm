<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.Model.Domains.Opportunity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete  Opportunity
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        <img src="../../Content/Images/delete.png" />Delete Opportunity</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Opportunity Information</legend>
        <table class="display-table">
			<tr>
				<td class="display-label">Id</td>
				<td class="display-field"><%: Model.Id %></td>
			</tr>
			<tr>
				<td class="display-label">Amount</td>
				<td class="display-field"><%: String.Format("{0:F}", Model.Amount) %></td>
			</tr>
			<tr>
				<td class="display-label">Status</td>
				<td class="display-field"><%: Model.Status %></td>
			</tr>
			<tr>
				<td class="display-label">Description</td>
				<td class="display-field"><%: Model.Description %></td>
			</tr>
		</table>
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Back to all Opportunities", "Index")%>
        </p>
    <% } %>

</asp:Content>

