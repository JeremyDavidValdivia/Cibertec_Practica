using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDeveloper.ActionFilters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        private object GetValues(RouteData rd, string field)
        {
            return rd.Values[field];
        }

        private object GetMessage(string strMessage, RouteData rd)
        {
            return $"Action Filter Log: {strMessage} Controller: {GetValues(rd, "controller")} action: {GetValues(rd, "action")}";
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            /* Aqui podemos poner código para validar si hay algun tipo de ataque */
            Debug.WriteLine(GetMessage("OnActionExecuting", filterContext.RouteData));
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine(GetMessage("OnActionExecuted", filterContext.RouteData));
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Debug.WriteLine(GetMessage("OnResultExecuting", filterContext.RouteData));
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debug.WriteLine(GetMessage("OnResultExecuted", filterContext.RouteData));
        }
    }
}