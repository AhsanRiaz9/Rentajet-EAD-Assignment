using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace BCSF18M009_Rentajet
{
     class GeneratePDF
    {
        public static void createPDF1(string fileName, Customer c, AircraftJet aj, int regNo, string sd, string ed, string src, string dest, double totalCost)
        {
            // instantiate a new document
            Document document = new Document(PageSize.LETTER, 15, 15, 15, 15);

            // instantiate the writer that will listen to the document
            string path = "../../"+ fileName;
            PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            // open the document
            document.Open();
            string heading = "Charter Contract"+"\nbetween\nRENTAJET AG\nand\nCompany or person";
            Phrase header = new Phrase(heading, FontFactory.GetFont("verdana", 20, Font.BOLD));
            Paragraph p = new Paragraph(header);
            p.Alignment = Element.ALIGN_CENTER;
            document.Add(p);
            string mainString = c.name + " charters the aircraft " +  aj.type + " with the registration number " + regNo + " for the time\nfrom " + sd + " to " + ed + " for a journey " + src  + " to " + dest + "via c1 to cn";
            mainString = "\n" + mainString + "flight plan: Time Place (from) Flight time Time Place Numberofpassengers"+  src +"\t" + dest + "(to)\n\n\n";
            Paragraph para1 = new Paragraph(mainString);
            document.Add(para1);
            string costString = "Total price net: € " + totalCost + "\n" +
                "19% VAT: €" + totalCost * 0.19 + "\n" +
                "Total price gross: € " + totalCost + totalCost * 0.19 + "\n\n\n";

            Paragraph para2 = new Paragraph(costString);
            document.Add(para2); 
            string footer = sd + "                                                                                               " + ed + "\n" +
                            "RENTAJET                                                                                           " + c.name;
            Paragraph para3 = new Paragraph(footer);
            document.Add(para3);
            //close the document
            document.Close();
        }
        public static void createPDF2(string fileName, Customer c, AircraftJet aj, int regNo, string sd, string ed, string src, string dest, double totalCost)
        {
            // instantiate a new document
            Document document = new Document(PageSize.LETTER, 15, 15, 15, 15);

            // instantiate the writer that will listen to the document
            string path = "../../" + fileName;
            PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            // open the document
            document.Open();
            string heading = "Charter Contract" + "\nbetween\nRENTAJET AG\nand\nCompany or person";
            Phrase header = new Phrase(heading, FontFactory.GetFont("verdana", 20, Font.BOLD));
            Paragraph p = new Paragraph(header);
            p.Alignment = Element.ALIGN_CENTER;
            document.Add(p);
            string mainString = c.name + " charters the aircraft " + aj.type + " with the registration number " + regNo + " for the time\nfrom " + sd + " to " + ed +
                "\n\nTotal charter period (hours): \n\n\n"  +
                "The charter price shall be composed of a fixed price component and an airfare component.\n"+ 
                "The airfare component is based on the flight hours flown and corresponds to the\n" + 
                "engine running time.It can be seen from the display of the engine running time in the cockpit.\n\n";

            Paragraph para1 = new Paragraph(mainString);
            document.Add(para1);
            string costString = "Base price (net): € " + totalCost + "\n" +
                "19% VAT: €" + totalCost * 0.19 + "\n" +
                "Basic price (gross): €" + totalCost + totalCost * 0.19 + "\n\n\n" +
                "Airfare per hour (net): €\n" +
                 "19 % VAT: €\n" +
                 "Airfare per hour(gross): €";

            Paragraph para2 = new Paragraph(costString);
            document.Add(para2);
            string footer = sd + "                                                                                               " + ed + "\n" +
                            "RENTAJET                                                                                           " + c.name;
            Paragraph para3 = new Paragraph(footer);
            document.Add(para3);
            //close the document
            document.Close();
        }
    }
}
