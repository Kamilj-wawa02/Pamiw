using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Languages
{
    public interface ITranslationsManager
    {
        string Get(string language, string key);
    }
}
