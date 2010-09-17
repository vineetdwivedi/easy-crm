<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.Model.Domains.Account>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete Account
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete Account</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Information</legend>
        <table class="display-table">
			<tr>
				<td class="display-label">Id</td>
				<td class="display-field"><%: Model.Id %></td>
			</tr>
			<tr>
				<td class="display-label">Name</td>
				<td class="display-field"><%: Model.Name %></td>
			</tr>
			<tr>
				<td class="display-label">Address</td>
				<td class="display-field"><%: Model.Address %></td>
			</tr>
			<tr>
				<td class="display-label">Description</td>
				<td class="display-field"><%: Model.Description %></td>
			</tr>
			<tr>
				<td class="display-label">Type</td>
				<td class="display-field"><%: Model.Type %></td>
			</tr>
		</table>
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Back to all Accounts", "Index") %>
        </p>
    <% } %>

</asp:Content>

