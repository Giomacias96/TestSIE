namespace TestSIE.Classes
{
    public class PropietarioCoche
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public int CocheId { get; set; }

        public PropietarioCoche() { }

        public PropietarioCoche(int id, int personaId, int cocheId)
        {
            Id = id;
            PersonaId = personaId;
            CocheId = cocheId;
        }

        public override string ToString()
        {
            return $"Propietario ID: {PersonaId}, Coche ID: {CocheId}";
        }
    }
}
