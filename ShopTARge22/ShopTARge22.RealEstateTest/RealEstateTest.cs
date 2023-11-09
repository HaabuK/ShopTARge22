using System;
using System.Net;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;

namespace ShopTARge22.RealEstateTest
{
	public class RealEstateTest : TestBase
	{
		[Fact]
		public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
		{
			RealEstateDto realEstate = new();

			realEstate.Address = "asd";
			realEstate.SizeSqrM = 1024;
			realEstate.RoomCount = 5;
			realEstate.Floor = 3;
			realEstate.BuildingType = "asd";
			realEstate.BuiltInYear = DateTime.Now;
			realEstate.UpdatedAt = DateTime.Now;

			var result = await Svc<IRealEstatesServices>().Create(realEstate);

			Assert.NotNull(result);
		}

		[Fact]
		public async Task ShouldNot_GetByIdRealEstate_WhereReturnsNotEqual()
		{
			//Arrange
			//Küsime realestate, mida ei eksisteeri
			Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
			Guid guid = Guid.Parse("10edee0b-37af-49a2-a9a2-aea61408e3be");

            //Act
            //peame kutsuma esile meetodi, mis on realEstateService classist
            await Svc<IRealEstatesServices>().DetailsAsync(guid);


            //Assert
            //assertimise võrdlus
            Assert.NotEqual(guid, wrongGuid);
        }

		[Fact]
        public async Task Should_GetByIdRealEstate_WhereReturnEqual()
        {
            //Arrange
            Guid db = Guid.Parse("10edee0b-37af-49a2-a9a2-aea61408e3be");
            Guid id = Guid.Parse("10edee0b-37af-49a2-a9a2-aea61408e3be");

            //Act
            //peame kutsuma esile meetodi, mis on realEstateService classist
            await Svc<IRealEstatesServices>().DetailsAsync(id);


            //Assert
            //assertimise võrdlus
            Assert.Equal(db,id);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            RealEstateDto realEstate = MockRealEstateData();

            var addRealEstate = await Svc<IRealEstatesServices>().Create(realEstate);

            var result = await Svc<IRealEstatesServices>().Delete((Guid)addRealEstate.Id);

            Assert.Equal(addRealEstate, result);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            RealEstateDto realEstate = MockRealEstateData();

            var RealEstate1 = await Svc<IRealEstatesServices>().Create(realEstate);
            var RealEstate2 = await Svc<IRealEstatesServices>().Create(realEstate);

            var result = await Svc<IRealEstatesServices>().Delete((Guid)RealEstate2.Id);

            Assert.NotEqual(RealEstate1.Id, result.Id);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            var guid = new Guid("10edee0b-37af-49a2-a9a2-aea61408e3be");

            RealEstateDto dto = MockRealEstateData();

            RealEstate realEstate = new();
            realEstate.Id = Guid.Parse("10edee0b-37af-49a2-a9a2-aea61408e3be");
            realEstate.Address = "Vallo";
            realEstate.SizeSqrM = 222;
            realEstate.RoomCount = 2;
            realEstate.Floor = 3;
            realEstate.BuildingType = "Loss";
            realEstate.BuiltInYear = DateTime.Now.AddYears(2);

            await Svc<IRealEstatesServices>().Update(dto);

            Assert.Equal(realEstate.Id, guid);
            Assert.DoesNotMatch(realEstate.Address, dto.Address);
            Assert.Equal(realEstate.Floor, dto.Floor);
            Assert.NotEqual(realEstate.RoomCount, dto.RoomCount);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData_V2()
        {
            RealEstateDto dto = MockRealEstateData();

            var createRealEstate = await Svc<IRealEstatesServices>().Create(dto);

            RealEstateDto update = UpdateRealEstateData();

            var result = await Svc<IRealEstatesServices>().Update(update);

            Assert.NotEqual(result.Id, createRealEstate.Id);
            Assert.DoesNotMatch(result.Address, createRealEstate.Address);
            Assert.NotEqual(result.Floor, createRealEstate.Floor);
            Assert.Equal(result.BuildingType, createRealEstate.BuildingType);
            Assert.NotEqual(result.UpdatedAt, createRealEstate.UpdatedAt);
            Assert.NotEqual(result.CreatedAt, createRealEstate.CreatedAt);
        }

        private RealEstateDto MockRealEstateData()
        {
            RealEstateDto realEstate = new()
            {
                Address = "asd",
                SizeSqrM = 123,
                RoomCount = 5,
                Floor = 3,
                BuildingType = "asd",
                BuiltInYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            
            };

            return realEstate;
        }

        private RealEstateDto UpdateRealEstateData()
        {
            RealEstateDto realEstate = new()
            {
                Address = "asadsad",
                SizeSqrM = 121212213,
                RoomCount = 555,
                Floor = 312,
                BuildingType = "asd",
                BuiltInYear = DateTime.Now.AddYears(2),
                UpdatedAt = DateTime.Now.AddYears(2),

            };

            return realEstate;
        }
    }
}

