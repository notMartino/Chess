using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Application.Services.Implementations
{
    public class BaseService
    {
        public bool IsValid { get; set; } = true;
        public string ErrorMessage { get; set; } = string.Empty;
        public List<string> ErrorList { get; set; } = new List<string>();
    }
}
