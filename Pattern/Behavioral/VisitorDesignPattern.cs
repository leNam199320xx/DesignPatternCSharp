using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Behavioral
{
    internal class VisitorDesignPattern
    {
        public class School
        {
            private static List<IElement> elements;
            static School()
            {
                elements = new List<IElement>
            {
                new Kid("Ram"),
                new Kid("Sara"),
                new Kid("Pam")
            };
            }
            public void PerformOperation(IVisitor visitor)
            {
                foreach (var kid in elements)
                {
                    kid.Accept(visitor);
                }
            }
        }

        public interface IElement
        {
            void Accept(IVisitor visitor);
        } 
        
        public class Salesman : IVisitor
        {
            public string Name { get; set; }
            public Salesman(string name)
            {
                Name = name;
            }
            public void Visit(IElement element)
            {
                Kid kid = (Kid)element;
                Console.WriteLine("Salesman: " + this.Name + " gave the school bag to the child: "
                                + kid.KidName);
            }
        }
        public class Doctor : IVisitor
        {
            public string Name { get; set; }
            public Doctor(string name)
            {
                Name = name;
            }

            public void Visit(IElement element)
            {
                Kid kid = (Kid)element;
                Console.WriteLine("Doctor: " + this.Name + " did the health checkup of the child: " + kid.KidName);
            }
        }
        public class Kid : IElement
        {
            public string KidName { get; set; }

            public Kid(string name)
            {
                KidName = name;
            }

            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public interface IVisitor
        {
            void Visit(IElement element);
        }
    }
}
