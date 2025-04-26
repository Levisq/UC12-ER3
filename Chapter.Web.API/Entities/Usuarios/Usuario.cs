using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter.Web.API.Entities.Usuarios;

public class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("nome")]
    public required string Nome { get; set; }

    [Column("endereco")]
    public string Endereco { get; set; }

    [Column("email")]
    public required string Email { get; set; }
}