using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;

namespace Parkers.Data
{
    /// <summary>
    /// Encapsulates a SQL stored procedure call.
    /// </summary>
    /// <include file='Sproc.doc.xml' path='comments/section[@name="Class"]/*' />
    public class Sproc : IDisposable
    {
        private static string applicationName = ".NET 2.0 (Parkers.Data)";
        private static string defaultDatabase;
        private static string defaultServer;
        private static int timeout = 20;

        private static object _lockObject = new object();

        private SqlCommand innerCommand;

        /// <summary>
        /// The name of the stored procedure to execute
        /// </summary>
        /// <value>A stored procedure name</value>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                innerCommand.CommandText = name;
            }
        }
        private string name;

        /// <summary>
        /// The name of the database which the command will execute against
        /// </summary>
        /// <value>A database name</value>
        ///        
        public string Database
        {
            get
            {
                return database;
            }
            set
            {
                database = value;
            }
        }
        private string database;

        /// <summary>
        /// The connectionStrings entry to use
        /// </summary>
        /// <value>The name of a connectionStrings entry</value>
        public string Server
        {
            get
            {
                return server;
            }
            set
            {
                server = value;
            }
        }
        private string server;

        /// <summary>
        /// Parameters collection for the stored procedure call
        /// </summary>
        /// <value>The Parameters property of the internal SqlCommand</value>
        public SqlParameterCollection Parameters
        {
            get
            {
                return innerCommand.Parameters;
            }
        }

        /// <summary>
        /// The time (in seconds) to wait for the command to execute.
        /// </summary>
        public int CommandTimeout
        {
            get
            {
                return innerCommand.CommandTimeout;
            }
            set
            {
                innerCommand.CommandTimeout = value;
            }
        }

        static Sproc()
        {
            defaultServer = (string)ConfigurationManager.AppSettings["Parkers.Data.DefaultServer"];
            defaultDatabase = (string)ConfigurationManager.AppSettings["Parkers.Data.DefaultDatabase"];
            int configTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["Parkers.Data.CommandTimeout"]);
            if (configTimeout > 0)
            {
                timeout = configTimeout;
            }

            if (ConfigurationManager.AppSettings["Parkers.Data.ApplicationName"] != null)
            {
                applicationName = (string)ConfigurationManager.AppSettings["Parkers.Data.ApplicationName"];
            }

            InitialiseCounter();
        }

        /// <summary>
        /// Create a new Sproc to execute against the default database on the default server.
        /// The Name property must be set before any Execute...() methods can be used.
        /// </summary>
        public Sproc() : this("", defaultDatabase, defaultServer)
        {
        }

        /// <overloads>
        /// Initialises a new instance of the Sproc class.
        /// </overloads>
        /// <summary>
        /// Creates a new Sproc to execute against the default database and server.
        /// </summary>
        /// <param name="name">Stored procedure name</param>
        public Sproc(string name) : this(name, defaultDatabase, defaultServer)
        {
        }

        /// <summary>
        /// Creates a new Sproc to execute against the specified database on the default server.
        /// </summary>
        /// <param name="name">Stored procedure name</param>
        /// <param name="database">Database name</param>
        public Sproc(string name, string database) : this(name, database, defaultServer)
        {
        }

        /// <summary>
        /// Creates a new Sproc to execute against the specified database on the specified server.
        /// </summary>
        /// <param name="name">Stored procedure name</param>
        /// <param name="database">Database name</param>
        /// <param name="server">Server name</param>
        public Sproc(string name, string database, string server)
        {
            this.name = name;
            this.database = database;
            this.server = server;

            innerCommand = new SqlCommand(name);
            innerCommand.CommandType = CommandType.StoredProcedure;
            innerCommand.CommandTimeout = timeout;
        }

        /// <summary>
        /// Executes the command and returns a bool indicating success or failure
        /// </summary>
        /// <returns><c>true</c> if the call completed successfully, <c>false</c> otherwise</returns>
        public bool ExecuteNonQuery()
        {
            SqlConnection newConnection = null;
            try
            {
                newConnection = GetConnection();
                innerCommand.Connection = newConnection;
                newConnection.Open();
                innerCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                if (newConnection != null && newConnection.State != ConnectionState.Closed)
                {
                    newConnection.Close();
                }
            }
        }

        /// <summary>
        /// Executes the command and returns the first column of the first row.
        /// </summary>
        /// <returns>The first column of the first row, or null if the result set is empty</returns>
        public object ExecuteScalar()
        {
            SqlConnection newConnection = null;
            try
            {
                newConnection = GetConnection();
                innerCommand.Connection = newConnection;
                newConnection.Open();
                return innerCommand.ExecuteScalar();
            }
            finally
            {
                if (newConnection != null && newConnection.State != ConnectionState.Closed)
                {
                    newConnection.Close();
                }
            }
        }


        /// <overloads>
        /// Executes the command and returns a DataSet containing the results.
        /// </overloads>
        /// <summary>
        /// Create a new DataSet and use "Table" as the table name for the results.
        /// </summary>
        /// <returns>A DataSet</returns>
        public DataSet ExecuteDataSet()
        {
            DataSet newDataSet = new DataSet();
            ExecuteDataSet(newDataSet);
            return newDataSet;
        }

        /// <summary>
        /// Add the results to an existing DataSet, using table name "Table".
        /// </summary>
        /// <param name="target">The DataSet to add the results to</param>
        public void ExecuteDataSet(DataSet target)
        {
            ExecuteDataSet(target, "Table");
        }

        /// <summary>
        /// Add the results to an existing DataSet, using the specified tablename.
        /// </summary>
        /// <param name="target">The DataSet to add the results to</param>
        /// <param name="tablename">The tablename for the results</param>
        public void ExecuteDataSet(DataSet target, string tablename)
        {
            SqlConnection newConnection = null;
            SqlDataAdapter newAdapter = null;
            try
            {
                newConnection = GetConnection();
                innerCommand.Connection = newConnection;

                newAdapter = new SqlDataAdapter(innerCommand);
                newAdapter.Fill(target, tablename);
            }
            finally
            {
                if (newAdapter != null)
                {
                    newAdapter.Dispose();
                }
                if (newConnection != null && newConnection.State != ConnectionState.Closed)
                {
                    newConnection.Close();
                }
            }
        }

        /// <summary>
        /// Executes the command and returns a SqlDataReader
        /// </summary>
        /// <returns>A SqlDataReader containing the results of the call</returns>
        /// <remarks>
        /// The SqlDataReader is created with CommandBehavior.CloseConnection, so the
        /// connection will be automatically closed when the reader is closed.
        /// </remarks>
        /// <include file='Sproc.doc.xml' path='comments/section[@name="ExecuteReader"]/*' />
        public SqlDataReader ExecuteReader()
        {
            SqlDataReader newReader = null;
            SqlConnection newConnection = null;
            try
            {
                newConnection = new SqlConnection("Data Source=.;Persist Security Info=True;User ID=web_Parkers;Password=N44ZMm4s2E;database=ParkersCar");
                innerCommand.Connection = newConnection;
                newConnection.Open();
                newReader = innerCommand.ExecuteReader(CommandBehavior.CloseConnection);
                return newReader;
            }
            catch (Exception e)
            {
                // Only close on exception, since SqlDataReader needs an open connection
                if (newReader != null && newReader.IsClosed == false)
                {
                    newReader.Close();
                }
                if (newConnection != null && newConnection.State != ConnectionState.Closed)
                {
                    newConnection.Close();
                }
                // Rethrow the exception
                throw e;
            }
        }

        /// <summary>
        /// Executes the command and returns a List of the specified type
        /// </summary>
        /// <typeparam name="T">The type of the output objects</typeparam>
        /// <param name="converter">A delegate which creates an object from a row of the result set</param>
        /// <returns>A List with one item for each row of the result set, excluding any rows for which the converter returned null.
        /// Returns an empty list if no rows are returned or the command fails.</returns>
        /// <include file='Sproc.doc.xml' path='comments/section[@name="ExecuteList"]/*' />
        public List<T> ExecuteList<T>(Converter<IDataRecord, T> converter)
        {
            List<T> result = new List<T>();
            using (SqlDataReader dr = this.ExecuteReader())
            {
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        T item = converter(dr);
                        if (item != null)
                        {
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Executes the command and returns an object created from the first row of the result set.
        /// </summary>
        /// <typeparam name="T">The type of the output object</typeparam>
        /// <param name="converter">A delegate which creates an object from a row of the result set</param>
        /// <returns>The result of passing the first row of the result set to converter, or null if no rows were returned.</returns>
        /// <include file='Sproc.doc.xml' path='comments/section[@name="ExecuteObject"]/*' />
        public T ExecuteObject<T>(Converter<IDataRecord, T> converter)
        {
            T result = default(T);
            using (SqlDataReader dr = this.ExecuteReader())
            {
                if (dr != null && dr.HasRows)
                {
                    dr.Read();
                    result = converter(dr);
                }
            }
            return result;
        }

        /// <summary>
        /// Executes the command asynchronously to return a List of the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="converter">A delegate which creates an object from a row of the result set</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IAsyncResult BeginExecuteList<T>(Converter<IDataRecord, T> converter, AsyncCallback callback)
        {
            return BeginExecuteReader(callback, converter);
        }

        /// <summary>
        /// Retrieves the List of results from a complete asynchronous call
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ar"></param>
        /// <returns></returns>
        public List<T> EndExecuteList<T>(IAsyncResult ar)
        {
            SqlDataReader dr = null;
            try
            {
                Converter<IDataRecord, T> converter = ar.AsyncState as Converter<IDataRecord, T>;
                dr = EndExecuteReader(ar);

                List<T> result = new List<T>();
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        T item = converter(dr);
                        if (item != null)
                        {
                            result.Add(item);
                        }
                    }
                }
                return result;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }
        }


        /// <summary>
        /// Fill the Parameters collection by querying the database
        /// </summary>
        /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
        /// <remarks>
        /// Since this requires a round-trip to the database, it should not be used routinely.
        /// </remarks>
        public bool FillParameters()
        {
            innerCommand.Parameters.Clear();

            SqlConnection newConnection = null;
            try
            {
                using (SqlCommandBuilder commandBuilder = new SqlCommandBuilder())
                {
                    newConnection = GetConnection();
                    innerCommand.Connection = newConnection;
                    newConnection.Open();
                    SqlCommandBuilder.DeriveParameters(innerCommand);
                }
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            finally
            {
                if (newConnection != null && newConnection.State != ConnectionState.Closed)
                {
                    newConnection.Close();
                }
            }
        }

        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        /// <returns>A new Sproc that is a deep copy of this instance</returns>
        public Sproc Clone()
        {
            Sproc newSproc = new Sproc(name, database, server);
            newSproc.Parameters.Clear();
            foreach (SqlParameter p in this.Parameters)
            {
                SqlParameter newParameter = new SqlParameter(p.ParameterName, p.SqlDbType, p.Size, p.Direction, p.IsNullable, p.Precision, p.Scale, p.SourceColumn, p.SourceVersion, p.Value);
                newSproc.Parameters.Add(newParameter);
            }
            return newSproc;
        }

        private static void InitialiseCounter()
        {
            if (HttpContext.Current == null)
            {
                return;
            }

            lock (_lockObject)
            {
                if (!(HttpContext.Current.Application["CurrentDbRequestCounts"] is Dictionary<string, int>))
                {
                    HttpContext.Current.Application["CurrentDbRequestCounts"] = new Dictionary<string, int>();
                }
            }
        }

        private SqlConnection GetConnection()
        {
            return GetConnection(false);
        }

        private SqlConnection GetAsyncConnection()
        {
            return GetConnection(true);
        }

        private SqlConnection GetConnection(bool isAsync)
        {
            string connectionString;
            //try
            //{
            //    connectionString = ConfigurationManager.ConnectionStrings[server].ConnectionString;
            //}
            //catch (NullReferenceException)
            //{
            //    throw new ApplicationException("Connection string not found");
            //}
            //connectionString += ";max pool size=100";
            //connectionString += ";application name=" + applicationName;
            //connectionString += ";database=" + database;
            //connectionString += ";connection timeout=5";
            //if (isAsync)
            //{
            //    connectionString += ";Asynchronous Processing=true";
            //}

            connectionString = "Data Source=.;Persist Security Info=True;User ID=web_Parkers;Password=N44ZMm4s2E;database=ParkersCar";

            SqlConnection newConnection = new SqlConnection(connectionString);

            return newConnection;
        }

        private IAsyncResult BeginExecuteReader(AsyncCallback callback, object state)
        {
            SqlDataReader newReader = null;
            SqlConnection newConnection = null;
            try
            {
                newConnection = GetAsyncConnection();
                innerCommand.Connection = newConnection;
                newConnection.Open();
                return innerCommand.BeginExecuteReader(callback, state, CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                // Only close on exception, since SqlDataReader needs an open connection
                if (newReader != null && newReader.IsClosed == false)
                {
                    newReader.Close();
                }
                if (newConnection != null && newConnection.State != ConnectionState.Closed)
                {
                    newConnection.Close();
                }
                // Rethrow the exception
                throw e;
            }
        }

        private SqlDataReader EndExecuteReader(IAsyncResult ar)
        {
            return innerCommand.EndExecuteReader(ar);
        }

        #region IDisposable Members

        /// <summary>
        /// Disposes innerCommand
        /// </summary>
        public void Dispose()
        {
            if (innerCommand != null)
            {
                innerCommand.Dispose();
            }
        }

        #endregion
    }

}
