using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Test02.DataAccess.DbModels
{
    public partial class Workshifts
    {
        public Workshifts()
        {
        }

        [Key]
        public int WorkshiftId { get; set; }
        public string Workshift { get; set; }
    }
}
