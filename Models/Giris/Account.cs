using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using staj2.data;

namespace staj2.Models.Giris
{
    public class Account
    {
        private data.loginEntities1 db;
        public Account()
        {
            db = new data.loginEntities1();
        }
        public bool Basarili(string kullanici, string password)
        {
            log resultUser = db.log.Where(x => x.Kuladi == kullanici && x.Sifre == password).FirstOrDefault();
            if (resultUser != null)
            {
           
                return true;
            }
            return false;
        }
    }

}