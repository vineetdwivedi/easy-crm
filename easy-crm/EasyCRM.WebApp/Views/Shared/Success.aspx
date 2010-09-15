<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Success
</asp:Content>
<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="infobox">
        <h2>
            <img src="../../Content/Images/success.png" />Your operation was successfully performed!</h2>
    </div>
    <div>
        <%: Html.ActionLink("Back to Home", "Index","Home") %>
    </div>
</asp:Content>
