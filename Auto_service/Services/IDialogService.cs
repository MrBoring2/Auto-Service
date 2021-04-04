using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_service.Services
{
    public interface IDialogService
    {
        void ShowMessage(string message);   // показ сообщения
        string FilePath { get; set; } 
        string FileName { get; set; }
        bool OpenFileDialog();  // открытие файла
        bool SaveFileDialog();
    }
}
