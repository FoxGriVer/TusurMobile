using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TusurWebAPI.Models;

namespace TusurWebAPI.DataBaseCommunication
{
    public class SpecialityDB
    {
        public List<Specialties> ListOfSpecialties { get; set; }
        private MySqlConnection connection { get; set; }

        public SpecialityDB(MySqlConnection _connection)
        {
            connection = _connection;
            ListOfSpecialties = new List<Specialties>();
        }

        public List<Specialties> GetSpecialties()
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Specialties`", connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListOfSpecialties.Add(new Specialties()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Faculty = reader["Faculty"].ToString(),
                    FreePlaces = Convert.ToInt32(reader["FreePlaces"]),
                    PayPlaces = Convert.ToInt32(reader["PayPlaces"]),
                    StartNumberOfPointsInPastYear = Convert.ToInt32(reader["StartNumberOfPointsInPastYear"]),
                    Price = Convert.ToInt32(reader["Price"]),
                    Duration = Convert.ToInt32(reader["Duration"]),
                    Qualification = reader["Qualification"].ToString(),
                    Testing = reader["Testing"].ToString(),
                });
            }
            connection.Close();
            return ListOfSpecialties;
        }

        public List<Specialties> GetExtendedSpecialties()
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Specialties.Id, Specialties.Name, Faculties.Id as 'FacultyId', Faculties.Name as 'FacultyName', Specialties.FreePlaces, Specialties.PayPlaces," +
                                                " Specialties.StartNumberOfPointsInPastYear, Specialties.Price, Specialties.Duration, Specialties.Testing, Qualification.Name as 'QualifName', Profiles.Id as 'ProfileId'," +
                                                " Profiles.SpecialityId as 'IdOfSpeciality', Profiles.Name as 'ProfileName' " +
            " FROM `Specialties` INNER JOIN Faculties on Faculties.Id = Specialties.Faculty" +
            " INNER JOIN Profiles on Profiles.SpecialityId = Specialties.Id" +
            " INNER JOIN Qualification on Qualification.Id = Specialties.Qualification", connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                bool isExist = false;
                foreach(var element in ListOfSpecialties)
                {
                    if (element.Id == Convert.ToInt32(reader["Id"]))
                        isExist = true;
                    else
                        isExist = false;
                }
                if(!isExist)
                {
                    Specialties oneOfSpecialities = new Specialties()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Faculty = reader["FacultyName"].ToString(),
                        FreePlaces = Convert.ToInt32(reader["FreePlaces"]),
                        PayPlaces = Convert.ToInt32(reader["PayPlaces"]),
                        StartNumberOfPointsInPastYear = Convert.ToInt32(reader["StartNumberOfPointsInPastYear"]),
                        Price = Convert.ToInt32(reader["Price"]),
                        Duration = Convert.ToInt32(reader["Duration"]),
                        Qualification = reader["QualifName"].ToString(),
                        Testing = reader["Testing"].ToString()
                    };
                    ListOfSpecialties.Add(oneOfSpecialities);
                }
                foreach(var element in ListOfSpecialties)
                {
                    if(element.Id == Convert.ToInt32(reader["IdOfSpeciality"]) )
                    {
                        element.ListOfProfiles.Add(new Profiles()
                        {
                            Id = Convert.ToInt32(reader["ProfileId"]),
                            Name = reader["ProfileName"].ToString()                             
                        });
                    }
                }

            }
            connection.Close();
            return ListOfSpecialties;
        }

        public bool AddSpeciality(Specialties _speciality)
        {
            //доделать проверку на факультет и квалификацию
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `tusurwebapi`.`Specialties` (`Id`, `Name`, `Faculty`, `FreePlaces`, `PayPlaces`," +
                                                " `StartNumberOfPointsInPastYear`, `Price`, `Duration`, `Qualification`, `Testing`) " +
                                                "VALUES (NULL, '"+ _speciality.Name +"', '10', '" + _speciality.FreePlaces + "', '" + _speciality.PayPlaces + "'," +
                                                " '" + _speciality.StartNumberOfPointsInPastYear + "', '" + _speciality.Price + "', '" + _speciality.Duration + "'," +
                                                " '3', '" + _speciality.Qualification + "');", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
            return Convert.ToBoolean(ans);
        }

        public bool DeleteSpeciality(int id)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `Specialties` WHERE `Specialties`.`Id` = " + id + " ", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
            return Convert.ToBoolean(ans);
        }

        public bool ChangeSpeciality(Specialties _changedSpeciality)
        {
            //доделать проверку на факультет и квалификацию
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE `tusurwebapi`.`Specialties` SET `Name` = '"+ _changedSpeciality.Name +"', `Faculty` = '9', `FreePlaces` = '" + _changedSpeciality.FreePlaces + "'," +
                                                " `PayPlaces` = '" + _changedSpeciality.PayPlaces + "', `StartNumberOfPointsInPastYear` = '" + _changedSpeciality.StartNumberOfPointsInPastYear + "'," +
                                                " `Price` = '" + _changedSpeciality.Price + "', `Duration` = '" + _changedSpeciality.Duration + "', `Qualification` = '2', `Testing` = '" + _changedSpeciality.Testing + "'" +
                                                " WHERE `Specialties`.`Id` = " + _changedSpeciality.Id + ";", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
            return Convert.ToBoolean(ans);
        }

    }
}
