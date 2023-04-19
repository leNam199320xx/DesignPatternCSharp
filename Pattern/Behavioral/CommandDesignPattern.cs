using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Behavioral
{
    internal class CommandDesignPattern
    {
        public class MenuOptions
        {
            private ICommand openCommand;
            private ICommand saveCommand;
            private ICommand closeCommand;
            public MenuOptions(ICommand open, ICommand save, ICommand close)
            {
                this.openCommand = open;
                this.saveCommand = save;
                this.closeCommand = close;
            }
            public void clickOpen()
            {
                openCommand.Execute();
            }
            public void clickSave()
            {
                saveCommand.Execute();
            }
            public void clickClose()
            {
                closeCommand.Execute();
            }
        }
        public class OpenCommand : ICommand
        {
            private Document document;
            public OpenCommand(Document doc)
            {
                document = doc;
            }
            public void Execute()
            {
                document.Open();
            }
        }
        public class SaveCommand : ICommand
        {
            private Document document;
            public SaveCommand(Document doc)
            {
                document = doc;
            }
            public void Execute()
            {
                document.Save();
            }
        }
        public class CloseCommand : ICommand
        {
            private Document document;
            public CloseCommand(Document doc)
            {
                document = doc;
            }
            public void Execute()
            {
                document.Close();
            }
        }
        public interface ICommand
        {
            void Execute();
        }
        public class Document
        {
            public void Open()
            {
                Console.WriteLine("Document Opened");
            }
            public void Save()
            {
                Console.WriteLine("Document Saved");
            }
            public void Close()
            {
                Console.WriteLine("Document Closed");
            }
        }
    }
}
