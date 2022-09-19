namespace CoursDelegate;
internal class Worker
{
    public void DoWork(Action? workStarted = null
        ,Action? workEnded = null)
    {
        Task work = Task.Run(() =>
        {
            workStarted?.Invoke();
            System.Threading.Thread.Sleep(5000);
            workEnded?.Invoke();
        });
    }
}
