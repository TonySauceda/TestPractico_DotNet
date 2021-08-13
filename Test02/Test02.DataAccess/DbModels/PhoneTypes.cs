using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Test02.DataAccess.DbModels
{
    public partial class PhoneTypes
    {
        public PhoneTypes()
        {
        }
        [Key]
        public int PhoneTypeId { get; set; }
        public string PhoneType { get; set; }
    }
}
