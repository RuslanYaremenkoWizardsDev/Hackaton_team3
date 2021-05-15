using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Data.SqlClient;

namespace TestLibrary
{
    public class Class1
    {
        private string _connectionString = "Data Source=DESKTOP-2SAV0E8;Initial Catalog=Hackaton_team3;Integrated Security=True";
        private SqlConnection _sqlConnection;
        private LoggingLevelSwitch _loggerSwitch;
        public Logger DbLogger;

        private Class1()
        {
            InitDbLogger();
            _sqlConnection = new SqlConnection(_connectionString);

            try
            {
                _sqlConnection.Open();
                DbLogger.Information("Connect to database");
            }
            catch (Exception e)
            {
                DbLogger.Error(e.Message);
            }
        }

        public static Class1 GetCore()
        {
            return new Class1();
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
