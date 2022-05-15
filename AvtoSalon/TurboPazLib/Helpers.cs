using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TurboPaz.Enums;
using TurboPazLib.Enums;

namespace TurboPazLib
{
    public class Helpers
    {
        public static string ReadString(string caption, bool required = false)
        {
        l1:

            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            string value = Console.ReadLine();
            Console.ResetColor();
            if (required && string.IsNullOrWhiteSpace(value))
            {
                PrintError("Xais olunur uygun deyeri daxil edin:");
                goto l1;
            }

            return value;
        }

        public static int ReadInt(string caption, int minvalue = 1)
        {
        l1:
            Console.Write(caption);

            string value = Console.ReadLine();

            if (!int.TryParse(value, out int number))
            {
                PrintError("Xais olunur duzgun deyeri daxil edin:");
                goto l1;
            }
            else if (number < minvalue)
            {
                PrintError($"Daxil oluna bilecek minimum deyer: {minvalue}");
                goto l1;
            }
            return number;
        }

        public static int ReadIntYear(string caption,int minValue = 0,int maxValue =0)
        {
            l1:
            Console.Write(caption);
            string value = Console.ReadLine();
            if (!int.TryParse(value, out int number))
            {
                PrintError("Xaiş olunur düzgün ədəd daxil edin");
                goto l1;
            }
            else if (number < minValue)
            {
                PrintError($"Daxil oluna biləcək minimum ədəd {minValue}");
                goto l1;
            }
            else if (number>maxValue)
            {
                PrintError($"Daxil edə bilən maksimum ədəd {maxValue}");
                goto l1;
            }
            return number;
        }

        public static double ReadDouble(string caption, double minvalue = 0 , double maxvalue=20)
        {
        l1:
            Console.Write(caption);
            string value = Console.ReadLine();
            double number;

            if (!double.TryParse(value, out number))
            {
                PrintError("Xais olunur duzgun deyeri daxil edin");
                goto l1;
            }
            else if (number < minvalue)
            {
                PrintError($"Daxil oluna bilecek minimum deyer: {minvalue} ");
                goto l1;
            }
            else if (number>maxvalue)
            {
                PrintError($"Daxil olunacaq maksimum dəyər:{maxvalue}");
                goto l1;
            }
            return number;
        }

        public static MenuStateEnum ReadMenu(string caption)
        {
        l1:
            Console.WriteLine(caption);

            string value = Console.ReadLine();
            bool res;
            int a;
            res = int.TryParse(value, out a);

            if (res == true)
            {
                int valueinted = int.Parse(value);

                if (valueinted <= 12)
                {
                    bool success = Enum.IsDefined(typeof(MenuStateEnum), value);

                    if (success)
                    {
                        PrintError("Belə bir menyu mövcud deyil!");
                        goto l1;
                    }
                    else if (!Enum.TryParse(value, out MenuStateEnum menu))
                    {
                        PrintError("Belə bir menyu mövcud deyil,xaiş olunur indeksə uyğun menyu daxil edin!");
                        goto l1;
                    }
                }
                else
                {
                    PrintError("Xaiş olunur düzgün rəqəm daxil edin!");
                    goto l1;
                }
            }
            else
            {
                PrintError("Zəhmət olmasa rəqəm daxil edin!");
                goto l1;
            }
            return (MenuStateEnum)Enum.Parse(typeof(MenuStateEnum), value);
        }

        public static GasTypeEnum ReadGasType(string caption)
        {
        l1:
            Console.WriteLine(caption);

            string value = Console.ReadLine();
            bool res;
            int a;
            res = int.TryParse(value, out a);

            if (res == true)
            {
                int valueinted = int.Parse(value);

                if (valueinted < 5)
                {
                    bool success = Enum.IsDefined(typeof(GasTypeEnum), value);

                    if (success)
                    {
                        PrintError("Bu yanacaq növü mövcud deyil!!!");
                        goto l1;
                    }
                    if (!Enum.TryParse(value, out GasTypeEnum gas))
                    {
                        PrintError("Yanacaq növünü   !!!");
                        goto l1;
                    }

                }
                else
                {
                    PrintError("Xaiş olunur düzgün rəqəm daxil edin!!");
                    goto l1;
                }
            }
            else
            {
                PrintError("Xaiş olunur düzgün rəqəm daxil edin!!");
                goto l1;
            }

            return (GasTypeEnum)Enum.Parse(typeof(GasTypeEnum), value);
        }

        public static GearBoxEnum ReadGearBoxType(string caption)
        {
        l1:
            Console.WriteLine(caption);

            string value = Console.ReadLine();
            bool res;
            int a;
            res = int.TryParse(value, out a);
            
            if (res == true)
            {
                int valueinted = int.Parse(value);

                if (valueinted <= 2)
                {
                    bool success = Enum.IsDefined(typeof(GearBoxEnum), value);

                    if (success)
                    {
                        PrintError("Belə sürətlər qutusu mövcud deyil!!!");
                        goto l1;
                    }
                    if (!Enum.TryParse(value, out GearBoxEnum gear))
                    {
                        PrintError("Belə sürətlərqutusu mövcud deyil,xaiş olunur düzgün rəqəm daxil edin !!!");
                        goto l1;
                    }

                }
                else
                {
                    PrintError("Düzgün rəqəm daxil edin!!");
                    goto l1;
                }
            }
            else
            {
                PrintError("Xaiş olunur düzgün rəqəm daxil edin!!");
                goto l1;
            }

            return (GearBoxEnum)Enum.Parse(typeof(GearBoxEnum), value);
        }
        public static BanModelEnum ReadBanType(string caption)
        {
        l1:
            Console.WriteLine(caption);

            string value = Console.ReadLine();
            bool res;
            int a;
            res = int.TryParse(value, out a);

            if (res == true)
            {
                int valueinted = int.Parse(value);

                if (valueinted < 7)
                {
                    bool success = Enum.IsDefined(typeof(BanModelEnum), value);

                    if (success)
                    {
                        PrintError("Belə ban növü movcud deyil!!!");
                        goto l1;
                    }
                    if (!Enum.TryParse(value, out BanModelEnum ban))
                    {
                        PrintError("Belə bir ban növü mövcud deyil,xaiş olunur düzgün rəqəm daxil edin !!!");
                        goto l1;
                    }

                }
                else
                {
                    PrintError("Düzgün rəqəm daxil edin!!");
                    goto l1;
                }
            }
            else
            {
                PrintError("Xaiş olunur düzgün rəqəm daxil edin!!");
                goto l1;
            }

            return (BanModelEnum)Enum.Parse(typeof(BanModelEnum), value);
        }



        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Init(string message)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Avtomobil Salonu";

            CultureInfo ci = new CultureInfo("az-Latn-Az");
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            ci.DateTimeFormat.LongDatePattern = "dd.MM.yyyy";
            ci.DateTimeFormat.ShortTimePattern = "HH:mm";
            ci.DateTimeFormat.LongTimePattern = "HH:mm:ss";

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
        [Obsolete]
        public static void SaveToFile<T>(string filname, T graphData)
        {
            using (var fs = new FileStream(filname, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, graphData);
            }
        }
        [Obsolete]
        public static T LoadFromFile<T>(string filname)
        {
            if (!File.Exists(filname))
            {
                return default(T);
            }
            using (var fs = new FileStream(filname, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                var graph = bf.Deserialize(fs);
                if (graph is T)
                {
                    return (T)graph;
                }
                return default(T);
            }

        }
    }
}
