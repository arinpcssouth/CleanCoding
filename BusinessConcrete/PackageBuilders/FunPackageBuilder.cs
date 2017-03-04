using BusinessAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Education.Packages;
using BusinessAbstract.Builders;
using Model.Education;

namespace BusinessConcrete.PackageBuilders
{
    public interface IAddArts 
    {
        IAddMusic AddArts(Arts arts); 
    }
    public interface IAddMusic 
    {
        IAddSports AddMusic(Music music);
    }
    public interface IAddSports 
    {
        IPackageBuilder AddSports(Sports sports);
    }

   



    public class FunPackageBuilder :  IAddArts , IAddMusic, IAddSports , IPackageBuilder
    {
        
       
        private List<IMajor> Majors { get; set; }

        //funPackage.Majors = new List<Model.Education.IMajor>();

        public FunPackageBuilder()
        {
        Majors = new List<IMajor>();
        }

        public IAddMusic AddArts(Arts arts)
        {
            Majors.Add(arts);
            return this;
        }

        public IAddSports AddMusic(Music music)
        {
            Majors.Add(music);
            return this;
        }

        public IPackageBuilder AddSports(Sports sports)
        {
            Majors.Add(sports);
            return this;
        }


        public IPackage Build()
        {
            IPackage package = new FunPackage();
            package.Majors = this.Majors;
            return package;
        }


    }
}
