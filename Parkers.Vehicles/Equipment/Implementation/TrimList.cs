using System.Collections.Generic;

namespace Parkers.Vehicles
{
    public class TrimList : List<ITrim>
    {
        public bool Contains(string name)
        {
            string nameLower = name.ToLower();
            foreach (ITrim t in this)
            {
                if (t.Name.ToLower() == nameLower)
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(string name)
        {
            string nameLower = name.ToLower();
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Name.ToLower() == nameLower)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
