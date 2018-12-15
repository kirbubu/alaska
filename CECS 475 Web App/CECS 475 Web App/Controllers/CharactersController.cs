using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CECS_475_Web_App.Models;
using System.Text.RegularExpressions;

namespace CECS_475_Web_App.Controllers
{
    public class CharactersController : Controller
    {

        public IActionResult Index()
        {
            string path = Directory.GetCurrentDirectory();
            DirectoryInfo d = new DirectoryInfo(path + @"\wwwroot\images\Characters");
            FileInfo[] Files = d.GetFiles("*.webp");
            var Characters = new List<Character>();
            foreach(var file in Files)
            {
                Characters.Add(new Character() { File = file.Name, Name = Regex.Replace(file.Name, @"(^\w)|(\s\w)", m => m.Value.ToUpper()).Replace(".webp","") });
            }

            return View(Characters);
        }
    }
}