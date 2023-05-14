using Module.Bases.Domain.Models;

namespace Module.Members.Domain.Models
{
    public class MemberChange : BaseEntity
    {
        public string MemberId { get; set; } = null!;
        public string FieldName { get; set; } = null!;
        public string FromValue { get; set; } = null!;
        public string ToValue { get; set; } = null!;

        public static List<MemberChange> Compare(Member newMember, Member? oldMember)
        {
            if (oldMember != null && oldMember.Id != newMember.Id)
                throw new Exception($"MemberChange.Compare: Member Id not match. Old Member Id = {oldMember.Id}. New Member Id = {newMember.Id}");

            var changes = new List<MemberChange>();

            if (newMember.Name != oldMember?.Name)
                changes.Add(new MemberChange
                {
                    MemberId = newMember.Id,
                    FieldName = nameof(newMember.Name),
                    FromValue = oldMember?.Name ?? string.Empty,
                    ToValue = newMember.Name
                });

            if (newMember.Email != oldMember?.Email)
                changes.Add(new MemberChange
                {
                    MemberId = newMember.Id,
                    FieldName = nameof(newMember.Email),
                    FromValue = oldMember?.Email ?? string.Empty,
                    ToValue = newMember.Email
                });

            return changes;
        }
    }
}
