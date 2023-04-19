using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Behavioral
{
    internal class MementoDesignPattern
    {
        public class LEDTV
        {
            public string Size { get; set; }
            public string Price { get; set; }
            public bool USBSupport { get; set; }
            public LEDTV(string Size, string Price, bool USBSupport)
            {
                this.Size = Size;
                this.Price = Price;
                this.USBSupport = USBSupport;
            }
            public string GetDetails()
            {
                return "LEDTV [Size=" + Size + ", Price=" + Price + ", USBSupport=" + USBSupport + "]";
            }
        }
        public class Originator
        {
            public LEDTV ledTV;

            public Memento CreateMemento()
            {
                return new Memento(ledTV);
            }
            public void SetMemento(Memento memento)
            {
                ledTV = memento.ledTV;
            }
            public string GetDetails()
            {
                return "Originator [ledTV=" + ledTV.GetDetails() + "]";
            }
        }

        public class Caretaker
        {
            private List<Memento> ledTvList = new List<Memento>();
            public void AddMemento(Memento m)
            {
                ledTvList.Add(m);
                Console.WriteLine("LED TV's snapshots Maintained by CareTaker :" + m.GetDetails());
            }
            public Memento GetMemento(int index)
            {
                return ledTvList[index];
            }
        }

        public class Memento
        {
            public LEDTV ledTV { get; set; }
            public Memento(LEDTV ledTV)
            {
                this.ledTV = ledTV;
            }
            public string GetDetails()
            {
                return "Memento [ledTV=" + ledTV.GetDetails() + "]";
            }
        }
    }
}
