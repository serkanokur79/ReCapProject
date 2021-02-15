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

        public IResult DeleteRental(Rental rental)
        {
            Rental rentalToDelete = _rentalDal.GetAll().Find(r => r.CarId == rental.CarId);
            _rentalDal.Delete(rentalToDelete);
            return new SuccessResult(Messages.RentalDeleted);

        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalsWithDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsWithDetails(), Messages.RentalsListedWithDetails);
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id == id), Messages.RentalListedById);
        }

        public IResult UpdateRental(Rental rental)
        {
            Rental rentalToUpdate = _rentalDal.GetAll().Find(r => r.CarId == rental.CarId);

            rentalToUpdate.CarId = rental.CarId;
            rentalToUpdate.CustomerId = rental.CustomerId;
            rentalToUpdate.RentDate = rental.RentDate ;
            rentalToUpdate.ReturnDate = rental.ReturnDate;

            _rentalDal.Update(rentalToUpdate);

            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
