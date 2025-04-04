using System.Collections.Generic;
using System.Data;
using APIOne.src.Contratos.IRepository;
using APIOne.src.Entity;
using Dapper;

namespace APIOne.src.Repository
{
    public class UserRepository(
        IDbConnection _context
        ) : IUserRepository
    {
        //CREATE
        public async Task<UsersEntity> Create(UsersEntity request)
        {
            string query = @$"
                INSERT INTO public.usuarios(
	                nome, email, cpf, idade, password)
	                VALUES (:Nome, :Email, :Cpf, :Idade, :Password)

                RETURNING id, nome, email, cpf, idade, password;";

            return await _context.QueryFirstOrDefaultAsync<UsersEntity>(query, request);
        }
        //GET
        public async Task<UsersEntity> Get(int id)
        {
            string query = @"SELECT * FROM public.usuarios where id = :Id";
            return await _context.QueryFirstOrDefaultAsync<UsersEntity>(query, new { Id = id });
        }
        //DELETE
        public async Task<bool> Delete(int id)
        {
            string query = @"DELETE FROM public.usuarios where Id = :id";
            return await _context.ExecuteAsync(query, new { Id = id }) > 0;
        }

        //lIST
        public async Task<List<UsersEntity>> List()  
        {
            string query = @"SELECT * FROM public.usuarios";
            return (await _context.QueryAsync<UsersEntity>(query)).ToList();
        }

        //UPDATE
        public async Task<UsersEntity> Update(UsersEntity request)
        {
            string query = @"UPDATE public.usuarios
	            SET nome=:Nome, email=:Email, cpf=:Cpf, idade=:Idade, password=:Password
	            WHERE Id = :Id
                RETURNING id, nome, email, cpf, idade, password;
            ";

            return await _context.QueryFirstOrDefaultAsync<UsersEntity>(query, request);
        }
    }
}

