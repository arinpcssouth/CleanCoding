using Model.Education.Packages;

namespace BusinessConcrete.PackageBuilders
{
    public interface IPackageBuilder
    {
        IPackage Build();
    }
}