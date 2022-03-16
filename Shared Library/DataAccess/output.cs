using Shared_Library.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Shared_Library.DataAccess
{
    public static class output
    {

        public static async Task outputFile(List<AnsibleInventoryModel> inventory, string path)
        {
          
            using (StreamWriter file = new StreamWriter(path))
            {
                file.Flush();
                file.BaseStream.Position = 0;
                //file.BaseStream.ReadTimeout = 2000;
                //file.BaseStream.WriteTimeout = 2000;
                foreach (var inventoryList in inventory)
                {
                    await file.WriteLineAsync($"[{inventoryList.group}]");
                    foreach (var item in inventoryList.devices)
                    {
                        await file.WriteLineAsync($"{item.hostname}");
                    }
                };
            }
           
        }

    }
}
