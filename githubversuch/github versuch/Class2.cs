using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Mail;


// + Read all ReportX 
// + create 1 report File Report|Monthx|.csv
// + move all reportx and charging report??? to archive folder
// Send Mail to Service Request (Burgi, Ramona) with report file

    //To do!
    //+ log file eintragen + zugriff
    //send mail
    //preise zusammenrechnen letzte zeile
    // + pfade anpassen


namespace github_versuch
{
    class Class2
    {
        private string inputDirectoryPath = @"C:\Datein\";
        private string inputFileNamePattern = "*.csv";
        public string outputFilePath = @"C:\Archiv\" + $"{DateTime.Now.ToString("MMMM")}_Report.csv";
        private string outputArchiv = @"C:\Archiv\";
        private string newArchiv = @"C:\Archiv\" + $"{DateTime.Now.ToString("MMMM")}";



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
                //Error.Add("The files have been processed.");
                Console.WriteLine("The files have been processed."); //Console



                foreach (var file in new DirectoryInfo(inputDirectoryPath).GetFiles()) //Move files + create monthly folder
                {
                    Directory.CreateDirectory(outputArchiv + $"{DateTime.Now.ToString("MMMM")}");
                    file.MoveTo($@"{newArchiv}\{file.Name}");
                    //Error.Add("Files have been moved to new archiv folder.");
                    Console.WriteLine("Files have been moved to new archiv folder."); //Console
                }
            }
            catch (Exception e) //Exception
            {
                //Error.Add($"An exception occured while combining files");
                Console.WriteLine($"An exception occured while combining files: {e.Message}!");
                throw new SystemException("An exception occured while combining files.");
            }
            //log.Log(Error); // Write Log
            //Error.Clear(); // Clear Log

            /*
            
            // Send Mail to SR Austria
            sendMail.SendMailBecauseOfMonthlyReport(InformServiceRequestAT, set.GetSettings, "AT");
            log.Log(new List<string>() { "A mail has been send to AT, because of new monthly report." });
            Console.WriteLine("A mail has been send to AT, because of new monthly report.");
            
            */









        }
    }
}
