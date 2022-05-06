namespace agendadigital.entidades
{
    public class Telefono
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int IdContacto { get; set; }
        public Contacto contacto { get; set; }
        

    }
}
