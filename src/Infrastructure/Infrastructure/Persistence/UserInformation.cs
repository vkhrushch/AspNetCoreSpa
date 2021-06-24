using AspNetCoreSpa.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace AspNetCoreSpa.Infrastructure.Persistence
{
    public class UserInformation: IUserInformation
    {
        public Dictionary<Guid, string> GetUsers()
        {
            string fullPath = @"C:\Users\omusiyenko001\source\repos\AspNetCoreSpa2\src\Presentation\STS\STS.db";
            SQLiteConnection conread = new SQLiteConnection("Data Source=" + fullPath);
            conread.Open();

            SQLiteDataAdapter DB = new SQLiteDataAdapter("SELECT * FROM AspNetUsers", conread);
            DataSet DS = new DataSet();
            DB.Fill(DS, "Users");
            return DS.Tables[0].AsEnumerable().ToDictionary(i => Guid.Parse(i["Id"].ToString()), v => v["Email"].ToString());
        }
    }
}
