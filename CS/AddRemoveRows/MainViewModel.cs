using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AddRemoveRows {
    public class Product {
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public int UnitPrice { get; set; }
        public bool Discontinued { get; set; }

        public Product() { }
        public Product(int i) {
            ProductName = "ProductName" + i;
            CompanyName = "CompanyName" + i;
            UnitPrice = i;
            Discontinued = i % 2 == 0;
        }
    }
    public class MainViewModel : ViewModelBase {
        public ObservableCollection<Product> Products { get; private set; }
        public MainViewModel() {
            Products = new ObservableCollection<Product>(GetSource());
        }
        static IEnumerable<Product> GetSource() {
            for(int i = 0; i < 9; i++) {
                yield return new Product(i);
            }
        }
    }
}
