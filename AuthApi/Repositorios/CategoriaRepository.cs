using AuthApi.Entidades;
using AuthApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Repositorios
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaFM>> GetAllAsync()
            => await _context.Categorias.AsNoTracking().ToListAsync();

        public async Task<CategoriaFM?> GetByIdAsync(int id)
            => await _context.Categorias.FindAsync(id);

        public async Task<CategoriaFM> AddAsync(CategoriaFM entity)
        {
            _context.Categorias.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(CategoriaFM entity)
        {
            _context.Categorias.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Categorias.FindAsync(id);
            if (existing == null) return false;
            _context.Categorias.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
