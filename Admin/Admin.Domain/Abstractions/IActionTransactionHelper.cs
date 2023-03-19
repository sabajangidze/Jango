using Microsoft.AspNetCore.Mvc.Filters;

namespace Admin.Domain.Abstractions;

public  interface IActionTransactionHelper
{
    void BeginTransaction();

    void EndTransaction(ActionExecutedContext filterContext);

    void CloseSession();
}
