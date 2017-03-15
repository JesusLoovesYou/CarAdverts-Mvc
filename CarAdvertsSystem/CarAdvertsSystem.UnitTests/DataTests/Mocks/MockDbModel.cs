using CarAdverts.Models.Contracts;

namespace CarAdvertsSystem.UnitTests.DataTests.Mocks
{
    public class MockDbModel : IDbModel
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
