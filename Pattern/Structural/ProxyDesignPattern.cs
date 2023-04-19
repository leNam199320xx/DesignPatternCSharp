﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Structural
{
    internal class ProxyDesignPattern
    {
        public class SharedFolderProxy : ISharedFolder
        {
            private ISharedFolder folder;
            private ProxyDesignPattern.Employee employee;
            public SharedFolderProxy(ProxyDesignPattern.Employee emp)
            {
                employee = emp;
            }
            public void PerformRWOperations()
            {
                if (employee.Role.ToUpper() == "CEO" || employee.Role.ToUpper() == "MANAGER")
                {
                    folder = new SharedFolder();
                    Console.WriteLine("Shared Folder Proxy makes call to the RealFolder 'PerformRWOperations method'");
                    folder.PerformRWOperations();
                }
                else
                {
                    Console.WriteLine("Shared Folder proxy says 'You don't have permission to access this folder'");
                }
            }
        }
        public class SharedFolder : ISharedFolder
        {
            public void PerformRWOperations()
            {
                Console.WriteLine("Performing Read Write operation on the Shared Folder");
            }
        }
        public interface ISharedFolder
        {
            void PerformRWOperations();
        }
        public class Employee
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
            public Employee(string username, string password, string role)
            {
                Username = username;
                Password = password;
                Role = role;
            }
        }
    }
}
