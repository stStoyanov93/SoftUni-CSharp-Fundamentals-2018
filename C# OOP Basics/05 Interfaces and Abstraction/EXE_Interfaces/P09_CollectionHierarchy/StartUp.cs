using System;
using System.Collections.Generic;

namespace P09_CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var indexesAddCollection = new List<int>();
            var indexesAddRemove = new List<int>();
            var indexesMyList = new List<int>();

            var elementsToAdd = Console.ReadLine().Split();

            int insertAt;

            foreach (var element in elementsToAdd)
            {
                insertAt = addCollection.Add(element);
                indexesAddCollection.Add(insertAt);

                insertAt = addRemoveCollection.Add(element);
                indexesAddRemove.Add(insertAt);

                insertAt = myList.Add(element);
                indexesMyList.Add(insertAt);
            }

            var countOfElementsToRemove = int.Parse(Console.ReadLine());

            var removedFromRemoveAndAdd = new List<string>();
            var removedFromMyList = new List<string>();

            string removedItem;

            for (int i = 0; i < countOfElementsToRemove; i++)
            {
                removedItem = addRemoveCollection.Remove();
                removedFromRemoveAndAdd.Add(removedItem);

                removedItem = myList.Remove();
                removedFromMyList.Add(removedItem);
            }

            Console.WriteLine(string.Join(' ', indexesAddCollection));
            Console.WriteLine(string.Join(' ', indexesAddRemove));
            Console.WriteLine(string.Join(' ', indexesMyList));

            Console.WriteLine(string.Join(' ', removedFromRemoveAndAdd));
            Console.WriteLine(string.Join(' ', removedFromMyList));
        }
    }
}
