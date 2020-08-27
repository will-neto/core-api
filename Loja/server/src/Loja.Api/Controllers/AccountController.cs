using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Loja.Infra.CrossCutting.Identity.Authorization;
using Loja.Infra.CrossCutting.Identity.Models;
using Loja.Infra.CrossCutting.Identity.Models.AccountViewModels;
using Loja.Infra.CrossCutting.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Api.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("nova-conta")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
   
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = "Informe os dados corretamente"
                });
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Senha);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim("manager", "read"));
                await _userManager.AddClaimAsync(user, new Claim("manager", "save"));

                //var registroCommand = new RegistrarOrganizadorCommand(Guid.Parse(user.Id), model.Nome, model.CPF, user.Email);
                //await _mediator.EnviarComando(registroCommand);

                //if (!OperacaoValida())
                //{
                //    await _userManager.DeleteAsync(user);
                //    return Response(model);
                //}

                //_logger.LogInformation(1, "Usuario criado com sucesso!");
                var userIdentity = await _userManager.FindByEmailAsync(model.Email);

                var userClaims = await _userManager.GetClaimsAsync(user);

                var response = TokenService.GenerateToken(userIdentity, userClaims);

                return Ok(new
                {
                    success = true,
                    user,
                    token = response
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = "Não foi possível criar o usuário"
            });
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //NotificarErroModelInvalida();
                return BadRequest(new
                {
                    success = false,
                    errors = "Informe os dados corretamente"
                });
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, false, false);

            if (result.Succeeded)
            {
                var userIdentity = await _userManager.FindByEmailAsync(model.Email);

                var userClaims = await _userManager.GetClaimsAsync(userIdentity);

                var response = TokenService.GenerateToken(userIdentity, userClaims);

                return Ok(new
                {
                    success = true,
                    user = userIdentity,
                    token = response
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = "E-mail ou senha incorretas"
            });
        }

    }
}