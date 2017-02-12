Imports Agent.Common

Public Class CleanupOldDirs : Inherits Common.AgentTask

    <TaskParameter(Requirement.Mandatory, "C:\boom")>
    Public Property DirRoot As String

    <TaskParameter(Requirement.Optional, False)>
    Public Property Recursive As String

    Protected Overrides Sub Run()
        Console.WriteLine("Cleaning up old Dirs")

        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2).TotalMilliseconds)
    End Sub

End Class
