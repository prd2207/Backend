using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class VesselTripDTO
    {
        [Key]
        public int VesselTripID { get; set; }
        [Display(Name = "Departure Port Name")]
        [Required(ErrorMessage = "Please Select Departure Port Name.")]
        public int DeparturePortID { get; set; }
        public string DeparturePortName { get; set; }

        [Display(Name = "Arrival Port Name")]
        [Required(ErrorMessage = "Please Select Arrival Port Name.")]
        public int ArrivalPortID { get; set; }
        public string ArrivalPortName { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Enter Tentitive Departure Date.")]
        [Display(Name = "Tentative  Departure Date")]
        public DateTime? TentitiveDepartureDate { get; set; }
        public string TentitiveDepartureDateStr { get; set; }
        [Display(Name = "Tentative Departure Time")]
        public TimeSpan? TentitiveDepartureTime { get; set; }
        [NotMapped]
        public string TentitiveDepartureTimestr { get; set; }
        [Display(Name = "Tentative Arrival Date")]
        [Required(ErrorMessage = "Please Enter Tentitive Arrival Date.")]
        [DataType(DataType.Date)]
        public DateTime? TentitiveArrivalDate { get; set; }
        public string TentitiveArrivalDateStr { get; set; }
        [Display(Name = "Tentative Arrival Time")]
        public TimeSpan? TentitiveArrivalTime { get; set; }
        [NotMapped]
        public string TentitiveArrivalTimeStr { get; set; }
        [Display(Name = "Actual Departure Date")]
        //[Required(ErrorMessage = "Please Enter Actual Departure Date.")]
        [DataType(DataType.Date)]
        public DateTime? ActualDepartureDate { get; set; }
        public string ActualDepartureDateStr { get; set; }
        [Display(Name = "Actual Departure Time")]
        public TimeSpan? ActualDepartureTime { get; set; }
        [NotMapped]
        public string ActualDepartureTimeStr { get; set; }

        [Display(Name = "Actual Arrival Date")]
        //[Required(ErrorMessage = "Please Enter Actual Arrival Date.")]
        [DataType(DataType.Date)]
        public DateTime? ActualArrivalDate { get; set; }
        public string ActualArrivalDateStr { get; set; }
        [Display(Name = "Actual Arrival Time")]

        public TimeSpan? ActualArrivalTime { get; set; }
        [NotMapped]
        public string ActualArrivalTimeStr { get; set; }

        //[Display(Name = "Total Vessel Amount")]
        //public decimal? TotalVesselAmount { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        [Display(Name = "Vessel Number")]
        [Required(ErrorMessage = "Please Select Vessel Number.")]
        public int? VesselID { get; set; }


        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please Select Company Name.")]
        public int? CompanyID { get; set; }
        [Display(Name = "Latitude ")]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        public decimal? Lat { get; set; }
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
        [Display(Name = "Longitude  ")]
        public decimal? Lon { get; set; }
        public string CompanyName { get; set; }
        public string VesselNumber { get; set; }
        [Display(Name = "Total Amount In Doc Currency")]
        public decimal? TotalAmountInDocCurrency { get; set; }
        [Display(Name = "Total Amount In INR")]
        public decimal? TotalAmountInINR { get; set; }



    }

    public class VesselTripAPIDTO
    {
        [Key]
        public int VesselTripID { get; set; }
        public string CompanyName { get; set; }
        public string VesselName { get; set; }
        public string VesselNumber { get; set; }
        [JsonIgnore]
        [Display(Name = "Departure Port Name")]
        [Required(ErrorMessage = "Please Select Departure Port Name.")]
        public int DeparturePortID { get; set; }
        public string DeparturePortName { get; set; }
        [JsonIgnore]
        [Display(Name = "Arrival Port Name")]
        [Required(ErrorMessage = "Please Select Arrival Port Name.")]
        public int ArrivalPortID { get; set; }
        public string ArrivalPortName { get; set; }
        [Display(Name = "Tentitive Departure Date")]
        public DateTime TentitiveDepartureDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [JsonIgnore]
        [NotMapped]
        public string TentitiveDepartureDateStr { get; set; }
        [Display(Name = "Tentitive Departure Time")]
        public TimeSpan? TentitiveDepartureTime { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string TentitiveDepartureTimestr { get; set; }
        [Display(Name = "Tentitive Arrival Date")]
        public DateTime TentitiveArrivalDate { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string TentitiveArrivalDateStr { get; set; }
        [Display(Name = "Tentitive Arrival Time")]
        public TimeSpan TentitiveArrivalTime { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string TentitiveArrivalTimeStr { get; set; }
        [Display(Name = "Actual Departure Date")]

        public DateTime? ActualDepartureDate { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string ActualDepartureDateStr { get; set; }
        [Display(Name = "Actual Departure Time")]
        public TimeSpan? ActualDepartureTime { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string ActualDepartureTimeStr { get; set; }
        [Display(Name = "Actual Arrival Date")]
       // [JsonConverter(typeof(DateTimeOffsetJsonConverter))]
        public DateTime? ActualArrivalDate { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string ActualArrivalDateStr { get; set; }
        [Display(Name = "Actual Arrival Time")]
        public TimeSpan? ActualArrivalTime { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string ActualArrivalTimeStr { get; set; }
        public decimal TotalVesselAmount { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public int? CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }
        [JsonIgnore]
        public int? ModifiedBy { get; set; }

       
        public decimal? Lat { get; set; }
        public decimal? Long { get; set; }
        
        

    }

    public class UpdateVesselEndTripDTO
    {
        [Key]
        [JsonProperty("vesselTripId")]
        public string  VesselTripID { get; set; }
        [JsonProperty("actualArrivalDate")]
        public string ActualArrivalDate { get; set; }
        [JsonProperty("actualArrivaltime")]
        public string ActualArrivalTime { get; set; }
    }
}

