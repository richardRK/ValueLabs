using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication17
{
    class Program
    {
        static void Main(string[] args)
        {



            Program p = new Program();

            //load inputs
            var lst1 = p.RegisteredCandidatesSource1();
            var lst2 = p.RegisteredCandidatesSource2();



            //combine both of them.
            string[] combined = lst1.Concat(lst2).ToArray();


            //match the pattern in the format of "Surname, Forename" 
            string pattern = @"^([a-zA-Z]+), ([a-zA-Z]+$)";


            List<string> match = new List<string>();
            List<string> mismatch = new List<string>();


            foreach (var str1 in combined)
            {

                Match result = Regex.Match(str1, pattern);
                if (result.Success)
                {
                    match.Add(str1);
                }

                else
                {
                    mismatch.Add(str1);
                }
            }


            //remove duplicates
            var uniqueMatch = match.Distinct().ToList();
            var uniqueMisMatch = mismatch.Distinct().ToList();

            
            var uniqueMtchArry = uniqueMatch.ToArray();

            //Create a method(s) to count how many times the first character of the forename appears in both lists.
            Solve(uniqueMtchArry);

            Console.ReadLine();

        }

        private static void Solve(string[] uniqueMtchArry)
        {
            List<char> firstCharLst = new List<char>();

            foreach (var entity in uniqueMtchArry)
            {
                string original = entity.ToLower();
                int comma = original.IndexOf(',');

                string Surname = original.Substring(0, comma);

                string Forename = original.Substring(original.LastIndexOf(',') + 1).Trim(' ');

                var firstChar = Forename.First();


                if (!firstCharLst.Contains(firstChar))
                {
                    //logic to count occurances
                    var count = findOccurances(uniqueMtchArry, firstChar);

                    var upperfirstChar = Char.ToUpper(firstChar);
                    Console.WriteLine(upperfirstChar + " appears " + count + " times");
                }

                firstCharLst.Add(firstChar);

            }

        }

        private static int findOccurances(string[] uniqueMtchArry, char firstChar)
        {
            int count = 0;

            foreach (var input in uniqueMtchArry)
            {

                string original = input.ToLower();

                for (int j = 0; j < original.Length; j++)
                {

                    if (firstChar == original[j])
                    {
                        count++;
                    }
                }
            }

            return count;
        }





        public string[] RegisteredCandidatesSource1()
        {
            //"Lastname, firstname"
            var arrNames1 = new string[]
            {
                "Carrie, Kirker",
                "Masako, Freas",
                "Collins, Bill",
                "Smith , Bart",
                "Allen,  Tim",
                "Courtney Tyrrell",
                "Gidget, Borey",
                "Holley, Witte",
                "Robby,  Payeur",
                "Deloise,, Carnegie",
                "Sherwood ,Dille, Tim",
                "Lea, Balfour",
                "Catharine, Capra",
                "Julian, Turman",
                "Hoa ,Wissing",
                "Shanika, Theriault",
                "Eloise ,Fielden",
                "Marylynn, Masterson",
                "Hyun, Gonser",
                "Sherlene , Tumlin",
                "Harley , Delosreyes",
                "Lillie, Stolp",
                "Fred, Noblin",
                "Tangela ,Leider",
                "Long, Bruner",
                "Gaynell, Jaquith",
                "Karey, Whitworth",
                "Arturo, Shanley"
            };
            return arrNames1;
        }
        public string[] RegisteredCandidatesSource2()
        {
            //"Lastname, firstname"
            var arrNames2 = new string[]
            {
                "Viki, Sharer",
                "Jule, Goldblatt",
                "Mao, Aldana",
                "Lorretta, Roman",
                "Scarlet, Solis",
                "Carrie, Kirker",
                "Masako, Freas",
                "Mollie, Rabinowitz",
                "Marceline ,Polley",
                "Earlene, Spake",
                "Eduardo, Benda",
                "Robt, Enderle",
                "Antonio, Mchaney",
                "Tilda, Kahan",
                "Melva, Erby",
                "Latashia, Szewczyk",
                "Faustina, Emberton",
                "Vallie, Bordeau",
                "Janette, Husted",
                "Anglea, Haman",
                "Parker, Doggett",
                "Lael, Chiaramonte",
                "Marie, Spilman",
                "Alene, Dressel",
                "Pamela, Monsour",
                "Bao, Mcardle",
                "Zina, Aikens",
                "Gudrun ,Caughman",
                "Rebecca",
                "Beverlee, Oiler,",
                "Elnora, Meaders,",
                "Becky, Leathers",
                "Lola",
                "Teofila, Gullatt",
                "Jacquiline, Lowrey",
                "Alica, Pellerin",
                "Jodie, Redding",
                "Zoraida, Vallecillo,",
                "Tova, Goranson",
                "Wendolyn, Cicero",
                "Long ,,Pigford",
                "Gaynell, Jaquith",
                "Karey, Whitworth",
                "Arturo, Shanley",
                "Shirl, Clingan",
                "Latarsha, Hollins",
                "Alvera, Keenan",
                "Elisha, Lipps",
                "Sherlyn, Semmes",
                "Galina, Porras"
            };
            return arrNames2;
        }
    }
}
