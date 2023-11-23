using System;
using ShopTARge22.Core.Dto;

namespace ShopTARge22.Core.ServiceInterface
{
	public interface IEmailServices
	{
		void SendEmail(EmailDto request);
	}
}

