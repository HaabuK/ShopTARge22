using System;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;

namespace ShopTARge22.Core.ServiceInterface
{
	public interface IKindergartensServices
	{
        Task<Kindergarten> Create(KindergartenDto dto);
        Task<Kindergarten> DetailsAsync(Guid id);
        Task<Kindergarten> Delete(Guid id);
        Task<Kindergarten> Update(KindergartenDto dto);
    }
}

