using Caliburn.Micro;
using JRMDesktopUI.Library.Api;
using JRMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRMDesktopUI.ViewModels
{
    public class SalesViewModel: Screen
    {
		private IProductEndpoint _productEndpoint;
		private BindingList<ProductModel> _products;
		private int _itemQuantity = 1;
		private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();
		private ProductModel _selectedProduct;


		public SalesViewModel(IProductEndpoint productEndpoint)
		{
			_productEndpoint = productEndpoint;
		}

		protected override async void OnViewLoaded(object view)
		{
			base.OnViewLoaded(view);
			await LoadProducts();
		}

		private async Task LoadProducts()
		{
			var productList = await _productEndpoint.GetAll();
			Products = new BindingList<ProductModel>(productList);
		}

		public BindingList<ProductModel> Products
		{
			get { return _products; }
			set 
			{ 
				_products = value;
				NotifyOfPropertyChange(() => Products);
			}
		}

		public ProductModel SelectedProduct
		{
			get { return _selectedProduct; }
			set
			{
				_selectedProduct = value;
				NotifyOfPropertyChange(() => SelectedProduct);
				NotifyOfPropertyChange(() => CanAddToCart);
			}
		}

		public int ItemQuantity
		{
			get { return _itemQuantity; }
			set
			{ 
				_itemQuantity = value;
				NotifyOfPropertyChange(() => ItemQuantity);
				NotifyOfPropertyChange(() => CanAddToCart);
			}
		}

		public BindingList<CartItemModel> Cart
		{
			get { return _cart; }
			set 
			{ 
				_cart = value;
				NotifyOfPropertyChange(() => Cart);
			}
		}

		public string SubTotal
		{
			get 
			{
				decimal subtotal = 0;
				foreach( var item in Cart)
				{
					subtotal += (item.Product.RetailPrice * item.QuantityInCart);
				}
				return subtotal.ToString("C");
			}
		}

		public string Tax
		{
			get
			{
				// replace with calculation
				return "$0.00";
			}
		}

		public string Total
		{
			get
			{
				// replace with calculation
				return "$0.00";
			}
		}

		public bool CanAddToCart
		{
			get
			{
				bool output = false;

				if (ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity)
				{
					output = true;
				}
				return output;

			}
		}

		public bool CanRemoveFromCart
		{
			get
			{
				bool output = false;

				//Make sure something is selected

				return output;

			}
		}

		public bool CanCheckOut
		{
			get
			{
				bool output = false;

				//Make sure something is in the cart

				return output;

			}
		}

		public void AddToCart()
		{
			CartItemModel existingItem = Cart.FirstOrDefault(x => x.Product == SelectedProduct);

			if(existingItem != null)
			{
				existingItem.QuantityInCart += ItemQuantity;

				// HACK - there must be a better way of refreshing the cart display
				Cart.Remove(existingItem);
				Cart.Add(existingItem);
			}
			else
			{
				CartItemModel item = new CartItemModel
				{
					Product = SelectedProduct,
					QuantityInCart = ItemQuantity
				};
				Cart.Add(item);
			}
			
			SelectedProduct.QuantityInStock -= ItemQuantity;
			ItemQuantity = 1;
			NotifyOfPropertyChange(() => SubTotal);
			NotifyOfPropertyChange(() => Cart);
		}

		public void RemoveFromCart()
		{

			NotifyOfPropertyChange(() => SubTotal);
		}

		public void CheckOut()
		{

		}

	}
}
