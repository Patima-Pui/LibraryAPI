using System;
using System.Collections.Generic;

namespace LibraryAPI
{
    public class UserModel
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthday { get; set; }
        public string email { get; set; }
        public string upsertName { get; set; }
    }

    public class UsersListModel
    {
        public List<UserModel> usersList { get; set; }
    }

    public class LoginModle
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class ResponseModel
    {
        public bool state { get; set; }
        public string message { get; set; }
    }

    public class ResposeLoginModel : ResponseModel
    {
        public int userId { get; set; }
    }
   
   
}