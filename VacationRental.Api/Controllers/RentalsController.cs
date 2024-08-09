using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VacationRental.Api.Models;

namespace VacationRental.Api.Controllers
{
    [Route("api/v1/rentals")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IDictionary<int, RentalViewModel> _rentals;
        private readonly IDictionary<int, BookingViewModel> _bookings;

        public RentalsController(IDictionary<int, RentalViewModel> rentals, IDictionary<int, BookingViewModel> bookings)
        {
            _rentals = rentals;
            _bookings = bookings;
        }

        [HttpGet]
        [Route("{rentalId:int}")]
        public RentalViewModel Get(int rentalId)
        {
            if (!_rentals.ContainsKey(rentalId))
                throw new ApplicationException("Rental not found");

            return _rentals[rentalId];
        }

        [HttpPost]
        public ResourceIdViewModel Post(RentalBindingModel model)
        {
            var key = new ResourceIdViewModel { Id = _rentals.Keys.Count + 1 };

            _rentals.Add(key.Id, new RentalViewModel
            {
                Id = key.Id,
                Units = model.Units,
                PreparationTimeInDays = model.PreparationTimeInDays // Handle new property
            });

            return key;
        }

        [HttpPut]
        [Route("{rentalId:int}")]
        public IActionResult Put(int rentalId, RentalBindingModel model)
        {
            if (!_rentals.ContainsKey(rentalId))
                return NotFound();

            var rental = _rentals[rentalId];

            // Validate updates: ensure no overbooking or preparation time overlap
            foreach (var booking in _bookings.Values)
            {
                if (booking.RentalId == rentalId)
                {
                    var newPreparationTimeEnd = booking.Start.AddDays(booking.Nights + model.PreparationTimeInDays);
                    if (newPreparationTimeEnd > DateTime.Now)
                        return BadRequest("Cannot update rental due to preparation time conflict with existing bookings.");
                }
            }

            rental.Units = model.Units;
            rental.PreparationTimeInDays = model.PreparationTimeInDays;

            return NoContent();
        }
    }
}
