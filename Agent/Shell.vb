Imports Agent.Common

Module Shell

    Private m_agentTaskAssemblies As Specialized.StringCollection = My.Settings.AgentTaskAssemblies

    Sub Main()
        Dim taskAssemblies As String() = m_agentTaskAssemblies.Cast(Of String).ToArray()
        Dim params As AgentTaskRuntimeParameters = AgentTaskRuntimeParametersFactory.Create(My.Application.CommandLineArgs)
        Dim instance As IAgentTask = AgentTaskFactory.Instantiate(params, taskAssemblies)

        instance.Execute()


        Dim errorList = instance.GetErrorList
        If errorList.Count > 0 Then
            raiseExceptions(errorList)
        End If

    End Sub

    Private Sub raiseExceptions(errorList As List(Of AgentTaskError))
        If errorList.Count = 1 Then
            Throw errorList.Item(0).Exception
        Else
            Throw New AggregateException(errorList.Select(Function(n) n.Exception).AsQueryable)
        End If

    End Sub

End Module
