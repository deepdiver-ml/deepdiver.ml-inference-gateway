using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace deepdiver.UI.Controllers.Lib {
public class UniqueSession : Attribute, IActionFilter {
        public void OnActionExecuting(ActionExecutingContext context) {
            String sessionId = Guid.NewGuid().ToString("N");

            var controller = context.Controller as Controller;
            var field = context.Controller.GetType().GetField("SessionId");

            if (field is not  null) {
                field.SetValue(controller, sessionId);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) {}
    }
}