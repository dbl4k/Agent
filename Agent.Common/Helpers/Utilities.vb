Imports System.Collections.Generic
Imports System.Reflection

Public Class Utilities

    Public Shared Function GetAgentTaskList(assemblyNames As Specialized.StringCollection) As List(Of Type)
        Return GetAgentTaskList(assemblyNames.Cast(Of String).ToArray())
    End Function

    Public Shared Function GetAgentTaskList(assemblyNames As String()) As List(Of Type)
        Dim result As New List(Of Type)

        For Each assemblyName In assemblyNames
            Dim assembly As Assembly = LoadAssembly(assemblyName)
            Dim agentTasks = GetAgentTaskList(assembly)

            result.AddRange(agentTasks)

            'If agentTasks.Count > 0 Then
            '    For Each agentTask In agentTasks
            '        result.Add(DirectCast(agentTask, T))
            '    Next
            'End If
        Next

        Return result
    End Function

    Public Shared Function GetAgentTaskList(assembly As Assembly) As List(Of Type)
        Return assembly.GetTypes.Where(Function(n) n.BaseType = GetType(AgentTask)).ToList()
    End Function

    Public Shared Function LoadAssembly(assemblyName As String) As Assembly
        Return Assembly.Load(assemblyName)
    End Function

End Class
