using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace HKTReceiptGenerator
{
    public class ReceiptWriter
    {
        //@return the file path of the saved text file
        public static String WriteToFile(String text, DateTime dateIn, String firstName)
        {
            String currentDirectory = Directory.GetCurrentDirectory();
            String receiptDir = currentDirectory + "\\Receipts\\";

            String date = dateIn.ToShortDateString();
            date = date.Replace("/", "-");
            String name = firstName.Replace(" ", "");
            String saveName = name + date;
            String fullPath = receiptDir + saveName;

            string finalizedFilePath = "";
            if (!File.Exists(fullPath + ".txt"))
            {
                using (StreamWriter outfile = new StreamWriter(fullPath + @".txt"))
                {
                    outfile.Write(text);
                }
                finalizedFilePath = fullPath + ".txt";
            }
            else
            {
                int counter = 1;
                while (File.Exists(fullPath + "(" + counter + ")" + ".txt"))
                {
                    counter++;
                }
                finalizedFilePath = fullPath + "(" + counter + ")" + ".txt";

                using (StreamWriter outfile = new StreamWriter(finalizedFilePath))
                {
                    outfile.Write(text);
                }

                saveName += "(" + counter + ")";
            }

            // too many messages
            //MessageBox.Show("Done! " + saveName + " was saved in Receipts");
            return finalizedFilePath;
        }
    }
}
