using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CECS_475_Web_App.Models
{

    public class CharacterModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
        
        public IEnumerable<Character> Characters { get; set; }

        public async Task OnGetAsync()
        {
            var chars = from c in Characters
                        select c;
            if (!String.IsNullOrEmpty(SearchString))
            { 
                chars = chars.Where(s => s.Name.Contains(SearchString));
            }
            Characters = await EntityFrameworkQueryableExtensions.ToListAsync<Character>(((IQueryable<Character>)chars.Where(s => s.Name.Contains(SearchString))));

        }

    }
}
