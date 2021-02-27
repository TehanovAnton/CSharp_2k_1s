using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork9
{
    class User
    {
        // лист всех созданных объектов
        private static List<User> allObjects = new List<User>();



        public int version;
        public bool work;
        public string name;



        public User(string name)
        {
            version = 0;
            work = false;
            this.name = name;
            allObjects.Add(this);
        }



        private delegate void func(User u);
        private func OU = u =>
        {
            u.version++;
            Console.WriteLine($"{u.name} version uudated");
        };
        public void OnUpdate()
        {
            OU(this);
        }



        private func OS = u =>
        {
            u.work = true;
            Console.WriteLine($"{u.name} Start Working");
        };
        public void OnStartWork()
        {
            OS(this);
        }



        private delegate void Veiw();
        static Veiw VO = () =>
        {
            for (byte i = 0; i < allObjects.Count; i++)
            {
                Console.WriteLine($"V:{allObjects[i].version}\tW:{allObjects[i].work}");
            }
            Console.WriteLine();
        };
        public static void VeiwObjects() 
        {
            VO();
        }
    }
}
