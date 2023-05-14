using Module.Members.Domain.Models;
using Module.Members.Domain.Stores;
using Module.Members.Infrastructure.Databases;

namespace Module.Members.Application.Stores
{
    public class MemberChangeStore : MemberBaseStore<MemberChange>, IMemberChangeStore
    {
        public MemberChangeStore(MemberDbContext dbContext) : base(dbContext)
        {
        }
    }
}
