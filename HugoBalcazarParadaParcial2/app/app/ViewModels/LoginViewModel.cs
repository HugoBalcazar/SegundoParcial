namespace App.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Services;
    using Xamarin.Forms;
    using global::App.Models;
    using Views;

    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        int nota;
        bool isrunning;
        bool isenabled;
        ApiService apiService;
        #endregion

        #region Properties
        public int Nota
        {
            get
            {
                return this.nota;
            }
            set
            {
                SetValue(ref this.nota, value);
            }
        }
        public bool IsRunning
        {
            get
            {
                return this.isrunning;
            }
            set
            {
                SetValue(ref this.isrunning, value);
            }
        }
        public bool IsEnabled
        {
            get
            {
                return this.isenabled;
            }
            set
            {
                SetValue(ref this.isenabled, value);
            }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(cmdLogin);
            }
        }

        private async void cmdLogin()
        {
            IsRunning = true;
            IsEnabled = false;

            var conexion = await this.apiService.CheckConnection();

            if (!conexion.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                   "ERROR",
                   conexion.Message,
                   "Accept");
                return;
            }

            #endregion

        }
    }
}