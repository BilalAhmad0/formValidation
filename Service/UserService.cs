using BasicAuthentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicAuthentication.Services
{
    public class UserService 
    {
        private List<Person> _users = new List<Person>
        {
            new Person { Id = 2,
                FirstName = "Bilal",
                LastName = "Ahmad", 
                Username = "ba681773@gmail.com", 
                Password = "test" }
        };   
        public int Authenticate(string username, string password)
        {
            try
            {
                if(_users.FirstOrDefault().Username == username &&
                    _users.FirstOrDefault().Password == password)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }   
        }
    }
}