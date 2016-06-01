using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class PersonViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var tempHandler = PropertyChanged;
            if (tempHandler != null)
            {
                tempHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    OnPropertyChanged(nameof(Id));
                    _id = value;

                }
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value != _firstName)
                {
                    OnPropertyChanged(nameof(FirstName));
                    _firstName = value;

                }
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
                if (value != _secondName)
                {
                    OnPropertyChanged(nameof(SecondName));
                    _secondName = value;

                }
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
                if (value != _age)
                {
                    OnPropertyChanged(nameof(Age));
                    _age = value;

                }
            }
        }
        public Person ToPerson()
        {
            return new Person()
            {
                Id = _id,
                FirstName = _firstName,
                SecondName = _secondName,
                Age = _age
            };
        }

        private int _id;
        private int _age;
        private string _secondName;
        private string _firstName;


        public PersonViewModel(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            SecondName = person.SecondName;
            Age = person.Age;

        }
        public PersonViewModel()
        {
            FirstName = string.Empty;
            SecondName = string.Empty;


        }

       
    }
}