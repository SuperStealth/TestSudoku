using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Services
{
    public interface IGameService
    {
        public Task<bool> Init();

        bool Started { get; }
    }
}
