using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Hackaton_team3
{
    public class Core
    {
        private static Core _core;
        private string _connectionPath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Хакатон\Hackaton_team3\TournamtsDb.mdf;Integrated Security=True";
        private SqlConnection _sqlConnection;
        private LoggingLevelSwitch _loggerSwitch;
        public List<Tournament> listOfTournaments { get; set; }
        public Logger DbLogger { get; private set; }

        public void Innitialize()
        {
            List<string> serializedTournaments = GetSerializedtournamentsFromDB();
            listOfTournaments = new List<Tournament>();
            foreach (var ser in serializedTournaments)
            {
                Tournament temp = Tournament.Create(ser);
                temp.Matches = new List<Match>();
                string[] tempSplit = ser.Split(',');
                temp.Id = Int32.Parse(tempSplit[tempSplit.Length - 1]);
                listOfTournaments.Add(temp);

            }
          
            foreach (var tounament in listOfTournaments)
            {
                List<string> serializesMatches = GetSerializedMatchesByTournamentFromDB(tounament.Id.ToString());
                foreach (var serMatch in serializesMatches)
                {
                    Match temp = Match.Create(serMatch);
                    string[] tempSplit = serMatch.Split(',');
                    temp.Id = Int32.Parse(tempSplit[tempSplit.Length - 1]);
                    tounament.Matches.Add(temp);
                }
            }




            foreach (var tounament in listOfTournaments)
            {
                foreach (var match in tounament.Matches)
                {
                    string[] participants = GetParticipantFromDbByMatch(match.Id.ToString());
                    Participant temp1 = Participant.Create(participants[0]);
                    Participant temp2 = Participant.Create(participants[1]);
                    match.ParticipantOne = temp1;
                    match.ParticipantTwo = temp2;
                }

            }
        }
        private Core()
        {
            ConnectDataBase();
        }

        public static Core GetCore()
        {
            if (_core == null)
            {
                _core = new Core();
            }

            return _core;
        }

        public bool ConnectDataBase()
        {
            if (_connectionPath != null)
            {
                bool result = true;
                InitDbLogger();
                _sqlConnection = new SqlConnection(_connectionPath);

                try
                {
                    _sqlConnection.Open();
                    DbLogger.Information("Connect to database");
                }
                catch (Exception e)
                {
                    result = false;
                    DbLogger.Error(e.Message);
                }

                return result;
            }

            throw new ArgumentNullException("String connection path is null");
        }

        public bool TableHasValues(string tableName)
        {
            bool res = false;

            string query = $"select * from [dbo].[{tableName}]";
            SqlCommand command = new SqlCommand(query, _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                res = true;
            }
            reader.Close();
            DbLogger.Information($"Query is done : {query}");
            return res;
        }
        public string[] GetParticipantFromDbByMatch(string matchId)
        {

            if (TableHasValues("Matches") && TableHasValues("Participants"))
            {
                if (matchId != null)
                {
                    string[] result = new string[2];

                    try
                    {
                        string query = $"select * from [dbo].[Participants] where id = (select [ParticipantOne] from [dbo].[Matches] where [dbo].[Matches].[ID]={matchId}) ";
                        SqlCommand command = new SqlCommand(query, _sqlConnection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            result[0] = $"{reader[1]},{reader[2]}";
                        }
                        reader.Close();
                        DbLogger.Information($"Query is done : {query}");
                    }
                    catch (Exception e)
                    {
                        result[0] = string.Empty;
                        DbLogger.Error(e.ToString());
                    }

                    try
                    {
                        string query = $"select * from [dbo].[Participants] where id = (select [ParticipantTwo] from [dbo].[Matches] where [dbo].[Matches].[ID]={matchId})";
                        SqlCommand command = new SqlCommand(query, _sqlConnection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            result[1] = $"{reader[1]},{reader[2]}";
                        }
                        reader.Close();
                        DbLogger.Information($"Query is done : {query}");
                    }
                    catch (Exception e)
                    {
                        result[1] = string.Empty;
                        DbLogger.Error(e.ToString());
                    }

                    return result;
                }
                else
                {
                    throw new ArgumentNullException("Value is null");
                }

                if (matchId != null)
                {
                    string[] result = new string[2];

                    try
                    {
                        string query = $"select * from [dbo].[Participants] where id = (select [ParticipantOne] from [dbo].[Matches] where [dbo].[Matches].[ID]={matchId}) ";
                        SqlCommand command = new SqlCommand(query, _sqlConnection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            result[0] = $"{reader[0]},{reader[1]}";
                        } 

                        reader.Close();
                        DbLogger.Information($"Query is done : {query}");
                    }
                    catch (Exception e)
                    {
                        result[0] = string.Empty;
                        DbLogger.Error(e.ToString());
                    }

                    try
                    {
                        string query = $"select * from [dbo].[Participants] where id = (select [ParticipantTwo] from [dbo].[Matches] where [dbo].[Matches].[ID]={matchId})";
                        SqlCommand command = new SqlCommand(query, _sqlConnection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            result[1] = $"{reader[1]},{reader[2]}";
                        }
                        reader.Close();
                        DbLogger.Information($"Query is done : {query}");
                    }
                    catch (Exception e)
                    {
                        result[1] = string.Empty;
                        DbLogger.Error(e.ToString());
                    }

                    return result;
                }
                else
                {
                    throw new ArgumentNullException("Value is null");
                }

            }
            else
            {
                throw new ArgumentNullException("Table is empty");
            }
           
        }
       
        public List<string> GetSerializedtournamentsFromDB()
        {
            List<string> result = new List<string>();
            if (TableHasValues("Tournaments"))
            {
                try
                {
                    string query = $"select * from [dbo].[Tournaments]";
                    SqlCommand command = new SqlCommand(query, _sqlConnection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add( $"{reader[1]},{reader[2]},{reader[3]},{reader[4]},{reader[5]},{reader[6]},{reader[7]},{reader[8]},{reader[9]},{reader[0]}");
                    }
                    reader.Close();
                    DbLogger.Information($"Query is done : {query}");
                }
                catch (Exception e)
                {                    
                    DbLogger.Error(e.ToString());
                }
            }

            return result;
        }

        public bool InsertParticipantInToDb(string value)
        {
            if (value != null)
            {
                bool result = true;
                try
                {
                    string query = $"insert dbo.[Participants] values({value})";
                    SqlCommand command = new SqlCommand(query, _sqlConnection);
                    int i = command.ExecuteNonQuery();
                    DbLogger.Information($"{i}Query is done : {query}");
                }
                catch (Exception e)
                {
                    result = false;
                    DbLogger.Error(e.ToString());
                }

                return result;
            }

            throw new ArgumentNullException("Value is null");
        }

        public bool InsertTournamentDb(string value)
        {
            DbLogger.Information($"Trying : InsertTournamentDb");
            if (value != null)
            {
                bool result = true;
                try
                {
                    string query = $"insert dbo.[Tournaments] values({value})";
                    DbLogger.Information($"Trying : {query}");
                    SqlCommand command = new SqlCommand(query, _sqlConnection);
                    int i = command.ExecuteNonQuery();
                    DbLogger.Information($"{i}Query is done : {query}");
                }
                catch (Exception e)
                {
                    result = false;
                    DbLogger.Error(e.ToString());
                }
                return result;
            }

            throw new ArgumentNullException("Value is null");
        }

        public bool InsertMatchDb(string value)
        {
            if (value != null)
            {
                bool result = true;
                try
                {
                    string query = $"insert dbo.[Matchess] values({value})";                 
                    SqlCommand command = new SqlCommand(query, _sqlConnection);
                    int i = command.ExecuteNonQuery();                 
                }
                catch (Exception e)
                {
                    result = false;
                    DbLogger.Error(e.ToString());
                }
                return result;
            }

            throw new ArgumentNullException("Value is null");
        }

        public List<string> GetSerializedMatchesByTournamentFromDB(string tournamentId)
        {

        
            List<string> result = new List<string>();

            if (TableHasValues("Tournaments_Matches") && TableHasValues("Matches"))
            {
               
                if (tournamentId != null)
                {
                    List<string> macthIds = new List<string>();
                   
                    try
                    {
                        string query = $"select * from [dbo].[Tournaments_Matches] where TournamentID = {tournamentId} ";
                        SqlCommand command = new SqlCommand(query, _sqlConnection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            macthIds.Add( $"{reader[0]}");
                        }
                        reader.Close();
                        DbLogger.Information($"Query is done : {query}");
                    }
                    catch (Exception e)
                    {                       
                        DbLogger.Error(e.ToString());
                    }


                    StringBuilder sb = new StringBuilder();
                    foreach (var id in macthIds)
                    {
                        sb.Append($"{id},");
                    }
                    string s = sb.ToString();
                    if (sb.ToString().Length>0)
                    {
                        s = s.ToString().Substring(0, s.Length - 1);
                    }

                    DbLogger.Information($"S : {s}");

                    try
                    {
                        string query = $"select * from [dbo].[Matches] where id in ({s})";
                        SqlCommand command = new SqlCommand(query, _sqlConnection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            result.Add($"{reader[1]},{reader[2]},{reader[3]},{reader[4]},{reader[5]},{reader[0]}");
                        }
                        reader.Close();
                        DbLogger.Information($"Query is done : {query}");
                    }
                    catch (Exception e)
                    {
                        DbLogger.Error(e.ToString());
                    }
                }
                else
                {
                    throw new ArgumentNullException("Value is null");
                }

          

            }
          


            return result;
        }
        private void InitDbLogger()
        {
            _loggerSwitch = new LoggingLevelSwitch();
            _loggerSwitch.MinimumLevel = LogEventLevel.Debug;

            DbLogger = new LoggerConfiguration()
                .WriteTo.File($"DbLog_{DateTime.Now.ToString("dd_MM__hh_mm_ss")}.txt")
                .MinimumLevel.ControlledBy(_loggerSwitch)
                .CreateLogger();
        }
    }
}
