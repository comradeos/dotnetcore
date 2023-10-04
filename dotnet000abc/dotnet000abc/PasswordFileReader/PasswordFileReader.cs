using System; // невикористана бібла
using System.Collections.Generic; // невикористана бібла
using System.Linq; // невикористана бібла
using System.Text; // невикористана бібла
using System.Text.RegularExpressions;
using System.Threading.Tasks; // невикористана бібла

namespace Task // таск зазвичай це системний бекграундний процесс, я би так не називав неймспейс
{
    class PasswordFileReader // почитай про internal class, це шпаргалка https://i.stack.imgur.com/ExkwO.png
    {
        private string filePath; // readonly? :) і неймінг конвеншн теж глянь для подібних змінних - private instance fields

        public PasswordFileReader(string filePath)
        {
            this.filePath = filePath;
        }

        public int CountValidPasswords()
        {
            int validPasswordCount = 0;
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (IsValidPassword(line))
                            validPasswordCount++; // тут все норм, але чи знаєш ти різницю між "++myVar" і "myVar++" якшо нє - глянь
                    }
                }
                return validPasswordCount;
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
                return -1;
            }
        }

        static bool IsValidPassword(string line)
        {
            string[] parts = line.Split(':');
            if (parts.Length != 2)
                return false; 

            string requirement = parts[0].Trim();
            string password = parts[1].Trim();

            Match match = Regex.Match(requirement, @"(\w) (\d+)-(\d+)");
            if (!match.Success)
                return false; 

            char requiredChar = match.Groups[1].Value[0];
            int minCount = int.Parse(match.Groups[2].Value); // почитай різницю між int.Parse() і Convert.ToInt32(), теж корисно буде
            int maxCount = int.Parse(match.Groups[3].Value);

            int charCount = password.Split(requiredChar).Length - 1;

            return charCount >= minCount && charCount <= maxCount;
        }
    }
}