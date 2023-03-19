using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Domain.Abstractions;

public interface IActionTransactionHelper
{
    void BeginTransaction();

    void EndTransaction(ActionExecutedContext filterContext);

    void CloseSession();
}
