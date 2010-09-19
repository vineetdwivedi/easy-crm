<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EasyCRM.Model.Domains.Opportunity>" %>
<table class="editor-table">
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.Amount) %>
        </td>
        <td class="editor-field">
            <%: Html.TextBoxFor(model => model.Amount) %>
            <%: Html.ValidationMessageFor(model => model.Amount) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.Status) %>
        </td>
        <td class="editor-field">
            <%: Html.DropDownListFor(model => model.Status, ViewData["Statuses"] as SelectList)%>
            <%: Html.ValidationMessageFor(model => model.Status) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.Account) %>
        </td>
        <td class="editor-field">
            <%: Html.DropDownList("AccountId", ViewData["Accounts"] as SelectList)%>
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
</table>
