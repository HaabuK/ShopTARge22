using System;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto.AccountsDtos;

namespace ShopTARge22.Core.ServiceInterface
{
	public interface IAccountServices
	{
        Task<ApplicationUser> Register(ApplicationUserDto dto);

    }
}

