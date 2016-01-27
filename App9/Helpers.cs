using App9.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App9
{
    public static class Helpers
    {
        private static readonly Random Rand = new Random();
        public static string LoremIpsum(int minWords, int maxWords, int minSentences = 1, int maxSentences = 1, int numParagraphs = 1)
        {
            var words = new[]
            {
                "lo_rem", "ipsum", "dolor", "sit", "amet", "con_sectetuer",
                "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"
            };

            var result = string.Empty;
            for (var p = 0; p < numParagraphs; p++)
            {
                for (var s = 0; s < Rand.Next(maxSentences - minSentences) + minSentences; s++)
                {
                    if (s > 0) result += ". ";
                    for (var w = 0; w < Rand.Next(maxWords - minWords) + minWords + 1; w++)
                    {
                        if (w > 0) { result += " "; }
                        result += words[Rand.Next(words.Length)];
                    }
                }
            }

            return result;
        }

        public static List<Girl> GetGirls()
        {
            return GetGirls(false);
        }

        public static List<Girl> GetGirls(bool lipsum)
        {
            List<Girl> girls = new List<Girl>{
                new Girl()
                {
                    Name = lipsum ? LoremIpsum(20,70) : "Louise",
                    Age = 25,
                    Image = "/Assets/PolandWinter_ROW12765572701_1366x768.jpg"
                },
                new Girl()
                {
                    Name = lipsum ? LoremIpsum(20,70) : "Mette",
                    Age = 24,
                    Image = "/Assets/RedLakeBolivia_ROW14723021979_1920x1080.jpg"
                },
                new Girl()
                {
                    Name = lipsum ? LoremIpsum(20,70) : "Anne",
                    Age = 22,
                    Image = "/Assets/RockyFog_ROW11830938350_1920x1080.jpg"
                },
                new Girl()
                {
                    Name = lipsum ? LoremIpsum(20,70) : "Pil",
                    Age = 31,
                    Image = "/Assets/RWBlackbird_ROW9876826987_1920x1080.jpg"
                },
                new Girl()
                {
                    Name = lipsum ? LoremIpsum(20,70) : "Maj",
                    Age = 35,
                    Image = "/Assets/SmoketreeDew_ROW16416575560_1920x1080.jpg"
                }
            };
            return girls;
        }

        public static ObservableCollection<Girl> GetRandomGirls(ObservableCollection<Girl> girls, bool lipsum, int maxAge)
        {
            girls.Clear();
            List<Girl> newGirls = GetGirls(lipsum).Where(x => x.Age <= maxAge).ToList();
            newGirls.ForEach(x => girls.Add(x));
            girls.OrderBy(x => Rand.Next());
            return girls;
        }

        public static ObservableCollection<Girl> GetRandomGirls(ObservableCollection<Girl> girls, bool lipsum)
        {
            girls.Clear();
            List<Girl> newGirls = GetGirls(lipsum).ToList();
            newGirls.ForEach(x => girls.Add(x));
            girls.OrderBy(x => Rand.Next());
            return girls;
        }
    }
}
