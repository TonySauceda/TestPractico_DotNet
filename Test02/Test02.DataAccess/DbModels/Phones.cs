using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Test02.DataAccess.DbModels
{
    public partial class Phones
    {
        [Key]
        public int PhoneId { get; set; }
        public int KeyUser { get; set; }
        public int PhoneTypeId { get; set; }
        public string Phone { get; set; }

        public virtual Users KeyUserNavigation { get; set; }
        public virtual PhoneTypes PhoneType { get; set; }
    }
}
