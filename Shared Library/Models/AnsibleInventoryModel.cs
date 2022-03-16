using System.Collections.Generic;

namespace Shared_Library.Models
{
    public class AnsibleInventoryModel
    {
        //ansible inventory list
        public string group { get; set; }
        public List<AnsibleInventoryDeviceModel> devices { get; set; }
    }
}
