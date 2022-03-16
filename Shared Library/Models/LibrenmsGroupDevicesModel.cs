using System.Collections.Generic;

namespace Shared_Library.Models
{
    public class LibrenmsGroupDevicesModel
    {
        //devices id in librenms group
        public List<LibrenmsGroupDeviceModel> devices { get; set; }
        public int count { get; set; }
       
    }
}
