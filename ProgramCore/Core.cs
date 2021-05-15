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
        public string ConnectionPath
        {
            get
            {
                return _connectionPath;
            }
            set
            {
                if (value != null)
                {
                    _connectionPath = value;
                }
                else
                {
                    throw new ArgumentNullException("Value is null");
                }
            }
        }

        private Core()
        {

        }

        private Core(string connectionPath)
        {
            ConnectionPath = connectionPath;
        }

        public static Core GetCore()
        {
            if (_core == null)
            {
                _core = new Core();
            }

            return _core;
        }

        public static Core GetCore(string connectionPath)
        {
            if (connectionPath != null)
            {
                if (_core == null)
                {
                    _core = new Core(connectionPath);
                }
                else
                {
                    _core.ConnectionPath = connectionPath;
                }

                return _core;
            }

            throw new ArgumentNullException("String connection path is null");
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
