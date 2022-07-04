using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            var item = random.Next(0, this.Count - 1);

            this.RemoveAt(item);

            return this[item];
        }
    }
}
