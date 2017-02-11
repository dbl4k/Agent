﻿Imports Agent.Common

Public MustInherit Class AgentTask : Implements IAgentTask

    Private Property m_errorList As New List(Of AgentTaskError)

    Public MustOverride Sub Run() Implements IAgentTask.Run

#Region "Error Recording / Retrieval"

    Protected Sub RecordError(exception As Exception)
        RecordError(exception, String.Empty)
    End Sub

    Protected Sub RecordError(exception As Exception, comment As String)
        RecordError(exception, comment, DateTime.Now)
    End Sub

    Protected Sub RecordError(exception As Exception, comment As String, timestamp As Date)
        m_errorList.Add(New AgentTaskError With {
                          .Exception = exception,
                          .Comment = comment,
                          .Timestamp = timestamp
                      })
    End Sub

    Public Function GetErrorList()
        m_errorList.Sort()
        Return m_errorList
    End Function

#End Region

End Class
