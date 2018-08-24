using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Logger.WebApp.Helpers
{
    public static class CustomHtmlHelpers
    {
        public static string TruncateByLength(this HtmlHelper helper, string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }

        public static string DateFormatt(this DateTime? date, string format = "", string _default = "")
        {
            if (date == null) return _default;
            return format != String.Empty ? date.Value.ToString(format) : date.Value.ToShortDateString();
        }

        public static string GetFieldName<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            return helper.ViewData.TemplateInfo.GetFieldName(expression);
        }

        public static string GetFieldId<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            return helper.ViewData.TemplateInfo.GetFieldId(expression);
        }

        public static string GetFieldName<TModel, TProperty>(this TemplateInfo templateInfo, Expression<Func<TModel, TProperty>> expression)
        {
            return templateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
        }

        public static string GetFieldId<TModel, TProperty>(this TemplateInfo templateInfo, Expression<Func<TModel, TProperty>> expression)
        {
            return templateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression));
        }

        public static RouteValueDictionary AddAttributesIf(this object htmlAttributes, bool condition, object htmlAddAttr)
        {
            RouteValueDictionary attributesAux = new RouteValueDictionary(htmlAttributes);
            RouteValueDictionary attributes = new RouteValueDictionary();

            //replace '_' to '-'
            foreach (var a in attributesAux)
                if (a.Key.Contains("_"))
                    attributes.Add(a.Key.Replace('_', '-'), a.Value);
                else
                    attributes.Add(a.Key, a.Value);

            if (condition)
            {
                RouteValueDictionary addAttr = new RouteValueDictionary(htmlAddAttr);
                foreach (var item in addAttr)
                {
                    attributes.Add(item.Key.Replace("_", "-"), item.Value); ;
                }
            }
            return attributes;
        }

        public static string GetPathStyle(this HtmlHelper helper, string subpath, string stylename)
        {
            subpath = subpath != "" ? "/" + subpath : "";
            string pathscript = String.Format("{0}/Static/css{1}/{2}.css?v={3}", WebConfig.VirtualPath, subpath, stylename, Params.SysVersion);
            return pathscript;
        }

        public static string GetPathScript(this HtmlHelper helper, string subpath, string scriptname)
        {
            subpath = subpath != "" ? "/" + subpath : "";
            string pathscript = String.Format("{0}/Static/js{1}/{2}.js?v={3}", WebConfig.VirtualPath, subpath, scriptname, Params.SysVersion);
            return pathscript;
        }

        public static string GetPathScriptController(this HtmlHelper helper, string scriptname = "", bool flagshared = false)
        {
            string pathscript = string.Empty;
            string area = (helper.ViewContext.RouteData.DataTokens["area"] ?? "").ToString();
            area = area != "" ? "/Areas/" + area : "";
            string controller = helper.ViewContext.RouteData.GetRequiredString("controller");
            string action = scriptname == "" ? helper.ViewContext.RouteData.GetRequiredString("action") : scriptname;

            if (!flagshared)
            {
                pathscript = String.Format("{0}/Static/js/Controllers{1}/{2}/{3}.js?v={4}", WebConfig.VirtualPath, area, controller, action, Params.SysVersion);
            }
            else
            {
                pathscript = String.Format("{0}/Static/js/Controllers{1}/Shared/{2}.js?v={3}", WebConfig.VirtualPath, area, scriptname, Params.SysVersion);
            }

            return pathscript;
        }

        public static string GetPathImg(this HtmlHelper helper, string subpath, string image)
        {
            subpath = subpath != "" ? "/" + subpath : "";
            string pathscript = String.Format("{0}/Static/img{1}/{2}", WebConfig.VirtualPath, subpath, image);
            return pathscript;
        }

        public static string GetActionUrl(this HtmlHelper helper, string action, params string[] arrayqueries)
        {
            string area = (helper.ViewContext.RouteData.DataTokens["area"] ?? "").ToString();
            area = area != "" ? "/" + area : "";
            string controller = helper.ViewContext.RouteData.GetRequiredString("controller");
            string querystr = string.Empty;
            if (arrayqueries.Length > 0)
            {
                querystr = "?" + String.Join("&", arrayqueries);
            }
            string urlaction = String.Format(@"{0}{1}/{2}/{3}{4}", WebConfig.VirtualPath, area, controller, action, querystr);
            return urlaction;
        }

        public static string GetActionUrlGen(this HtmlHelper helper, string action, string controller = "", string area = "", params string[] arrayqueries)
        {
            area = area != "" ? "/" + area : "";
            controller = controller != "" ? "/" + controller : "";
            string querystr = string.Empty;
            if (arrayqueries.Length > 0)
            {
                querystr = "?" + String.Join("&", arrayqueries);
            }

            string urlaction = String.Format(@"{0}{1}{2}/{3}{4}", WebConfig.VirtualPath, area, controller, action, querystr);
            return urlaction;
        }


    }
}