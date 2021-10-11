using Microsoft.Win32;

namespace lab3.View
{
    class DialogService : IDialogService
    {
        public string FilePath { get; private set; }

        public bool Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Assemblies (*.dll) | *.dll"
            };
            if (openFileDialog.ShowDialog() != true) return false;
            FilePath = openFileDialog.FileName;
            return true;
        }
    }
}
