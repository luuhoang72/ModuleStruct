using Microsoft.Extensions.Options;
using Module.Bases.Infrastructure.Databases;
using Module.Members.Domain.Models;
using MongoDB.Driver;

namespace Module.Members.Infrastructure.Databases
{
    public class MemberDbOption : BaseDbOption
    {
    }

    public class MemberDbContext : MongoDbContext<MemberDbOption>
    {
        public MemberDbContext(IOptions<MemberDbOption> options) : base(options, "mb")
        {
        }

        public IMongoCollection<Member> Members { get { return Get<Member>(); } }
        public IMongoCollection<MemberChange> MemberChanges { get { return Get<MemberChange>(); } }
    }
}
