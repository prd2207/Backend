﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelspunVessel.DTO.Masters
{
    public class CustomerDetailDDLDTO
    {
        [Key]
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }


    }
}
