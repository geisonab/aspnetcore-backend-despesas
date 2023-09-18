using System.ComponentModel.DataAnnotations;

namespace despesas_pessoais.Models
{
    public class DespesasModel
    {
        public static DespesasModel DespesaVazio()
        {
            return new DespesasModel
            {
                IdDespesa = 0,
                Titulo = "",
                Valor = 0,
                Data = DateTime.MinValue,

            };
        }

        [Key]
        public int IdDespesa { get; set; }
        [StringLength(50)]
        public required string Titulo { get; set; }
        public required decimal Valor { get; set; }
        public required DateTime Data { get; set; }
    }
}