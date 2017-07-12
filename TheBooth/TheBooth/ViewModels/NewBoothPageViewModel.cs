using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Services;
using TheBooth.Common;

namespace TheBooth.ViewModels
{
    public class NewBoothPageViewModel : BaseViewModel, IMultiPageNavigationAware
    {
        public NewBoothPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
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
