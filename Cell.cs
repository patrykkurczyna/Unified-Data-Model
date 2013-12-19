using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    [Serializable]
    public class Cell
    {   
        // TODO - how to store data type and how to do generic types for cell content ?
        protected Object _content;


        public virtual Object Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public Cell()
        {
            _content = 0;
        }

        public Cell(Object content)
        {
            this._content = content;
        }

        public override String ToString()
        {
            return _content.ToString();
        }
    }
}
