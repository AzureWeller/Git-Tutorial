using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git_Tutorial.Models
{
    public class GitEntry
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required List<GitCommand> Commands {get;set;}
    }

    public class GitCommand
    { 
        public required string Command { get; set; }
        public required string Description { get; set; }
    }
}
