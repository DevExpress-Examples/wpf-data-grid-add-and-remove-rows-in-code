Imports DevExpress.Xpf.Grid
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace HowToAddAndRemoveRowsInCode
	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
			Me.DataContext = New MyViewModel()
		End Sub
		Private Sub addNewRow(ByVal sender As Object, ByVal e As RoutedEventArgs)
			view.AddNewRow()
			Dim newRowHandle As Integer = DataControlBase.NewItemRowHandle
			grid.SetCellValue(newRowHandle, "ProductName", "New Product")
			grid.SetCellValue(newRowHandle, "UnitPrice", 10)
			grid.SetCellValue(newRowHandle, "CompanyName", "New Company")
			grid.SetCellValue(newRowHandle, "Discontinued", False)
		End Sub
		Private Sub deleteRow(ByVal sender As Object, ByVal e As RoutedEventArgs)
			view.DeleteRow(view.FocusedRowHandle)
		End Sub
	End Class

	Public Class MyViewModel
		Public Sub New()
			CreateList()
		End Sub

		Public Property PersonList() As ObservableCollection(Of Person)
		Private Sub CreateList()
			PersonList = New ObservableCollection(Of Person)()
			For i As Integer = 0 To 2
				Dim p As New Person(i)
				PersonList.Add(p)
			Next i
		End Sub
	End Class

	Public Class Person
		Public Sub New()
		End Sub
		Public Sub New(ByVal i As Integer)
			ProductName = "ProductName" & i
			CompanyName = "CompanyName" & i
			UnitPrice = i
			Discontinued = i Mod 2 = 0
		End Sub

		Public Property ProductName() As String
		Public Property CompanyName() As String
		Public Property UnitPrice() As Integer
		Public Property Discontinued() As Boolean
	End Class
End Namespace
