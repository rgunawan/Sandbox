using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spring.Ioc.Test
{
    class MyArray : IArray
    {
        private ArrayList Driver = new ArrayList();

        public object this[int index]
        {
            get
            { return Driver[index]; }
            set { Driver[index] = value; }
        }

        public int Count
        {
            get { return Driver.Count; }
        }

        public int Add(object value)
        {
            return Driver.Add(value);
        }

        public void Clear()
        {
            Driver.Clear();
        }

        public void Insert(int index, object value)
        {
            Driver.Insert(index, value);
        }

        public void RemoveAt(int index)
        {
            Driver.RemoveAt(index);
        }
    }
}
