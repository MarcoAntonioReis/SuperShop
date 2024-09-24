using Prism.Commands;
using Prism.Navigation;
using SuperShop.Prism.Models;
using SuperShop.Prism.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Prism.ItemViewModel
{
    public class ProductsItemViewModel : ProductResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectProductCommand;
        public ProductsItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        public DelegateCommand SelectProductCommand => _selectProductCommand ?? (_selectProductCommand = new DelegateCommand(SelectProductAsync));
        private async void SelectProductAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                {"product",this}
            };
            await _navigationService.NavigateAsync(nameof(ProductDetailPage), parameters);
        }
    }
}
