<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EasyCRM.WebApp.ViewModels.ContactViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit Contact
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation();%>
    <h2>
        <img src="../../Content/Images/edit.png" />Edit Contact</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true, "The modification of the contact was unsuccessful. Please, correct the errors and try again.")%>
    <fieldset>
        <legend>Contact Information</legend>
        <%: Html.EditorFor(model => model.Contact, new { Statuses = Model.Statuses }) %>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to all Contacts", "Index") %>
    </div>
</asp:Content>
