using System;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using TusurWebAPI.Models;
using System.Collections.Generic;

namespace TusurWebAPI.DataBaseCommunication
{
    public class TusurWebAPIContext
    {
        private string ConnectionString { get; set; }
        private MySqlConnection connection { get; set; }
        public SubjectDB SubjectDB { get; set; }
        public VariantDB VariantDB { get; set; }
        public QuestionDB QuestionDB { get; set; }
        public SpecialityDB SpecialityDB { get; set; }
        public ProfileDB ProfileDB { get; set; }

        public TusurWebAPIContext()
        {
            this.ConnectionString = "Server=54.36.121.209;Database=tusurwebapi;UID=dotcomuser;Password=dotcomuser123;SslMode=none";
            GetConnection();
            SubjectDB = new SubjectDB(connection);   
            VariantDB = new VariantDB(connection);
            QuestionDB = new QuestionDB(connection);
            SpecialityDB = new SpecialityDB(connection);
            ProfileDB = new ProfileDB(connection);
        }

        private void GetConnection()
        {
            connection = new MySqlConnection(ConnectionString);
        }

    }
}
