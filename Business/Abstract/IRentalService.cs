using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAllRentals();
        IDataResult<List<RentalDetailDto>> GetAllRentalsWithDetails();
        IDataResult<Rental> GetRentalById(int id);
        IResult AddRental(Rental rental);
        IResult UpdateRental(Rental rental);
        IResult DeleteRental(Rental rental);

    }
}
