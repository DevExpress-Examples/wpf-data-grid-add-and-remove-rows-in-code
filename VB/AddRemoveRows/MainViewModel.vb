Imports DevExpress.Mvvm
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Namespace AddRemoveRows

    Public Class Product

        Public Property ProductName As String

        Public Property CompanyName As String

        Public Property UnitPrice As Integer

        Public Property Discontinued As Boolean

        Public Sub New()
        End Sub

        Public Sub New(ByVal i As Integer)
            ProductName = "ProductName" & i
            CompanyName = "CompanyName" & i
            UnitPrice = i
            Discontinued = i Mod 2 = 0
        End Sub
    End Class

    Public Class MainViewModel
        Inherits ViewModelBase

        Private _Products As ObservableCollection(Of AddRemoveRows.Product)

        Public Property Products As ObservableCollection(Of Product)
            Get
                Return _Products
            End Get

            Private Set(ByVal value As ObservableCollection(Of Product))
                _Products = value
            End Set
        End Property

        Public Sub New()
            Products = New ObservableCollection(Of Product)(GetSource())
        End Sub

        Private Shared Iterator Function GetSource() As IEnumerable(Of Product)
            For i As Integer = 0 To 9 - 1
                Yield New Product(i)
            Next
        End Function
    End Class
End Namespace
