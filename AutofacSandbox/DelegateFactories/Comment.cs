using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateFactories
{
    class Comment : Interfaces.IComment
    {
        private readonly string author;
        private readonly DateTime postedOn;
        private readonly string content;

        public Comment(string author, string content)
        {
            this.author = author;
            this.postedOn = DateTime.Now;
            this.content = content;
        }

        public string Author
        {
            get { return author; }
        }

        public DateTime PostedOn
        {
            get { return postedOn; }
        }

        public string Content
        {
            get { return content; }
        }

        public override string ToString()
        {
            var returnBuilder = new System.Text.StringBuilder();

            returnBuilder.AppendLine(string.Format("{0} ({1} {2})", Author, PostedOn.ToShortDateString(), PostedOn.ToShortTimeString()));
            returnBuilder.AppendLine(Content);

            return returnBuilder.ToString();
        }
    }
}
