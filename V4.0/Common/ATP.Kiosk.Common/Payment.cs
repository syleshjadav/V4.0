using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ATP.Kiosk.Common
{
    public class Payment
    {
        public static bool IsLUHNValid(string ccNo)
        {
            bool isValid = false;
            int indicator = 1; // will be indicator for every other number
            int firstNumToAdd = 0; // will be used to store sum of first set of numbers
            int secondNumToAdd = 0; // will be used to store second set of numbers
            string num1; // will be used if every other number added is greater than 10, store the left-most integer here
            string num2; // will be used if ever yother number added is greater than 10, store the right-most integer here

            // Convert our creditNo string to a char array
            char[] ccArr = ccNo.ToCharArray();
            double Num;
            bool isNum = double.TryParse(ccNo, out Num);

            if (isNum)
            {
                for (int i = ccArr.Length - 1; i >= 0; i--)
                {
                    char ccNoAdd = ccArr[i];
                    int ccAdd = Int32.Parse(ccNoAdd.ToString());
                    if (indicator == 1)
                    {
                        // If we are on the odd number of numbers, add that number to our total
                        firstNumToAdd += ccAdd;
                        // set our indicator to 0 so that our code will know to skip to the next piece
                        indicator = 0;
                    }
                    else
                    {
                        // if the current integer doubled is greater than 10
                        // split the sum in to two integers and add them together
                        // we then add it to our total here
                        if ((ccAdd + ccAdd) >= 10)
                        {
                            int temporary = (ccAdd + ccAdd);
                            num1 = temporary.ToString().Substring(0, 1);
                            num2 = temporary.ToString().Substring(1, 1);
                            secondNumToAdd += (Convert.ToInt32(num1) + Convert.ToInt32(num2));
                        }
                        else
                        {
                            // otherwise, just add them together and add them to our total
                            secondNumToAdd += ccAdd + ccAdd;
                        }
                        // set our indicator to 1 so for the next integer we will perform a different set of code
                        indicator = 1;
                    }
                }
                // If the sum of our 2 numbers is divisible by 10, then the card is valid. Otherwise, it is not
                if ((firstNumToAdd + secondNumToAdd) % 10 == 0)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            else
                isValid = false;

            return isValid;
        }

        public static string Right(string value, int length)
        {
            return value.Substring(value.Length - length);
        }

        public const String AMEXPattern = @"^3[47][0-9]{13}$";
        public const String MasterCardPattern = @"^5[1-5][0-9]{14}$";
        public const String VisaCardPattern = @"^4[0-9]{12}(?:[0-9]{3})?$";
        public const String DinersClubCardPattern = @"^3(?:0[0-5]|[68][0-9])[0-9]{11}$";
        public const String enRouteCardPattern = @"^(2014|2149)";
        public const String DiscoverCardPattern = @"^6(?:011|5[0-9]{2})[0-9]{12}$";
        public const String JCBCardPattern = @"^(?:2131|1800|35\d{3})\d{11}$";

        protected static NameValueCollection _patterns;

        public static NameValueCollection CardPatterns
        {
            get
            {
                if (_patterns == null)
                {
                    _patterns = new NameValueCollection();
                    _patterns.Add("AMEX", AMEXPattern);
                    _patterns.Add("MasterCard", MasterCardPattern);
                    _patterns.Add("Visa", VisaCardPattern);
                    _patterns.Add("DinersClub", DinersClubCardPattern);
                    _patterns.Add("enRoute", enRouteCardPattern);
                    _patterns.Add("Discover", DiscoverCardPattern);
                    _patterns.Add("JCB", JCBCardPattern);
                }
                return _patterns;
            }
            set
            {
                _patterns = value;
            }
        }

        public static String GetCardType(String cardNumber)
        {
            String cardType = "Unknown";

            try
            {
                String cardNum = cardNumber.Replace(" ", "").Replace("-", "");
                Regex regex;
                foreach (String cardTypeName in CardPatterns.Keys)
                {
                    regex = new Regex(CardPatterns[cardTypeName]);
                    if (regex.IsMatch(cardNum))
                    {
                        cardType = cardTypeName;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return cardType;
        }

        public static string FormatName(string o)
        {
            string result;

            if (o.Contains("/"))
            {
                string[] nameSplit = o.Split('/');

                result = nameSplit[1] + " " + nameSplit[0];
            }
            else
            {
                result = o;
            }

            return result;
        }

        public static string FormatCardNumber(string o)
        {
            var result = Regex.Replace(o, "[^0-9]", string.Empty);

            return result;
        }
    }
}