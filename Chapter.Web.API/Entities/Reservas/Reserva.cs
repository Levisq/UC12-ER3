using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chapter.Web.API.Entities.Reservas;

public class Reserva
{
    [Key]
    [Column("Cod_Reserva")]
    public int Id { get; set;}

    [Column("FK_Livro")]
    public int LivroId { get; set;}

    [Column("FK_Usuario")]
    public int UsuarioId {get; set;}

    [Column("DataInicial")]
    public DateTime DataInicial { get; set;}

    [Column("DataFinal")]
    public DateTime DataFinal { get; set;}

}