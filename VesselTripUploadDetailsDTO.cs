using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class VesselTripUploadDetailsDTO
    {
        [Key]
        public int VesselTripUploadID { get; set; }
        public string WelspunCompany { get; set; }
        public string VesselNumber { get; set; }
        public string VesselName { get; set; }
        public string CustomerCompany { get; set; }
        public string CustomerCode { get; set; }
        public string Container { get; set; }
        public string InvoiceNumber { get; set; }
        public string BLNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal AmountInDocCurrency { get; set; }

        public decimal AmountInINR { get; set; }
        public decimal TotalAmountInDocCurrency { get; set; }
        public decimal TotalAmountInINR { get; set; }
        // public decimal AmountInUSD { get; set; }
        // public decimal TotalAmountInUSD { get; set; }
        public string SourcePort { get; set; }
        public DateTime TentativeStartDate { get; set; }
        public TimeSpan? TentativeStartTime { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public TimeSpan? ActualStartTime { get; set; }
        public string DestinationPort { get; set; }
        public DateTime TentativeEndDate { get; set; }
        public TimeSpan? TentativeEndTime { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public TimeSpan? ActualEndTime { get; set; }
        //public bool IsDelete { get; set; }
        //public decimal Let { get; set; }
        //public decimal Lon { get; set; }
        public int VesselTripUploadMasterID { get; set; }
        public string ValidationSummary { get; set; }

        //public CSVFileDTO() { }

    }


}
