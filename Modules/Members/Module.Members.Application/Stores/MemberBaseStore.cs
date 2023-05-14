using Module.Bases.Application.Stores;
using Module.Bases.Domain.Models;
using Module.Members.Infrastructure.Databases;

namespace Module.Members.Application.Stores
{
    public class MemberBaseStore<T> : BaseStore<T, MemberDbContext, MemberDbOption>
        where T : BaseEntity, new()
    {
        public MemberBaseStore(MemberDbContext dbContext) : base(dbContext)
        {
        }
    }
}
