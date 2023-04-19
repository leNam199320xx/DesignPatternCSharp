using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Structural
{
    internal class BridgeDesignPattern
    {
        public class Client
        {
            // Ngoại trừ giai đoạn khởi tạo, trong đó một đối tượng Abstraction được liên 
            // kết với một đối tượng Implementation cụ thể, Client chỉ nên phụ thuộc vào  
            // lớp Abstraction . Bằng cách này, Client có thể hỗ trợ bất kỳ kết hợp 
            // hiện thực - trừu tượng nào.
            public void ClientCode(Abstraction abstraction)
            {
                Console.Write(abstraction.Operation());
            }
        }
        public class Abstraction
        {
            public Bridge Implementer { get; set; }

            public Abstraction(Bridge implementation)
            {
                Implementer = implementation;
            }
            public virtual string Operation()
            {
                Console.WriteLine("ImplementationBase:Operation()");
                Implementer.OperationImplementation();

                return "implement operation finished!";
            }
        }

        public class RefinedAbstraction : Abstraction
        {
            public RefinedAbstraction(Bridge implementation) : base(implementation)
            {
            }
            public override string Operation()
            {
                Console.WriteLine("RefinedAbstraction:Operation()");
                Implementer.OperationImplementation();

                return "implement operation finished!";
            }
        }

        public interface Bridge
        {
            void OperationImplementation();
        }

        public class ImplementationA : Bridge
        {
            public void OperationImplementation()
            {
                Console.WriteLine("ImplementationA:OperationImplementation()");
            }
        }

        public class ImplementationB : Bridge
        {
            public void OperationImplementation()
            {
                Console.WriteLine("ImplementationB:OperationImplementation()");
            }
        }
    }
}
