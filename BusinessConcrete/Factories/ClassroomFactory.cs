using BusinessAbstract.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.PeopleClasses;
using Model.Education;

namespace BusinessConcrete.Factories
{
    public class ClassroomFactory : IClassroomFactory
    {
        public List<Classroom> GenerateClassrooms()
        {
            List<Classroom> classes = new List<Classroom>();
            classes.Add(CreateFirstClass());
            classes.Add(CreateSecondClass());
            return classes;
        }


        #region private

        private Classroom CreateFirstClass()
        {
            Classroom classroom = new Classroom
            {
                Grade = 1,
                Name = "Red Class",
                RoomNumber = 130,
                Package = new PackageBuilders.Active.ActivePackageBuilder()
                                            .AddFirstSports(new Sports { Name = "Basketball advance", TypeOfSport = "Basketball" })
                                            .AddSecondSports(new Sports { Name = "Football masters", TypeOfSport = "Football" })
                                            .AddThirdSports(new Sports { Name = "FreeStyle", TypeOfSport = "Swimming" })
                                            .AddMusic(new Music { Name = "Jazz is awesome!", MusicStyle = "Jazz" })
                                            .Build()                
            };
            return classroom;
        }

        private Classroom CreateSecondClass()
        {
            Classroom classroom = new Classroom
            {
                Grade = 2,
                Name = "Blue Class",
                RoomNumber = 120, Package = new PackageBuilders.FunPackageBuilder()
                                            .AddArts(new Arts { ArtCategory = "Painting", Name = "Painting Classroom" })
                                            .AddMusic(new Music { MusicStyle = "Pop", Name = "Fun time 101" })
                                            .AddSports(new Sports { TypeOfSport = "Basketball", Name = "Go Pro 101" })
                                            .Build()
            };
            return classroom;
        }
        #endregion

    }
}
