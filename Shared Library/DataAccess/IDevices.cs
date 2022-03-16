using Shared_Library.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared_Library.DataAccess
{
    public interface IDevices
    {
        
        [Get("/devices")]
        Task<LibrenmsDevicesModel> GetDevices([HeaderCollection] IDictionary<string, string> headers);
    }
}
