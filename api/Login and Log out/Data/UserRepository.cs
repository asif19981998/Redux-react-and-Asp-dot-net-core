using Login_and_Log_out.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_and_Log_out.Data
{
    public class UserRepository : IUserRepository
    {
        public readonly UserDbContext _db;
        public UserRepository(UserDbContext db)
        {
            _db = db;

        }
        public User Create(User user)
        {
            _db.Users.Add(user);
           user.Id = _db.SaveChanges();
            return user;
        }

        public User GetByEmail(string email)
        {
            return _db.Users.FirstOrDefault(user => user.Email == email);
        }

        public User GetById(int id)
        {
            return _db.Users.FirstOrDefault(user => user.Id == id);
        }
    }
}
