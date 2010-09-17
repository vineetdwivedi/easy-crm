<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.WebApp.ViewModels.AddTaskViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add a Task to the Contact
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add a Task to the Contact</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Tasks</legend>
            <table class="editor-table">
				<tr>
					<td class="editor-label">
						<%: Html.LabelFor(model => model.TaskId) %>
					</td>
					<td class="editor-field">
						<%: Html.DropDownListFor(model => model.TaskId, Model.Tasks)%>
					</td>
				</tr>
            </table>
			<p>
                <input type="submit" value="Add" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to Contact", "Details") %>
    </div>

</asp:Content>

