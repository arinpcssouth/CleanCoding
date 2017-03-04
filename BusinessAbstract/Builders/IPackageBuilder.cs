using Model.Education.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAbstract.Builders
{
    public interface IAddArts
    {
        IPackage Build { get; }
    }
}
