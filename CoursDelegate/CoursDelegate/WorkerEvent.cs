namespace CoursDelegate;
internal class WorkerEvent
{
    public event EventHandler? Started;
    public event EventHandler? Ended;

    public void DoWork()
    {
        Task work = Task.Run(() =>
        {
            Started?.Invoke(this, new EventArgs());
            System.Threading.Thread.Sleep(5000);
            Ended?.Invoke(this, new EventArgs());
        });
    }
}
