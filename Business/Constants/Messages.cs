﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "The car has been added to Database";
        public static string CarDeleted = "The car has been deleted from Database";
        public static string CarUpdated = "The car has been updated in Database";
        public static string CarNameInvalid = "The car name must be at least 2 characters";
        public static string BrandAdded = "The brand has been added to Database";
        public static string BrandDeleted = "The brand has been deleted from Database";
        public static string BrandUpdated = "The brand has been updated in Database";
        public static string ColorAdded = "The color has been added to Database";
        public static string ColorDeleted = "The color has been deleted from Database";
        public static string ColorUpdated = "The color has been updated in Database";

        public static string CarPriceInvalid = "The car price must be at least 0";
        public static string CarsListed = "The cars have been listed";
        public static string CarsListedWithDetails = "The cars have been listed with details";
        public static string CarListedById = "The car has been listed according to Id";
        public static string CarsListedByBrandId = "The car has been listed according to BrandId";
        public static string CarsListedByColorId = "The car has been listed according to ColorId";

        public static string Maintenance = "The server is under maintenance";

        public static string BrandsListed = "The brands have been listed";
        public static string BrandListedById = "The brand has been listed according to BrandId";
        public static string ColorsListed = "The colors have been listed";
        public static string ColorListedById = "The color has been listed according to ColorId";

        public static string RentalAdded = "The car has been added to the Rental";
        public static string CarStillOnRent = "The car is still on rent. It cannot be added to Rentals.";
        public static string RentalsListed = "Rentals have been listed.";
        public static string RentalsListedWithDetails = "Rentals have been listed with details.";
        public static string NoRentals = "There are no possible Rentals.";

        public static string RentalNewCustomer = "Rental has a new Customer";

        public static string UsersListed = "Users have been listed";
        public static string CustomerAdded = "Customer has been added.";
        public static string CustomerDeleted = "Customer has been deleted.";
        public static string CustomerUpdated = "Customer has been updated.";
        public static string UserAdded = "User has been added.";
        public static string UserDeleted = "User has been deleted.";
        public static string UserListedById = "User has been listed by id.";
        public static string UserUpdated = "User has been updated.";

        public static string RentalDeleted = "Rental has been deleted.";
        public static string RentalListedById = "Rental has been listed by id.";
        public static string RentalUpdated = "Rental has been updated.";

        public static string CarImageLimitExceeded = "More than 5 images cannot be added";
        public static string NoCarImages = "The car does NOT have any images";

        public static string CarImageDeleted = "Car Image deleted";
        public static string CarImageAdded = "Car Image added";
        public static string CarImageUpdated = "Car Image updated";

        public static string AuthorizationDenied = "Authorization Denied";

        public static string UserRegistered = "UserRegistered";
        public static string UserNotFound = "User Not Found";
        public static string PasswordError = "Password error";
        public static string SuccessfulLogin = "Login Succesful";
        public static string UserAlreadyExists = "User Already exists";
        public static string AccessTokenCreated = "Access Token Created";
        public static string RolesListed = "Roles Listed";
    }
}
