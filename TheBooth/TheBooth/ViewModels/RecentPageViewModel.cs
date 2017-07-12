using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Services;
using TheBooth.Common;
using TheBooth.Core;

namespace TheBooth.ViewModels
{
    public class RecentPageViewModel : BaseViewModel, IMultiPageNavigationAware
    {
        public RecentPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService,pageDialogService)
        {

        }

        public void OnInternalNavigatedFrom(NavigationParameters parameters)
        {
            
        }
        #region Properties
        private ObservableCollection<Booth> _boothCollection;
        public ObservableCollection<Booth> BoothCollection
        {
            get { return _boothCollection; }
            set { SetProperty(ref _boothCollection, value); }
        }
        private Booth _selectedBooth;
        public Booth SelectedBooth
        {
            get { return _selectedBooth; }
            set { SetProperty(ref _selectedBooth, value); }
        }
        #endregion
        public void OnInternalNavigatedTo(NavigationParameters parameters)
        {
            BoothCollection = new ObservableCollection<Booth> { 
                new Booth { Title = "Spring Fiesta", Location = "Wild Waters", EventId = Guid.NewGuid(), DueDate = DateTime.Now.AddMonths(2).ToString("f"), Description = "To reset your password, enter the email address you use to sign in to CollectPlus.To reset your password, enter the email address you use to sign in to CollectPlus.To reset your password, enter the email address you use to sign in to CollectPlus.To reset your password, enter the email address you use to sign in to CollectPlus."}, 
                new Booth { Title = "BushFire", Location = "Swaziland", EventId = Guid.NewGuid(), DueDate = DateTime.Now.AddMonths(3).ToString("f"),Description = "To reset your password, enter the email address you use to sign in to CollectPlus.To reset your password, enter the email address you use to sign in to CollectPlus.To reset your password, enter the email address you use to sign in to CollectPlus.To reset your password, enter the email address you use to sign in to CollectPlus." }, 
                new Booth { Title = "Live In Color", Location = "Vosloorus", EventId = Guid.NewGuid(), DueDate = DateTime.Now.AddMonths(5).ToString("f"),Description = "To reset your password, enter the email address you use to sign in to CollectPlus.To reset your password, enter the email address you use to sign in to CollectPlus.To reset your password, enter the email address you use to sign in to CollectPlus." } };
            base.OnNavigatedTo(parameters);
        }
    }
}
