using System;


namespace TestSie
{

    /// <summary>
    /// Biblioteca de acceso a la base de datos de cualquier proveedor.
    /// Requiere que la cadena de conexión este encriptada
    /// </summary>
    /// <remarks>
    /// Esta biblioteca se encuentra dentro del archivo MiConexionms.dll.
    /// está incluida en el Namespace atbo.MiConexionms.
    ///</remarks>
    sealed class GetDataEnc : GetData, IGetData
    {
        #region Variables

        #endregion

        #region Atributos
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase GetData con la conexión por omisión (giis).
        /// </summary>
        public GetDataEnc() : base()
        {
            Decrypt();

        }


        /// <summary>
        /// Inicializa una nueva instancia de la clase GetDataEnc con la conexion por omision con usuario.
        /// </summary>
        /// <param name="userName">El LogonID del usuario</param>
        /// <param name="userPassword">La contraseña del usuario</param>
        public GetDataEnc(string userName, string userPassword) : base(userName, userPassword)
        {
            Decrypt();
        }


        /// <summary>
        /// Inicializa una nueva instancia de la clase GetDataEnc.
        /// </summary>
        /// <param name="connStringSectionName">La sección en el archivo de configuración en donde se guardó la cadena de conexión</param>
        public GetDataEnc(string connStringSectionName) : base(connStringSectionName)
        {
            Decrypt();
        }


        /// <summary>
        /// Inicializa una nueva instancia de la clase GetDataEnc con conexion especifica y usuario
        /// </summary>
        /// <param name="connStringSectionName">La sección en el archivo de configuración en donde se guardó la cadena de conexión</param>
        /// <param name="userName">El LogonID del usuario</param>
        /// <param name="userPassword">La contraseña del usuario</param>
        public GetDataEnc(string connStringSectionName, string userName, string userPassword) : base(connStringSectionName, userName, userPassword)
        {
            Decrypt();
        }

        /// <summary>
        /// Desencripta la cadena de conexión.
        /// </summary>
        private void Decrypt()
        {
            try
            {
                base._connectionString = Crypt.Decrypt(this._connectionString.Substring(1), "R3$uN1mda@2015@&dk%#2caW");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion

        #region Metodos

        #endregion

    }
}
