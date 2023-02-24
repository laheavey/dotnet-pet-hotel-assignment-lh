using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel.Models
{
    public enum PetBreedType {
        //     Chiwawa, //0
        //     Poodle, //1
        //     Wiener, 
        //     GoldenRetriever
        Shepherd,
        Poodle,
        Beagle,
        Bulldog,
        Terrier,
        Boxer,
        Labrador,
        Retriever

    }
    
    public enum PetColorType {
        // brown,
        White,
        Black,
        Golden,
        Tricolor,
        Spotted

           
            
    }


    public class Pet {
        public int id {get; set;}

        public string pet_name {get; set;}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType breed {get; set;}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColorType color {get; set;}

        public DateTime checkedInAT {get; set;}

        [ForeignKey("petOwner")]
       public int petOwnerid { get; set; }

       public PetOwner petOwner { get; set; }
    }
}
