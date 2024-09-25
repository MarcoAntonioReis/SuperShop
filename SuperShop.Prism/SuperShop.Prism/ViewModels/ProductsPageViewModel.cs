using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SuperShop.Prism.Helpers;
using SuperShop.Prism.ItemViewModel;
using SuperShop.Prism.Models;
using SuperShop.Prism.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace SuperShop.Prism.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<ProductsItemViewModel> _products;
        private bool _isRunning;
        private string _search;
        private List<ProductResponse> _myProducts;
        private DelegateCommand _searchCommand;

        public ProductsPageViewModel(
            INavigationService navigationService,
            IApiService apiService
            ) : base(navigationService)
        {
            Title = Languages.Products;
            _navigationService = navigationService;
            _apiService = apiService;
            LoadProductsAsync();
        }


        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(ShowProducts));

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                ShowProducts();
            }
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public ObservableCollection<ProductsItemViewModel> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        private async void LoadProductsAsync()
        {

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                //necessary to because it need to transfer to the main tread 
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert(
                        Languages.Error,
                        Languages.ConnectionError,
                        Languages.Accept);
                });
                return;
            }
            IsRunning = true;

            string url = App.Current.Resources["UrlApi"].ToString();



            Response response = await _apiService.GetListAsync<ProductResponse>(url, "/Api", "/products");

            IsRunning = false;


            if (response == null)
            {
                await App.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                return;
            }
            _myProducts = (List<ProductResponse>)response.Result;
            ShowProducts();
        }
        private void ShowProducts()
        {
            if (string.IsNullOrEmpty(Search))
            {
                Products = new ObservableCollection<ProductsItemViewModel>(_myProducts.Select(p =>
                    new ProductsItemViewModel(_navigationService)
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl,
                        ImageFullPath = p.ImageFullPath,
                        LastPurchase = p.LastPurchase,
                        LastSale = p.LastSale,
                        IsAvailable = p.IsAvailable,
                        Stock = p.Stock,
                        User = p.User
                    }));
            }
            else
            {
                Products = new ObservableCollection<ProductsItemViewModel>(
                    _myProducts.Select(p =>
                    new ProductsItemViewModel(_navigationService)
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl,
                        ImageFullPath = p.ImageFullPath,
                        LastPurchase = p.LastPurchase,
                        LastSale = p.LastSale,
                        IsAvailable = p.IsAvailable,
                        Stock = p.Stock,
                        User = p.User
                    })
                    .Where(p => p.Name.ToLower().Contains(Search.ToLower()))
                    .ToList());
            }
        }

    }
}
