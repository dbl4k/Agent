﻿Public Class AgentTaskFactory

    Public Shared Function Instantiate(params As AgentTaskRuntimeParameters, agentTaskAssemblies As String()) As IAgentTask
        Dim agentTaskType = findAgentTaskTypeByName(params.TaskName, agentTaskAssemblies)
        Dim instance As IAgentTask = Activator.CreateInstance(agentTaskType)

        ' TODO: push parameters into instance
        ' TODO: validate mandatory instance parameters are present.
        ' TODO: validate parameter value types.

        Return instance
    End Function

    Private Shared Function findAgentTaskTypeByName(agentTaskName As String, agentTaskAssemblies As String()) As Type
        Dim result As Type = Nothing

        Dim agentTasks = getAllAvailableAgentTasks(agentTaskAssemblies)

        Dim absoluteMatch As Type = getAgentTaskTypeByAbsoluteMatch(agentTaskName, agentTasks)

        If absoluteMatch Is Nothing Then
            Dim partialMatches As List(Of Type) = getAgentTaskTypeByPartialMatch(agentTaskName, agentTasks)

            ' If we're partial matching, we need exactly one result.
            If partialMatches Is Nothing OrElse partialMatches.Count = 0 Then
                Throw New InvalidAgentTaskNameException(String.Format(Messages.E_FINDTASK_NOMATCHES, agentTaskName))
            ElseIf partialMatches.Count > 1 Then
                Throw New InvalidAgentTaskNameException(String.Format(Messages.E_FINDTASK_TOOMANYMATCHES, agentTaskName, partialMatches.Count))
            End If

            ' We've found exactly 1 result on a partial match, use this.
            result = partialMatches.FirstOrDefault
        Else
            ' We've found exactly 1 result on an absolute match, use this.
            result = absoluteMatch
        End If

        Return result
    End Function


    Private Shared Function getAllAvailableAgentTasks(agentTaskAssemblies As String()) As List(Of Type)
        Return Utilities.GetAgentTaskList(agentTaskAssemblies)
    End Function

    Private Shared Function getAgentTaskTypeByAbsoluteMatch(fullName As String, agentTasks As List(Of Type)) As Type
        Return agentTasks.Find(Function(n) n.FullName.ToLower = fullName.ToLower)
    End Function

    Private Shared Function getAgentTaskTypeByPartialMatch(partialName As String, agentTasks As List(Of Type)) As List(Of Type)
        Return agentTasks.Where(Function(n) n.Name.ToLower = partialName.ToLower).ToList
    End Function

End Class
