using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Behavioral
{
    internal class StrategyDesignPattern
    {
        public class CompressionContext
        {
            private ICompression Compression;

            public CompressionContext(ICompression Compression)
            {
                this.Compression = Compression;
            }
            public void SetStrategy(ICompression Compression)
            {
                this.Compression = Compression;
            }
            public void CreateArchive(string compressedArchiveFileName)
            {
                Compression.CompressFolder(compressedArchiveFileName);
            }
        }
        public class ZipCompression : ICompression
        {
            public void CompressFolder(string compressedArchiveFileName)
            {
                Console.WriteLine("Folder is compressed using zip approach: '" + compressedArchiveFileName
                     + ".zip' file is created");
            }
        }
        public class RarCompression : ICompression
        {
            public void CompressFolder(string compressedArchiveFileName)
            {
                Console.WriteLine("Folder is compressed using Rar approach: '" + compressedArchiveFileName
                     + ".rar' file is created");
            }
        }
        public interface ICompression
        {
            void CompressFolder(string compressedArchiveFileName);
        }
    }
}
