Public Interface IAgentTask

    Sub AssignParameters(params As AgentTaskRuntimeParameters)

    Sub Run()

    Sub Execute()

    Function GetErrorList() As List(Of AgentTaskError)

End Interface
