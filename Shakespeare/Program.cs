using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shakespeare
{
    class Program
    {
        static void Main(string[] args)
        {
            string shakespeareRoot = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "shakespeare-db");

            //TODO: calculate the total number of words across all works
            //of Shakespeare stored under the shakespeareRoot path




            //Console.WriteLine("Total number of words: ");
        }
    }
}
