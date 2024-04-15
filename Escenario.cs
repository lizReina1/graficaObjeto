using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace PlanoGenerico
{
    public class Escenario
    {
        List<object> listofObject;

        public Escenario()
        {
            this.listofObject = new List<object>();
        }

        public void setList(Object objetForEscenario)
        {
            listofObject.Add(objetForEscenario);
        }

        public List<object> getList()
        {
           return listofObject;
        }



    }
}
