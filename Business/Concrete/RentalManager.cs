using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult AddRental(Rental rental)
        {
            Rental existingRental = _rentalDal.GetAll().Find(r=>r.CarId == rental.CarId);


            if (existingRental != null && (existingRental.GetType() == typeof(Rental)) ) {

                    if (existingRental.ReturnDate == null)
                        {
                            return new ErrorResult( Messages.CarStillOnRent );
                        }
                    else 
                    {
                        Rental RentalToUpdate = new Rental() { Id=existingRental.Id, CarId=existingRental.CarId, CustomerId=rental.CustomerId, RentDate=rental.RentDate, ReturnDate=null};
                        _rentalDal.Update(RentalToUpdate);
                        return new SuccessResult(Messages.RentalNewCustomer);
                    }
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
        }
               
        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalsWithDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsWithDetails(), Messages.RentalsListedWithDetails);
        }
    }
}
