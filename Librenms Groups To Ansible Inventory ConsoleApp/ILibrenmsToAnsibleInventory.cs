using Shared_Library.Models;

internal interface ILibrenmsToAnsibleInventory
{
    Task<List<AnsibleInventoryModel>> GetDevices();
}