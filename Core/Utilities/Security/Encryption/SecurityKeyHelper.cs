using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
	/* Anahtar mantığı için gerekli olan simetrik anahtar haline getiriyor;--> appsettings.json'dan gelen parametreyi byte cinsine çeviriyoruz.  */
	public class SecurityKeyHelper
	{
		public static SecurityKey CreateSecurityKey(string securityKey)
		{
			return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
		}
	}
}
