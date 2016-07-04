using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace WebDeveloper.Helpers
{
    public static class CustomHelper
    {
        public static IHtmlString DisplayIntegerExtension(this HtmlHelper helper, string tag, double? value)
        {
            return new HtmlString($"<{tag}>{((value == null) ? "0.00" : value.ToString())}</{tag}>");
        }

        public static IHtmlString DisplayStringExtension(this HtmlHelper helper, string tag, string value)
        {
            return new HtmlString($"<{tag}>{value}</{tag}>");
        }

        private static string GetDateTime(DateTime? tDate)
        {
            return (tDate == null) ? "none" : tDate.Value.ToString("dd/MM/yyyy");
        }

        public static IHtmlString DisplayDateOrNullExtension(this HtmlHelper helper, string tag, DateTime? tDate)
        {
            return new HtmlString($"<{tag}>{GetDateTime(tDate)}</{tag}>"); 
        }
        
    }
}