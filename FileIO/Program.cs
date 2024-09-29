using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace FileIO
{
    internal class Program
    {


        static void Main(string[] args)
        {
            bool exitProgram = false;

            while (!exitProgram)
            {

               


                string xmlFilePath = @"C:\Users\Harshvardhan Gupta\Downloads\sample1.xml";
                string htmlFilePath = @"C:\Users\Harshvardhan Gupta\Downloads\sample2.html";
                string textFilePath = @"C:\Users\Harshvardhan Gupta\Downloads\sample1.txt";


                Console.WriteLine("Select Case Study:");
                Console.WriteLine("1: Read from XML File");
                Console.WriteLine("2: Read from Html File");
                Console.WriteLine("3: Read from txt File");
                Console.WriteLine("4: Write to txt File");
                Console.WriteLine("5: write to xml File");
                Console.WriteLine("6: Write to html File");
                Console.WriteLine("7: Exit");

                Console.WriteLine("Enter operation: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Reading the XML file.");
                        XmlFile.ReadFromXmlFile(xmlFilePath);
                        break;

                    case 2:
                        Console.WriteLine("Reading the Html File");
                        HtmlFile.ReadFromHtmlFile(htmlFilePath);
                        break;

                    case 3:
                        Console.WriteLine("reading the txt file");
                        TextFile.ReadFromTextFile(textFilePath);
                        break;

                    case 4:
                        Console.WriteLine("writing on xml file.");
                        XmlFile.WriteToXmlFile(xmlFilePath);
                        break;

                    case 5:
                        Console.WriteLine("writing on html file.");
                        HtmlFile.WriteToHtmlFile(htmlFilePath);
                        break;

                    case 6:
                        Console.WriteLine("writing on txt file.");
                        TextFile.WriteToTextFile(textFilePath);
                        break;

                    case 7:
                        Console.WriteLine();
                        exitProgram = true;
                        break;

                    default:
                        Console.WriteLine("Invalid.");
                        break;
                }
            }
            
        }

       
    }
    public class XmlFile
    {
        public static void ReadFromXmlFile(string filePath)
        {
            try
            {
                XElement xml = XElement.Load(filePath);
                Console.WriteLine("Contents of the XML File:\n" + xml);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading XML file: {ex.Message}");
            }
        }

        public static void WriteToXmlFile(string filePath)
        {
            try
            {
                XElement xmlContent = XElement.Load(filePath);
                
                xmlContent.Add(new XElement("entry", $"entry1 at {DateTime.Now}"));
                xmlContent.Add(new XElement("entry", $"entry2 at {DateTime.Now}"));
                xmlContent.Save(filePath);
                Console.WriteLine($"Successfully wrote to XML file: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to XML file: {ex.Message}");
            }
        }
    }

    public class HtmlFile
    {
        public static void ReadFromHtmlFile(string filePath)
        {
            try
            {
                string htmlContent = File.ReadAllText(filePath);
                Console.WriteLine("Contents of the HTML File:\n" + htmlContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading HTML file: {ex.Message}");
            }
        }

        public static void WriteToHtmlFile(string filePath)
        {
            try
            {
                string htmlContent = File.Exists(filePath) ? File.ReadAllText(filePath) : "<html><body></body></html>";
                int bodyTagPos = htmlContent.IndexOf("</body>");

                if (bodyTagPos > -1)
                {
                    htmlContent = htmlContent.Insert(bodyTagPos, $"<p>New entry at {DateTime.Now}</p>");
                }

                File.WriteAllText(filePath, htmlContent);
                Console.WriteLine($"Successfully wrote to HTML file: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to HTML file: {ex.Message}");
            }
        }
    }
    public class TextFile
    {
        public static void ReadFromTextFile(string filePath)
        {
            try
            {
                string textContent = File.ReadAllText(filePath);
                Console.WriteLine("Contents of the Text File:\n" + textContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading Text file: {ex.Message}");
            }
        }

        public static void WriteToTextFile(string filePath)
        {
            try
            {
                string textContent = $"New entry at {DateTime.Now}\n";


                File.AppendAllText(filePath, textContent);
                Console.WriteLine($"Successfully wrote to Text file: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to Text file: {ex.Message}");
            }
        }
    }
}
