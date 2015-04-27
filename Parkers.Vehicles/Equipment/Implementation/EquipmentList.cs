using System.Collections.Generic;

namespace Parkers.Vehicles
{
    public class EquipmentList : List<IEquipmentItem>
    {
        public bool Contains(string item)
        {
            foreach (EquipmentItem i in this)
            {
                if (i.Name == item)
                {
                    return true;
                }
            }
            return false;
        }

        public void Remove(string item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Name == item)
                {
                    this.RemoveAt(i);
                    i--;
                }
            }
        }
    }

}
