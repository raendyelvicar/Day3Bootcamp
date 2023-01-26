using Day3Bootcamp.Exceptions;

namespace Day3Bootcamp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Translate> HomeDictionary = new List<Translate>
            {
                new Translate() {Id="Kontak", En="Contact"},
                new Translate() {Id="Pengaturan", En="Setting"},
                new Translate() {Id="Tentang Kami", En="About Us"},
            };

            List<Translate> ProfileDictionary = new List<Translate>
            {
                new Translate() {Id="Ubah", En="Edit"},
                new Translate() {Id="Nama", En="Name"},
                new Translate() {Id="Alamat", En="Address"},
            };

            List<Translate> SettingDictionary = new List<Translate>
            {
                new Translate() {Id="Kata Sandi", En="Password"},
                new Translate() {Id="Simpan", En="Save"},
                new Translate() {Id="Keluar", En="Logout"},
            };


            Dictionary<string, List<Translate>> dict = new Dictionary<string, List<Translate>>
            {
                { "Home", HomeDictionary},
                { "Profile", ProfileDictionary},
                { "Settings", SettingDictionary}
            };

            Console.WriteLine("Choose dictionary:");
            int idx = 0;
            foreach(var key in dict.Keys)
            {
                Console.WriteLine(++idx + ". " + key);
            }

             HandleInputUser(dict);
        }

        static void HandleInputUser(Dictionary<string, List<Translate>> dict)
        {
            try
            {
                int choosen = Convert.ToInt32(Console.ReadLine());
                while (!ValidateInput(choosen))
                {
                    Console.WriteLine($"There is no input {choosen}. Please try again.");
                    choosen = Convert.ToInt32(Console.ReadLine());
                }

                string choosenKey = dict.ElementAt(choosen - 1).Key;

                Console.WriteLine("======== " + choosenKey+ " Menu ========\n");
                Console.WriteLine("| {0,-12} | {1,-10} |", "Bahasa", "English");
                Console.WriteLine("| {0,-12} | {1,-10} |", "-------", "-------");
                foreach (var data in dict[choosenKey])
                {
                    Console.WriteLine("| {0,-12} | {1,-10} |", data.Id, data.En);
                }
            }
            catch (System.FormatException e)
            {
                Console.WriteLine($"{e.Message} Please try again.");
                HandleInputUser(dict);
            }
        }

        static bool ValidateInput(int choosen)
        {   
            if(choosen != 1 ^ choosen != 2 ^ choosen != 3)
            {
                return false;
            }

            return true;
        }
    }
}