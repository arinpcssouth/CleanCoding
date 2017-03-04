using BusinessAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Education.Packages;
using BusinessAbstract.Builders;

namespace BusinessConcrete.PackageBuilders
{
    public class ChallengePackageBuilder : BusinessAbstract.Builders.IAddArts
    {
        public IPackage Build
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
