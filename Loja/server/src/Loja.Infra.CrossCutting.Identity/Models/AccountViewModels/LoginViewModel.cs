﻿using System.ComponentModel.DataAnnotations;

namespace Loja.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }

        //public string Nome { get; set; }
    }
}
