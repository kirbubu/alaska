using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace CECS_475_Web_App.Models
{
    public class Post
{
    public long Id { get; set; }
    private string _key;
        public string key
        {
            get
            {
                if (_key == null)
                {
                    _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;

            }

            set { _key = value; }

        }

        [Display(Name = "Forum Title")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 100 characters long")]
        public string Title { get; set; }

        public string User { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(5, ErrorMessage ="Forum posts must be at least 5 characters long")]
        public string Body { get; set; }

        public DateTime Posted { get; set; }
    }

}
