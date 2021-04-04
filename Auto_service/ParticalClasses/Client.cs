using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_service
{
    public partial class Client
    {
        private string lastVisit;
        public string LastVisit
        {
            get
            {
                if (ClientService.Count > 0)
                    return this.ClientService.Max(v => v.StartTime).ToString("dd.MM.yyyy");
                else return "";
            }
        }
        public int CountOfVisit
        {
            get
            {
                if (ClientService.Count > 0)
                    return this.ClientService.Count;
                else return 0;
            }
        }
    }
}
