Public Class CleanupOldFiles : Inherits Common.AgentTask

    Protected Overrides Sub Run()
        Console.WriteLine("Cleaning up old files")
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2).TotalMilliseconds)
    End Sub


End Class
