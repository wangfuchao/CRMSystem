using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRMSystemApp.Business.InfoClass
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HouseCell : ViewCell
	{
		public HouseCell ()
		{
			InitializeComponent ();
		}
        #region "Name BindableProperty"
        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(
                "Name",
                typeof(string),
                typeof(HouseCell),
                null);
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        #endregion
        #region "Phone BindableProperty"
        public static readonly BindableProperty PhoneProperty =
            BindableProperty.Create(
                "Phone",
                typeof(string),
                typeof(HouseCell),
                null);
        public string Phone
        {
            get { return (string)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }
        #endregion
        #region "HouseType BindableProperty"
        public static readonly BindableProperty HouseTypeProperty =
            BindableProperty.Create(
                "HouseType",
                typeof(string),
                typeof(HouseCell),
                null);
        public string HouseType
        {
            get { return (string)GetValue(HouseTypeProperty); }
            set { SetValue(HouseTypeProperty, value); }
        }
        #endregion

        #region "Photo BindableProperty"
        public static readonly BindableProperty PhotoProperty =
            BindableProperty.Create(
                "Photo",
                typeof(ImageSource),
                typeof(HouseCell),
                null);
        public ImageSource Photo
        {
            get { return (ImageSource)GetValue(PhotoProperty); }
            set { SetValue(PhotoProperty, value); }
        }
        #endregion

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                imgPhoto.Source = Photo;
                lblName.Text = Name;
                lblPhone.Text = Phone;
                lblHouse.Text = HouseType;
            }
        }
    }
}