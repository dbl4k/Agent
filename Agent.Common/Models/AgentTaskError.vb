Imports Agent.Common

Public Class AgentTaskError : Implements IComparable(Of AgentTaskError)

    Public Property Timestamp As Date
    Public Property Exception As Exception
    Public Property Comment As String

#Region "IComparable Implementation"

    Private Function IComparable_CompareTo(other As AgentTaskError) As Integer Implements IComparable(Of AgentTaskError).CompareTo
        Return Me.Timestamp.CompareTo(other)
    End Function

#End Region

End Class
