using DevExpress.Mvvm;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AddRemoveRows {
    public class AddRemoveRowBehavior : Behavior<TableView> {
        public static DependencyPropertyKey AddCommandPropertyKey = DependencyProperty.RegisterReadOnly(nameof(AddCommand), typeof(ICommand), typeof(AddRemoveRowBehavior), new PropertyMetadata(null));
        public static DependencyProperty AddCommandProperty;
        public ICommand AddCommand {
            get { return (ICommand)GetValue(AddCommandProperty); }
            private set { SetValue(AddCommandPropertyKey, value); }
        }

        public static DependencyPropertyKey DeleteCommandPropertyKey = DependencyProperty.RegisterReadOnly(nameof(DeleteCommand), typeof(ICommand), typeof(AddRemoveRowBehavior), new PropertyMetadata(null));
        public static DependencyProperty DeleteCommandProperty;
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
            AssociatedObject.InitNewRow += OnInitNewRow;
        }

        void AddNewRow() {
            AssociatedObject.AddNewRow();
        }
        void OnInitNewRow(object sender, InitNewRowEventArgs e) {
            AssociatedObject.Grid.SetCellValue(GridControl.NewItemRowHandle, AssociatedObject.Grid.Columns["ProductName"], "New Product");
            AssociatedObject.Grid.SetCellValue(GridControl.NewItemRowHandle, AssociatedObject.Grid.Columns["UnitPrice"], 10);
            AssociatedObject.Grid.SetCellValue(GridControl.NewItemRowHandle, AssociatedObject.Grid.Columns["CompanyName"], "New Company");
            AssociatedObject.Grid.SetCellValue(GridControl.NewItemRowHandle, AssociatedObject.Grid.Columns["Discontinued"], false);
        }
        void DeleteRow() {
            AssociatedObject.DeleteRow(AssociatedObject.FocusedRowHandle);
        }
    }
}
