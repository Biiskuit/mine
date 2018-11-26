

using System;
using System.IO;
using System.Collections.Generic;
using SautinSoft.Document;
using System.Text;


namespace github_versuch
{
    class Class1
    {


        /// <summary>
        /// This sample shows how to merge multiple csv files.
        /// </summary>
        /// <remarks>
        /// Details: https://sautinsoft.com/products/document/examples/merge-multiple-files-net-csharp-vb.php
        /// </remarks>
        public void MergeMultipleDocuments()
        {
            // Path to our combined document.
            string singleCSVPath = $"{DateTime.Now.ToString("MMMM")}_Report.csv";
            string workingDir = @"C:\Datein\";



            List<string> supportedFiles = new List<string>();
            // Fill the collection 'supportedFiles' by *.csv.
            foreach (string file in Directory.GetFiles(workingDir, "*.*"))
            {
                string ext = Path.GetExtension(file).ToLower();

                if (ext == ".csv")
                    supportedFiles.Add(file);
            }

            // Create single CSV.
            DocumentCore singleCSV = new DocumentCore();

            foreach (string file in supportedFiles)
            {
                DocumentCore dc = DocumentCore.Load(file);

                Console.WriteLine("Adding: {0}...", Path.GetFileName(file));

                // Create import session.
                ImportSession session = new ImportSession(dc, singleCSV, StyleImportingMode.KeepSourceFormatting);

                // Loop through all sections in the source document.
                foreach (Section sourceSection in dc.Sections)
                {



                    // Because we are copying a section from one document to another,
                    // it is required to import the Section into the destination document.
                    // This adjusts any document-specific references to styles, bookmarks, etc.
                    //
                    // Importing a element creates a copy of the original element, but the copy
                    // is ready to be inserted into the destination document.
                    Section importedSection = singleCSV.Import<Section>(sourceSection, true, session);

                    // First section start from new page.
                    if (dc.Sections.IndexOf(sourceSection) == 0)
                        importedSection.PageSetup.SectionStart = SectionStart.NewPage;

                    // Now the new section can be appended to the destination document.
                    singleCSV.Sections.Add(importedSection);
                }
            }

            // Save single CSV to a file.
            singleCSV.Save(singleCSVPath);

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(singleCSVPath) { UseShellExecute = true });
        }
    }
}


    