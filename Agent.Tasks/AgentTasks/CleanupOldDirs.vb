Public Class CleanupOldDirs : Inherits Common.AgentTask

    Public Overrides Sub Run()
        Console.WriteLine("Cleaning up old Dirs")

        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2).TotalMilliseconds)
    End Sub

End Class
