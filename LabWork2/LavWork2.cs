using System;
using System.Linq;
using System.Text;

namespace LabWork2
{
    class LavWork2
    {
        static void Main(string[] args)
        {
            #region Типы

            #region Примитивнвые типы
            Console.Write("введите bool: ");
            bool boolType = Boolean.Parse(Console.ReadLine());
            Console.WriteLine(boolType);

            Console.Write("введите byte: ");
            byte byteType = Byte.Parse(Console.ReadLine());
            Console.WriteLine(byteType); // без знаковая переменная длинной 8байт {0; 255}

            Console.Write("введите sbyte: ");
            sbyte sbyteType = SByte.Parse(Console.ReadLine());
            Console.WriteLine(sbyteType); // знаковвая пременная длиннной 8байт {-128; 127}

            Console.Write("введите short: ");
            short shortType = Int16.Parse(Console.ReadLine());
            Console.WriteLine(shortType); // знаковвая пременная  длиннной 16байт {-32768; 32767}

            Console.Write("введите ushort: ");
            ushort ushortType = UInt16.Parse(Console.ReadLine());
            Console.WriteLine(ushortType); // без знаковвая пременная  длиннной 16байт {0; 65535}

            Console.Write("введите int: ");
            int intType = Int32.Parse(Console.ReadLine());
            Console.WriteLine(intType); // знаковвая пременная  длиннной 32байт {-2147483648; 2147483647}

            Console.Write("введите uint: ");
            uint uintType = UInt32.Parse(Console.ReadLine());
            Console.WriteLine(uintType); // без знаковвая пременная  длиннной 32байт {0; 4294967295}

            Console.Write("введите long: ");
            long longType = Int64.Parse(Console.ReadLine());
            Console.WriteLine(longType); // знаковвая пременная  длиннной 64байт {-9223372036854775808; 9223372036854775807}

            Console.Write("введите ulong: ");
            ulong ulongType = UInt64.Parse(Console.ReadLine());
            Console.WriteLine(ulongType); // без знаковвая пременная  длиннной 64байт {0; 18446744073709551615}

            Console.Write("введите char: ");
            char charType = char.Parse(Console.ReadLine());
            Console.WriteLine(charType); // символьная переменная

            Console.Write("введите float: ");
            float floatType = float.Parse(Console.ReadLine());
            Console.WriteLine(floatType); // (single) перменная с плавающей запятой 4байт

            Console.Write("введите double: ");
            double doubleType = double.Parse(Console.ReadLine());
            Console.WriteLine(doubleType); // перменная с плавающей запятой 8байт

            Console.Write("введите decimal: ");
            decimal decimalType = decimal.Parse(Console.ReadLine());
            Console.WriteLine(decimalType); // перменная с плавающей запятой 16байт          
            #endregion

            #region Явное и нечвное преобразрвание
            intType = shortType;        // неявное перобразование
            longType = intType;         // неявное перобразование
            doubleType = floatType;     // неявное перобразование
            floatType = intType;        // неявное перобразование
            doubleType = longType;      // неявное перобразование

            charType = Convert.ToChar(1);             //явное преобразование
            shortType = (short)charType;
            sbyteType = (sbyte)byteType;
            byteType = (byte)sbyteType;
            doubleType = (double)intType;
            #endregion

            #region упаковка и распаковка
            int age = 18;
            Object ageObject = age;                 // упаковка int age в Object ageObject
            byte ageByte = (byte)(int)ageObject;    // распаковка Object ageObject в byte ageByte
            #endregion

            #region неявно типизированная пермеенная 
            var varType = 1;                                    // неявно типизоранная перемнная
            Console.WriteLine(Convert.ToBoolean(varType + 1));
            #endregion

            #region работа с nullabel перменой
            Nullable<int> nullableIntType = 15; // теперь int может принимать значение null, что означает об отсутствии значения
            Console.WriteLine($"nullabelIntType = {nullableIntType}", nullableIntType);
            nullableIntType = null;
            Console.WriteLine($"nullabelIntType = {nullableIntType}", nullableIntType);
            #endregion

            #region ошибка присвоения неявно типизированной пременной значения другого типа
            var implicytyTypedVaraible = 57;
            //implicytyTypedVaraible = true;

            Console.Clear();
            #endregion

            #endregion

            #region Строии

            #region объявление строкового  литерала
            string sName = "anton", sAge = "18";
            Console.WriteLine($"резлуьтат сравенения sName == sAge: {Convert.ToBoolean(String.Compare(sName, sAge))}\n" +
                $"sName == sName: {Convert.ToBoolean(String.Compare(sName, sAge))}", sName, sAge);
            #endregion

            #region простые действи янад строками
            string copyAge = sAge;
            Console.WriteLine($"сложение строк: {String.Concat(sName, sAge)}\n копия sAge{copyAge}" +
                $"\nвыделение подстроки: {sName.Substring(0, sName.Length - 2)}", sName, sAge, copyAge);

            string fia = String.Format("{0}, {1} {2}", sName, "Tehanov", sAge);
            string[] fiaArr = fia.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string el in fiaArr)
                Console.WriteLine(el);

