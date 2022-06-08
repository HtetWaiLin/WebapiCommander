using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Data
{
    public class MockRepo : ICommanderRepo
    {
        public List<Command> GetList()
        {
            var listitem = new List<Command>
            {
                new Command{ Id = 0 ,HowTo = "Boil an egg", Line = "Boil Water", Platform = "Kettle & Pan"},
                new Command{ Id = 1 ,HowTo = "Cut Break", Line = "Get a Knife", Platform = "Knife & Choping board"},
                new Command{ Id = 2 ,HowTo = "Make up of tea", Line = "Place teabag in cup", Platform = "Kettle & Cup"},
            };
            return listitem;
            //throw new NotImplementedException();
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil Water", Platform = "Kettle & Pan" };
            //throw new NotImplementedException();
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }

        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
