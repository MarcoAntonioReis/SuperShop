using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using SuperShop.Prism.Helpers;


namespace SuperShop.Prism.ViewModels
{
    public class ModifyUserPageViewModel : ViewModelBase
    {
        public ModifyUserPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.ModifyUser;
        }
    }
}
