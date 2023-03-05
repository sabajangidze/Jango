using System.Web.Mvc;

namespace Web.Domain.Abstractions;

public interface IActionTransactionHelper
{
    void BeginTransaction();

    void EndTransaction(ActionExecutedContext filterContext);

    void CloseSession();
}
