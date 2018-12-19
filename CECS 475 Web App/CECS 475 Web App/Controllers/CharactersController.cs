using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CECS_475_Web_App.Models;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace CECS_475_Web_App.Controllers
{
    public class CharactersController : Controller
    {
        CharacterModel characterModel = new CharacterModel();


        public IActionResult Index(string SearchString)
        {
            string path = Directory.GetCurrentDirectory();
            DirectoryInfo d = new DirectoryInfo(path + @"\wwwroot\images\Characters");
            FileInfo[] Files = d.GetFiles("*.webp");
            var chars = new List<Character>();
            foreach (var file in Files)
            {
                chars.Add(new Character() { File = file.Name, Name = Regex.Replace(file.Name, @"(^\w)|(\s\w)", m => m.Value.ToUpper()).Replace(".webp", "") });
            }

            characterModel.Characters = chars;
            var characters = from c in characterModel.Characters
                             select c;
            if (!String.IsNullOrEmpty(SearchString))
            {
                characters = chars.Where(s => s.Name.Contains(SearchString));
                characterModel.Characters = characters.Where(s => s.Name.Contains(SearchString));
            }
            
            return View(characterModel);
        }

    }
}