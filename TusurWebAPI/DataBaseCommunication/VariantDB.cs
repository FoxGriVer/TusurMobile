using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TusurWebAPI.Models;

namespace TusurWebAPI.DataBaseCommunication
{    
    public class VariantDB
    {
        public List<Variants> ListOfVariants { get; set; }
        private MySqlConnection connection { get; set; }

        public VariantDB(MySqlConnection _connection)
        {
            connection = _connection;
            ListOfVariants = new List<Variants>();
        }

        public List<Variants> GetVariants()
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Variants`", connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListOfVariants.Add(new Variants()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Text = reader["Text"].ToString(),
                    IsTrue = Convert.ToBoolean(reader["IsTrue"]),
                    QuestionId = Convert.ToInt32(reader["QuestionId"])
                });
            }
            connection.Close();
            return ListOfVariants;
        }

        public List<Object> GetExtendedVariants()
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Variants.Id, Variants.Text, Variants.IsTrue, Variants.QuestionId, Questions.Header FROM `Variants` LEFT JOIN Questions on Questions.Id = Variants.QuestionId", connection);
            var reader = cmd.ExecuteReader();
            List<Object> ListOfObjects = new List<object>();
            while (reader.Read())
            {
                var variant = new
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Text = reader["Text"].ToString(),
                    IsTrue = Convert.ToBoolean(reader["IsTrue"]),
                    QuestionId = Convert.ToInt32(reader["QuestionId"]),
                    QuestionHeader = reader["Header"].ToString()
                };
                ListOfObjects.Add(variant);
            }
            connection.Close();
            return ListOfObjects;
        }

        public bool AddVariant(Variants _newVariant)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(" INSERT INTO `tusurwebapi`.`Variants` (`QuestionId`, `Text`, `IsTrue`) VALUES ('" + _newVariant.QuestionId + "', '" + _newVariant.Text + "', "+ _newVariant.IsTrue+");", connection);
            try
            {
                var ans = cmd.ExecuteNonQuery();
                connection.Close();
                return Convert.ToBoolean(ans);
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteVariant(int id)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `Variants` WHERE `Variants`.`Id` = " + id + " ", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
            return Convert.ToBoolean(ans);
        }

        public bool ChangeVariant(Variants _changedVariant)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE `tusurwebapi`.`Variants` SET `QuestionId` = '" + _changedVariant.QuestionId + "', `Text` = '" + _changedVariant.Text + "', `IsTrue` = " + _changedVariant.IsTrue + " WHERE `Variants`.`Id` = '"+ _changedVariant.Id +"' ;", connection);
            try
            {
                var ans = cmd.ExecuteNonQuery();
                connection.Close();
                return Convert.ToBoolean(ans);
            }
            catch
            {
                return false;
            }

        }

    }
}
