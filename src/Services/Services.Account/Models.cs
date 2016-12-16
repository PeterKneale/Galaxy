
using ServiceStack.DataAnnotations;

namespace Services.Account
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class AccountData
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}