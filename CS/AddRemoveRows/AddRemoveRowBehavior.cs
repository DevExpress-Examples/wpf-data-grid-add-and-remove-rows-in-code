using DevExpress.Mvvm;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace AddRemoveRows {
    public class AddRemoveRowBehavior : Behavior<TableView> {
        static readonly DependencyPropertyKey AddCommandPropertyKey;
        static readonly DependencyPropertyKey DeleteCommandPropertyKey;
        public static readonly DependencyProperty AddCommandProperty;
        public static readonly DependencyProperty DeleteCommandProperty;
        static AddRemoveRowBehavior() {
            AddCommandPropertyKey = DependencyProperty.RegisterReadOnly(nameof(AddCommand), typeof(ICommand), typeof(AddRemoveRowBehavior), new PropertyMetadata(null));
            AddCommandProperty = AddCommandPropertyKey.DependencyProperty;
            DeleteCommandPropertyKey = DependencyProperty.RegisterReadOnly(nameof(DeleteCommand), typeof(ICommand), typeof(AddRemoveRowBehavior), new PropertyMetadata(null));
            DeleteCommandProperty = DeleteCommandPropertyKey.DependencyProperty;
        }

        public ICommand AddCommand {
            get { return (ICommand)GetValue(AddCommandProperty); }
            private set { SetValue(AddCommandPropertyKey, value); }
        }
        public ICommand DeleteCommand {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            private set { SetValue(DeleteCommandPropertyKey, value); }
        }

        public AddRemoveRowBehavior() {
            AddCommand = new DelegateCommand(AddNewRow);
            DeleteCommand = new DelegateCommand(DeleteRow);
        }

        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.AddingNewRow += OnAddingNewRow;
        }
        protected override void OnDetaching() {
            AssociatedObject.AddingNewRow -= OnAddingNewRow;
            base.OnDetaching();
        }

        void AddNewRow() {
            AssociatedObject.AddNewRow();
        }
        void OnAddingNewRow(object sender, AddingNewEventArgs e) {
            e.NewObject = new Product() {
                ProductName = "New Product",
                CompanyName = "New Company",
                UnitPrice = 10,
                Discontinued = false
            };
        }
        void DeleteRow() {
            AssociatedObject.DeleteRow(AssociatedObject.FocusedRowHandle);
        }
    }
}
