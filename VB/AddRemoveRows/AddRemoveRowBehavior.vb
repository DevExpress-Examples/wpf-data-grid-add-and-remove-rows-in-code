Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Grid
Imports System.Windows
Imports System.Windows.Input

Namespace AddRemoveRows

    Public Class AddRemoveRowBehavior
        Inherits Behavior(Of TableView)

        Public Shared AddCommandPropertyKey As DependencyPropertyKey = DependencyProperty.RegisterReadOnly(NameOf(AddRemoveRowBehavior.AddCommand), GetType(ICommand), GetType(AddRemoveRowBehavior), New PropertyMetadata(CType(Nothing, PropertyChangedCallback)))

        Public Shared AddCommandProperty As DependencyProperty

        Public Property AddCommand As ICommand
            Get
                Return CType(GetValue(AddCommandProperty), ICommand)
            End Get

            Private Set(ByVal value As ICommand)
                SetValue(AddCommandPropertyKey, value)
            End Set
        End Property

        Public Shared DeleteCommandPropertyKey As DependencyPropertyKey = DependencyProperty.RegisterReadOnly(NameOf(AddRemoveRowBehavior.DeleteCommand), GetType(ICommand), GetType(AddRemoveRowBehavior), New PropertyMetadata(CType(Nothing, PropertyChangedCallback)))

        Public Shared DeleteCommandProperty As DependencyProperty

        Public Property DeleteCommand As ICommand
            Get
                Return CType(GetValue(DeleteCommandProperty), ICommand)
            End Get

            Private Set(ByVal value As ICommand)
                SetValue(DeleteCommandPropertyKey, value)
            End Set
        End Property

        Public Sub New()
            AddCommand = New DelegateCommand(AddressOf AddNewRow)
            DeleteCommand = New DelegateCommand(AddressOf DeleteRow)
        End Sub

        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()
            AssociatedObject.InitNewRow += AddressOf OnInitNewRow
        End Sub

        Private Sub AddNewRow()
            AssociatedObject.AddNewRow()
        End Sub

        Private Sub OnInitNewRow(ByVal sender As Object, ByVal e As InitNewRowEventArgs)
            AssociatedObject.Grid.SetCellValue(GridControl.NewItemRowHandle, AssociatedObject.Grid.Columns("ProductName"), "New Product")
            AssociatedObject.Grid.SetCellValue(GridControl.NewItemRowHandle, AssociatedObject.Grid.Columns("UnitPrice"), 10)
            AssociatedObject.Grid.SetCellValue(GridControl.NewItemRowHandle, AssociatedObject.Grid.Columns("CompanyName"), "New Company")
            AssociatedObject.Grid.SetCellValue(GridControl.NewItemRowHandle, AssociatedObject.Grid.Columns("Discontinued"), False)
        End Sub

        Private Sub DeleteRow()
            AssociatedObject.DeleteRow(AssociatedObject.FocusedRowHandle)
        End Sub
    End Class
End Namespace
