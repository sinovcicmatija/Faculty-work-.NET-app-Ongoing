using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DatabaseRPP context) : base(context)
        {
        }

        public User GetUserByEmail(string email)
        {
            return Entities.FirstOrDefault(e => e.Email == email);
        }

        public override int Update(User entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
