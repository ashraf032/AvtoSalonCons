using System;
using System.Linq;
using TurboPaz.Enums;
using TurboPaz.Models;
using TurboPazLib;
using TurboPazLib.Enums;

namespace TurboPaz
{
    [Obsolete]
    internal class Program
    {
        static void Main(string[] args)
        {
            #region
            const string modelsfileup = @"models.dat";
            const string brandsfileup = @"brands.dat";


            Helpers.Init("Avtomobil Salonu");
            var modelprop = Helpers.LoadFromFile<Model[]>(modelsfileup);
            Model[] models = null;
            if (modelprop == null)
                models = new Model[0];
            else
            {
                models = (Model[])modelprop;
                int max = models.Max(b => b.Id);
                Model.SetCounter(max);
            }
            var brandprop = Helpers.LoadFromFile<Brand[]>(brandsfileup);
            Brand[] brands = null;
            if (brandprop == null)
                brands = new Brand[0];
            else
            {
                brands = (Brand[])brandprop;
                int max = brands.Max(b => b.Id);
                Brand.SetCounter(max);
            }

            int id;
            int len;


        l1:
            PrintMenu();

            MenuStateEnum m = Helpers.ReadMenu("Xais edirik menyunu secin >");
            #endregion

            #region SwitchCase
            switch (m)
            { 
                case MenuStateEnum.ModelAll:
                    Console.Clear();
                    Console.WriteLine("Modellərin siyahısı >");
                    foreach (var model in models)
                    {
                        var brand = brands.FirstOrDefault(a => a.Id == model.BrandId);
                        Console.WriteLine(model.ToString(brand));
                    }
                    goto l1;
                case MenuStateEnum.BrandAll:
                    Console.Clear();
                    ShowAllBrands(brands);
                    goto l1;
                case MenuStateEnum.ModelById:
                    id = Helpers.ReadInt("Modelin ID-si > ", 0);
                    if (id == 0)
                    {
                        goto case MenuStateEnum.ModelAll;
                    }
                    var search = new Model(id);

                    int index = Array.IndexOf(models, search);

                    if (index != -1)
                    {
                        search = models[index];
                        Console.Clear();
                        Helpers.PrintWarning($"Tapılan nəticə > {search}");
                        goto l1;
                    }

                    Helpers.PrintError("Model tapılmadı");
                    goto case MenuStateEnum.ModelById;

                case MenuStateEnum.ModelAdd:

                    ShowAllBrands(brands);
                    int brandId;
                    string color = "";
                l2:
                    brandId = Helpers.ReadInt("Brendin İD-sini daxil et > ", minvalue: 1);
                    
                    var selectedBrand = new Brand(brandId);
                    
                    if (Array.IndexOf(brands, selectedBrand) == -1)
                    {
                        Helpers.PrintError("Xaiş olunur siyahıdankılardan seçim edin!");
                        goto l2;
                    }

                    len = models.Length;
                    Array.Resize(ref models, len + 1);
                    models[len] = new Model();
                    models[len].BrandId = brandId;
                    models[len].Name = Helpers.ReadString("Modelin adı > ", true);
                    models[len].Year = Helpers.ReadIntYear("Modelin ilini daxil edin > ",1940,2030);
                    models[len].Engine = Helpers.ReadDouble("Mühərrik həcmi > ", 0.1,20);
                    PrintGearBoxTypes();
                    GearBoxEnum c = Helpers.ReadGearBoxType("Sürətlər qutusunu seçin > ");
                    models[len].GearBox = c.ToString();
                    PrintBanTypes();
                    BanModelEnum b = Helpers.ReadBanType("Ban növünü seçin > ");
                    models[len].BanType = b.ToString();
                l10:
                    color = Helpers.ReadString("Modelin rəngi: ", true);
                    bool containsInt = color.Any(char.IsDigit);
                    if (containsInt != true)
                    {
                        models[len].Color = color;
                    }
                    else
                    {
                        Helpers.PrintError("Düzgün rəng daxil edin!");
                        goto l10;
                    }
                    PrintGasTypes();
                    GasTypeEnum g = Helpers.ReadGasType("Yanacaq növünü seçin >");
                    models[len].GasType = g.ToString();
                    models[len].Price = Helpers.ReadInt("Modelin qiyməti > ", 1000);

                    Console.Clear();
                    goto case MenuStateEnum.ModelAll;
                case MenuStateEnum.ModelEdit:
                    id = Helpers.ReadInt("Modelin İD-si > ", 0);

                    if (id == 0)
                    {
                        goto case MenuStateEnum.ModelAll;
                    }

                    var searchbyedit = new Model(id);

                    int indexbyedit = Array.IndexOf(models, searchbyedit);

                    if (indexbyedit != -1)
                    {
                        search = models[indexbyedit];
                        Console.Clear();
                        Helpers.PrintWarning($"Tapılan model > {search}");

                        string namebyedit = Helpers.ReadString(" Modelin adını daxil edin > ");

                        if (!string.IsNullOrWhiteSpace(namebyedit))
                        {
                            search.Name = namebyedit;
                        }

                        ShowAllBrands(brands);
                        int brandidforedit;
                    l3:
                        brandidforedit = Helpers.ReadInt("Modelin İD-sini daxil edin > ", minvalue: 1);

                        var selectedbrandforedit = new Brand(brandidforedit);

                        if (Array.IndexOf(brands, selectedbrandforedit) == -1)
                        {
                            Helpers.PrintError("Xaiş olunur siyahıdan seçin!");
                            goto l3;
                        }
                        search.BrandId = brandidforedit;
                        search.Year = Helpers.ReadIntYear("Modelin ilini daxil edin > ", 1940, 2030);
                        search.Engine = Helpers.ReadDouble("Mühərrikin həcmini təyin edin > ", 0.1);

                    l11:
                        string color2 = Helpers.ReadString("Modelin rəngi: ", true);
                        bool containsIntEdit = color2.Any(char.IsDigit);
                        if (containsIntEdit != true)
                        {
                            search.Color = color2;
                        }
                        else
                        {
                            Helpers.PrintError("Düzgün rəng daxil edin!");
                            goto l11;
                        }


                        search.Price = Helpers.ReadInt("Qiyməti təyin edin > ", 0);
                        PrintGearBoxTypes();
                        GearBoxEnum x = Helpers.ReadGearBoxType("Sürətlər qutusunu seçin > ");
                        search.GearBox = x.ToString();

                        PrintBanTypes();
                        BanModelEnum z = Helpers.ReadBanType("Ban növünü seçin > ");
                        search.BanType = z.ToString();

                        PrintGasTypes();
                        GasTypeEnum y = Helpers.ReadGasType("Yanacaq növünü seçin >");
                        search.GasType = y.ToString();

                        goto case MenuStateEnum.BrandAll;
                    }


                    Helpers.PrintError("Axtarılan model tapılmadı!");
                    goto case MenuStateEnum.ModelEdit;

                case MenuStateEnum.ModelRemove:
                    id = Helpers.ReadInt("Modelin İD-sini daxil edin > ", 0);

                    if (id == 0)
                    {
                        goto case MenuStateEnum.ModelAll;
                    }

                    var searchbyremove = new Model(id);

                    int indexbyremove = Array.IndexOf(models, searchbyremove);

                    if (indexbyremove == -1)
                    {
                        Helpers.PrintError("Axtarılan model tapılmadı!");
                        goto case MenuStateEnum.ModelRemove;
                    }


                    for (int i = indexbyremove; i < models.Length - 1; i++)
                    {
                        models[i] = models[i + 1];
                    }
                    Array.Resize(ref models, models.Length - 1);

                    goto case MenuStateEnum.ModelAll;

                case MenuStateEnum.BrandById:
                    id = Helpers.ReadInt("Brend İD-sini daxil edin > ", 0);

                    if (id == 0)
                    {
                        goto case MenuStateEnum.BrandAll;
                    }

                    var searchbrand = new Brand(id);

                    int indexbrand = Array.IndexOf(brands, searchbrand);

                    if (indexbrand != -1)
                    {
                        searchbrand = brands[indexbrand];
                        Console.Clear();
                        Helpers.PrintWarning($"Tapılan brend > {searchbrand}");
                        goto l1;
                    }


                    Helpers.PrintError("Brend tapılmadı!");
                    goto case MenuStateEnum.BrandById;
                case MenuStateEnum.BrandAdd:
                    string Name = Helpers.ReadString("Brend adını daxil edin> ", true);
                    for (int i = 0; i < brands.Length; i++)
                    {
                        if (brands[i].Name.ToUpper() == Name.ToUpper())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Bu brend adı mövcuddur,xaiş olunur yenidən cəhd edin");
                            Console.ResetColor();
                            goto case MenuStateEnum.BrandAdd;
                           
                        }
                    }
                    Brand brand2 = new Brand();
                    brand2.Name = Name;
                    Array.Resize(ref brands, brands.Length + 1);
                    brands[brands.Length - 1] = brand2;
                    Console.Clear();
                    goto case MenuStateEnum.BrandAll;
                case MenuStateEnum.BrandEdit:
                    id = Helpers.ReadInt("Brendin İD-sini daxil edin > ", 0);

                    if (id == 0)
                    {
                        goto case MenuStateEnum.BrandAll;
                    }

                    var searchbrandbyedit = new Brand(id);

                    int indexbrandbyedit = Array.IndexOf(brands, searchbrandbyedit);

                    if (indexbrandbyedit != -1)
                    {
                        searchbrandbyedit = brands[indexbrandbyedit];
                        Console.Clear();
                        Helpers.PrintWarning($"Tapılan > {searchbrandbyedit}");

                        string namebyedit = Helpers.ReadString("Brendin adını daxil edin > ");

                        if (!string.IsNullOrWhiteSpace(namebyedit))
                        {
                            searchbrandbyedit.Name = namebyedit;
                        }
                        goto case MenuStateEnum.BrandAll;
                    }


                    Helpers.PrintError("Axtarılan model tapılmadı!");
                    goto case MenuStateEnum.BrandEdit;
                case MenuStateEnum.BrandRemove:
                    id = Helpers.ReadInt("Brendin İD-Si > ", 0);

                    if (id == 0)
                    {
                        goto case MenuStateEnum.BrandAll;
                    }

                    var searchbradbyremove = new Brand(id);

                    int indexbrandbyremove = Array.IndexOf(brands, searchbradbyremove);

                    if (indexbrandbyremove == -1)
                    {
                        Helpers.PrintError("Axtarılan model tapılmadı!");
                        goto case MenuStateEnum.BrandRemove;
                    }

                    for (int i = indexbrandbyremove; i < brands.Length - 1; i++)
                    {
                        brands[i] = brands[i + 1];
                    }
                    Array.Resize(ref brands, brands.Length - 1);

                    goto case MenuStateEnum.BrandAll;
                case MenuStateEnum.SaveChanges:
                    Helpers.SaveToFile(modelsfileup, models);
                    Helpers.SaveToFile(brandsfileup, brands);

                    Console.Clear();
                    Console.WriteLine("Yaddaşa yazıldı!");
                    goto l1;
                case MenuStateEnum.Exit:
                    Helpers.PrintError("Çıxmaq üçün <enter> basın! ");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Environment.Exit(0);
                    }
                    Console.Clear();
                    goto l1;
                default:
                    break;
            }

