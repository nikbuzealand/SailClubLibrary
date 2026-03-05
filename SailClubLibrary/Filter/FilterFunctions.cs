using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailClubLibrary.Filter
{
    public class FilterFunctions
    {
        public List<T> GenericFilter<T>(List<T> listItems, List<Predicate<T>> listPreds)
        {
            foreach (Predicate<T> pred in listPreds)
            {
                listItems = listItems.FindAll(pred);
            }
            return listItems;
        }
    }
}
