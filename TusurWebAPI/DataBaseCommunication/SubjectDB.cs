using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TusurWebAPI.Models;
namespace TusurWebAPI.DataBaseCommunication
{
    public class SubjectDB
    {
        public List<Subjects> ListOfSubjects { get; set; }
        private MySqlConnection connection { get; set; }

        public SubjectDB(MySqlConnection _connection)
        {
            connection = _connection;
            ListOfSubjects = new List<Subjects>();
        }

        public List<Subjects> GetSubjects()
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Subjects`", connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListOfSubjects.Add(new Subjects()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    AmmountOfPoints = Convert.ToInt32(reader["AmmountOfPoints"])
                });
            }
            connection.Close();
            return ListOfSubjects;
        }

        public void AddSubject(Subjects _newSubject)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `Subjects` (`Id`, `Name`, `AmmountOfPoints`) VALUES (NULL, '" + _newSubject.Name + "', '" + _newSubject.AmmountOfPoints + "');", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
        }

        public bool DeleteSubject(int id)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `Subjects` WHERE `Subjects`.`Id` = " + id + " ", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
            return Convert.ToBoolean(ans);
        }

        public bool ChangeSubject(Subjects _changedSubject)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE `tusurwebapi`.`Subjects` SET `AmmountOfPoints` = '"+ _changedSubject.AmmountOfPoints +"', `Name` = '" + _changedSubject.Name + "' WHERE `Subjects`.`Id` = '"+ _changedSubject.Id + "' ;", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
            return Convert.ToBoolean(ans);
        }

    }
}
