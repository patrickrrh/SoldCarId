using SoldCarId.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoldCarId.Repository
{
    public class Database
    {
        private static Database1Entities db = null;
        private Database() { }

        public static Database1Entities getDb()
        {
            if (db == null)
            {
                db = new Database1Entities();
            }

            return db;

        }


    }
}