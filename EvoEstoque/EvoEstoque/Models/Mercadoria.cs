using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoEstoque.Models
{
    [Table("Mercadoria")]
    public class Mercadoria
    {
        [Display(Name ="Código")]
        [Column("Id")]
        public int  Id { get; set; }

        [Display(Name = "Descricao")]
        [Column("Descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Unidade")]
        [Column("Unidade")]
        public string Unidade { get; set; }

        [Display(Name = "Estoque")]
        [Column("Estoque")]
        public int Estoque { get; set; }
    }
}
