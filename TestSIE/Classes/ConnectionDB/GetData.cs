using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;

namespace TestSie
{

    /// <summary>
    /// Biblioteca de acceso a la base de datos de cualquier proveedor.
    /// </summary>
    /// <remarks>
    /// Esta biblioteca se encuentra dentro del archivo Dbms.dll,
    /// está incluida en el Namespace Dsa.MiConexionms.
    /// </remarks>
    public class GetData : IDisposable, IGetData
    {
        #region Variables
        private DbProviderFactory _DbFactory;
        private string _sentenciaSQL;
        protected string _connectionString;
        private string _serverName;
        private List<string> _sentenciasSQL;
        private List<DbParameter> _parameters;
        private int _commandTimeout = 30;
        //private DbConnection _dbConnection;
        #endregion

        #region Atributos
        /// <summary>
        /// Asigna el atributo sentencia SQL.
        /// </summary>
        /// <value>La sentencia SQL.</value>
        public string SentenciaSQL
        {
            set { _sentenciaSQL = value; }
        }

        /// <summary>
        /// Obtiene una lista de Sentencias SQL.
        /// </summary>
        /// <value>Una  lista de sentencias SQL.</value>
        public List<string> SentenciasSQL
        {
            set { _sentenciasSQL = value; }
        }

        /// <summary>
        /// Obtiene el nombre o ip del servidor
        /// </summary>
        public string ServerName
        {
            get
            {
                _serverName = GetServerName();
                return _serverName;
            }
        }
        /// <summary>
        /// Obtiene una conexión.
        /// </summary>
        public DbConnection DbConnection
        {
            get
            {
                return GetDBConnection();
            }
        }

        /// <summary>
        /// Configura el tiempo de espera para que el comando se complete antes de que la operacion sea cancelada.
        /// </summary>
        public int CommandTimeout
        {
            set { _commandTimeout = value; }
        }


        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase GetData con la conexión por omisión (Inteknus).
        /// </summary>
        public GetData()
        {
            this._sentenciasSQL = new List<string>();
            if (ConfigurationManager.ConnectionStrings["MiConexion"] != null)
            {
                _DbFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["MiConexion"].ProviderName.ToString());
                _connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
            }
            else
            {
                throw new Exception("Missing default ConnectionString section in configuration file!");
            }
        }


