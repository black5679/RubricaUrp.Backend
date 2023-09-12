using RubricaUrp.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUrp.Backend.Domain.Repositories
{
    public interface ICursoRepository
    {
        Task<CursoModel> GetById(int id);
        Task<int> Insert(CursoModel curso);
    }
}
