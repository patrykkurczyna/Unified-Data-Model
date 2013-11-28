using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class Cell
    {   
        // TODO - how to store data type and how to do generic types for cell content ?
        protected string _type;
        protected string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public Cell(string content, string type)
        {
            this._content = content;
            this._type = type;
        }
    }
}
