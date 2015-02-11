using System.Collections.Generic;

namespace MirthConnectFX.Model
{
    public class PropertyList : List<Property>
    {
        public string this[string key]
        {
            get
            {
                return Find(x => x.Name == key).Value;
            }
            set
            {
                var item = Find(x => x.Name == key);
                item.Value = value;
            }
        }
    }
}