namespace Chapter.Web.API.Entities.Usuarios.Dto;
public class UsuarioDto
{
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string Endereco { get; set; }
        public required string Email { get; set; }
}