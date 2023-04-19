
using System.Collections.Generic;

namespace DesignPattern.Pattern.Behavioral
{
    internal class IteratorDesignPattern
    {
        public class Iterator : IteratorDesignPattern.AbstractIterator
        {
            private ConcreteCollection collection;
            private int current = 0;
            private int step = 1;

            public Iterator(ConcreteCollection collection)
            {
                this.collection = collection;
            }
            public Elempoyee First()
            {
                current = 0;
                return collection.GetEmployee(current);
            }

            public Elempoyee Next()
            {
                current += step;
                if (!IsCompleted)
                {
                    return collection.GetEmployee(current);
                }
                else
                {
                    return null;
                }
            }
            public bool IsCompleted
            {
                get { return current >= collection.Count; }
            }
        }
        public class ConcreteCollection : AbstractCollection
        {
            private List<Elempoyee> listEmployees = new List<Elempoyee>();
            //Create Iterator
            public IteratorDesignPattern.Iterator CreateIterator()
            {
                return new IteratorDesignPattern.Iterator(this);
            }
            // Gets item count
            public int Count
            {
                get { return listEmployees.Count; }
            }
            //Add items to the collection
            public void AddEmployee(Elempoyee employee)
            {
                listEmployees.Add(employee);
            }
            //Get item from collection
            public Elempoyee GetEmployee(int IndexPosition)
            {
                return listEmployees[IndexPosition];
            }
        }
        public interface AbstractCollection
        {
            public Iterator CreateIterator();
        }

        public interface AbstractIterator
        {
            IteratorDesignPattern.Elempoyee First();
            IteratorDesignPattern.Elempoyee Next();
            bool IsCompleted { get; }
        }
        public class Elempoyee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public Elempoyee(string name, int id)
            {
                Name = name;
                ID = id;
            }
        }
    }
}
