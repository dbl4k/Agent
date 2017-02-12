Public Interface IAgentTask

    Sub AssignParameters(params As AgentTaskRuntimeParameters)

    Sub Run()

    Sub Execute()

    Function GetErrorList(Optional applySort As Boolean = True) As List(Of AgentTaskError)

End Interface
