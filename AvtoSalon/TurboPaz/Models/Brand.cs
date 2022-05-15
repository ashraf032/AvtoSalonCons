using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboPaz.Models
{
    [Serializable]
    public class Brand : IEquatable<Brand>
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        static int counter = 0;

        public Brand()
        {
            counter++;
            Id = counter;

        }
        public Brand(int id)
        {
            this.Id = id;
        }
        public static void SetCounter(int counter)
        {
            Brand.counter = counter;
            counter++;

        }
        public bool Equals(Brand oth)
        {
            return Id == oth.Id;
        }

        public override string ToString()
        {
            return $"*ID nömrəsi = {Id}\n*Brendin adı={Name}";
        }

    }
}
