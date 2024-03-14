using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRolesRepository : Repository<User_Role>
    {
        public UserRolesRepository(DatabaseRPP context) : base(context)
        {
        }
        public List<User_Role> GetAllRoles()
        {
            return Entities.ToList();
        }

        public override int Update(User_Role entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
