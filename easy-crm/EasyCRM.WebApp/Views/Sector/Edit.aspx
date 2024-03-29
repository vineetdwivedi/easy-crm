﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.Model.Domains.IndustrialSector>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Sector
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <% Html.EnableClientValidation(); %>

    <h2>
        <img src="../../Content/Images/edit.png" />Edit Sector</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true, "The modification of the sector was unsuccessful. Please, correct the errors and try again.")%>
        
        <fieldset>
            <legend>Sector Information</legend>
            <table class="editor-table">
				<tr>
					<td class="editor-label">
						<%: Html.LabelFor(model => model.Sector) %>
					</td>
					<td class="editor-field">
						<%: Html.TextBoxFor(model => model.Sector) %>
						<%: Html.ValidationMessageFor(model => model.Sector) %>
					</td>
				</tr>
			</table>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to all Sectors", "Index") %>
    </div>

</asp:Content>

