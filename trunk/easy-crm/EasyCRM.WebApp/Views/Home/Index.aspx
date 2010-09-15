<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome on EasyCRM!</h2>
    <p style="text-align:justify;">
        <span class="green">EasyCRM</span> is a complete application that provides you with the most commons <b><acronym title="Customer Relationship Management">CRM</acronym></b> softwares' functionalities.
         This application is composed of two interfaces. The first, for Salespeople (who are nomadic) is based on a thin client (your web browser).
         Basically, the goal of this interface is to allow Commercials to record their activities and record as much information about customers
         wherever they are. The second interface is a thick client for the Head Commercial (sedentary by nature) which oversees all business.
         Its goal is to have an overview of the business.
    </p>

    <p>Yes, you've got it, your are on the first interface! It lets you create, edit, delete an account, task, contact, opportunity, etc. </p>
    <p>To start, click on the item that interest you in the top navigation bar, and let's goooooooo! <img src="../../Content/Images/car.png" alt="Let's go!"/></p>   
    
</asp:Content>
