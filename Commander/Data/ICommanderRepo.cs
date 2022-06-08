using Commander.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        //save
       bool SaveChange();
       List<Command> GetList();
       Command GetCommandById(int id);
       void CreateCommand(Command cmd);
       void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}
