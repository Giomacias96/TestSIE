using System.Collections.Generic;
using System.Configuration;

namespace TestSie
{
    /// <summary>
    /// Objeto para crear y regresar una conexión independientemente de si está Encriptada o desencriptada.
    /// </summary>
    public static class Conn
    {

        #region Variables

        #endregion

        #region Atributos

        #endregion

        #region Constructores

        #endregion

        #region Metodos
        /// <summary>
        /// Regresa una Conexión GetData.
        /// </summary>
        /// <returns>Regresa un Objeto GetData con la conexión a la base de datos.</returns>
        static public GetData GetConn()
        {
            if (ConfigurationManager.ConnectionStrings["MiConexion"].ToString().StartsWith("¡"))
            {
                return new GetDataEnc();
            }
            else
            {
                return new GetData();
            }
        }

        /// <summary>
        /// Regresa una Conexión GetData.
        /// </summary>
        /// <param name="connStringSectionName">El nombre de la sección en el archivo de configuración.</param>
        /// <returns>Regresa un Objeto GetData con la conexión a la base de datos.</returns>
        static public GetData GetConn(string connStringSectionName)

        {
            if (ConfigurationManager.ConnectionStrings[connStringSectionName].ToString().StartsWith("¡"))
            {
                return new GetDataEnc(connStringSectionName);
            }
            else
            {
                return new GetData(connStringSectionName);
            }
        }


        /// <summary>
        /// Regresa una Conexión GetData.
        /// </summary>
        /// <param name="userName">El LogonID del Usuario.</param>
        /// <param name="userPassword">El password del usuario.</param>
        /// <returns>
        /// Regresa un Objeto GetData con la conexión a la base de datos.
        /// </returns>
        static public GetData GetConn(string userName, string userPassword)
        {
            if (ConfigurationManager.ConnectionStrings["MiConexion"].ToString().StartsWith("¡"))
            {
                return new GetDataEnc(userName, userPassword);
            }
            else
            {
                return new GetData(userName, userPassword);
            }
        }


        /// <summary>
        /// Regresa una Conexión GetData.
        /// </summary>
        /// <param name="connStringSectionName">El nombre de la sección en el archivo de configuración.</param>
        /// <param name="userName">El LogonID del Usuario.</param>
        /// <param name="userPassword">El password del usuario.</param>
        /// <returns>
        /// Regresa un Objeto GetData con la conexión a la base de datos.
        /// </returns>
        static public GetData GetConn(string connStringSectionName, string userName, string userPassword)
        {
            if (ConfigurationManager.ConnectionStrings[connStringSectionName].ToString().StartsWith("¡"))
            {
                return new GetDataEnc(connStringSectionName, userName, userPassword);
            }
            else
            {
                return new GetData(connStringSectionName, userName, userPassword);
            }
        }


        /// <summary>
        /// Obtiene una conexión a la medida
        /// </summary>
        /// <param name="connectionInfo">La información de la conexión.</param>
        /// <returns>
        /// Regresa un Objeto GetData con la conexión a la base de datos.
        /// </returns>
        static public GetData GetCustomConn(KeyValuePair<string, string> connectionInfo)
        {
            return new GetData(connectionInfo);
        }

        #endregion

    }
}
