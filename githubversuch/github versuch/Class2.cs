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
            try
            {

                string[] inputFilePaths = Directory.GetFiles(inputDirectoryPath, inputFileNamePattern);
                Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);

                var allCsv = Directory.EnumerateFiles(inputDirectoryPath, inputFileNamePattern, SearchOption.TopDirectoryOnly);
                string[] header = { File.ReadLines(allCsv.First()).First(l => !string.IsNullOrWhiteSpace(l)) };
                var mergedData = allCsv
                    .SelectMany(csv => File.ReadLines(csv)
                        .SkipWhile(l => string.IsNullOrWhiteSpace(l)).Skip(1)); // skip header of each file
                File.WriteAllLines(outputFilePath, header.Concat(mergedData));

                //Console.WriteLine("The file {0} has been processed.", inputFilePaths);
            }
            catch(Exception e)
            {
                Console.WriteLine($"An exception occured: {e.Message}!");
            }

        /*


            string[] inputFilePaths = Directory.GetFiles(inputDirectoryPath, inputFileNamePattern);
            Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);


            using (var outputStream = File.Create(outputFilePath))
            {
                foreach (string inputFilePath in inputFilePaths) //every file
                {

                    // File.AppendAllText(outputFilePath, File.ReadAllText(inputFilePath));
                    using (FileStream inputStream = File.OpenRead(inputFilePath)) //openRead
                    {



                        //File.AppendAllText(outputFilePath, File.ReadAllText(inputStream));

                        // Buffer size can be passed as the second argument.
                        firstlistA.CopyTo(outputStream);
                    }



                    Console.WriteLine("The file {0} has been processed.", inputFilePath);
                }
            }

            */






        /*


    using (var outputStream = File.Create(outputFilePath))
    {


        foreach (var inputFilePath in inputFilePaths) //every file
        {

           // File.AppendAllText(outputFilePath, File.ReadAllText(inputFilePath));


            using (var inputStream = File.OpenRead(inputFilePath)) //openRead
            {







                //File.AppendAllText(outputFilePath, File.ReadAllText(inputStream));


                // Buffer size can be passed as the second argument.
                inputStream.CopyTo(outputStream);
            }



            Console.WriteLine("The file {0} has been processed.", inputFilePath);
                }
        
            }
            */
    


        }
    }
}
