using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class VesselTripDetailDTO
    {   
            [Key]

            public int VesselTripDetailID { get; set; }
            public int VesselTripID { get; set; }
            [Display(Name = "Customer Name")]
            [Required(ErrorMessage = "Please Select Customer Name.")]
            public int CustomerID { get; set; }
            [NotMapped]
            public List<CustomerDetailDDLDTO> lstCustomerName = new List<CustomerDetailDDLDTO>();
            public string CustomerName {get; set;}
            [StringLength(50, ErrorMessage = "Maximum 50 characters")]
            [Required(ErrorMessage = "Please Enter Container Field.")]
            [RegularExpression("^[a-zA-Z-0-9,@&()-+._#$][a-zA-Z-0-9,@&()-+._#$  ']*$", ErrorMessage = "Enter valid container field.")]
            public string Container { get; set; }
            [Display(Name = "Invoice Number")]
            [Required(ErrorMessage = "Please Enter Invoice Number.")]
            [RegularExpression("^[a-zA-Z-0-9,@&()-+._#$][a-zA-Z-0-9,@&()-+._#$  ']*$", ErrorMessage = "Enter valid Invoice number.")]
            [MaxLength(100, ErrorMessage = "Invoice Number Max Size is 100.")]
            public string InvoiceNumber { get; set; }
            //[Display(Name = "Bill Amount")]
            //[Required(ErrorMessage = "Please Enter Bill Amount.")]
            ////[Range(0.01, ErrorMessage = "Please enter bill amount greater than 0.")]
            //[Range(0.01, 999999999999999999.99, ErrorMessage = "Invalid bill amount greater than 0 and Max 18 digits")]
            //public decimal BillAmount { get; set; }
            [StringLength (100)]
            [Display(Name = "BL Number")]
            public string BLNumber { get; set; }
            [DataType(DataType.Date)]
            [Display(Name = "Invoice Date")]
            [Required(ErrorMessage = "Please Enter Invoice Date.")]
            public DateTime? InvoiceDate { get; set;}
            [Display(Name = "Amount In Doc Currency")]
            [Range(0.01, 999999999999999999.99, ErrorMessage = "The field Amount In Doc Currency Must be a greater than 0")]
            public decimal? AmountInDocCurrency { get; set; }
            [Display(Name = "Amount In INR")]
            [Range(0.01, 999999999999999999.99, ErrorMessage = "The field Amount INR Must be a greater than 0")] 
            public decimal? AmountInINR { get; set; }
            public DateTime? CreatedDate { get; set; }
            public DateTime? ModifiedDate { get; set; }




    }
    }

