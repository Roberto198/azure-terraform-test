using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.Client.DbModels;

namespace VMS.Client
{

    public interface IVanController
    {

        //Van GetVansController();
        Van AddVanController(Van van);

        Van[] GetVansController();
  
    }

    public class VanController : IVanController
    {
        private readonly VMSContext _context;

        public VanController(VMSContext context)
        {
            _context = context;
        }

        public Van[] GetVansController()
        {

            Van[] van = _context.Vans.ToArray();
            if (van == null)
            {
                throw new Exception("No Van found");
            }

            return van;

        }

        public Van AddVanController(Van newVan)
        {
            try
            {
                _context.Vans.Add(newVan);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            return newVan;

        }

    }
}
