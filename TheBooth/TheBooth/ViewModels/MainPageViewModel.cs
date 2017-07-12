using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Services;
using TheBooth.Common;

namespace TheBooth.ViewModels
{
    public class MainPageViewModel : BaseViewModel, IMultiPageNavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnInternalNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnInternalNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
