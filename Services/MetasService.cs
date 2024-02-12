using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_IsaacCoste.DAL;
using Parcial1_Ap1_IsaacCoste.Models;
using System.Linq.Expressions;

namespace Parcial1_Ap1_IsaacCoste.Services
{
    public class MetasService
    {
        private readonly Contexto _contexto;
        public MetasService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Insertar(Metas Metas)
        {
            _contexto.Metas.Add(Metas);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Modificar(Metas Metas)
        {
            _contexto.Update(Metas);
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Existe(int MetaId)
        {
            return await _contexto.Metas.AnyAsync(a => a.MetaId == MetaId);
        }
        public async Task<bool> Guardar(Metas Metas)
        {
            if (!await Existe(Metas.MetaId))
                return await Insertar(Metas);
            else
                return await Modificar(Metas);
        }
        public async Task<bool> Eliminar(Metas Metas)
        {
            var cantidad = await _contexto.Metas.Where(a => a.MetaId == Metas.MetaId).ExecuteDeleteAsync();
            return cantidad > 0;
        }
        public async Task<Metas?> Buscar(int MetaId)
        {
            return await _contexto.Metas.Where(a => a.MetaId == MetaId).AsNoTracking().SingleOrDefaultAsync();
        }
        public async Task<List<Metas>> Listar(Expression<Func<Metas, bool>> criterio)
        {
            return await _contexto.Metas.Where(criterio).AsNoTracking().ToListAsync();
        }
    }
}
