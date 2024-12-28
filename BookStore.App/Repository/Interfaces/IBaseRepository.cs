namespace BookStore.App.Repository.Interfaces
{
    public interface IBaseRepository
    {
        public Task SoftDeleteAsync(Guid id);
        public Task RecoverAsync(Guid id);
        public Task DeleteAsync(Guid id);
    }
}
