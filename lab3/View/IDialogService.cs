namespace lab3.View
{
    public interface IDialogService
    {
        string FilePath { get; }
        bool Open();
    }
}
