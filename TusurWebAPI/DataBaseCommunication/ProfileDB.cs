using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TusurWebAPI.Models;

namespace TusurWebAPI.DataBaseCommunication
{
    public class ProfileDB
    {
        public List<Profiles> ListOfProfiles { get; set; }
        private MySqlConnection connection { get; set; }

        public ProfileDB(MySqlConnection _connection)
        {
            connection = _connection;
            ListOfProfiles = new List<Profiles>();
        }

        public List<Object> GetExtendedProfiles()
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Profiles.Id, Profiles.Name, Profiles.Description, Profiles.SpecialityId, Specialties.Name as 'SpecialityName'" +
                                                " FROM `Profiles`" +
                                                " INNER JOIN Specialties on Specialties.Id = Profiles.SpecialityId", connection);
            var reader = cmd.ExecuteReader();
            List<Object> listOfCustomProfiles = new List<Object>();
            while (reader.Read())
            {
                var profile = new
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    SpecialityId = Convert.ToInt32(reader["SpecialityId"]),
                    SpecialityName = reader["SpecialityName"].ToString(),
                };
                listOfCustomProfiles.Add(profile);
            }
            connection.Close();
            return listOfCustomProfiles;
        }

        public List<Profiles> GetProfiles()
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Profiles`", connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListOfProfiles.Add(new Profiles()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    SpecialityId = Convert.ToInt32(reader["SpecialityId"])
                });
            }
            connection.Close();
            return ListOfProfiles;
        }

        public void AddProfile(Profiles _newProfile)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `tusurwebapi`.`Profiles` (`Id`, `SpecialityId`, `Name`, `Description`)" +
                                                " VALUES (NULL, '"+_newProfile.SpecialityId+"', '" + _newProfile.Name + "', '" + _newProfile.Description + "');", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
        }

        public bool ChangeProfile(Profiles _changedProfile)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE `tusurwebapi`.`Profiles` SET `SpecialityId` = '"+ _changedProfile.SpecialityId +"', `Name` = '" + _changedProfile.Name + "', `Description` = '" + _changedProfile.Description + "'" +
                                                " WHERE `Profiles`.`Id` = " + _changedProfile.Id + ";", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
            return Convert.ToBoolean(ans);
        }

        public bool DeleteProfile(int id)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `Profiles` WHERE `Profiles`.`Id` = " + id + " ", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
            return Convert.ToBoolean(ans);
        }

    }
}
