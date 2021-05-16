using System;
using System.Data.SqlClient;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace ProgramCore
{
    public class Core
    {
        private static Core _core;
        private string _connectionPath = "Data Source=DESKTOP-2SAV0E8;Initial Catalog=Hackaton_team3;Integrated Security=True";
        private SqlConnection _sqlConnection;
        private LoggingLevelSwitch _loggerSwitch;
        public Logger DbLogger { get; private set; }
        
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
