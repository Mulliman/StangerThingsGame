using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StrangerThings.Web
{
    [Route("api/[controller]")]
    public class TranslateController : Controller
    {
        // GET api/<controller>/5
        [HttpGet("{lang}/{value}")]
        public string Get(string value, string lang)
        {
            var translator = new GoogleTranslator.Translator(@"D:\Development\Redweb\StrangerThings\StrangerThings\StrangerThings.Web\strangerthings.json");

            return translator.TranslatePhraseToEnglish(value, lang);
        }
    }
}
