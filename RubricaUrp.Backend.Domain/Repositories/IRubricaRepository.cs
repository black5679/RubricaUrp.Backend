using RubricaUrp.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUrp.Backend.Domain.Repositories
{
    public interface IRubricaRepository
    {
        Task Save(List<RubricaModel> rubricas, int idCurso);
        Task<IEnumerable<RubricaModel>> GetByIdCurso(int idCurso);
    }
}
