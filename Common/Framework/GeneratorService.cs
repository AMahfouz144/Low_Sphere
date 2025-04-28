using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Common
{
    public class GeneratorService : IGeneratorService
    {
        public string GenerateReferenceId(int length = 10, bool containsChars = true, bool containsNumbers = true)
        {
            var chars = "ABCDEFGHJKLMNOPQRSTUVWXYZ".ToCharArray(); 
            var numbers = "0123456789".ToCharArray();
            List<char> arrRes = new List<char>();

            if (containsChars && containsNumbers)
                for (int i = 0; i < length; i++)
                {
                    Random rnd = new Random(Guid.NewGuid().GetHashCode());

                    if (i % 2 == 0)
                    {
                        int charIndex = rnd.Next(chars.Length);
                        arrRes.Add(chars[charIndex]);
                    }
                    else
                    {
                        int numberIndex = rnd.Next(0, numbers.Length - 1);
                        arrRes.Add(numbers[numberIndex]);
                    }
                }

            else
            {
                var resources = containsChars ? chars : numbers;

                for (int i = 0; i < length; i++)
                {
                    Random rnd = new Random(Guid.NewGuid().GetHashCode());
                    int index = rnd.Next(chars.Length);
                    arrRes.Add(resources[index]);
                }
            }


            string res = new string(arrRes.OrderBy(obj => new Random(Guid.NewGuid().GetHashCode()).Next()).ToArray());
            return res;
        }

        public string GeneratePassword(int length = 8, bool containsCaptelChars = true, bool containsNumbers = true, bool containsSpecialChars = true)
        {
            var captelchars = "ABCDEFGHJKLMNOPQRSTUVWXYZ".ToUpper().ToCharArray();
            var chars = "ABCDEFGHJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();

            var numbers = "0123456789".ToCharArray();
            var specialChars = "@$!.".ToCharArray();

            List<char> arrRes = new List<char>();
            if (containsCaptelChars && containsNumbers && containsSpecialChars)
                for (int i = 0; i < length; i++)
                {
                    Random rnd = new Random(Guid.NewGuid().GetHashCode());

                    if (i == 0)
                    {
                        int specialIndex = rnd.Next(specialChars.Length);
                        arrRes.Add(specialChars[specialIndex]);
                    }
                    else if (i == 1)
                    {
                        int captelCharIndex = rnd.Next(captelchars.Length);
                        arrRes.Add(captelchars[captelCharIndex]);
                    }

                    else if (i % 2 == 0)
                    {
                        int charIndex = rnd.Next(chars.Length);
                        arrRes.Add(chars[charIndex]);
                    }
                    else
                    {
                        int numberIndex = rnd.Next(0, numbers.Length - 1);
                        arrRes.Add(numbers[numberIndex]);
                    }
                }

            else if (containsCaptelChars && containsNumbers)
                for (int i = 0; i < length; i++)
                {
                    Random rnd = new Random(Guid.NewGuid().GetHashCode());

                    if (i % 2 == 0)
                    {
                        int charIndex = rnd.Next(chars.Length);
                        arrRes.Add(chars[charIndex]);
                    }
                    else
                    {
                        int numberIndex = rnd.Next(0, numbers.Length - 1);
                        arrRes.Add(numbers[numberIndex]);
                    }
                }
            else
            {
                var resources = containsCaptelChars ? chars : numbers;

                for (int i = 0; i < length; i++)
                {
                    Random rnd = new Random(Guid.NewGuid().GetHashCode());
                    int index = rnd.Next(chars.Length);
                    arrRes.Add(resources[index]);
                }
            }

            string res = new string(arrRes.OrderBy(obj => new Random(Guid.NewGuid().GetHashCode()).Next()).ToArray());
            return res;
        }
    }
}