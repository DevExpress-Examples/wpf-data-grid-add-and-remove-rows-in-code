Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Grid
Imports System.Windows
Imports System.Windows.Input

Namespace AddRemoveRows

    Public Class AddRemoveRowBehavior
        Inherits Behavior(Of TableView)

        Private Shared ReadOnly AddCommandPropertyKey As DependencyPropertyKey

        Private Shared ReadOnly DeleteCommandPropertyKey As DependencyPropertyKey

        Public Shared ReadOnly AddCommandProperty As DependencyProperty

        Public Shared ReadOnly DeleteCommandProperty As DependencyProperty

        Shared Sub New()
            AddCommandPropertyKey = DependencyProperty.RegisterReadOnly(NameOf(AddRemoveRowBehavior.AddCommand), GetType(ICommand), GetType(AddRemoveRowBehavior), New PropertyMetadata(CType(Nothing, PropertyChangedCallback)))
            AddCommandProperty = AddCommandPropertyKey.DependencyProperty
            DeleteCommandPropertyKey = DependencyProperty.RegisterReadOnly(NameOf(AddRemoveRowBehavior.DeleteCommand), GetType(ICommand), GetType(AddRemoveRowBehavior), New PropertyMetadata(CType(Nothing, PropertyChangedCallback)))
            DeleteCommandProperty = DeleteCommandPropertyKey.DependencyProperty
        End Sub

        Public Property AddCommand As ICommand
            Get
                Return CType(GetValue(AddCommandProperty), ICommand)
            End Get

            Private Set(ByVal value As ICommand)
                SetValue(AddCommandPropertyKey, value)
            End Set
        End Property

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
            AddHandler AssociatedObject.InitNewRow, AddressOf OnInitNewRow
        End Sub

        Protected Overrides Sub OnDetaching()
            RemoveHandler AssociatedObject.InitNewRow, AddressOf OnInitNewRow
            MyBase.OnDetaching()
        End Sub

        Private Sub AddNewRow()
            AssociatedObject.AddNewRow()
        End Sub

        Private Sub OnInitNewRow(ByVal sender As Object, ByVal e As InitNewRowEventArgs)
            AssociatedObject.Grid.SetCellValue(DataControlBase.NewItemRowHandle, AssociatedObject.Grid.Columns("ProductName"), "New Product")
            AssociatedObject.Grid.SetCellValue(DataControlBase.NewItemRowHandle, AssociatedObject.Grid.Columns("UnitPrice"), 10)
            AssociatedObject.Grid.SetCellValue(DataControlBase.NewItemRowHandle, AssociatedObject.Grid.Columns("CompanyName"), "New Company")
            AssociatedObject.Grid.SetCellValue(DataControlBase.NewItemRowHandle, AssociatedObject.Grid.Columns("Discontinued"), False)
        End Sub

        Private Sub DeleteRow()
            AssociatedObject.DeleteRow(AssociatedObject.FocusedRowHandle)
        End Sub
    End Class
End Namespace
