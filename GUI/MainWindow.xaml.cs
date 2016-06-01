using Domain;
using NHibernate;
using NHibernate.Linq;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException("propertyName");
            }
            var tempHandler = PropertyChanged;
            if (tempHandler != null)
            {
                tempHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<Person> Persons
        {
            get
            {
                return _persons;
            }
            set
            {
                if (value != _persons)
                {
                    OnPropertyChanged(nameof(Persons));
                    _persons = value;
                }
            }
        }
        public Person SelectedPerson
        {
            get;
            set;
        }

        public PersonViewModel PersonView
        {

            get
            {
                return _personView;
            }
            set
            {
                if (value != _personView)
                {
                    OnPropertyChanged(nameof(PersonView));
                    _personView = value;
                }
            }
        }


        private Manager<Person> _personManager;
        private List<Person> _persons;
        private PersonViewModel _personView;

        public MainWindow()
        {
            _personManager = new Manager<Person>();
            Persons = _personManager.SellectAll().ToList();
            PersonView = new PersonViewModel();
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPerson != null)
            {
                Update(SelectedPerson.Id);

                Persons.Clear();
                Persons = _personManager.SellectAll().ToList();
            }
            else
            {
                MessageBox.Show("Not Selected Row!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Update(int ID)
        {

            PersonView = new PersonViewModel(SelectedPerson);



            _personManager.Update(ID, PersonView.ToPerson());



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Persons = _personManager.SellectWhere(p => p.Id == 3).ToList();




            //   _personManager.Add(PersonView.ToPerson());
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonView.FirstName = SelectedPerson.FirstName;
            PersonView.SecondName = SelectedPerson.SecondName;
            PersonView.Age = SelectedPerson.Age;
        }
    }
}
