using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablesQueuesDemo.Entities
{
    class Student : TableEntity
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int Grade { get; set; }
        public char Group { get; set; }
        public string ID
        {
            get
            {
                return
                    $"{Name[0]}" +
                    $"{BirthDay.Day}" +
                    $"{BirthDay.Month}" +
                    $"{BirthDay.Year}" +
                    $"{Grade}" +
                    $"{Group}";
            }
        }
        public Student(string name, 
            DateTime birthDay, 
            int grade, 
            char group)            
        {
            this.Name = name;
            this.BirthDay = birthDay;
            this.Grade = grade;
            this.Group = group;

            this.PartitionKey = $"{grade}{group}";
            this.RowKey = ID;
        }

        public Student()
        {

        }
    }
}
