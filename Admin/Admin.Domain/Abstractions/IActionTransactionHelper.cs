using System.Web.Mvc;

namespace Admin.Domain.Abstractions;

public  interface IActionTransactionHelper
{
    void BeginTransaction();

    void EndTransaction(ActionExecutedContext filterContext);

    void CloseSession();
}
