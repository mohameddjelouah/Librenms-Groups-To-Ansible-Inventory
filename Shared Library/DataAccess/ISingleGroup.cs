using Shared_Library.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared_Library.DataAccess
{
    public interface ISingleGroup
    {
        
        [Get("/devicegroups/{groupId}")]     
        Task<LibrenmsGroupDevicesModel> GetGroupDevices(int groupId, [HeaderCollection] IDictionary<string, string> headers);
    }
}
