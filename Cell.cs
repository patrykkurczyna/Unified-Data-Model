﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class Cell<T> :AbstractCell
    {   
        // TODO - how to store data type and how to do generic types for cell content ?
        protected T _content;

        public T Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public Cell(T content)
        {
            this._content = content;
        }

        public override String ToString()
        {
            return _content.ToString();
        }
    }
}