            Console.WriteLine(fia.Insert(0, "this is my FIA:"));
            string changedFia = fia.Insert(0, "this is my FIA:");
            Console.WriteLine(changedFia.Remove(changedFia.IndexOf('t'), changedFia.IndexOf(':')));
            #endregion

            #region пустые и null строки
            string emptyString = "", nullStirng = null;
            Console.WriteLine($"empty string: {emptyString}\tnull string: {nullStirng}\n" +
                $"сравнение: {emptyString == nullStirng}", emptyString, nullStirng);
            #endregion

            #region StringBuilder
            StringBuilder namelastName = new StringBuilder("anton tehanov", 100);
            for (int a = 1; a < namelastName.Length; a++)
            {
                if (Convert.ToBoolean(a % 2))
                    namelastName.Remove(a, 1);
            }
            Console.WriteLine(namelastName);
            Console.Clear();
            #endregion

            #endregion

            #region массивы

            #region прямоугольный массив
            int[,] twoDementialArr = { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 } };

            for (int line = 0; line < twoDementialArr.GetLength(0); line++)
            {
                for (int colone = 0; colone < twoDementialArr.GetLength(1); colone++)
                {
                    Console.Write("{0}\t", twoDementialArr[line, colone]);
                }

                Console.WriteLine();
            }
            #endregion

            #region изменение одномерного массива
            int[] arr = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Массив длиноой {arr.Length}:", arr.Length);
            foreach (int el in arr)
                Console.Write(el);

            Console.Write("\nвведите позицию для изменения: ");
            int position = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nвведите изменение: ");
            int value = Convert.ToInt32(Console.ReadLine());

            arr[position - 1] = value;

            Console.WriteLine($"изменённый массив:");
            foreach (int el in arr)
            {
                Console.Write(el);
            }
            #endregion

            #region зубчатый массив
            Console.WriteLine("введите массив вещественных чисел:");
            float[][] jaggedArray = { new float[2], new float[3], new float[4] };
            for (int line = 0; line < jaggedArray.GetLength(0); line++)
            {
                Console.WriteLine($" элементы {line} строки:", line);
                for (int colone = 0; colone < jaggedArray[line].Length; colone++)
                    jaggedArray[line][colone] = float.Parse(Console.ReadLine());
            }

            for (int line = 0; line < jaggedArray.GetLength(0); line++)
            {
                for (int colone = 0; colone < jaggedArray[line].Length; colone++)
                    Console.Write("{0}\t", jaggedArray[line][colone]);

                Console.WriteLine();
            }
            #endregion

            #region неявно и типизированная переменная для массива и строки
            var varaibleForArr = new int[21];
            var varaibleForString = "";
            Console.Clear();
            #endregion

            #endregion

            #region картежи
            ValueTuple<int, string, char, string, ulong> infAnt = (18, "anton", 't', "victorovich", 60602002);
            (int age, string name, char lastname, string otch, ulong yeara) nameAnd = (18, "andrew", 't',
                "victorovich", 60602002);

            Console.WriteLine(infAnt);
            Console.WriteLine(nameAnd);

            // распаковка
            (int antage, string antname, char lastname, string otch, ulong burth) = infAnt;
            Console.WriteLine($"{antage} {antname} {lastname} {otch} {burth}", antage, antname, lastname, otch, burth);
            Console.WriteLine(infAnt.CompareTo(nameAnd));
            #endregion

            #region локальная функция

            (int maxEl, int minEl, int sumArr, char firstCharStr) localFunction(int[] arr, string str)
            {                
                return (arr.Max(), arr.Min(), arr.Sum(), str[0]);
            }

            int[] arrV = { 1, 2, 3, 4, 5 };
            string str = "anton";

            Console.WriteLine(localFunction(arrV, str));
            Console.Clear();
            #endregion

            #region раьота с checked и unchecked

            void FunctionWithCheckedBlock()
            {
                checked
                {
                    //int intMaxValue = int.MaxValue + 10;
                }
            }

            void FunctionWithUnCheckedBlock()
            {
                unchecked
                {
                    int intMaxValue = int.MaxValue + 10;
                }
            }

            #endregion
        }
    }
}
