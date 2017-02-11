Imports Agent.Common

Module Module1

    Private m_agentTaskAssemblies As Specialized.StringCollection = My.Settings.AgentTaskAssemblies

    Sub Main()
        ' TODO Read commandline params in to determine agent name.
        Dim agentTaskType = findAgentTaskTypeByName("Agent.Tasks.CleanupOldDirs44")
        Console.WriteLine(String.Format(Messages.E_FINDTASK_FOUNDTASK, agentTaskType.FullName))
        Dim agentTask As IAgentTask = Activator.CreateInstance(agentTaskType)
        agentTask.Run()
    End Sub

    Private Function findAgentTaskTypeByName(agentTaskName As String) As Type
        Dim result As Type = Nothing

        Dim agentTasks = getAllAvailableAgentTasks()

        Dim absoluteMatch As Type = agentTasks.Find(Function(n) n.FullName.ToLower = agentTaskName.ToLower)

        If absoluteMatch Is Nothing Then
            Dim partialMatches As List(Of Type) = agentTasks.Where(Function(n) n.Name.ToLower = agentTaskName.ToLower).ToList

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


    Private Function getAllAvailableAgentTasks() As List(Of Type)
        Return Utilities.GetAgentTaskList(m_agentTaskAssemblies)
    End Function

End Module
