using System;
using System.Text;

namespace TestProject
{
    public class CustomString
    {

        private string customString;

        public CustomString()
        {
            this.customString = null;
        }

        public string getString()
        {
            return customString;
        }

        public void setString(string x)
        {
            this.customString = x;
        }


        public int countNumbers()
        {
            int count = 0;
            for (int i = 0; i < customString.Length; i++)
            {

                if (char.IsDigit(customString[i]))
                { //checks if char is an integer
                    count++;
                }
            }
            return count;
        }

        public String removeEveryNthCharacter(int n, bool maintainSpacing)
        {

            //checks if n is greater than string
            if (n > customString.Length)
                throw new IndexOutOfRangeException();

            //checks if n is less than 0
            if (n <= 0)
                throw new ArgumentException();

            StringBuilder sb = new StringBuilder(customString);
            int offset = 0;  //keeps track of the offset when an index is deleted
            for (int i = n - 1; i < customString.Length; i += n)
            {
                if (maintainSpacing)
                    sb[i] = ' ';
                else
                {
                    sb.Remove(i - offset, 1);
                    offset++;
                }
            }


            return sb.ToString();
        }

    }
}
