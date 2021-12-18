using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;


namespace NV_CLIENT
{
    class AccountBUS
    {
        static IFirebaseConfig config = new FirebaseConfig
        { BasePath = "https://antran259820-default-rtdb.asia-southeast1.firebasedatabase.app/" };
        static FirebaseClient client = new FirebaseClient(config);

        public bool AddNew(Account newAccount)
        {
            try
            {
                client.Push("accounts", newAccount);
                return true;
            }
            catch { return false; }
        }

        public bool CheckAccount(Account account)
        {
            FirebaseResponse response = client.Get("accounts");
            Dictionary<String, Account> dictAccounts = response.ResultAs<Dictionary<String, Account>>();
            String key = dictAccounts.FirstOrDefault(x => x.Value.Username == account.Username && x.Value.Password == account.Password).Key; 
            if (String.IsNullOrEmpty(key)) return false; return true;
        }
    }
}
