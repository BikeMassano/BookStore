namespace BookStore.App.Interfaces.Repository
{
    public interface IRepositoryBase
    {
        public Task SoftDeleteAsync(Guid id);
        public Task RecoverAsync(Guid id);
        public Task DeleteAsync(Guid id);
    }
}
