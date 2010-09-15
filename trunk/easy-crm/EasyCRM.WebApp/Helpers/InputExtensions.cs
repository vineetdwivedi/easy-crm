using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Html;

namespace EasyCRM.WebApp.Helpers
{
    public static class InputExtensions
    {
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                                                                    Expression<Func<TModel, TProperty>> expression,
                                                                    object htmlAttributes, bool disabled)
        {
            var values = new RouteValueDictionary(htmlAttributes);
            // might want to just set this rather than Add() since "disabled" might be there already
            if (disabled) values["disabled"] = "disabled";

            return htmlHelper.TextBoxFor<TModel, TProperty>(expression, values);
        }

    }
}