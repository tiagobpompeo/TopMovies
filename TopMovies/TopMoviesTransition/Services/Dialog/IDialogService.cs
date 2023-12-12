using System;
using System.Threading.Tasks;

namespace TopMoviesTransition.Services.Dialog
{
    public interface IDialogService
    {
        Task ShowDialog(string message, string title, string buttonLabel);
        void ShowToast(string message);
        Task ShowMessage(string title, string message);
        Task<bool> ShowConfirm(string title, string message);
        Task<string> ShowImageOptions();
    }
}
