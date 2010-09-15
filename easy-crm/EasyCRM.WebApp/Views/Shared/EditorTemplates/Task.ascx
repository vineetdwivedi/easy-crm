<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EasyCRM.Model.Domains.Task>" %>

<table class="editor-table">
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.Subject) %>
        </td>
        <td class="editor-field">
            <%: Html.TextAreaFor(model => model.Subject, new { cols="24", rows = "4"}) %>
            <%: Html.ValidationMessageFor(model => model.Subject) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.Status) %>
        </td>
        <td class="editor-field">
            <%: Html.DropDownList("Status", ViewData["Statuses"] as SelectList) %>
            <%: Html.ValidationMessageFor(model => model.Status) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.StartDate) %>
        </td>
        <td class="editor-field">
            <%: Html.TextBoxFor(model => model.StartDate, String.Format("{0:g}", Model.StartDate), (bool)ViewData["DisabledDates"]) %>
            <%: Html.ValidationMessageFor(model => model.StartDate) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.LimitDate) %>
        </td>
        <td class="editor-field">
            <%: Html.TextBoxFor(model => model.LimitDate, String.Format("{0:g}", Model.LimitDate), (bool)ViewData["DisabledDates"]) %>
            <%: Html.ValidationMessageFor(model => model.LimitDate) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.EndDate) %>
        </td>
        <td class="editor-field">
            <%: Html.TextBoxFor(model => model.EndDate, String.Format("{0:g}", Model.EndDate), (bool)ViewData["DisabledDates"]) %>
            <%: Html.ValidationMessageFor(model => model.EndDate) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.Priority) %>
        </td>
        <td class="editor-field">
            <%: Html.DropDownList("Priority", ViewData["Priorities"] as SelectList) %>
            <%: Html.ValidationMessageFor(model => model.Priority) %>
        </td>
    </tr>
</table>
