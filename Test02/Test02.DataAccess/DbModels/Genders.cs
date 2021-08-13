using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Test02.DataAccess.DbModels
{
    public partial class Genders
    {
        public Genders()
        {
        }

        [Key]
        public int GenderId { get; set; }
        public string Gender { get; set; }
    }
}
