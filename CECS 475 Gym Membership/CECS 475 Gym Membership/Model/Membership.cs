using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading.Tasks;

namespace CECS_475_Gym_Membership.Model
{
    public class Membership
    {
       private readonly static string[] e= {"aol.com", "att.net", "comcast.net", "facebook.com", "gmail.com", "gmx.com", "googlemail.com",
  "google.com", "hotmail.com", "hotmail.co.uk", "mac.com", "me.com", "mail.com", "msn.com",
  "live.com", "sbcglobal.net", "verizon.net", "yahoo.com", "yahoo.co.uk" };
        private readonly static List<String> emailendings = new List<string>(e);
        private string _fname { get; set; }
        private string _lname { get; set; }
        private string _email { get; set; }

        public Membership(string firstname, string lastname, string email)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }

        public string FirstName
        {
            get
            {
                return _fname;
            }
            set
            {
                _fname = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lname;
            }
            set
            {
                _lname = value;
            }
        }

       public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value == null || !value.Contains('@'))
                    throw new EmailInvalidException();
                List<string> words = new List<string>(value.Split('@'));
                bool IsEmailPartsValid = (words.Count == 2);
                bool IsEndingValid = (emailendings.FindIndex(em => string.Equals(words[1], em)) > -1);
                if (IsEmailPartsValid && IsEndingValid)
                {
                    _email = value;
                }
                else
                {
                    throw new EmailInvalidException();
                }
            }
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " : " + Email;
        }

        



    }
}
