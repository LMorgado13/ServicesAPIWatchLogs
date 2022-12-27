
//using System.Data.Entity;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using WatchDog.Domain.Entity;
using WatchDog.Infrastructure.Data;
using WatchDog.Infrastructure.Interface;


namespace WatchDog.Infrastructure.Repository
{
    public class UsersRepository  :  IUsersRepository 
    {
        private readonly EntityContext _context;
        private readonly DbContext dbContext;

        public UsersRepository(EntityContext context)
        {
            _context = context;
            this.dbContext = dbContext;
        }

        public Users DbUser { get; set; }
        public Users Authenticate(string userName, string password)
        {
            using (SqlConnection connection = (SqlConnection)_context.CreateConnection())
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", userName);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;


                //SqlParameter pContactName = new SqlParameter("@UserName", userName);
                //SqlParameter pContactPassword = new SqlParameter("@Password", password);
                //return DbUser.FromSql("EXECUTE UsersGetByUserAndPassword @UserName", pContactName);


                //SqlCommand cmd = connection.CreateCommand();
                //connection.Open();
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.CommandText = "UsersGetByUserAndPassword";
                //cmd.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 50).Value = userName;
                //cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = password;
                //cmd.ExecuteNonQuery();
                //connection.Close();
                ////Users response = DbUser.IsSuccess;



            }
           
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Users Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Users entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Users entity)
        {
            throw new NotImplementedException();
        }

      
    }
}