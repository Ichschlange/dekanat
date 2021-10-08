using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dekanat
{
    class Student
    {
        public string lastname { get; set; }
        public string midname { get; set; }
        public string firstname { get; set; }
        public int id_group { get; set; }

        public Student() { }
        public Student(string lastname, string midname, string firstname, int id_group)
        {
            this.lastname = lastname;
            this.midname = midname;
            this.firstname = firstname;
            this.id_group = id_group;
        }
    }
}
