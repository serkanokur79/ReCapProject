
using Core.Entities.Concrete;
using Core.Utilities.Results;

using System.Collections.Generic;


namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAllUsers();
        IDataResult<User> GetUserById(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);

    }
}
