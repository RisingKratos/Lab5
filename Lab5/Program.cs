using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serialize
{
    [Serializable]
    public class Person
    {
        public Person(int age)
        {
            this.Age = age;
        }
        public Person()
        {
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        private static void Serializing(Person sp)
        {
            XmlSerializer x = new XmlSerializer(typeof(Person));

            FileStream fs = new FileStream("t.txt", FileMode.OpenOrCreate);
                    

            x.Serialize(fs, sp);

            fs.Close();

            fs = new FileStream("t.txt", FileMode.Open);

            Person p2 = x.Deserialize(fs) as Person;

            fs.Close();
        }

        static void Main(string[] args)
        {
            Person s = new Person(18);
            s.Name = "Muslim";
            s.Surname = "Beibytuly";
            Serializing(s);
        }
    }
}
