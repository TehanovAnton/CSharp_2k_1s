using System;
using System.Text;

namespace LabWork9
{
    class ProgramA
    {
        delegate void stringProcessing(ref string str);

        static void Event()
        {
            Admin admin = new Admin();

            User user1 = new User("anton");
            User user2 = new User("lanester");

            admin.upgrade += user1.OnUpdate;
            admin.upgrade += user2.OnUpdate;

            admin.work += user1.OnStartWork;
            admin.work += user2.OnStartWork;
            User.VeiwObjects();

            admin.StartWork();
            User.VeiwObjects();

            admin.Update();
            User.VeiwObjects();
        }

        static void Main(string[] args)
        {
            Event();

            string s = "Антон Теханов Викторович";

            Action<string, Func<string, string>> alghoritm = delegate (string str, Func<string, string> func)
            {
                str = func(str);

                func = str => str.Replace(" ", "|,");
                str = func(str);

                func = str =>
                {
                    string res = "";
                    for (int i = 0; i < str.Length; i++)
                        res += "уеэоаыяию".Contains(str[i]) ? 'ё' : str[i];
                    return res;
                };
                str = func(str);

                func = str => str.Replace(',', '\0');
                str = func(str);

                func = str =>
                {
                    string res = "";
                    for (int i = 0; i < str.Length; i++)
                        res += "уеэоаыяию".Contains(str[i]) ? (char)((int)str[i] + (((int)'А' - (int)'а'))) : str[i];
                    return res;
                };
                str = func(str);

                Console.WriteLine(str);
            };

            alghoritm(s, s => s.ToLower());
        }
    }
}
