<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EasyCRM.Model.Domains.Contact>" %>
<table class="editor-table">
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.LastName) %>
        </td>
        <td class="editor-field">
            <%: Html.TextBoxFor(model => model.LastName) %>
            <%: Html.ValidationMessageFor(model => model.LastName) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.FirstName) %>
        </td>
        <td class="editor-field">
            <%: Html.TextBoxFor(model => model.FirstName) %>
            <%: Html.ValidationMessageFor(model => model.FirstName) %>
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
            <%: Html.LabelFor(model => model.Status) %>
        </td>
        <td class="editor-field">
            <%: Html.DropDownListFor(model => model.Status, ViewData["Statuses"] as SelectList) %>
            <%: Html.ValidationMessageFor(model => model.Status) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.Email) %>
        </td>
        <td class="editor-field">
            <%: Html.TextBoxFor(model => model.Email) %>
            <%: Html.ValidationMessageFor(model => model.Email) %>
        </td>
    </tr>
</table>
