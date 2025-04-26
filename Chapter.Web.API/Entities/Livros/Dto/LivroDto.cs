namespace Chapter.Web.API.Entities.Livros.Dto;
public class LivroDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int QuantidadePaginas { get; set; }
    public int Estoque { get; set; }
}