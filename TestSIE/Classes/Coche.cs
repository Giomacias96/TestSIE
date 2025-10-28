namespace TestSIE.Classes
{
    public class Coche
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string VIN { get; set; }

        public Coche() { }

        public Coche(int id, string marca, string modelo, string vin)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            VIN = vin;
        }

        public override string ToString()
        {
            return $"{Marca} {Modelo} - VIN: {VIN}";
        }
    }

}
