using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Repository
{
    public interface ICadastroRepository
    {
        string CadastroAdd(CadastroModel dados);
        string CadastroUpd(CadastroModel dados);
        string CadastroDel(int id);
        IEnumerable<CadastroModel> CadastroGet();

    }
}
