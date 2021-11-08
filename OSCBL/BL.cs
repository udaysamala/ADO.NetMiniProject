using OSCDAL;
using OSCDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCBL
{
    public class BL
    {
        DAL dalObj = new DAL();
        public int CheckLogin(Customer newObj)
        {
            try
            {
                
                int result = dalObj.Login(newObj);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int checkadminlogin(Admin newadmin)
        {
            try
            {
                int result = dalObj.AdminLogin(newadmin);
                return result;


            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
