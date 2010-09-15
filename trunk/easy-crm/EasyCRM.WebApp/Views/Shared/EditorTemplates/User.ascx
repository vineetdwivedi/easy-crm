<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EasyCRM.Model.Domains.User>" %>
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
            <%: Html.LabelFor(model => model.UserName) %>
        </td>
        <td class="editor-field">
            <%: Html.TextBoxFor(model => model.UserName, null, (bool) ViewData["DisabledUserName"]) %>
            <%: Html.ValidationMessageFor(model => model.UserName) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.Password) %>
        </td>
        <td class="editor-field">
            <%: Html.PasswordFor(model => model.Password, new { value = (Model == null) ? "" : Model.Password})%>
            <%: Html.ValidationMessageFor(model => model.Password) %>
        </td>
    </tr>
    <tr>
        <td class="editor-label">
            <%: Html.LabelFor(model => model.ConfirmPassword) %>
        </td>
        <td class="editor-field">
            <%: Html.PasswordFor(model => model.ConfirmPassword, new { value = (Model == null) ? "" : Model.Password})%>
            <%: Html.ValidationMessageFor(model => model.ConfirmPassword) %>
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
