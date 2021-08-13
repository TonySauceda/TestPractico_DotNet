using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test02.Core.Requests;
using Test02.Core.Responses;
using Test02.DataAccess.DbModels;
using Test02.DataAccess.Interfaces;

namespace Test02.Logic
{
    public class UserLogic
    {
        public static BadRequestResponse _badRequestResponse;
        private readonly IUserService _userService;
        private readonly IWorkshiftService _workshiftService;
        private readonly IGenderService _genderService;
        private readonly IPhoneTypeService _phoneTypeService;
        public UserLogic(IUserService userService, IWorkshiftService workshiftService, IGenderService genderService, IPhoneTypeService phoneTypeService)
        {
            _userService = userService;
            _workshiftService = workshiftService;
            _genderService = genderService;
            _phoneTypeService = phoneTypeService;
        }

        public async Task<Users> GuardarUsuarioAsync(CreateUserRequest request)
        {
            var newUser = new Users
            {
                Birthdate = request.Birthdate,
                GenderId = 0,
                Lastname = request.Lastname,
                Name = request.Name,
                Pin = request.Pin,
                Rfc = request.Rfc,
                Surname = request.Surname,
                WorkshiftId = 0,
                Phones = new List<Phones>()
            };

            #region Validar Pin

            var existePin = await _userService.ExistePinAsync(request.Pin);
            if (existePin)
            {
                _badRequestResponse = new BadRequestResponse { Message = $"El pin {request.Pin} ya se encuentra registrado.", Request = request };
                return null;
            }

            #endregion

            #region Validar Workshift

            Workshifts workShift = null;
            if (int.TryParse(request.Workshift, out int workShiftId))
                workShift = await _workshiftService.ObtenerAsync(workShiftId);
            else
                workShift = await _workshiftService.ObtenerAsync(request.Workshift);

            if (workShift == null)
            {
                _badRequestResponse = new BadRequestResponse { Message = $"El turno {request.Workshift} no es válido.", Request = request };
                return null;
            }

            newUser.WorkshiftId = workShift.WorkshiftId;

            #endregion

            #region Validar Gender

            Genders gender = null;
            if (int.TryParse(request.Gender, out int genderId))
                gender = await _genderService.ObtenerAsync(genderId);
            else
                gender = await _genderService.ObtenerAsync(request.Gender);

            if (gender == null)
            {
                _badRequestResponse = new BadRequestResponse { Message = $"El genero {request.Gender} no es válido.", Request = request };
                return null;
            }

            newUser.GenderId = gender.GenderId;

            #endregion

            #region Validar PhoneType

            var phoneTypes = await _phoneTypeService.ObtenerListaAsync();
            List<string> erros = new();
            foreach (var phone in request.Phones)
            {
                PhoneTypes pType = null;
                if (int.TryParse(phone.PhoneType, out int phoneTypeId))
                    pType = phoneTypes.Where(x => x.PhoneTypeId == phoneTypeId).FirstOrDefault();
                else
                    pType = phoneTypes.Where(x => x.PhoneType == phone.PhoneType).FirstOrDefault();

                if (pType == null)
                    erros.Add(phone.PhoneType);
                else
                    newUser.Phones.Add(new Phones { Phone = phone.Phone, PhoneTypeId = pType.PhoneTypeId });
            }

            if (erros.Count > 0)
            {
                string mensaje = erros.Count == 1 ? $"El tipo de teléfono {erros.First()} no es válido." : $"Los siguientes tipos de teléfono {string.Join(',', erros)} no son válidos.";
                _badRequestResponse = new BadRequestResponse { Message = mensaje, Request = request };
                return null;
            }

            #endregion

            var userBd = await _userService.GuardarAsync(newUser);

            return userBd;
        }

        public async Task<bool> ModificarUsuarioAsync(UpdateUserRequest request)
        {
            var updatedUser = await _userService.ObtenerAsync(request.KeyUser);
            updatedUser.Birthdate = request.Birthdate;
            updatedUser.Lastname = request.Lastname;
            updatedUser.Name = request.Name;
            updatedUser.Pin = request.Pin;
            updatedUser.Rfc = request.Rfc;
            updatedUser.Surname = request.Surname;

            #region Validar Pin

            var existePin = await _userService.ExistePinAsync(request.Pin, request.KeyUser);
            if (existePin)
            {
                _badRequestResponse = new BadRequestResponse { Message = $"El pin {request.Pin} ya se encuentra registrado.", Request = request };
                return false;
            }

            #endregion

            #region Validar Workshift

            Workshifts workShift = null;
            if (int.TryParse(request.Workshift, out int workShiftId))
                workShift = await _workshiftService.ObtenerAsync(workShiftId);
            else
                workShift = await _workshiftService.ObtenerAsync(request.Workshift);

            if (workShift == null)
            {
                _badRequestResponse = new BadRequestResponse { Message = $"El turno {request.Workshift} no es válido.", Request = request };
                return false;
            }

            updatedUser.WorkshiftId = workShift.WorkshiftId;

            #endregion

            #region Validar Gender

            Genders gender = null;
            if (int.TryParse(request.Gender, out int genderId))
                gender = await _genderService.ObtenerAsync(genderId);
            else
                gender = await _genderService.ObtenerAsync(request.Gender);

            if (gender == null)
            {
                _badRequestResponse = new BadRequestResponse { Message = $"El genero {request.Gender} no es válido.", Request = request };
                return false;
            }

            updatedUser.GenderId = gender.GenderId;

            #endregion

            #region Validar PhoneType

            var phoneTypes = await _phoneTypeService.ObtenerListaAsync();
            List<string> erros = new();
            foreach (var phone in request.Phones)
            {
                PhoneTypes pType = null;
                if (int.TryParse(phone.PhoneType, out int phoneTypeId))
                    pType = phoneTypes.Where(x => x.PhoneTypeId == phoneTypeId).FirstOrDefault();
                else
                    pType = phoneTypes.Where(x => x.PhoneType == phone.PhoneType).FirstOrDefault();

                if (pType == null)
                    erros.Add(phone.PhoneType);
                else
                {
                    if (updatedUser.Phones.Where(x => x.PhoneTypeId == pType.PhoneTypeId).Count() == 0)
                        updatedUser.Phones.Add(new Phones { Phone = phone.Phone, PhoneTypeId = pType.PhoneTypeId });
                    else
                    {
                        foreach (var updatedUserPhone in updatedUser.Phones)
                            if (updatedUserPhone.PhoneTypeId == pType.PhoneTypeId)
                                updatedUserPhone.Phone = phone.Phone;
                    }
                }
            }

            if (erros.Count > 0)
            {
                string mensaje = erros.Count == 1 ? $"El tipo de teléfono {erros.First()} no es válido." : $"Los siguientes tipos de teléfono {string.Join(',', erros)} no son válidos.";
                _badRequestResponse = new BadRequestResponse { Message = mensaje, Request = request };
                return false;
            }

            #endregion

            var result = await _userService.ModificarAsync(updatedUser);

            if (!result)
                _badRequestResponse = new BadRequestResponse { Message = $"Error al modificar el registro", Request = request };

            return result;
        }
    }
}
