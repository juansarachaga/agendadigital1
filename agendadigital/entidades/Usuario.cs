namespace agendadigital.entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ContactoId { get; set; }
        public Contacto contacto { get; set; }
        
    }
}
