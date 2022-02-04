using BasicAuthentication.Model;
using BasicAuthentication.Services;
using System;


namespace formsValidation.Manager
{
    public class AuthenticationManger
    {
        public bool Authenticate(AuthenticateModel model)
        {
            try
            {
                bool status=false;

                UserService am = new UserService();
                var user = am.Authenticate(model.Username, model.Password);
                if (user == 1){
                    status = true;
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
