using System.Collections.Generic;

namespace Shared_Library.Models
{
    public class LibrenmsDevicesModel
    {
        //librenms list of devices
        public List<LibrenmsDeviceModel> devices { get; set; }
        public int count { get; set; }
    }
}
