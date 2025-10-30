using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestSie;

namespace TestSIE
{
    /// <summary>
    /// Variable
    /// </summary>
    public class Persona
    {

        #region Variables
        private int _id = 0;
        private string _nombre = string.Empty;
        private string _apellido = string.Empty;
        private Stat _objStat = Stat.New;
        #endregion

        #region Atributos
        /// <summary>
        /// Obtiene o asigna Un int requerido  con el valor del campo id.
        /// </summary>
        /// <value>Un <i>int</i> con Un int requerido  con el valor del campo id.</value>
        public int Id
        {
            get { return this._id; }
            set { if (this._id != value) { this._id = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }

        /// <summary>
        /// Obtiene o asigna Un string requerido  con el valor del campo Nombre.
        /// </summary>
        /// <value>Un <i>string</i> con Un string requerido  con el valor del campo Nombre.</value>
        public string Nombre
        {
            get { return this._nombre; }
            set { if (this._nombre != value) { this._nombre = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }

        /// <summary>
        /// Obtiene o asigna Un string requerido  con el valor del campo Apellido.
        /// </summary>
        /// <value>Un <i>string</i> con Un string requerido  con el valor del campo Apellido.</value>
        public string Apellido
        {
            get { return this._apellido; }
            set { if (this._apellido != value) { this._apellido = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }


        /// <summary>
        /// Obtiene el estado del objeto.
        /// </summary>
        /// <value>Un <i>Stat</i> con el estado del objeto.</value>
        public Stat ObjStat
        {
            get { return _objStat; }
        }

        /// <summary>
        /// Obtiene el estado del objeto.
        /// </summary>
        /// <value>Un <i>string</i> con el estado del objeto.</value>
        public string ObjStatString
        {
            get { return _objStat.ToString(); }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Persona"/>.
        /// </summary>
        public Persona()
        {
            this._objStat = Stat.New;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Persona"/>.
        /// </summary>
        public Persona(int id)
        {
            this._id = id;

            try
            {
                using (GetData gd = Conn.GetConn("MiConexion"))
                {
                    gd.SentenciaSQL = "SELECT id, Nombre, Apellido "
                        + "FROM Persona "
                        + "WHERE Id=@Id";
                    gd.AddParameter(_id, "Id");

                    List<Persona> ls = gd.GetList(Create).ToList();
                    if (ls.Count > 0)
                    {
                        this._id = id;
                        this._nombre = ls[0].Nombre;
                        this._apellido = ls[0].Apellido;

                        this._objStat = Stat.Loaded;
                    }
                    else
                    {
                        this._id = id;
                        this._nombre = string.Empty;
                        this._apellido = string.Empty;

                        this._objStat = Stat.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Crea el texto del metodo Create
        /// </summary>
        /// <param name="record"></param>
        public static Persona Create(IDataRecord record)
        {
            return new Persona
            {
                _id = record["id"] != DBNull.Value ? int.Parse(record["Id"].ToString()) : 0,
                _nombre = record["Nombre"].ToString() ?? "",
                _apellido = record["Apellido"].ToString() ?? "",

                _objStat = Stat.Loaded
            };
        }

        #endregion

        #region Metodos
        public static DataTable LoadPersons()
        {
            DataTable dt = new DataTable();
            using (GetData gd = Conn.GetConn("MiConexion"))
            {
                gd.SentenciaSQL = "SELECT Id, Nombre, Apellido FROM Persona";
                dt = gd.GetDataTable();
            }
            return dt;
        }
        #endregion

        #region IStatable Members


        /// <summary>
        /// Cambia el objeto a Preloaded cargado por un objeto externo.
        /// </summary>
        public void SetPreLoaded()
        {
            this._objStat = Stat.PreLoaded;
        }

        #endregion

        #region ISavable Members

        /// <summary>
        /// Inserta, Actualiza o borra de la base de datos seg�n el estado del objeto.
        /// </summary>
        public void Save()
        {
            try
            {
                using (GetData gd = Conn.GetConn("MiConexion"))
                {
                    switch (this._objStat)
                    {
                        case Stat.New:
                            gd.SentenciaSQL = "INSERT INTO Persona(Nombre,Apellido) "
                                + "VALUES(@Nombre,@Apellido) ";

                            //gd.AddParameter(_id, "Id");
                            gd.AddParameter(_nombre, "Nombre");
                            gd.AddParameter(_apellido, "Apellido");

                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Changed:
                            gd.SentenciaSQL = "UPDATE Persona SET Nombre=@Nombre, "
                                + "Apellido=@Apellido "
                                + "WHERE Id=@Id";
                            gd.AddParameter(_id, "Id");
                            gd.AddParameter(_nombre, "Nombre");
                            gd.AddParameter(_apellido, "Apellido");

                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Deleted:
                            gd.SentenciaSQL = "DELETE FROM Persona WHERE Id=@Id";
                            gd.AddParameter(Id, "@Id");

                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Marca el objeto para ser borrado de la base de datos cuando se ejecute el m�todo Save()
        /// </summary>
        public void Delete()
        {
            this._objStat = Stat.Deleted;
        }

        /// <summary>
        /// Marca el objeto para ser borrado de la base de datos y lo borra inmediatamente de la DB.
        /// </summary>
        public void DeleteNow()
        {
            this._objStat = Stat.Deleted;
            this.Save();
        }



        /// <summary>
        /// Revisa si todos los atributos que se van a grabar no son nulos o vacios.
        /// </summary>
        /// <exception cref="System.Exception">Existen atributos vacios o nulos y que son obligatorios en la clase!</exception>
        public void CheckIfReadyToSave()
        {
            if (this._id == 0 || this._nombre == string.Empty || this._apellido == string.Empty)
            {
                throw new Exception("Existen atributos vacios o nulos y que son obligatorios en la clase!");
            }

        }

        #endregion
    }
}