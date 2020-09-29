Option Explicit On
Option Strict On
Option Infer Off
Public Class HouseHold
    Implements IPerson

    Private _Name As String ' Name of house hold owener
    Private _Surname As String ' Surname of household owener
    Private _Items() As Items
    Private _NumItems As Integer
    Private _HouseNumber As Integer
    Private _NumberPeople As Integer  'to get number of people per household including owner
    Private _PersonName As String ' to record name of Item owner
    Private _PersonSurname As String ' to record Surname of item owener

    'Constructor accepting three parameters and resizing Items array
    Public Sub New(Name As String, surname As String, NumItems As Integer, numPeople As Integer)
        _Name = Name
        _Surname = surname
        _NumberPeople = numPeople
        _NumItems = ValidInt(NumItems) ' Number of items cannot be less than zero
        ReDim _Items(_NumItems)

        For i As Integer = 1 To NumItems
            _Items(i) = New Items()
        Next
    End Sub

    ' Declare properties for every attribute
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property

    Public ReadOnly Property Surname As String
        Get
            Return _Surname
        End Get
    End Property

    Public Property Items(Index As Integer) As Items
        Get
            Return _Items(Index)
        End Get
        Set(value As Items)
            _Items(Index) = value
        End Set
    End Property

    Public Property HouseNumber As Integer
        Get
            Return _HouseNumber
        End Get
        Set(Value As Integer)
            _HouseNumber = Value
        End Set
    End Property
    Public ReadOnly Property NumItems As Integer
        Get
            Return _NumItems
        End Get
    End Property

    Private Property IPerson_Name As String Implements IPerson.Name
        Get
            Return _PersonName
        End Get
        Set(value As String)
            _PersonName = value
        End Set
    End Property

    Private Property IPerson_Surname As String Implements IPerson.Surname
        Get
            Return _PersonSurname
        End Get
        Set(value As String)
            _PersonSurname = value
        End Set
    End Property

    Public Property NumberPeople As Integer
        Get
            Return _NumberPeople
        End Get
        Set(value As Integer)
            _NumberPeople = value
        End Set
    End Property

    ' Function to turn nagative integer to zero
    Protected Function ValidInt(Value As Integer) As Integer
        If (Value < 0) Then
            Return 0
        Else
            Return Value
        End If
    End Function

    'Overridable function that will calculate average of recycable and waste items
    Public Function CalcAve() As Double
        Dim total As Double = 0
        total += _NumItems
        Dim ave As Double
        ave = total / _NumberPeople
        Return ave
    End Function

    'Function that will return string based on each average of recycable and non recycable items 
    Public Function CalcRating() As String
        Dim rating As String = ""
        Select Case CalcAve()
            Case Is <= 5
                rating = "Good."
            Case Is > 5
                rating = "Okay"
            Case Is >= 10
                rating = "Bad"
        End Select
        Return rating
    End Function

    Public Function Display() As String
        Return "Owner Name & Surname: " & _Name & " " & _Surname & Environment.NewLine & "Number Of People in the House: " & CStr(_NumberPeople) & "House Number: " &
            CStr(_HouseNumber) & Environment.NewLine & "Rating: " & CalcRating()
    End Function
End Class
