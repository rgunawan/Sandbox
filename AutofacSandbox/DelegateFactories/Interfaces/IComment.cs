using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateFactories.Interfaces
{
    interface IComment
    {
        string Author { get; }
        DateTime PostedOn { get; }
        string Content { get; }
    }
}
