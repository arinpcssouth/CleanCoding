using BusinessAbstract;
using BusinessAbstract.Builders;
using Model.Education;
using Model.Education.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessConcrete.PackageBuilders.Active
{
    
    public class ActivePackageBuilder : IAddFirstSports, IAddSecondSports, IAddThirdSports, IAddMusic,  IPackageBuilder
    {


        private List<IMajor> Majors { get; set; }

        //funPackage.Majors = new List<Model.Education.IMajor>();

        public ActivePackageBuilder()
        {
            Majors = new List<IMajor>();
        }

        public IAddSecondSports AddFirstSports(Sports sports)
        {
            Majors.Add(sports);
            return this;
        }

        public IAddThirdSports AddSecondSports(Sports sports)
        {
            Majors.Add(sports);
            return this;
        }

        public IAddMusic AddThirdSports(Sports sports)
        {
            Majors.Add(sports);
            return this;
        }

        public IPackageBuilder AddMusic(Music music)
        {
            Majors.Add(music);
            return this;
        }


        public IPackage Build()
        {
            IPackage package = new FunPackage();
            package.Majors = this.Majors;
            return package;
        }


    }


    #region chain interfaces
    public interface IAddFirstSports
    {
        IAddSecondSports AddFirstSports(Sports sports);
    }
    public interface IAddSecondSports
    {
        IAddThirdSports AddSecondSports(Sports sports);
    }

    public interface IAddThirdSports
    {
        IAddMusic AddThirdSports(Sports sports);
    }

    public interface IAddMusic
    {
        IPackageBuilder AddMusic(Music music);
    }
    #endregion


}
