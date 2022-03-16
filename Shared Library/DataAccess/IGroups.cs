using Shared_Library.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared_Library.DataAccess
{
    public interface IGroups
    {
        
        [Get("/devicegroups")]
        Task<LibrenmsGroupsModel> GetGroups([HeaderCollection] IDictionary<string, string> headers);
    }
}
