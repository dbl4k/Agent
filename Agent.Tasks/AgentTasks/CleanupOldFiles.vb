Public Class CleanupOldFiles : Inherits Common.AgentTask

    Protected Overrides Sub Run()
        Console.WriteLine("Cleaning up old files")
        throwUneccessaryExceptions()
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2).TotalMilliseconds)

    End Sub

    Sub throwUneccessaryExceptions()
        RecordError(New EntryPointNotFoundException("Oh wow"), "this is a sample")
        Throw New IndexOutOfRangeException("OMG!")
    End Sub

End Class
