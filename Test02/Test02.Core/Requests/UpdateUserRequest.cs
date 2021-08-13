using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test02.Core.Requests
{
    public class UpdateUserRequest : CreateUserRequest
    {
        [Required(ErrorMessage = "El id es requerido.")]
        public int KeyUser { get; set; }
    }
}
