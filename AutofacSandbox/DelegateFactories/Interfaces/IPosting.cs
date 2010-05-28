using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateFactories.Interfaces
{
    interface IPosting
    {

        string Title { get; }
        string Author { get; }
        DateTime PostedOn { get; }
        string Content { get; }
        IEnumerable<IComment> Comments { get; }

        IComment AddComment(string author, string content);
    }
}
