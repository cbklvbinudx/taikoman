using System;
using System.IO;
using System.Linq;

namespace taikoman
{
    class Program
    {

        static readonly string osufile = @"D:\important\proje\taikoman\taikoman\taikoman\Junichi Masuda - Battle! (Legendary Pokemon) (Charlotte) [Inner Oni].osu";

        static void Main(string[] args)
        {

            string[] readosufile = File.ReadAllLines(osufile);

            bool hitobjects = false;

            for(int i = 0; i < readosufile.Count(); i++)
            {
                if (Equals(readosufile[i], "[HitObjects]"))
                {
                    hitobjects = true;
                }
                else if (hitobjects) {
                    string[] elements = readosufile[i].Split(",");

                    string timing = elements[2];
                    string colour = elements[4];
                    string spinner = elements[5];

                    Console.WriteLine(readosufile[i]);
                }
            }
            Console.WriteLine("\ngoinked");
        }
    }
}
