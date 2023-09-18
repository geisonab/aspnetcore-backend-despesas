using despesas_pessoais.Models;
using Microsoft.AspNetCore.Mvc;

namespace despesas_pessoais.Interfaces
{
    public interface IDespesasRepository
    {
        public void CriarDespesa(DespesasModel despesa);

        public Task<IEnumerable<DespesasModel>> BuscarDespesas();

        public Task<DespesasModel> BuscarPeloId(int id);

        public void EditarDespesa(DespesasModel despesa);

        public void ExcluirDespesa(DespesasModel despesa);

        public Task<bool> SaveAllAsync();
    }
}