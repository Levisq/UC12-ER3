using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter.Web.API.Entities.Livros;

public class Livro
{
    [Key]
    [Column("cod_livro")]
    public int Id { get; set; }

    [Column("titulo")]
    public string Titulo { get; set; }

    [Column("num_pages")]
    public int QuantidadePaginas { get; set; }
    
    [Column("num_stoque")]
    public int Estoque { get; set; }

}