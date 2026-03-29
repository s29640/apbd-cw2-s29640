using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentRental.Exceptions
{
    internal class DuplicateUserIdException :DomainException
    {
        public DuplicateUserIdException(int id) 
            : base($"User with id {id} already exists.")
        {
        }
    }
}
