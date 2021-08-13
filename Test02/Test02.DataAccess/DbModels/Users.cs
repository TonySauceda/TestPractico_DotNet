using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Test02.DataAccess.DbModels
{
    public partial class Users
    {
        public Users()
        {
            Phones = new HashSet<Phones>();
        }

        [Key]
        public int KeyUser { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Surname { get; set; }
        public string Rfc { get; set; }
        public int WorkshiftId { get; set; }
        public int GenderId { get; set; }
        public string Pin { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual Genders Gender { get; set; }
        public virtual Workshifts Workshift { get; set; }
        public virtual ICollection<Phones> Phones { get; set; }
    }
}
