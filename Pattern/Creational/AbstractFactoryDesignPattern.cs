using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Creational
{
    internal class AbstractFactoryDesignPattern
    {
        public interface MonAnFactory
        {
            public HuTieu LayToHuTieu();
            public My LayToMy();
        }
        public interface HuTieu
        {
            string GetModelDetails();
        }
        public interface My
        {
            string GetModelDetails();
        }
        public class Client
        {
            HuTieu hutieu;
            My my;

            public Client(MonAnFactory factory)
            {
                hutieu = factory.LayToHuTieu();
                my = factory.LayToMy();
            }

            public string GetHuTieuDetails()
            {
                return hutieu.GetModelDetails();
            }

            public string GetMyDetails()
            {
                return my.GetModelDetails();
            }
        }
        public class LoaiGioFactory : MonAnFactory
        {
            public HuTieu LayToHuTieu()
            {
                return new HuTieuGio();
            }

            public My LayToMy()
            {
                return new MyGio();
            }
        }
        public class LoaiNacFactory : MonAnFactory
        {
            public HuTieu LayToHuTieu()
            {
                return new HuTieuNac();
            }

            public My LayToMy()
            {
                return new MyNac();
            }
        }
        class HuTieuNac : HuTieu
        {
            public string GetModelDetails()
            {
                return "HU TIEU NAC cua em day";
            }
        }

        class HuTieuGio : HuTieu
        {
            public string GetModelDetails()
            {
                return "HU TIEU GIO cua em day";
            }
        }

        class MyNac : My
        {
            public string GetModelDetails()
            {
                return "MY NAC cua em day";
            }
        }

        class MyGio : My
        {
            public string GetModelDetails()
            {
                return "MY GIO cua em day";
            }
        }
    }
}
