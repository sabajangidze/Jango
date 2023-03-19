using Admin.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Admin.Infrastructure.Repositories;

public class ActionTransactionHelper : IActionTransactionHelper
{
    private readonly IUnitOfWork _unitOfWork;
    private ITransaction _transaction;

    public ActionTransactionHelper(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void BeginTransaction()
    {
        _transaction = _unitOfWork.BeginTransaction();
    }

    public void EndTransaction(ActionExecutedContext filterContext)
    {
        if (_transaction is null)
        {
            throw new NotSupportedException();
        }

        if (filterContext.Exception is null)
        {
            _unitOfWork.Commit();
            _transaction.Commit();
        }
        else
        {
            try
            {
                _transaction.RollBack();
            }
            catch (Exception ex)
            {
                throw new AggregateException(filterContext.Exception, ex);
            }
        }
    }

    public void CloseSession()
    {
        if (_transaction != null)
        {
            _transaction.Dispose();
            _transaction = null;
        }
    }
}
