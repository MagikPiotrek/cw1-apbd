using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

namespace Cw1
{
    public class Student
    {
        //Wlasciwosc Skrocona
        public string Nazwisko { get; set; }
        //propfull
        private string _imie;

        public string Imie
        {
            get { return _imie; }
            set
            {
                if (value == null) throw new ArgumentException();
                _imie = value;
            }
        }

    }
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";

                var client = new HttpClient();
                var result = await client.GetAsync("https://www.pja.edu.pl");

                if (!result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Server Error");
                    return;
                }

                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                var matches = regex.Matches(html);

                var set = new HashSet<string>();

                var list = new List<string>();

                var elements = from e in list
                               where e.StartsWith("A")
                               select e;
                var elements2 = list.Where(s => s.StartsWith("A"));

                var slownik = new Dictionary<string, string>();

                foreach (var m in matches)
                {
                    Console.WriteLine(m);
                }

            }catch(Exception exc)
            {
                //interpolacja stringa
                //string.Format("Wystapil blad {0}", exc.ToString());
                Console.WriteLine($"Wystapil blad {exc.ToString()}");
            }
            


            Console.WriteLine("KONIEC");
        }
    }
}
