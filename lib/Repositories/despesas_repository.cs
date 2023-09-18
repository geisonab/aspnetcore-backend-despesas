using despesas_pessoais.Data;
using despesas_pessoais.Interfaces;
using despesas_pessoais.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace despesas_pessoais.Repositories
{
    public class DespesasRepository : IDespesasRepository
    {
        private readonly AppDBContext _context;

        public DespesasRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DespesasModel>> BuscarDespesas()
        {
            return await _context.DespesasTable.ToListAsync();
        }

        public async Task<DespesasModel> BuscarPeloId(int id)
        {
            var despesa = await _context.DespesasTable.Where(x => x.IdDespesa == id).FirstOrDefaultAsync();

            return despesa ?? DespesasModel.DespesaVazio();
        }

        public void CriarDespesa(DespesasModel despesa)
        {
            _context.DespesasTable.Add(despesa);
        }

        public void EditarDespesa(DespesasModel despesa)
        {
            _context.Entry(despesa).State = EntityState.Modified;
        }

        public void ExcluirDespesa(DespesasModel despesa)
        {
            _context.DespesasTable.Remove(despesa);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}