using APIOne.src.Entity;

namespace APIOne.src.Contratos.IRepository
{
    public interface IUserRepository
    {
        Task<UsersEntity> Create(UsersEntity request);
        Task<UsersEntity> Get(int id);
        Task<UsersEntity> Update(UsersEntity request);
        Task<bool> Delete(int id);
        Task<List<UsersEntity>> List();
    }
}
