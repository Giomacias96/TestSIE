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
    public class Coche
    {

        #region Variables
        private int _id = 0;
        private string _marca = string.Empty;
        private string _modelo = string.Empty;
        private string _vIN = string.Empty;
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
        /// Obtiene o asigna Un string requerido  con el valor del campo Marca.
        /// </summary>
        /// <value>Un <i>string</i> con Un string requerido  con el valor del campo Marca.</value>
        public string Marca
        {
            get { return this._marca; }
            set { if (this._marca != value) { this._marca = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }

        /// <summary>
        /// Obtiene o asigna Un string requerido  con el valor del campo Modelo.
        /// </summary>
        /// <value>Un <i>string</i> con Un string requerido  con el valor del campo Modelo.</value>
        public string Modelo
        {
            get { return this._modelo; }
            set { if (this._modelo != value) { this._modelo = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }

        /// <summary>
        /// Obtiene o asigna Un string requerido  con el valor del campo VIN.
        /// </summary>
        /// <value>Un <i>string</i> con Un string requerido  con el valor del campo VIN.</value>
        public string VIN
        {
            get { return this._vIN; }
            set { if (this._vIN != value) { this._vIN = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
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
        /// Inicializa una nueva instancia de la clase <see cref="Coche"/>.
        /// </summary>
        public Coche()
        {
            this._objStat = Stat.New;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Coche"/>.
        /// </summary>
        public Coche(int id)
        {
            this._id = id;

            try
            {
                using (GetData gd = Conn.GetConn("MiConexion"))
                {
                    gd.SentenciaSQL = "SELECT id, Marca, Modelo, VIN "
                        + "FROM Coche "
                        + "WHERE Id=@Id";
                    gd.AddParameter(_id, "Id");

                    List<Coche> ls = gd.GetList(Create).ToList();
                    if (ls.Count > 0)
                    {
                        this._id = id;
                        this._marca = ls[0].Marca;
                        this._modelo = ls[0].Modelo;
                        this._vIN = ls[0].VIN;

                        this._objStat = Stat.Loaded;
                    }
                    else
                    {
                        this._id = id;
                        this._marca = string.Empty;
                        this._modelo = string.Empty;
                        this._vIN = string.Empty;

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
        public static Coche Create(IDataRecord record)
        {
            return new Coche
            {
                _id = record["id"] != DBNull.Value ? int.Parse(record["Id"].ToString()) : 0,
                _marca = record["Marca"].ToString() ?? "",
                _modelo = record["Modelo"].ToString() ?? "",
                _vIN = record["VIN"].ToString() ?? "",

                _objStat = Stat.Loaded
            };
        }

        #endregion

        #region Metodos
        public static DataTable LoadCars()
        {
            DataTable dt = new DataTable();
            using (GetData gd = Conn.GetConn("MiConexion"))
            {
                gd.SentenciaSQL = "SELECT Id, Marca, Modelo, VIN FROM Coche";
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
                            gd.SentenciaSQL = "INSERT INTO Coche(Marca,Modelo,VIN) "
                                + "VALUES(@Marca,@Modelo,@VIN) ";

                            //gd.AddParameter(_id, "Id");
                            gd.AddParameter(_marca, "Marca");
                            gd.AddParameter(_modelo, "Modelo");
                            gd.AddParameter(_vIN, "VIN");

                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Changed:
                            gd.SentenciaSQL = "UPDATE Coche SET Marca=@Marca, "
                                + "Modelo=@Modelo, "
                                + "VIN=@VIN "
                                + "WHERE Id=@Id";
                            gd.AddParameter(_id, "Id");
                            gd.AddParameter(_marca, "Marca");
                            gd.AddParameter(_modelo, "Modelo");
                            gd.AddParameter(_vIN, "VIN");

                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Deleted:
                            gd.SentenciaSQL = "DELETE FROM Coche WHERE Id=@Id";
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
            if (this._id == 0 || this._marca == string.Empty || this._modelo == string.Empty || this._vIN == string.Empty)
            {
                throw new Exception("Existen atributos vacios o nulos y que son obligatorios en la clase!");
            }

        }

        #endregion

    }
}