            #endregion

            #region Methods
            static void PrintGearBoxTypes()
            {
                foreach (var item in Enum.GetValues(typeof(GearBoxEnum)))
                {
                    Helpers.PrintWarning($"{((byte)item).ToString().PadLeft(2)}. {item}");
                }
            }
            static void PrintMenu()
            {
                Helpers.PrintWarning("Avtomobil salonu ");
                foreach (var item in Enum.GetValues(typeof(MenuStateEnum)))
                {
                    Helpers.PrintWarning($"{((byte)item).ToString().PadLeft(2)}. {item}");
                }
            }

            static void PrintBanTypes()
            {
                foreach (var item in Enum.GetValues(typeof(BanModelEnum)))
                {
                    Helpers.PrintWarning($"{((byte)item).ToString().PadLeft(2)}. {item}");
                }
            }

            static void PrintGasTypes()
            {
                foreach (var item in Enum.GetValues(typeof(GasTypeEnum)))
                {
                    Helpers.PrintWarning($"{((byte)item).ToString().PadLeft(2)}. {item}");
                }
            }



            static void ShowAllBrands(Brand[] brands)
            {
                Console.WriteLine("*Brendlərin siyahısı >");
                foreach (var brand in brands)
                {
                    Console.WriteLine("-----------------");
                    Console.WriteLine(brand);
                    Console.WriteLine("-----------------");
                }
            }
            #endregion
        }
    }
}
