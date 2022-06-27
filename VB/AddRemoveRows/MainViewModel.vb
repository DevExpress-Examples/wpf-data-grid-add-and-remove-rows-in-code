Imports DevExpress.Mvvm
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Namespace AddRemoveRows

    Public Class Person

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

        Private _Persons As ObservableCollection(Of AddRemoveRows.Person)

        Public Property Persons As ObservableCollection(Of Person)
            Get
                Return _Persons
            End Get

            Private Set(ByVal value As ObservableCollection(Of Person))
                _Persons = value
            End Set
        End Property

        Public Sub New()
            Persons = New ObservableCollection(Of Person)(GetSource())
        End Sub

        Private Shared Iterator Function GetSource() As IEnumerable(Of Person)
            For i As Integer = 0 To 9 - 1
                Yield New Person(i)
            Next
        End Function
    End Class
End Namespace
