using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;
//using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly EFDbContext _context;

        public SqlCommanderRepo(EFDbContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Command.Add(cmd);
          
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Command.Remove(cmd);
            // throw new NotImplementedException();
        }

        public Command GetCommandById(int id)
        {
            return _context.Command.FirstOrDefault(p => p.Id == id);
            //throw new NotImplementedException();
        }

        public List<Command> GetList()
        {
            return _context.Command.ToList();
            //throw new NotImplementedException();
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
            //throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            //throw new NotImplementedException();
        }
    }
}
