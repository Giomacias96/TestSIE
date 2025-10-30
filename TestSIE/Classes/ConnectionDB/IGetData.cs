using System.Collections.Generic;
using System.Data;

namespace TestSie
{
    /// <summary>Interface para Clase Dbms de Acceso a Datos de DSA.</summary>
    public interface IGetData
    {
        /// <summary>Un arreglo de Sentencias SQL que se ejecutarán</summary>
        List<string> SentenciasSQL { set; }

        /// <summary>
        /// Asigna la sentencia SQL con que se construirá el objeto GetData.
        /// </summary>
        string SentenciaSQL { set; }

        /// <summary>Obtiene un DataSet a partir de las Sentencia SQL.</summary>
        /// <returns>Un DataSet con un DataTable llamado DataTable con los datos obtenidos a partir de la Sentencia SQL.</returns>
        DataSet GetDataSet();

        /// <summary>
        /// Obtiene un DataSet con unDataTable con el nombre especificado.
        /// </summary>
        /// <param name="dataTableName">El nombre del DataTable deseado.</param>
        /// <returns>Un DataSet con un DataTable llamado DataTable con los datos obtenidos a partir de la Sentencia SQL.</returns>
        DataSet GetDataSet(string dataTableName);

        /// <summary>Gets the data table.</summary>
        /// <returns></returns>
        DataTable GetDataTable();

        /// <summary>
        /// Obtiene un DataTable con el nombre especificado con los datos obtenidos a partir de la Sentencia SQL.
        /// </summary>
        /// <param name="dataTableName">El nombre del DataTable deseado.</param>
        /// <returns>Un DataTable llamado DataTable con los datos obtenidos a partir de la Sentencia SQL.</returns>
        DataTable GetDataTable(string dataTableName);

        /// <summary>Agrega el contenido de un DataTable a otro.</summary>
        /// <param name="dt1">El DataTable al que hay que agregar el otro.</param>
        /// <param name="dt2">El DataTable que hay que agregar.</param>
        /// <returns>Un DataTable con los datos de los dos DataTables</returns>
        /// <returns>Un DataTable con el contenido de los dos DataTables combinados.</returns>
        DataTable DataTableAppend(DataTable dt1, DataTable dt2);

        /// <summary>Obtiene un dato como resultado de una sentencia SQL.</summary>
        /// <remarks>Se usa generalmente con las funciones SQL de sum, count, max, min, etc.
        /// </remarks>
        /// <returns>Una cadena con el resultado de la sentencia.</returns>
        string GetSingleData();

        /// <summary>Ejecuta una sentencia SQL contra la base de datos.</summary>
        /// <returns>El número de registros afectados.</returns>
        int SaveData();

        /// <summary>
        /// Ejecuta una serie de Sentencias SQL contra la base de datos en una sola transacción
        /// </summary>
        /// <remarks>
        /// Si alguna de las sentencias falla no ocurre ningún cambio en la base de datos y una nueva excepcion es creada.
        /// </remarks>
        /// <returns>El número de registros afectados o -1 si alguna de las sentencias falla.</returns>
        int TSaveData();

        /// <summary>Ejecuta una sentencia SQL contra la base de datos.</summary>
        /// <returns>Un entero con el resultado de la sentencia SQL.</returns>
        int SaveDataID();

        /// <summary>Libera los recursos usados por la clase GetData</summary>
        void Dispose();
    }
}
