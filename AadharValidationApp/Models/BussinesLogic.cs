namespace AadharValidationApp.Models
{
    public class BussinesLogic
    {
        private string path = "E:\\Projects\\AadharValidationApp\\AadharValidationApp\\AadharValidationApp\\AadharInfo\\AadharInfoText.txt";
        public void InsertAdharnumber(string number)
        {

            
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(number + ",");
            }
        }
        public string[] ReadTxtFile()
        {
            string[] array;
            string text = File.ReadAllText(path);
            if (text == "")
            {
                array = new string[0];
            }
            else
            {
                 array = text.Split(',');
            }

            return array;
        }
        public bool ValidateAdharnumber(string aadharnumber)
        { 
            bool isValidated = false;
            string value = "";
            string [] aadharlist = ReadTxtFile();
            if (aadharlist.Length == 0)
            {
                value = "";
                
            }
            else
            {
                 value = Array.Find(aadharlist,
                          element => element.Contains(aadharnumber));
            }
            if (value == null || value == "")
            {
                InsertAdharnumber(aadharnumber);
                isValidated = true;
            }
            else {
            isValidated = false;
            }


            return isValidated;
        
        }

    }
}
