using System;
using System.ComponentModel.DataAnnotations;

namespace ShopTARge22.Utilities
{
	public class ValidEmailDomainAttribute : ValidationAttribute
	{
		private readonly string ALLOWEDDOMAIN;
		public ValidEmailDomainAttribute(string allowedDomain)
		{
			ALLOWEDDOMAIN = allowedDomain;
		}

        public override bool IsValid(object value)
        {
			string[] strings = value.ToString().Split('@');
			return strings[1].ToUpper() == ALLOWEDDOMAIN.ToUpper();
        }
    }
}

