<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<EasyCRM.Model.Domains.IndustrialSector>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>All Industrial Sectors</h2>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
	
    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Sector
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Sector %>
            </td>
        </tr>
    
    <% } %>

    </table>


</asp:Content>

