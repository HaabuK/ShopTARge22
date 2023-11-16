using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
/* KG Dto
   public Guid? Id { get; set; }
   public string GroupName { get; set; }
   public int ChildrenCount { get; set; }
   public string KindergartenName { get; set; }
   public string Teacher { get; set; }
   public DateTime CreatedAt { get; set; }
   public DateTime UpdatedAt { get; set; }
 */
namespace ShopTARge22.Kindergarten.Test
{
    public class KindergartenTest: TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyKindergarten_WhenReturnResult()
        {
            //Arrange - create the Dto object and assign values
            KindergartenDto kindergarten = new();
            kindergarten.GroupName = "MingiGruppOn";
            kindergarten.ChildrenCount = 343;
            kindergarten.KindergartenName = "Leevike";
            kindergarten.Teacher = "Linda Hinda";
            kindergarten.CreatedAt = DateTime.Now;
            kindergarten.UpdatedAt = DateTime.Now;

            //Act
            var result = await Svc<IKindergartenServices>().Create(kindergarten);
            //Result
            Assert.NotNull(result);
        }
        /*
        Message: 
        Microsoft.EntityFrameworkCore.DbUpdateException : Required properties '{'GroupName'}' 
        are missing for the instance of entity type 'Kindergarten'.
        Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the entity key value.
            Stack Trace: 
        InMemoryTable1.ThrowNullabilityErrorException(IUpdateEntry entry, IList1 nullabilityErrors)
        InMemoryTable1.Create(IUpdateEntry entry)
        InMemoryStore.ExecuteTransaction(IList 1 entries, IDiagnosticsLogger 1 updateLogger)
        InMemoryDatabase.SaveChangesAsync(IList1 entries, CancellationToken cancellationToken)
        StateManager.SaveChangesAsync(IList 1 entriesToSave, CancellationToken cancellationToken)
        StateManager.SaveChangesAsync(StateManager stateManager, Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        DbContext.SaveChangesAsync(Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        DbContext.SaveChangesAsync(Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        KirdergartenServices.Create(KindergartenDto dto) line 39
        KindergartenTest.ShouldNot_InsertToDb_WhenKindergartenGroupName_IsNull() line 48
            --- End of stack trace from previous location ---
         
        */
        [Fact]
        public async Task ShouldNot_InsertToDb_WhenKindergartenGroupName_IsEmptyString()
        {
            KindergartenDto kindergarten = new();

            kindergarten.GroupName = "";
            kindergarten.ChildrenCount = 343;
            kindergarten.KindergartenName = "Leevike";
            kindergarten.Teacher = "Linda Hinda";
            kindergarten.CreatedAt = DateTime.Now;
            kindergarten.UpdatedAt = DateTime.Now;
            //Act
            // var result = await Svc<IKindergartenServices>().Create(kindergarten);
            var result = await Svc<IKindergartenServices>().Create(kindergarten);
            //Result
            Assert.Null(result);
        }
     
        [Fact]
        public async Task ShouldNot_GetByIdKinderGarten_WhenReturnsNotEqual()
        {
            //Arrange

            // Küsime kindergarten, mida meil ei ole
            Guid notAvailable = Guid.Parse(Guid.NewGuid().ToString());
            Guid available = Guid.Parse("b2f75912-827d-417f-b91f-4f2eaa09b246");

            //Act
            await Svc<IKindergartenServices>().DetailsAsync(available);

            //Assert
            Assert.NotEqual(available, notAvailable);

        }
    }
}