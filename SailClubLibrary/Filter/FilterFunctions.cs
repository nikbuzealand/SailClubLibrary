using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailClubLibrary.Filter
{
    public class FilterFunctions<T>
    {
        //public List<T> GenericFilter<T>(List<T> listItems, List<Predicate<T>> listPreds)
        //{
        //    foreach (Predicate<T> pred in listPreds)
        //    {
        //        listItems = listItems.FindAll(pred);
        //    }
        //    return listItems;
        //}

        public static List<T> Filter(List<T> listVals, List<Predicate<T>> listPreds)
        {
            List<T> returnList = new List<T>();
            foreach(T item in listVals)
            {
                int count = 0;
                foreach(Predicate<T> pred in listPreds)
                {
                    if(pred(item))
                    {
                        count++;
                    }
                }
                if(count == listPreds.Count)
                {
                    returnList.Add(item);
                }
            }
            return returnList;
        }
    }
}
