<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.Model.Domains.Contact>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete Contact
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete Contact</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Information</legend>
        <table class="display-table">
			<tr>
				<td class="display-label">Id</td>
				<td class="display-field"><%: Model.Id %></td>
			</tr>
			<tr>
				<td class="display-label">Last Name</td>
				<td class="display-field"><%: Model.LastName %></td>
			</tr>
			<tr>
				<td class="display-label">First Name</td>
				<td class="display-field"><%: Model.FirstName %></td>
			</tr>
			<tr>
				<td class="display-label">Address</td>
				<td class="display-field"><%: Model.Address %></td>
			</tr>
			<tr>
				<td class="display-label">Status</td>
				<td class="display-field"><%: Model.Status %></td>
			</tr>
			<tr>
				<td class="display-label">Email</td>
				<td class="display-field"><%: Model.Email %></td>
			</tr>
		</table>
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Back to all Contacts", "Index") %>
        </p>
    <% } %>

</asp:Content>

