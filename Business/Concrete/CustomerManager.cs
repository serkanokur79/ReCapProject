using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;

using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

using System.Collections.Generic;


namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [CacheRemoveAspect("ICustomerManager.Get")]
        [SecuredOperation("Manager,Admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
           // ValidationTool.Validate(new CustomerValidator(), customer);

            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [SecuredOperation("Manager,Admin")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        [SecuredOperation("Manager,Admin")]
        public IDataResult<List<Customer>> GetAllCustomers()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll()); 
        }

        [SecuredOperation("Manager,Admin")]
        public IDataResult<Customer> GetCustomerById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.Id == customerId));
        }

        [CacheRemoveAspect("ICustomerManager.Get")]
        [SecuredOperation("Manager,Admin")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        [TransactionScopeAspect]
        public IResult TransactionalTest(Customer customer)
        {
            _customerDal.Add(customer);
            _customerDal.Update(customer);
            return null;
        }
    }
}
