using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboPazLib
{
    public enum MenuStateEnum : byte
    {
        ModelAll=1,
        BrandAll,
        ModelById,
        ModelAdd,
        ModelEdit,
        ModelRemove,
        BrandById,
        BrandAdd,
        BrandEdit,
        BrandRemove,


        SaveChanges,
        Exit,
    }
}
