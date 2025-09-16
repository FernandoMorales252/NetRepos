namespace AuthApi.Entidades
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
