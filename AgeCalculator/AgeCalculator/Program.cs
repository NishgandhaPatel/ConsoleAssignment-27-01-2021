using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;



namespace AgeCalculator
{
    [Serializable]
    class Person: IDeserializationCallback
    {
        DateTime bday = Convert.ToDateTime("03/05/1999");
        DateTime today = DateTime.Today;
        [NonSerialized]
        public int age;
        
       
            public Person()
        {

        }
            public Person(int age)
        {
            this.age = age;     
        }
public void OnDeserialization(object sender)
        {
            age = today.Year - bday.Year;
        }
    }
    class Program
    {
       
            static void Main(string[] args)
        {
            Person pd = new Person();
            FileStream fs = new FileStream(@"Person", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, pd);
            fs.Seek(0, SeekOrigin.Begin);
            Person res = (Person)bf.Deserialize(fs);
            Console.WriteLine($"Calculated age is:"+res.age);

        }
    }
}
