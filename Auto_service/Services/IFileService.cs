using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_service.Services
{
    public interface IFileService
    {
        void Save(string file, string filename);
    }
}
