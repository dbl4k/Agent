Public Class AgentTaskRuntimeParametersFactory

    Protected Friend Class Operators
        Public Const OP_ASSIGNMENT As String = "="
    End Class

    Public Shared Function Create(Of T As IList)(rawParams As T)
        Dim result As New AgentTaskRuntimeParameters

        If rawParams Is Nothing OrElse rawParams.Count = 0 Then
            ' TODO - handle no parameters, perhaps show a dynamic help message + list of available agents.
        Else
            ' Param 0 should be agent name, fuly resolved or partial.
            result.TaskName = rawParams(0)

            ' If we have more than one param, these are the mandatory/optional params.
            If rawParams.Count > 1 Then

                For i As Integer = 1 To rawParams.Count - 1
                    Dim key As String = String.Empty
                    Dim value As String = String.Empty

                    ' Get the index of the first assignment string.
                    Dim rawParam As String = rawParams.Item(i).ToString
                    Dim assignmentIndex As Integer = rawParam.IndexOf(Operators.OP_ASSIGNMENT)

                    ' We need to work out if we have a valid keyvalue pair, or just a key (could function like a switch in future maybe?)
                    If assignmentIndex >= 1 AndAlso assignmentIndex < rawParam.Count - 1 Then
                        key = rawParam.Substring(0, assignmentIndex)
                        value = rawParam.Substring(assignmentIndex + 1)
                    Else
                        ' No equality operator
                        key = rawParam
                    End If

                    result.Parameters.Add(key, value)
                Next
            End If

        End If

        Return result
    End Function

End Class
