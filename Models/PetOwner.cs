using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pet_hotel.Models
{
    public class PetOwner
    {
        public int id {get; set;}

        public string owner_name {get; set;}

        public string email {get; set;}

        public int pet_number {get; set;}
    }
}
