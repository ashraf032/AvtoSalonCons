using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TurboPaz.Models
{
    [Serializable]
    public class Model : IEquatable<Model>
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int BrandId { get; set; }

        public int  Year { get; set; }
        public double Price { get; set; }
        public string GasType { get; set; }
        public double Engine { get; set; }
        public string Color { get; set; }
        public string BanType { get; set; }
        public Brand Brand { get; set; }
        public string  GearBox { get; set; }
        static int counter = 0;

        public Model()
        {
            counter++;
            Id = counter;
        }
        public Model(int id)
        {
            this.Id = id;
        }
        public Model(Brand brand)
        {
            this.Brand = brand;
        }

        public static void SetCounter(int counter)
        {
            Model.counter = counter;

        }
        public bool Equals(Model oth)
        {
            return Id == oth.Id;
        }


        public override string ToString()
        {
            return $"*ID Nomresi: {Id}\n*Model Adi = {Name.ToUpper()}\n*Modelin ili {Year}\n*Model Yanacaq novu = {GasType.ToUpper()}\n*Model Ban Seriasi = {BanType.ToUpper()}\n*Modelin Sürətlər qutusu = {GearBox}\n*Qiyməti = {Price}{Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol}\n*Mator həcmi = {Engine}\n*Rəngi = {Color.ToUpper()}\n ";
        }
        public string ToString(Brand brand)
        {

            string data = (brand == null) ? null : $"{brand.Name.ToUpper()}";
            return $"*ID Nomresi: {Id}\n*Brendin adı {data}\n*Model Adi = {Name.ToUpper()}\n*Modelin ili {Year}\n*Model Yanacaq novu = {GasType.ToUpper()}\n*Model Ban Seriasi = {BanType.ToUpper()}\n*Modelin Sürətlər qutusu = {GearBox}\n*Qiyməti = {Price}{Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol}\n*Mator həcmi = {Engine}\n*Rəngi = {Color.ToUpper()}\n ";
        }
    }
}
