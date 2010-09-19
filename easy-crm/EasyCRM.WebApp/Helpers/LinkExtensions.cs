using System.Web.Mvc;
using System.Web.Mvc.Html;
using System;
using System.Text.RegularExpressions;

namespace EasyCRM.WebApp.Helpers
{
    public static class LinkExtensions
    {

        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string imageUrl)
        {
            return htmlHelper.ActionLinkWithImage(linkText, actionName, controllerName, imageUrl, linkText, true, null);
        }
        
        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper htmlHelper, string linkText, string actionName, string imageUrl, object routeValues)
        {
            return htmlHelper.ActionLinkWithImage(linkText, actionName, null, imageUrl, linkText, true, routeValues);
        }

        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string imageUrl, object routeValues)
        {
            return htmlHelper.ActionLinkWithImage(linkText, actionName, controllerName, imageUrl, linkText, true , routeValues);
        }

        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string imageUrl, string imageAltText,bool imageBeforeText, object routeValues)
        {

            string link = htmlHelper.ActionLink(linkText, actionName, controllerName,routeValues,null).ToString();

            string pattern = "(<a[^>]+>)(.+?)(</a>)"; 

            //we build the image tag
            TagBuilder builder = new TagBuilder("img");
            // Add attributes
            builder.MergeAttribute("src", imageUrl);
            builder.MergeAttribute("alt", imageAltText);

            string imgTag = builder.ToString(TagRenderMode.SelfClosing);

            if (imageBeforeText)
                link = Regex.Replace(link, pattern, "$1" + imgTag + "$2$3"); //$1 = <a ....>, $3= </a>, $2 = whatever inside $1 & $2,
            else
                link = Regex.Replace(link, pattern,  "$1$2" + imgTag +"$3");

            return  MvcHtmlString.Create(link);
        }

    }
}