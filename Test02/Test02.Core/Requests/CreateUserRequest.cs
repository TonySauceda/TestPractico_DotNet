using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test02.Core.Requests
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(50, ErrorMessage = "El nombre no puede ser mayor a 50 caracteres.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El apellido paterno es requerido.")]
        [StringLength(50, ErrorMessage = "El apellido paterno no puede ser mayor a 50 caracteres.")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "El apellido materno es requerido.")]
        [StringLength(50, ErrorMessage = "El apellido materno no puede ser mayor a 50 caracteres.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "El rfc es requerido.")]
        [StringLength(13, ErrorMessage = "El rfc no puede ser mayor a 13 caracteres.")]
        [RegularExpression(@"^(([ÑA-Z|ña-z|&amp;]{3}|[A-Z|a-z]{4})\d{2}((0[1-9]|1[012])(0[1-9]|1\d|2[0-8])|(0[13456789]|1[012])(29|30)|(0[13578]|1[02])31)(\w{2})([A|a|0-9]{1}))$|^(([ÑA-Z|ña-z|&amp;]{3}|[A-Z|a-z]{4})([02468][048]|[13579][26])0229)(\w{2})([A|a|0-9]{1})$", ErrorMessage = "El rfc no tiene un formato válido.")]
        public string Rfc { get; set; }
        [Required(ErrorMessage = "El turno es requerido.")]
        public string Workshift { get; set; }
        [Required(ErrorMessage = "El genero es requerido.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "El pinj es requerido.")]
        [StringLength(10, ErrorMessage = "El pin no puede ser mayor a 10 caracteres.")]
        public string Pin { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        public DateTime Birthdate { get; set; }
        public List<CreateUserPhoneRequest> Phones { get; set; }
    }

    public class CreateUserPhoneRequest
    {
        [Required(ErrorMessage = "El teléfono es requerido.")]
        [StringLength(10, ErrorMessage = "El teléfono no puede ser mayor a 10 caracteres.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono no tiene un formato válido.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "El tipo de teléfono es requerido.")]
        public string PhoneType { get; set; }
    }
}
