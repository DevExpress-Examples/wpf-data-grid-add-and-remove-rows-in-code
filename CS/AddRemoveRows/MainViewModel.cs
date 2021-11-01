using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AddRemoveRows {
    public class Person {
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public int UnitPrice { get; set; }
        public bool Discontinued { get; set; }

        public Person() { }
        public Person(int i) {
            ProductName = "ProductName" + i;
            CompanyName = "CompanyName" + i;
            UnitPrice = i;
            Discontinued = i % 2 == 0;
        }
    }
    public class MainViewModel : ViewModelBase {
        public static ObservableCollection<Person> Persons { get; private set; }
        public MainViewModel() {
            Persons = new ObservableCollection<Person>(GetSource());
        }
        static IEnumerable<Person> GetSource() {
            for(int i = 0; i < 9; i++) {
                yield return new Person(i);
            }
        }
    }
}
