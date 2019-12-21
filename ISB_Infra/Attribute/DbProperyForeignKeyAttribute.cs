using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Infra.Attribute
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class DbProperyForeignKeyAttribute : System.Attribute
    {

    }
}
