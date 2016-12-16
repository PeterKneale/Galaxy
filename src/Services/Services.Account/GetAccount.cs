using ServiceStack;
using ServiceStack.OrmLite;

namespace Services.Account
{
    [Route("/account/{id}")]
    public class GetAccount : IReturn<GetAccountResponse>
    {
        public int Id { get; set; }
    }

    public class GetAccountResponse
    {
        public AccountModel Account { get; set; }
        public string Result { get; set; }
    }

    public class GetAccountService : Service
    {
        public object Any(GetAccount request)
        {
            using (var transaction = Db.BeginTransaction())
            {
                var data = Db.SingleById<AccountData>(request.Id);
                if (data == null)
                {
                    throw HttpError.NotFound("Account does not exist");
                }
                
                var account = data.ConvertTo<AccountModel>();
                return new GetAccountResponse { Account = account };
            }
        }
    }
}