
using System;
using System.IO;


namespace github_versuch
{
    class Program
    {

        /*


        private static void CombineMultipleFilesIntoSingleFile(string inputDirectoryPath, string inputFileNamePattern, string outputFilePath)
        {
            inputDirectoryPath = @"C:\Users\e_ssca\Documents\GitHub\mine\githubversuch\Datein";
            outputFilePath = @"C:\Users\e_ssca\Documents\GitHub\mine\githubversuch";

            string[] inputFilePaths = Directory.GetFiles(inputDirectoryPath, inputFileNamePattern);
            Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);
            using (var outputStream = File.Create(outputFilePath))
            {
                foreach (var inputFilePath in inputFilePaths)
                {
                    using (var inputStream = File.OpenRead(inputFilePath))
                    {
                        // Buffer size can be passed as the second argument.
                         for (int i = 0; i < inputStream.PageCount; i++)
                        {
                            inputFilePath.AddPage(inputStream.Pages[i]); 


                            inputStream.CopyTo(outputStream);
                        
                    }
                    Console.WriteLine("The file {0} has been processed.", inputFilePath);
                }
            }
        }

        
        public static void MergePDFs(string targetPath, params string[] pdfs)
        {
            targetPath = @"C:\Users\e_ssca\Documents\GitHub\mine\githubversuch";

            using (var targetDoc = new Stream())
            
                foreach (string pdf in pdfs)
                {
                    using (var pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                    {
                        for (int i = 0; i < pdfDoc.PageCount; i++)
                        {
                            targetDoc.AddPage(pdfDoc.Pages[i]);
                        }
                    }
                }
                targetDoc.Save(targetPath);
            }
        }
        */

        static void Main(string[] args)
        {
            // Class1 Test = new Class1();
            //Test.MergeMultipleDocuments();

            Class2 Test = new Class2();
            Test.CombineMultipleFilesIntoSingleFile();

            Console.ReadLine();
        }

    } 
} 

    