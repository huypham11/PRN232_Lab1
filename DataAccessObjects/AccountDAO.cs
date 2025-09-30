using BusinessObjects;

namespace DataAccessObjects;

public class AccountDAO
{
    public static AccountMember GetAccountById(string accountID)
    {
        using var context = new MyStoreDbContext();
        return context.AccountMembers.FirstOrDefault(x => x.MemberId.Equals(accountID));
    }
}