<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.DateTime?>" %>
<%= Html.TextBox("", Model.HasValue ? String.Format("{0:g}", Model.Value) : string.Empty) %>

