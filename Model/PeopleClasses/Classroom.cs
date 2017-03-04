using Model.Education.Packages;

namespace Model.PeopleClasses
{
    public class Classroom
    {
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public int Grade { get; set; }

        public IPackage Package { get; set; }


    }
}