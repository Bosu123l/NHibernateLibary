using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HibTest
{
    public class Person
    {
        public virtual int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string SecondName
        {
            get
            {
                return _secondName;
            }
            set
            {
                _secondName = value;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
        private int _id;
        private string _name;
        private string _secondName;
        private int _age;
    }
}