namespace Usuarios.api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }   
        public string Senha { get; set; }
        public string  Role { get; set; } //Role == Admin // Role == User // Role == Manager // Role == SuperUser

    }
}
