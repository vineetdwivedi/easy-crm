<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EasyCRM.Model.Domains.Account>" %>
<table class="editor-table">
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.Name) %>
        </td>
        <td class="editor-field">
            <%: Html.TextBoxFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.Type) %>
        </td>
        <td class="editor-field">
            <%: Html.DropDownList("Type", ViewData["Types"] as SelectList) %>
            <%: Html.ValidationMessageFor(model => model.Type) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.Address) %>
        </td>
        <td class="editor-field">
            <%: Html.TextAreaFor(model => model.Address, new { cols="24", rows = "2"}) %>
            <%: Html.ValidationMessageFor(model => model.Address) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.Description) %>
        </td>
        <td class="editor-field">
            <%: Html.TextAreaFor(model => model.Description, new { cols="24", rows = "4"}) %>
            <%: Html.ValidationMessageFor(model => model.Description) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.IndustrialSector) %>
        </td>
        <td class="editor-field">
            <%: Html.DropDownList("SectorId", ViewData["Sectors"] as SelectList)%>
            <%: Html.ValidationMessageFor(model => model.Type) %>
        </td>
    </tr>
</table>
