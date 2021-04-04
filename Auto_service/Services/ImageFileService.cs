using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_service.Services
{
    class ImageFileService : IFileService
    {
        public void Save(string file, string filename)
        {     
            File.Copy(file, @"..\..\Resources\Клиенты\" + filename);
        }
    }
}
