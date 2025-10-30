namespace TestSie
{
    /// <summary>
    /// Tipo de variable para controlar los estados de un objeto.
    /// </summary>
    public enum Stat
    {
        /// <summary>Vacío</summary>
        Empty,
        /// <summary>Nuevo</summary>
        New,
        /// <summary>Guardado en la Base de Datos.</summary>
        Saved,
        /// <summary>Cargado desde la base de datos.</summary>
        Loaded,
        /// <summary>Cambiado.</summary>
        Changed,
        /// <summary>Borrado.</summary>
        Deleted,
        /// <summary>Cargado por objeto externo</summary>
        PreLoaded,
    }
}
