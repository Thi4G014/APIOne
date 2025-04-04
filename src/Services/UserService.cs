using System.Security.AccessControl;
using APIOne.src.Contratos.IRepository;
using APIOne.src.Contratos.IServices;
using APIOne.src.Entity;

namespace APIOne.src.Services
{
    public class UserService (
        IUserRepository _userRepository
        ):IUsersServices
    {
        public async Task<UsersEntity> Create(UsersEntity request)
        {
            return await _userRepository.Create(request);
        }

        public async Task<bool> Delete(int id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<UsersEntity> Get(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<List<UsersEntity>> List()
        {
            return await _userRepository.List();
        }

        public async Task<UsersEntity> Update(UsersEntity request)
        {
            return await _userRepository.Update(request);
        }
    }
}
