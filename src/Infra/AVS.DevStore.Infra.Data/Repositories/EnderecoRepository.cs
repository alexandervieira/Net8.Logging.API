using AVS.DevStore.Business.Intefaces;
using AVS.DevStore.Business.Models;
using AVS.DevStore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AVS.DevStore.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}