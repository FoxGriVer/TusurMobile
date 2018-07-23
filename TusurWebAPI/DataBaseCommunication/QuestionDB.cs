using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TusurWebAPI.Models;

namespace TusurWebAPI.DataBaseCommunication
{
    public class QuestionDB
    {
        public List<Questions> ListOfQuestions { get; set; }
        private MySqlConnection connection { get; set; }

        public QuestionDB(MySqlConnection _connection)
        {
            connection = _connection;
            ListOfQuestions = new List<Questions>();
        }

        public List<Questions> GetQuestions()
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Questions`", connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListOfQuestions.Add(new Questions()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Header = reader["Header"].ToString(),
                    Text = reader["Text"].ToString(),
                    IsPast = Convert.ToBoolean(reader["IsPast"])
                });
            }
            connection.Close();
            return ListOfQuestions;
        }

        public Questions GetExtendedQuestion(int _id)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Questions.Id, Questions.Header, Questions.Text, Questions.IsPast, Variants.Id as 'VariantId', Variants.Text as 'TextVariant', Variants.IsTrue FROM `Questions` INNER JOIN Variants on Variants.QuestionId = Questions.Id WHERE Questions.Id = '"+ _id +"' ", connection);
            var reader = cmd.ExecuteReader();
            reader.Read();
            if(reader.HasRows)
            {
                Questions currentQuestion = new Questions()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Header = reader["Header"].ToString(),
                    Text = reader["Text"].ToString(),
                    IsPast = Convert.ToBoolean(reader["IsPast"])
                };
                do
                {
                    currentQuestion.ListOfVariants.Add(new Variants()
                    {
                        Id = Convert.ToInt32(reader["VariantId"]),
                        Text = reader["TextVariant"].ToString(),
                        IsTrue = Convert.ToBoolean(reader["IsTrue"]),
                        QuestionId = Convert.ToInt32(reader["Id"])
                    });
                }
                while (reader.Read());
                connection.Close();
                return currentQuestion;
            }
            else
            {
                connection.Close();
                return null;
            }
        }

        public void AddQuestion(Questions _newQuestion)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `tusurwebapi`.`Questions` (`Header`, `Text`, `IsPast`) VALUES ('" + _newQuestion.Header + "', '" + _newQuestion.Text + "', " + _newQuestion.IsPast + ");", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
        }

        public bool DeleteQuestion(int id)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `Questions` WHERE `Questions`.`Id` = " + id + " ", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
            return Convert.ToBoolean(ans);
        }

        public bool ChangeQuestion(Questions _changedQuestion)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE `tusurwebapi`.`Questions` SET `Header` = '"+ _changedQuestion.Header +"', `Text` = '"+ _changedQuestion.Text +"', `IsPast` = "+ _changedQuestion.IsPast +"  WHERE `Questions`.`Id` =  '" + _changedQuestion.Id + "' ;", connection);
            var ans = cmd.ExecuteNonQuery();
            connection.Close();
            return Convert.ToBoolean(ans);
        }

    }
}
