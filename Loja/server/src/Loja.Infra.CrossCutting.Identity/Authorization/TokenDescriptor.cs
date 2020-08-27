using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Infra.CrossCutting.Identity.Authorization
{
    public class TokenDescriptor
    {

        public static string Audience { get; set; }
        public static string Issuer { get; set; }
        public static int MinutesValid { get; set; }
    }
}