        /// <summary>
        /// Inicializa una nueva instancia de la clase GetDataEnc con conexion especifica y usuario
        /// </summary>
        /// <param name="userName">El LogonID del usuario</param>
        /// <param name="userPassword">La contraseña del usuario</param>
        public GetData(string userName, string userPassword)
        {
            this._sentenciasSQL = new List<string>();
            if (ConfigurationManager.ConnectionStrings["MiConexion"] != null)
            {
                _DbFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["MiConexion"].ProviderName.ToString());
                _connectionString = string.Format("{0};uid={1};pwd={2}", ConfigurationManager.ConnectionStrings["MiConexion"], userName, userPassword);

            }
            else
            {
                throw new Exception("Missing default ConnectionString section with User!");
            }

        }


        /// <summary>
        /// Inicializa una nueva instancia de la clase GetDataEnc con conexion especifica y usuario
        /// </summary>
        /// <param name="connStringSectionName">La sección en el archivo de configuración en donde se guardó la cadena de conexión</param>
        public GetData(string connStringSectionName)
        {
            this._sentenciasSQL = new List<string>();
            if (ConfigurationManager.ConnectionStrings[connStringSectionName] != null)
            {
                _DbFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[connStringSectionName].ProviderName.ToString());
                _connectionString = ConfigurationManager.ConnectionStrings[connStringSectionName].ToString();
            }
            else
            {
                throw new Exception(string.Format("Missing {0} ConnectionString section in configuration file!", connStringSectionName));
            }
        }


        /// <summary>
        /// Inicializa una nueva instancia de la clase GetDataEnc con conexion especifica y usuario
        /// </summary>
        /// <param name="connStringSectionName">La sección en el archivo de configuración en donde se guardó la cadena de conexión</param>
        /// <param name="userName">El LogonID del usuario</param>
        /// <param name="userPassword">La contraseña del usuario</param>
        public GetData(string connStringSectionName, string userName, string userPassword)
        {
            this._sentenciasSQL = new List<string>();
            if (ConfigurationManager.ConnectionStrings[connStringSectionName] != null)
            {
                _DbFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[connStringSectionName].ProviderName.ToString());
                _connectionString = string.Format("{0};uid={1};pwd={2}", ConfigurationManager.ConnectionStrings[connStringSectionName], userName, userPassword);
            }
            else
            {
                throw new Exception(string.Format("Missing {0} ConnectionString section in configuration file!", connStringSectionName));
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase GetData con cadena de conexion y proveedor de datos a la medida.
        /// </summary>
        /// <param name="connectionInfo">La información de la conexion donde key:DataProvider, value:ConnectionString.</param>
        public GetData(KeyValuePair<string, string> connectionInfo)
        {
            this._sentenciasSQL = new List<string>();
            _DbFactory = DbProviderFactories.GetFactory(connectionInfo.Key);
            _connectionString = connectionInfo.Value;
        }




        #endregion

        #region Metodos


        /// <summary>
        /// Obtiene un dato como resultado de una sentencia SQL.
        /// </summary>
        /// <remarks>Se usa generalmente con las funciones SQL de sum, count, max, min, etc. 
        /// </remarks>
        /// <returns>Una cadena con el resultado de la sentencia.</returns>
        public string GetSingleData()
        {
            try
            {
                object Result;
                DbConnection DbConn = _DbFactory.CreateConnection();
                DbConn.ConnectionString = _connectionString;
                using (DbConn)
                {
                    DbConn.Open();
                    DbCommand cmd = DbConn.CreateCommand();
                    cmd.CommandText = this._sentenciaSQL;
                    cmd.CommandTimeout = _commandTimeout;
                    IncludeParameters(cmd);
                    Result = cmd.ExecuteScalar();
                    InitVariables();
                    if (Result == null)
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return Result.ToString();
                    }
                }
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Obtiene una lista de objetos de la clase especificado en la firma del metodo
        /// </summary>
        /// <typeparam name="T">La clase</typeparam>
        /// <param name="BuildObject">El nombre del metodo que asigna las variables de la lista</param>
        /// <returns>una lista de objetos de la clase especificado en la firma del metodo</returns>
        public IEnumerable<T> GetList<T>(Func<IDataRecord, T> BuildObject)
        {
            DbConnection DbConn = _DbFactory.CreateConnection();
            DbConn.ConnectionString = _connectionString;
            using (DbConn)
            {
                DbConn.Open();
                DbCommand cmd = DbConn.CreateCommand();
                cmd.CommandText = this._sentenciaSQL;
                cmd.CommandTimeout = _commandTimeout;
                IncludeParameters(cmd);
                DbDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        yield return BuildObject(dr);
                    }
                }
            }
        }

        /// <summary>Obtiene una lista de objetos </summary>
        /// <returns>Una lista de objetos</returns>
        public IEnumerable<object> GetList()
        {
            List<object> rows = new List<object>();
            DbConnection DbConn = _DbFactory.CreateConnection();
            DbConn.ConnectionString = _connectionString;
            using (DbConn)
            {
                DbConn.Open();
                DbCommand cmd = DbConn.CreateCommand();
                cmd.CommandText = this._sentenciaSQL;
                cmd.CommandTimeout = _commandTimeout;
                IncludeParameters(cmd);
                DbDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        rows.Add(dr[0]);
                    }
                }
                return rows;
            }
        }

        /// <summary>Obtiene una lista de objetos anonimos</summary>
        /// <returns>Una lista de objetos anonimos</returns>
        public IEnumerable<T> GetAList<T>(Func<DbDataReader, T> selector)
        {
            DbConnection DbConn = _DbFactory.CreateConnection();
            DbConn.ConnectionString = _connectionString;
            using (DbConn)
            {
                DbConn.Open();
                DbCommand cmd = DbConn.CreateCommand();
                cmd.CommandText = this._sentenciaSQL;
                cmd.CommandTimeout = _commandTimeout;
                IncludeParameters(cmd);
                DbDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        yield return selector(dr);
                    }
                }
            }
        }

        /// <summary>
        /// Executes the procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procedureText">The procedure text.</param>
        /// <param name="BuildObject">The build object.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public IEnumerable<T> ExecuteProcedure<T>(string procedureText, Func<IDataRecord, T> BuildObject)
        {
            DbConnection DbConn = _DbFactory.CreateConnection();
            DbConn.ConnectionString = _connectionString;
            using (DbConn)
            {
                DbConn.Open();
                DbCommand cmd = DbConn.CreateCommand();
                cmd.CommandText = procedureText;
                cmd.CommandTimeout = _commandTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                IncludeParameters(cmd);
                DbDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        yield return BuildObject(dr);
                    }
                }
            }
        }


        /// <summary>
        /// Obtiene un DataTable con los datos que resultan de correr una sentencia SQL
        /// </summary>
        /// <returns>Un DataTable con los datos que resultan de la consulta SQL.</returns>
        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                DbConnection DbConn = _DbFactory.CreateConnection();
                DbConn.ConnectionString = _connectionString;
                using (DbConn)
                {
                    DbConn.Open();
                    DbCommand cmd = DbConn.CreateCommand();
                    cmd.CommandText = this._sentenciaSQL;
                    cmd.CommandTimeout = _commandTimeout;
                    IncludeParameters(cmd);
                    DbDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    InitVariables();
                    return dt;
                }
            }
            catch (ConstraintException ex)
            {
                throw new Exception(string.Concat(ex.Message, " : ", dt.GetErrors()[0].RowError));
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// Obtiene un DataTable con los datos que resultan de correr una sentencia SQL
        /// </summary>
        /// <param name="dataTableName">El nombre del DataTable.</param> 
        /// <returns>Un DataTable con los datos que resultan de la consulta SQL.</returns>
        public DataTable GetDataTable(string dataTableName)
        {
            DataTable dt = new DataTable(dataTableName);
            try
            {
                DbConnection DbConn = _DbFactory.CreateConnection();
                DbConn.ConnectionString = _connectionString;
                using (DbConn)
                {
                    DbConn.Open();
                    DbCommand cmd = DbConn.CreateCommand();
                    cmd.CommandText = this._sentenciaSQL;
                    cmd.CommandTimeout = _commandTimeout;
                    IncludeParameters(cmd);
                    DbDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    InitVariables();
                    return dt;
                }
            }
            catch (ConstraintException ex)
            {
                throw new Exception(string.Concat(ex.Message, " : ", dt.GetErrors()[0].RowError));
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// Obtiene un DataSet con los datos que resultan de correr una sentencia SQL
        /// </summary>
        /// <returns>Un Objeto DataSet con los datos que resultan de la consulta SQL.</returns>

        public DataSet GetDataSet()
        {
            try
            {
                DbConnection DbConn = _DbFactory.CreateConnection();
                DbConn.ConnectionString = _connectionString;
                using (DbConn)
                {
                    DbConn.Open();
                    DbDataAdapter da = _DbFactory.CreateDataAdapter();
                    da.SelectCommand = DbConn.CreateCommand();
                    da.SelectCommand.CommandText = _sentenciaSQL;
                    da.SelectCommand.CommandTimeout = _commandTimeout;
                    IncludeParameters(da.SelectCommand);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "DataTable");
                    InitVariables();
                    return ds;
                }

            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Obtiene un DataSet con los datos que resultan de correr una sentencia SQL
        /// </summary>
        /// <param name="dataTableName">El nombre del DataTable.</param>
        /// <returns>
        /// Un Objeto DataSet con los datos que resultan de la consulta SQL.
        /// </returns>
        public DataSet GetDataSet(string dataTableName)
        {
            try
            {
                DbConnection DbConn = _DbFactory.CreateConnection();
                DbConn.ConnectionString = _connectionString;
                using (DbConn)
                {
                    DbConn.Open();
                    DbDataAdapter da = _DbFactory.CreateDataAdapter();
                    da.SelectCommand = DbConn.CreateCommand();
                    da.SelectCommand.CommandText = _sentenciaSQL;
                    da.SelectCommand.CommandTimeout = _commandTimeout;
                    IncludeParameters(da.SelectCommand);
                    DataSet ds = new DataSet();
                    da.Fill(ds, dataTableName);
                    InitVariables();
                    return ds;
                }

            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Ejecuta una sentencia SQL contra la base de datos.
        /// </summary>
        /// <returns>El número de registros afectados.</returns>
        public int SaveData()
        {
            try
            {
                DbConnection DbConn = _DbFactory.CreateConnection();
                DbConn.ConnectionString = _connectionString;
                using (DbConn)
                {
                    DbConn.Open();
                    DbCommand cmd = DbConn.CreateCommand();
                    cmd.CommandText = this._sentenciaSQL;
                    IncludeParameters(cmd);
                    int result = cmd.ExecuteNonQuery();
                    InitVariables();
                    return result;
                }

            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Ejecuta una sentencia SQL contra la base de datos.
        /// </summary>
        /// <returns>Un entero con el resultado de la sentencia SQL.</returns>
        /// <remarks>La sentendia SQL debe contener una clausula SELECT para que este método regrese un dato.
        /// p.ej. para Actian ingres agregar otra consulta con SELECT SCOPE_IDENTITY()
        /// para SQL Server debe terminar con SELECT SCOPE_IDENTITY()
        /// para MySQL debe terminar con SELECT LAST_INSERT_ID()</remarks>
        public int SaveDataID()
        {
            try
            {
                DbConnection DbConn = _DbFactory.CreateConnection();
                DbConn.ConnectionString = _connectionString;
                using (DbConn)
                {
                    DbConn.Open();
                    DbCommand cmd = DbConn.CreateCommand();
                    cmd.CommandText = this._sentenciaSQL;
                    IncludeParameters(cmd);
                    int result = int.Parse(cmd.ExecuteScalar().ToString());
                    InitVariables();
                    return result;
                }

            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Ejecuta una serie de Sentencias SQL contra la base de datos en una sola transacción
        /// </summary>
        /// <remarks>
        /// Si alguna de las sentencias falla no ocurre ningún cambio en la base de datos y una nueva excepcion es creada.
        /// </remarks>
        /// <returns>El número de registros afectados o -1 si alguna de las sentencias falla.</returns>
        public int TSaveData()
        {
            int x = 0;
            DbConnection DbConn = _DbFactory.CreateConnection();
            DbConn.ConnectionString = _connectionString;
            using (DbConn)
            {
                DbConn.Open();
                DbCommand cmd = DbConn.CreateCommand();
                cmd.Connection = DbConn;
                cmd.Transaction = DbConn.BeginTransaction();
                IncludeParameters(cmd);
                try
                {
                    foreach (string SentenciaSQL in _sentenciasSQL)
                    {
                        cmd.CommandText = SentenciaSQL;
                        x += cmd.ExecuteNonQuery();
                    }
                    cmd.Transaction.Commit();
                    InitVariables();
                    return x;
                }

                catch (DbException ex)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception(ex.Message);
                }
                catch (Exception ex)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }


        /// <summary>
        /// Ejecuta el Procedimiento almacenado definido en la SentenciaSQL;
        /// </summary>
        /// <returns>Un entero con el resultado de la sentencia SQL.</returns>
        /// <exception cref="System.Exception">
        /// </exception>
        public int ExecuteProcedure()
        {
            DbConnection DbConn = _DbFactory.CreateConnection();
            DbConn.ConnectionString = _connectionString;
            using (DbConn)
            {
                DbConn.Open();
                DbCommand cmd = DbConn.CreateCommand();
                cmd.CommandText = _sentenciaSQL;
                cmd.CommandTimeout = _commandTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                IncludeParameters(cmd);
                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch (DbException ex)
                {
                    throw new Exception(ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Ejecuta el Procedimiento especificado en el argumento
        /// </summary>
        /// <param name="procedureText">Un string con el nombre del procedimiento almacenado.</param>
        /// <returns>Una DataTable con los datos que regresa el procedimiento almacenado.</returns>
        /// <exception cref="System.Exception">
        /// </exception>
        public DataTable ExecuteProcedure(string procedureText)
        {
            DbConnection DbConn = _DbFactory.CreateConnection();
            DbConn.ConnectionString = _connectionString;
            using (DbConn)
            {
                DbConn.Open();
                DbCommand cmd = DbConn.CreateCommand();
                cmd.CommandText = procedureText;
                cmd.CommandTimeout = _commandTimeout;
                cmd.CommandType = CommandType.StoredProcedure;
                IncludeParameters(cmd);
                try
                {
                    IncludeParameters(cmd);
                    DbDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    InitVariables();
                    return dt;
                }
                catch (DbException ex)
                {
                    throw new Exception(ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }



        /// <summary>
        /// Inicializa el contenido de las sentencias SQL y los parámetros.
        /// </summary>
        private void InitVariables()
        {
            this._sentenciaSQL = String.Empty;
            this._sentenciasSQL = new List<string>();
            this._parameters = new List<DbParameter>();
        }

        /// <summary>
        /// Agrega el contenido de un DataTable a otro.
        /// </summary>
        /// <param name="dt1">El DataTable al que hay que agregar el otro.</param>
        /// <param name="dt2">El DataTable que hay que agregar.</param>
        /// <returns>Un DataTable con los datos de los dos DataTables</returns>
        /// <returns>Un DataTable con el contenido de los dos DataTables combinados.</returns>
        public DataTable DataTableAppend(DataTable dt1, DataTable dt2)
        {
            try
            {
                foreach (DataRow row in dt2.Rows)
                {
                    dt1.ImportRow(row);
                }
                return dt1;
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// Agrega una sentencia SQL a la lista de Sentencias para ser usadas dentro de una transacción contra la base de datos.
        /// </summary>
        /// <param name="sql">La Sentencia SQL.</param>
        public void AddSentence(string sql)
        {
            this._sentenciasSQL.Add(sql);
        }


        /// <summary>
        /// Agrega el parametro a la lista de parametros.
        /// </summary>
        /// <param name="value">El valor del parametro.</param>
        /// <param name="name">El nombre del paranetro.</param>
        public void AddParameter(object value, string name)
        {
            DbParameter parameter = this._DbFactory.CreateParameter();
            if (this._parameters == null)
            {
                this._parameters = new List<DbParameter>();
            }
            parameter.ParameterName = name;
            parameter.Value = value;

            this._parameters.Add(parameter);

        }

        /// <summary>
        /// Agrega los parametros al comando
        /// </summary>
        /// <param name="cmd">El comando.</param>
        private void IncludeParameters(DbCommand cmd)
        {
            if (this._parameters != null)
            {
                foreach (DbParameter param in this._parameters)
                {
                    cmd.Parameters.Add(param);
                }
                this._parameters.Clear();
                this._parameters = null;
            }
        }

        /// <summary>
        /// Obtiene un DataSet con los datos que resultan de correr una sentencia SQL
        /// </summary>
        /// <param name="SentenciasSelect">The sentecias select Nota: Debe de tener el FROM con mayusculas para detectar
        /// el nombre de la tabla.</param>
        /// <returns>
        /// Un Objeto DataSet con los datos que resultan de la consulta SQL.
        /// </returns>
        /// <exception cref="System.Exception">
        /// </exception>
        public DataSet GetDataSet(List<string> SentenciasSelect)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                int iniFrom = 0;
                int endFrom = 0;
                int tablenum = 0;
                int endTablename = 0;
                string tableName = string.Empty;
                foreach (string sentenciasSelect in SentenciasSelect)
                {
                    sb.AppendFormat("; {0}", sentenciasSelect);
                }
                DbConnection DbConn = _DbFactory.CreateConnection();
                DbConn.ConnectionString = _connectionString;
                using (DbConn)
                {
                    DbConn.Open();
                    DbDataAdapter da = _DbFactory.CreateDataAdapter();
                    DataSet ds = new DataSet("TableList");
                    DbCommand cmd = DbConn.CreateCommand();
                    tablenum = 0;
                    //obtener el nombre de las tablas
                    foreach (string sentenciasSelect in SentenciasSelect)
                    {
                        cmd.CommandText = sentenciasSelect;
                        cmd.CommandTimeout = _commandTimeout;
                        da.SelectCommand = cmd;

                        iniFrom = sentenciasSelect.IndexOf("FROM");
                        endFrom = sentenciasSelect.IndexOf(' ', iniFrom + 1);
                        if (sentenciasSelect.Substring(endFrom + 1).IndexOf(' ') > 0)
                        {
                            endTablename = sentenciasSelect.IndexOf(' ', endFrom + 1);
                            tableName = sentenciasSelect.Substring(endFrom, endTablename - endFrom);
                        }
                        else
                        {
                            tableName = sentenciasSelect.Substring(endFrom + 1);
                        }

                        if (tablenum == 0)
                        {
                            da.TableMappings.Add("Table", tableName);
                        }
                        else
                        {
                            da.TableMappings.Add(string.Format("Table{0}", tablenum), tableName);
                        }
                        da.Fill(ds, tableName);
                        tablenum++;
                    }
                    return ds;
                }
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Obtiene el nombre o ip del servidor a partir de la cadena de conexión.
        /// </summary>
        /// <returns>Un string con el nombre o ip del servidor.</returns>
        private string GetServerName()
        {
            try
            {
                string dataSource = string.Empty;
                DbConnectionStringBuilder connectionStringBuilder = _DbFactory.CreateConnectionStringBuilder();
                connectionStringBuilder.ConnectionString = _connectionString;
                dataSource = connectionStringBuilder["server"].ToString();
                return dataSource;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Regresa un objeto DbConnection.
        /// </summary>
        /// <returns>Un objeto DbConnection</returns>
        private DbConnection GetDBConnection()
        {
            try
            {
                DbConnection DbConn = _DbFactory.CreateConnection();
                DbConn.ConnectionString = _connectionString;
                return DbConn;
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Libera los recursos usados por la clase GetData
        /// </summary>
        public void Dispose()
        {
            this._parameters = null;
            _DbFactory = null;
            _sentenciaSQL = null;
            _connectionString = null;
            _sentenciasSQL = null;
        }

        #endregion
    }
}
