using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Security;
using InventarioGoalSytem.Models;

namespace InventarioGoalSytem.Controllers
{
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpPost]
        public bool Login(string user, string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(data);

            string strResult = System.Text.Encoding.Default.GetString(result);
            
            if (user == "GoalSystem" && strResult == "\u007f\\;¡Œ·•6þ\u001a\tû\u001e·Ã(\u0081\u0013VÅ")
            {
                FormsAuthentication.SetAuthCookie(user ?? "GoalSystem", false);
                return true;
            }
            else
            {
                return false;
            } 
        }
    }
}
