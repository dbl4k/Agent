Imports Agent.Common

Module Shell

    Private m_agentTaskAssemblies As Specialized.StringCollection = My.Settings.AgentTaskAssemblies

    Sub Main()
        Dim taskAssemblies As String() = m_agentTaskAssemblies.Cast(Of String).ToArray()
        Dim params As AgentTaskRuntimeParameters = AgentTaskRuntimeParametersFactory.Create(My.Application.CommandLineArgs)

        Dim instance As IAgentTask = AgentTaskFactory.Instantiate(params, taskAssemblies)

        'Console.WriteLine(String.Format(Messages.E_FINDTASK_FOUNDTASK, instance.))

        instance.Run()
    End Sub



End Module
