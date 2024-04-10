using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVObjList
{
    public class Person
    {
        int id;
        string name;
        string gender;
        int birthYear;
        int age;

        public Person(int empId, string empName, string empGender, int empBday, int empAge)
        {
            id = empId;
            name = empName;
            gender = empGender;
            birthYear = empBday;
            age = empAge;
        }


        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public int BirthYear { get => birthYear; set => birthYear = value; }

        public int Age { get => age; set => age = value; }
    }
}
