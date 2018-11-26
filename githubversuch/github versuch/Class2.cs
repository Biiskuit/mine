using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace github_versuch
{

    class Class2
    {
        private string inputDirectoryPath = @"C:\Datein\";
        private string inputFileNamePattern = "*.csv";
        public string outputFilePath = @"C:\Monate\" + $"{DateTime.Now.ToString("MMMM")}_Report.csv";



        public void CombineMultipleFilesIntoSingleFile()
        {
            string[] inputFilePaths = Directory.GetFiles(inputDirectoryPath, inputFileNamePattern);
            Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);

            using (var outputStream = File.Create(outputFilePath))
            {
                foreach (var inputFilePath in inputFilePaths)
                {
                    using (var inputStream = File.OpenRead(inputFilePath))
                    {


                        List<DailyValues> values = File.ReadAllLines("C:\\Users\\Josh\\Sample.csv")
                               .Skip(1)
                               .Select(v => DailyValues.FromCsv(v))
                               .ToList();







                        // Buffer size can be passed as the second argument.
                        inputStream.CopyTo(outputStream);
                    }


                    Console.WriteLine("The file {0} has been processed.", inputFilePath);
                }
            }


        } 
    }
}
