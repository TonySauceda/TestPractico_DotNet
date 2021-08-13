using Hotel.DataAccess.Interfaces;
using Hotel.WebApp.Models;
using Hotel.WebApp.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hotel.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            var usuario = await _usuarioService.ObtenerUsuarioAsync(model.Usuario);

            if (usuario == null)
            {
                ViewBag.Mensaje = "No se encontró el usuario.";
                return View(model);
            }

            if (!BCrypt.Net.BCrypt.EnhancedVerify(model.Contrasena, usuario.Contrasena))
            {
                ViewBag.Mensaje = "Contraseña inválida.";
                return View(model);
            }

            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Nombre),
                        new Claim(ClaimTypes.Role, usuario.TipoUsuario.TipoUsuario)
                    };

            var identity = new ClaimsIdentity(claims, Constantes.Identity.Auth);
            ClaimsPrincipal claimsPrincipal = new(identity);

            await HttpContext.SignInAsync(Constantes.Identity.Auth, claimsPrincipal);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(Constantes.Identity.Auth);

            return RedirectToAction("Index", "Home");
        }
    }
}
