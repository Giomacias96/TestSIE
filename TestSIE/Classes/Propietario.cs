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
    public class Propietario
    {

        #region Variables
        private int _id = 0;
        private int _personaId = 0;
        private int _cocheId = 0;
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
        /// Obtiene o asigna Un int requerido  con el valor del campo persona_id.
        /// </summary>
        /// <value>Un <i>int</i> con Un int requerido  con el valor del campo persona_id.</value>
        public int PersonaId
        {
            get { return this._personaId; }
            set { if (this._personaId != value) { this._personaId = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
        }

        /// <summary>
        /// Obtiene o asigna Un int requerido  con el valor del campo coche_id.
        /// </summary>
        /// <value>Un <i>int</i> con Un int requerido  con el valor del campo coche_id.</value>
        public int CocheId
        {
            get { return this._cocheId; }
            set { if (this._cocheId != value) { this._cocheId = value; if (this._objStat != Stat.New && this._objStat != Stat.Empty) { this._objStat = Stat.Changed; } } }
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
        /// Inicializa una nueva instancia de la clase <see cref="Propietario"/>.
        /// </summary>
        public Propietario()
        {
            this._objStat = Stat.New;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Propietario"/>.
        /// </summary>
        public Propietario(int id)
        {
            this._id = id;

            try
            {
                using (GetData gd = Conn.GetConn("MiConexion"))
                {
                    gd.SentenciaSQL = "SELECT id, persona_id, coche_id "
                                            + "FROM Propietario_Coche "
                                            + "WHERE Id=@Id";
                    gd.AddParameter(_id, "Id");

                    List<Propietario> ls = gd.GetList(Create).ToList();
                    if (ls.Count > 0)
                    {
                        this._id = id;
                        this._personaId = ls[0].PersonaId;
                        this._cocheId = ls[0].CocheId;

                        this._objStat = Stat.Loaded;
                    }
                    else
                    {
                        this._id = id;
                        this._personaId = 0;
                        this._cocheId = 0;

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
        public static Propietario Create(IDataRecord record)
        {
            return new Propietario
            {
                _id = record["id"] != DBNull.Value ? int.Parse(record["Id"].ToString()) : 0,
                _personaId = record["persona_id"] != DBNull.Value ? int.Parse(record["persona_id"].ToString()) : 0,
                _cocheId = record["coche_id"] != DBNull.Value ? int.Parse(record["coche_id"].ToString()) : 0,

                _objStat = Stat.Loaded
            };
        }

        #endregion

        #region Metodos

        public static bool IsCarUnassigned(int coche_id)
        {
            using (GetData gd = Conn.GetConn("MiConexion"))
            {
                gd.SentenciaSQL = "SELECT COUNT(*) FROM Propietario_Coche WHERE coche_id=@CocheId";
                gd.AddParameter(coche_id, "CocheId");
                if ((int.Parse(gd.GetSingleData()) > 0))
                {
                    return false;
                }
            }
            return true;
        }

        public static DataTable LoadPropietarios()
        {
            DataTable dt = new DataTable();
            using (GetData gd = Conn.GetConn("MiConexion"))
            {
                gd.SentenciaSQL = @"SELECT pc.Id, p.Nombre, p.Apellido, c.Marca, c.Modelo, c.VIN
                            FROM Propietario_Coche pc
                            INNER JOIN Persona p ON pc.persona_id = p.Id
                            INNER JOIN Coche c ON pc.coche_id = c.Id";
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
                            gd.SentenciaSQL = "INSERT INTO Propietario_Coche(persona_id,coche_id) "
                                + "VALUES(@PersonaId,@CocheId) ";

                            //gd.AddParameter(_id, "Id");
                            gd.AddParameter(_personaId, "PersonaId");
                            gd.AddParameter(_cocheId, "CocheId");

                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Changed:
                            gd.SentenciaSQL = "UPDATE Propietario_Coche SET persona_id=@PersonaId, "
                                + "coche_id=@CocheId "
                                + "WHERE Id=@Id";
                            gd.AddParameter(_id, "Id");
                            gd.AddParameter(_personaId, "PersonaId");
                            gd.AddParameter(_cocheId, "CocheId");

                            if (gd.SaveData() > 0)
                            {
                                this._objStat = Stat.Saved;
                            }
                            break;
                        case Stat.Deleted:
                            gd.SentenciaSQL = "DELETE FROM Propietario_Coche WHERE Id=@Id";
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
            if (this._id == 0 || this._personaId == 0 || this._cocheId == 0)
            {
                throw new Exception("Existen atributos vacios o nulos y que son obligatorios en la clase!");
            }

        }

        #endregion

    }
}