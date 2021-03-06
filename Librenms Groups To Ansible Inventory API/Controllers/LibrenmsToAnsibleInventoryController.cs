
using Shared_Library.DataAccess;
using Shared_Library.Models;
using Microsoft.AspNetCore.Mvc;


namespace Librenms_Groups_To_Ansible_Inventory_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrenmsToAnsibleInventoryController : ControllerBase
    {
        IDevices _devices;
        IGroups _groups;
        ISingleGroup _group;
        IConfiguration _configuration;
        public LibrenmsToAnsibleInventoryController(IDevices devices, IGroups groups,ISingleGroup group,IConfiguration configuration)
        {
            _devices = devices;
            _groups = groups;
            _group = group;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<List<AnsibleInventoryModel>> Get()
        {
            var header = new Dictionary<string, string> 
                        { { _configuration.GetValue<String>("Auth_Type"), _configuration.GetValue<String>("Token") } };
            List<AnsibleInventoryModel> inventory = new();
            var devices = (await _devices.GetDevices(header)).devices.ToList();
            var groups = (await _groups.GetGroups(header)).groups.ToList();
            foreach (var group in groups)
            {
                var list = await _group.GetGroupDevices(group.id, header);
                var ansibleDevices = (from l in list.devices join d in devices on l.device_id equals d.device_id select new AnsibleInventoryDeviceModel {hostname = d.hostname}).ToList(); 
                AnsibleInventoryModel ansible = new AnsibleInventoryModel { group = group.name, devices = ansibleDevices};
                inventory.Add(ansible);
            }
            await output.outputFile(inventory, _configuration.GetValue<String>("Dir"));
            return inventory;
        }     
       
    }
}
